//#define debugging
//#define replaceDoctype

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace KritaBrushInfo {

    public partial class MainForm : Form {
        public readonly String DEFAULT_FILE_NAME = @"C:\Users\evans\AppData\Roaming\krita\paintoppresets\DA_Oil_16_Rough_Blocking_Soft.kpp";
        public readonly String EXIFTOOL_NAME = @"C:\bin\EXIFTool\exiftool.exe";
        public readonly int PROCESS_TIMEOUT = 5000; // ms
        public readonly String NL = Environment.NewLine;
        private static ScrolledHTMLDialog overviewDlg;
        private static PreferencesDialog preferencesDlg;

        public String fileName1 = "";
        public String fileName2 = "";

        private List<KritaPresetParam> params1 = new List<KritaPresetParam>();
        private List<KritaPresetParam> params2 = new List<KritaPresetParam>();
        private List<KritaPresetParam> paramsCur;

        public MainForm() {
            fileName1 = Properties.Settings.Default.FileName1;
            fileName2 = Properties.Settings.Default.FileName2;

            InitializeComponent();

            textBoxFile1.Text = fileName1;
            textBoxFile2.Text = fileName2;
        }

        private void getInfo(String fileName, bool print) {
            if (fileName == null || fileName.Length == 0) {
                return;
            }
            String output = "";
            string presetText = "";
            if (print) {
                textBoxInfo.Text = fileName + NL + NL;
            }
            Process process = new Process();
            StringBuilder outputStringBuilder = new StringBuilder();
            bool success = false;
            try {
                process.StartInfo.FileName = EXIFTOOL_NAME;
                //process.StartInfo.WorkingDirectory = args.ExeDirectory;
                process.StartInfo.Arguments = "\"" + fileName + "\"";
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.EnableRaisingEvents = false;
                process.OutputDataReceived +=
                    (sender, eventArgs) => outputStringBuilder.AppendLine(eventArgs.Data);
                process.ErrorDataReceived +=
                    (sender, eventArgs) => outputStringBuilder.AppendLine(eventArgs.Data);
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                var processExited = process.WaitForExit(PROCESS_TIMEOUT);

                if (processExited == false) {
                    // Timed out
                    process.Kill();
                    output = outputStringBuilder.ToString();
                    throw new Exception("\nERROR: Process took too long to finish");
                } else if (process.ExitCode != 0) {
                    output = outputStringBuilder.ToString();
                    throw new Exception("Process exited with non-zero exit code of: "
                        + process.ExitCode + Environment.NewLine
                        + "Output from process: " + outputStringBuilder.ToString());
                } else {
                    success = true;
                    output = outputStringBuilder.ToString();
                }
            } catch (Exception ex) {
                if (print) {
                    textBoxInfo.AppendText("\nError running process: " + ex.Message);
                } else {
                    Utils.Utils.excMsg("Error running process: ", ex);
                }
            } finally {
                process.Close();
            }
            if (success) {
                if (output == null || output.Length == 0) {
                    if (print) {
                        textBoxInfo.AppendText("No output produced");
                    } else {
                        Utils.Utils.errMsg("No output produced");
                    }
                    return;
                }
                // Find the preset
                int start = output.IndexOf("<Preset ");
                int end = output.LastIndexOf("</Preset>");
                if (start == -1 || end == -1) {
                    if (print) {
                        textBoxInfo.AppendText("Cannot find Preset element");
                    }
                    return;
                }
                int len = output.Length;
                presetText = output.Substring(start, end - start + 9);
                processXml(presetText, print);
            } else {
                if (print) {
                    textBoxInfo.AppendText("\nProcess failed\nThe output is:\n");
                    textBoxInfo.AppendText(output);
                } else {
                    Utils.Utils.errMsg("Process failed");
                }
            }
        }

        private void processXml(String xmlString, bool print) {
            if (xmlString == null || xmlString.Length == 0) {
                if (print) {
                    textBoxInfo.AppendText("\nThe preset element is not defined");
                }
                return;
            }
#if debugging
            // DEBUG
            textBoxInfo.AppendText(xmlString + NL + NL);
#endif
            XDocument doc = XDocument.Parse(xmlString);
            KritaPresetParam param = null;
            foreach (XElement element in doc.Descendants("param")) {
                param = new KritaPresetParam(element);
                // Parse inside the param
                paramsCur.Add(param);
                if (print) {
                    if (!param.Err) {
                        textBoxInfo.AppendText(param.info());
                    } else {
                        textBoxInfo.AppendText(param.ErrorMessage);
                    }
                }
                processSubElements(param);
            }
        }

        private void processSubElements(KritaPresetParam param) {
            string value = param.Value.Trim();
            if (value == null || value.Length == 0) {
                return;
            }
            if (!value.StartsWith("<") || !value.EndsWith(">")) {
                return;
            }
#if replaceDocType
            value = Regex.Replace(value, "\\<\\!DOCTYPE params\\>", "").Trim();
#endif
#if debugging
            textBoxInfo.AppendText("*********************** begin *********************************" + NL);
            textBoxInfo.AppendText(parseXmlElement(value));
            textBoxInfo.AppendText("*********************** end ***********************************" + NL);
#endif
            // Reorder the attributes and replace param.Value
            reorderAttributes(param);

        }

        private void reorderAttributes(KritaPresetParam param) {
            IEnumerable<XElement> elements;
            IEnumerable<XAttribute> attributes;
            XElement element = XElement.Parse(param.Value);
            elements = element.Elements();
            attributes = element.Attributes();
            List<XAttribute> attributesList = new List<XAttribute>(attributes.Count());
            foreach (XAttribute attribute in attributes) {
                attributesList.Add(attribute);
            }
            attributesList.Sort((attr1, attr2) => attr1.Value.CompareTo(attr2.Value));
            XElement newElement = new XElement("New");
            foreach (XAttribute attribute1 in attributesList) {
                newElement.Add(new XAttribute(attribute1));
            }
            foreach (XElement element1 in elements) {
                newElement.Add(new XElement(element1));
            }
            // Replace the param.Value
            if (checkBoxReorderAttr.Checked) {
                param.Value = newElement.Value.ToString();
            }
        }

        /// <summary>
        /// Processes an XML string representing an element and returns the
        /// information in a string.  Use for debugging.
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns>A string representing the information</returns>
        private string parseXmlElement(String xmlString) {
            IEnumerable<XElement> elements;
            IEnumerable<XAttribute> attributes;
            if (xmlString == null || xmlString.Length == 0) {
                return "";
            }
            if (!xmlString.StartsWith("<") || !xmlString.EndsWith(">")) {
                return "";
            }
#if replaceDocType
            xmlString = Regex.Replace(xmlString, "\\<\\!DOCTYPE params\\>", "").Trim();
#endif
            StringBuilder info = new StringBuilder();
            string prefix = "*** ";
            string tab = "    ";
#if debugging
           // Print information about the element
           info.Append(elementInfo(xmlString));
#endif

            // Parse the element
            XElement element = XElement.Parse(xmlString);
            elements = element.Elements();
            string xmlString1 = null;
            foreach (XElement element1 in elements) {
                xmlString1 = null;
                //info.AppendLine(prefix + element.Name);
                info.AppendLine(prefix + tab + element1.Name);
                attributes = element1.Attributes();
                foreach (XAttribute attribute in attributes) {
                    info.AppendLine(prefix + tab + tab + "A: " + attribute.Name);
                }
                xmlString1 = element1.Value.ToString();
#if replaceDocType
                xmlString1 = Regex.Replace(xmlString1, "<!DOCTYPE params>", "").Trim();
#endif
                if (xmlString1 == null || xmlString1.Length == 0) {
                    info.AppendLine(prefix + tab + tab + "V: " + xmlString1);
                    continue;
                }
                if (!xmlString1.StartsWith("<") || !xmlString1.EndsWith(">")) {
                    info.AppendLine(prefix + tab + tab + "V: " + xmlString1);
                    continue;
                }
                info.AppendLine(prefix + tab + tab + "V: " + xmlString1);
            }
            return info.ToString();
        }

        /// <summary>
        /// Returns information about the element specified by the xmlString,
        /// inclusinf elements, descendent, and attributes.
        /// Use for debugging.
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        private string elementInfo(string xmlString) {
            IEnumerable<XElement> elements;
            IEnumerable<XAttribute> attributes;
            StringBuilder info = new StringBuilder();

            XElement element = XElement.Parse(xmlString);
            elements = element.Elements();
            info.AppendLine("element=" + element);
            info.AppendLine("nElements=" + elements.Count());
            foreach (XElement element1 in elements) {
                info.AppendLine("    " + element1);
            }
            elements = element.Descendants();
            info.AppendLine("nDescendents=" + elements.Count());
            foreach (XElement element1 in elements) {
                info.AppendLine("    " + element1);
            }
            attributes = element.Attributes();
            info.AppendLine("nAttributes=" + attributes.Count());
            foreach (XAttribute attribute1 in attributes) {
                info.AppendLine("    " + attribute1);
            }

            return info.ToString();
        }

        private void compare() {
            // Rerun getting params for both files
            params1.Clear();
            paramsCur = params1;
            getInfo(fileName1, false);
            if (params1.Count == 0) {
                Utils.Utils.errMsg("Did not get params for File 1");
                return;
            }
            params2.Clear();
            paramsCur = params2;
            getInfo(fileName2, false);
            if (params2.Count == 0) {
                Utils.Utils.errMsg("Did not get params for File 2");
                return;
            }
            textBoxInfo.Text = "1: " + fileName1 + NL;
            textBoxInfo.AppendText("2: " + fileName2 + NL + NL);

            // Look for items in 2 that are in 1
            bool found;
            KritaPresetParam foundParam = null;
            foreach (KritaPresetParam param1 in params1) {
                found = false;
                // Look for the same name
                foreach (KritaPresetParam param2 in params2) {
                    if (param1.Name.Equals(param2.Name)) {
                        found = true;
                        foundParam = param2;
                        break;
                    }
                }
                if (!found) {
                    textBoxInfo.AppendText(param1.Name + NL);
                    textBoxInfo.AppendText("   1: " + param1.Value + NL);
                    textBoxInfo.AppendText("   2: Not found in 2" + NL);
                    break;
                }
                if (found && !param1.equalsExceptType(foundParam)) {
                    textBoxInfo.AppendText(param1.Name + NL);
                    textBoxInfo.AppendText("   1: " + param1.Value + NL);
                    textBoxInfo.AppendText("   2: " + foundParam.Value + NL);
                }
            }

            // Look for items in 2 that are not in 1
            textBoxInfo.AppendText(NL);
            foreach (KritaPresetParam param2 in params2) {
                found = false;
                // Look for the same name
                foreach (KritaPresetParam param1 in params1) {
                    if (param1.Name.Equals(param2.Name)) {
                        found = true;
                        foundParam = param2;
                        break;
                    }
                }
                if (!found) {
                    textBoxInfo.AppendText(param2.Name + NL);
                    textBoxInfo.AppendText("   1: Not found in 1" + NL);
                    textBoxInfo.AppendText("   2: " + param2.Value + NL);
                    break;
                }
            }
        }

        private void readFile(int n) {
            if (n < 1 || n > 2) {
                Utils.Utils.errMsg("Invalid File number: File " + n);
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Krita Presets|*.kpp";
            dlg.Title = "Select a Preset File" + "(" + n + ")";
            // Set initial directory
            switch (n) {
                case 1:
                    if (File.Exists(fileName1)) {
                        dlg.FileName = fileName1;
                        dlg.InitialDirectory = Path.GetDirectoryName(fileName1);
                    }
                    break;
                case 2:
                    if (File.Exists(fileName2)) {
                        dlg.FileName = fileName2;
                        dlg.InitialDirectory = Path.GetDirectoryName(fileName2);
                    }
                    break;
            }
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                switch (n) {
                    case 1:
                        fileName1 = dlg.FileName;
                        break;
                    case 2:
                        fileName2 = dlg.FileName;
                        break;
                }
                resetFilenames();
            }

        }

        private void resetFilenames() {
            textBoxFile1.Text = fileName1;
            textBoxFile2.Text = fileName2;
            Properties.Settings.Default.FileName1 = fileName1;
            Properties.Settings.Default.FileName2 = fileName2;
            Properties.Settings.Default.Save();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) {
        }

        private void OnProcess1Click(object sender, EventArgs e) {
            if (fileName1 == null || fileName1.Length == 0) {
                Utils.Utils.errMsg("File 1 is not defined");
                return;
            }
            if (!File.Exists(fileName1)) {
                Utils.Utils.errMsg(fileName1 + " does not exist");
                return;
            }
            params1.Clear();
            paramsCur = params1;
            getInfo(fileName1, true);
        }

        private void OnProcess2Click(object sender, EventArgs e) {
            if (fileName2 == null || fileName2.Length == 0) {
                Utils.Utils.errMsg("File 2 is not defined");
                return;
            }
            if (!File.Exists(fileName2)) {
                Utils.Utils.errMsg(fileName2 + " does not exist");
                return;
            }
            params1.Clear();
            paramsCur = params1;
            getInfo(fileName2, true);
        }

        private void OnCompareClick(object sender, EventArgs e) {
            compare();
        }

        private void OnQuitCick(object sender, EventArgs e) {
            Close();
        }

        private void OnBrowseFile1Click(object sender, EventArgs e) {
            readFile(1);
        }

        private void OnBrowseFile2Click(object sender, EventArgs e) {
            readFile(2);
        }

        private void onOverviewClick(object sender, EventArgs e) {
            // Create, show, or set visible the overview dialog as appropriate
            if (overviewDlg == null) {
                MainForm app = (MainForm)FindForm().FindForm();
                overviewDlg = new ScrolledHTMLDialog(
                    Utils.Utils.getDpiAdjustedSize(app, new Size(800, 600)));
                overviewDlg.Show();
            } else {
                overviewDlg.Visible = true;
            }
        }

         private void OnPreferencesClick(object sender, EventArgs e) {
            // Create, show, or set visible the preferences dialog as appropriate
            if (preferencesDlg == null) {
                preferencesDlg = new PreferencesDialog();
                preferencesDlg.Show();
            } else {
                preferencesDlg.Visible = true;
            }

        }

        private void OnAboutClick(object sender, EventArgs e) {
            AboutBox dlg = new AboutBox();
            dlg.ShowDialog();
        }

    }
}