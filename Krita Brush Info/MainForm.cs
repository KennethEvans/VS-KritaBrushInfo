//#define debugging
//#define replaceDoctype

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KritaBrushInfo {

    public partial class MainForm : Form {
        enum FileType { File1, File2, Bundle1, Bundle2, Brush1, Brush2 };
        public readonly String EXIFTOOL_NAME = @"C:\bin\EXIFTool\exiftool.exe";
        public readonly int PROCESS_TIMEOUT = 5000; // ms
        public readonly String NL = Environment.NewLine;
        private static ScrolledHTMLDialog overviewDlg;
        private static PreferencesDialog preferencesDlg;

        private List<KritaPresetParam> params1 = new List<KritaPresetParam>();
        private List<KritaPresetParam> params2 = new List<KritaPresetParam>();
        private List<KritaPresetParam> paramsCur;

        public MainForm() {
            InitializeComponent();

            textBoxFile1.Text = Properties.Settings.Default.FileName1;
            textBoxFile2.Text = Properties.Settings.Default.FileName2;
            textBoxBundle1.Text = Properties.Settings.Default.BundleName1;
            textBoxBundle2.Text = Properties.Settings.Default.BundleName2;
            textBoxBrush1.Text = Properties.Settings.Default.BrushName1;
            textBoxBrush2.Text = Properties.Settings.Default.BrushName2;
            checkBoxReorderAttr.Checked = Properties.Settings.Default.ReorderAttributes;
            checkBoxPrintRaw.Checked = Properties.Settings.Default.PrintRawXml;
            checkBoxBundle1.Checked = Properties.Settings.Default.UseBundle1;
            checkBoxBundle2.Checked = Properties.Settings.Default.UseBundle2;

            // Set the correct panel by running the BundleCheckState handler
            OnBundle1CheckStateChanged(null, null);
            OnBundle2CheckStateChanged(null, null);
        }

        /// <summary>
        /// Starts a process to run ExifTool, extracts the preset, and
        /// calls processXml to process the Preset text.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="print">Whether to print progress to the output TextBox.</param>
        private void processFile(string fileName, string displayName, bool print) {
            if (print) {
                textBoxInfo.Text = displayName + NL + NL;
            }
            // Get the preset text
            string presetText = getPresetTextFromFile(fileName);
            if (presetText == null) {
                textBoxInfo.AppendText("Failed to get Preset text" + NL);
                return;
            }
            // Process the XML
            processXml(presetText, print);
        }

        /// <summary>
        /// Processes the preset text.
        /// </summary>
        /// <param name="presetText is the presetText."></param>
        /// <param name="print">Whether to print progress to the output TextBox.</param>
        private void processXml(String presetText, bool print) {
            if (presetText == null || presetText.Length == 0) {
                if (print) {
                    textBoxInfo.AppendText("\nThe preset element is not defined");
                }
                return;
            }
#if debugging
            // DEBUG
            textBoxInfo.AppendText(xmlString + NL + NL);
#endif
            // Calculate the KritaPresetParam's
            XDocument doc = XDocument.Parse(presetText);
            KritaPresetParam param = null;
            foreach (XElement element in doc.Descendants("param")) {
                param = new KritaPresetParam(element);
                // Parse inside the param
                paramsCur.Add(param);
                if (!param.Err) {
                    //// DEBUG
                    //if (print) {
                    //    textBoxInfo.AppendText("B " + param.info());
                    //}
                    if (checkBoxReorderAttr.Checked) reorderAttributes(param);
                    if (print) {
                        textBoxInfo.AppendText(param.info());
                    }
                } else {
                    if (print) {
                        textBoxInfo.AppendText(param.ErrorMessage);
                    }
                }
            }
            // Print the raw XML
            if (print && checkBoxPrintRaw.Checked) {
                processRawXml(presetText);
            }
            // Check for other elements than param
            if (print) {
                processCheckForNonParamElements(presetText);
            }
        }

        /// <summary>
        /// Checks if ExifTool exists and is valid and returns the name of the
        /// executable if successful.
        /// </summary>
        /// <returns>Name of the ExifTool executable or null on failure.</returns>
        private string getExifTool() {
            // Check for ExifTool .exe
            string exifToolExe = Properties.Settings.Default.ExifToolExe;
            if (exifToolExe == null || exifToolExe.Length == 0) {
                Utils.Utils.errMsg("ExifTool .exe is not specified.\nSet it in Preferences.");
                return null;
            }
            if (!File.Exists(exifToolExe)) {
                Utils.Utils.errMsg("ExifTool (" + exifToolExe + ") does not exist");
                return null;
            }
            return exifToolExe;
        }

        /// <summary>
        /// Starts a process to run ExifTool, extracts the preset, and
        /// calls processXml to process the preset.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="print"></param>
        /// <returns></returns>
        private string getPresetTextFromFile(string fileName) {
            if (fileName == null || fileName.Length == 0) return null;
            string exifToolExe = getExifTool();
            if (exifToolExe == null) return null;

            string metadataText = null;
            string presetText = null;
            Process process = new Process();
            StringBuilder outputStringBuilder = new StringBuilder();
            bool success = false;
            try {
                process.StartInfo.FileName = exifToolExe;
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

                metadataText = outputStringBuilder.ToString();
                if (processExited == false) {
                    // Timed out
                    process.Kill();
                    throw new Exception("\nERROR: Process took too long to finish");
                } else if (process.ExitCode != 0) {
                    throw new Exception("Process exited with non-zero exit code of: "
                        + process.ExitCode + Environment.NewLine
                        + "Output from process: " + metadataText);
                } else {
                    success = true;
                }
            } catch (Exception ex) {
                Utils.Utils.excMsg("Error running ExifTool process: ", ex);
            } finally {
                process.Close();
            }
            if (success) {
                if (metadataText == null || metadataText.Length == 0) {
                    Utils.Utils.errMsg("Metadata is missing or empty");
                    return null;
                }
                // Find the preset
                int start = metadataText.IndexOf("<Preset ");
                int end = metadataText.LastIndexOf("</Preset>");
                if (start == -1 || end == -1) {
                    Utils.Utils.errMsg("Cannot find Preset element in metadata");
                    return null;
                }
                int len = metadataText.Length;
                presetText = metadataText.Substring(start, end - start + 9);
            } else {
                Utils.Utils.errMsg("Failed to process metadata");
                return null;
            }
            return presetText;
        }

        /// <summary>
        /// Reorders the attributes in the Element of the given KritaPresetParam.
        /// </summary>
        /// <param name="param"></param>
        private void reorderAttributes(KritaPresetParam param) {
            // Check if it an element
            XElement element;
            try {
                element = XElement.Parse(param.Value);
            } catch (Exception) {
                return;
            }
            if (!element.HasAttributes) return;
            reorderAllAttributes(element);
            // Replace the param.Value, removing newlines that may have been added
            // (Helps with formatting the output)
            param.Value = element.ToString().Replace(System.Environment.NewLine, "");
        }

        private void reorderAllAttributes(XElement element) {
            IEnumerable<XAttribute> attributes = element.Attributes();
            IEnumerable<XElement> elements = element.Elements();
            List<XAttribute> attributesList = new List<XAttribute>(attributes.Count());
            List<XElement> elementsList = new List<XElement>(elements.Count());
            foreach (XAttribute attribute in attributes) {
                attributesList.Add(attribute);
            }
            attributesList.Sort((attr1, attr2) =>
                attr1.Name.ToString().CompareTo(attr2.Name.ToString()));
            element.ReplaceAttributes();
            foreach (XAttribute attribute in attributesList) {
                element.Add(attribute);
            }
            // Recurse for all elements
            foreach (XElement element1 in elements) {
                reorderAllAttributes(element1);
            }
        }
        /// <summary>
        /// Checks if there are any other elements besides param in the preset.
        /// (If so, we are not handling them.)
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        private bool processCheckForNonParamElements(string xmlString) {
            XDocument doc = XDocument.Parse(xmlString);
            List<XElement> elements = new List<XElement>();
            foreach (XElement element in doc.ElementsAfterSelf()) {
                if (!element.Name.Equals("param")) {
                    elements.Add(element);
                }
            }
            if (elements.Count > 0) {
                StringBuilder output = new StringBuilder();
                textBoxInfo.AppendText(NL + "Found elements not named param:" + NL);
                foreach (XElement element in elements) {
                    textBoxInfo.AppendText("    " + element.Name + NL);
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Prints the formated Preset field in the output.
        /// </summary>
        /// <param name="xmlString"></param>
        private void processRawXml(string xmlString) {
            textBoxInfo.AppendText(NL + "Raw XML:" + NL);
            XDocument doc = XDocument.Parse(xmlString);
            textBoxInfo.AppendText(doc.ToString());
            textBoxInfo.AppendText(NL);
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

        private void process1(bool print) {
            String name = "";
            if (checkBoxBundle1.Checked) {
                name = textBoxBundle1.Text;
                if (name == null || name.Length == 0) {
                    Utils.Utils.errMsg("Bundle 1 is not defined");
                    return;
                }
                if (!File.Exists(name)) {
                    Utils.Utils.errMsg(name + " does not exist");
                    return;
                }
                // Get the preset file from the bundle
                string brushName = textBoxBrush1.Text;
                string tempFile = null;
                try {
                    tempFile = Path.GetTempFileName();
                    if (File.Exists(tempFile)) File.Delete(tempFile);
                    bool found = false;
                    using (ZipArchive archive = ZipFile.OpenRead(name)) {
                        foreach (ZipArchiveEntry entry in archive.Entries) {
                            if (entry.Name.Equals(brushName)) {
                                found = true;
                                entry.ExtractToFile(tempFile);
                                break;
                            }
                        }
                    }
                    if (!found) {
                        Utils.Utils.errMsg("Not found: " + brushName);
                        return;
                    }
                    params1.Clear();
                    paramsCur = params1;
                    processFile(tempFile, name + NL + "    Brush: " + brushName, true);
                } catch (Exception ex) {
                    Utils.Utils.excMsg("Failed to find " + brushName, ex);
                    return;
                } finally {
                    if (tempFile != null && File.Exists(tempFile)) {
                        File.Delete(tempFile);
                    }
                }
            } else {
                name = textBoxFile1.Text;
                if (name == null || name.Length == 0) {
                    Utils.Utils.errMsg("File 1 is not defined");
                    return;
                }
                if (!File.Exists(name)) {
                    Utils.Utils.errMsg(name + " does not exist");
                    return;
                }
                params1.Clear();
                paramsCur = params1;
                processFile(name, name, print);
            }
        }

        private void process2(bool print) {
            String name = "";
            if (checkBoxBundle2.Checked) {
                name = textBoxBundle2.Text;
                if (name == null || name.Length == 0) {
                    Utils.Utils.errMsg("Bundle 2 is not defined");
                    return;
                }
                if (!File.Exists(name)) {
                    Utils.Utils.errMsg(name + " does not exist");
                    return;
                }
                // Get the preset file from the bundle
                string brushName = textBoxBrush2.Text;
                string tempFile = null;
                try {
                    tempFile = Path.GetTempFileName();
                    if (File.Exists(tempFile)) File.Delete(tempFile);
                    bool found = false;
                    using (ZipArchive archive = ZipFile.OpenRead(name)) {
                        foreach (ZipArchiveEntry entry in archive.Entries) {
                            if (entry.Name.Equals(brushName)) {
                                found = true;
                                entry.ExtractToFile(tempFile);
                                break;
                            }
                        }
                    }
                    if (!found) {
                        Utils.Utils.errMsg("Not found: " + brushName);
                        return;
                    }
                    params2.Clear();
                    paramsCur = params2;
                    processFile(tempFile, name + NL + "    Brush: " + brushName, true);
                } catch (Exception ex) {
                    Utils.Utils.excMsg("Failed to find " + brushName, ex);
                    return;
                } finally {
                    if (tempFile != null && File.Exists(tempFile)) {
                        File.Delete(tempFile);
                    }
                }
            } else {
                name = textBoxFile2.Text;
                if (name == null || name.Length == 0) {
                    Utils.Utils.errMsg("File 2 is not defined");
                    return;
                }
                if (!File.Exists(name)) {
                    Utils.Utils.errMsg(name + " does not exist");
                    return;
                }
                params2.Clear();
                paramsCur = params2;
                processFile(name, name, print);
            }
        }

        /// <summary>
        /// Compares the two files and displays the output.
        /// </summary>
        private void compare() {
            // Process 1
            process1(false);
            if (params1.Count == 0) {
                Utils.Utils.errMsg("Did not get params for Brush 1");
                return;
            }
            // Process 2
            process2(false);
            if (params2.Count == 0) {
                Utils.Utils.errMsg("Did not get params for Brush 2");
                return;
            }

            // Write heading to textBoxInfo
            textBoxInfo.Text = "1: ";
            if (checkBoxBundle1.Checked) {
                textBoxInfo.AppendText(textBoxBundle1.Text + NL
                    + "    Brush: " + textBoxBrush1.Text + NL + NL);
            } else {
                textBoxInfo.AppendText(textBoxFile1.Text + NL + NL);
            }
            textBoxInfo.AppendText("2: ");
            if (checkBoxBundle2.Checked) {
                textBoxInfo.AppendText(textBoxBundle2.Text + NL
                    + "    Brush: " + textBoxBrush2.Text + NL + NL);
            } else {
                textBoxInfo.AppendText(textBoxFile2.Text + NL + NL);
            }

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
                    continue;
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

        private void getFileName(FileType type) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select a File" + " (" + type + ")";
            string fileName = "";
            // Set initial directory
            switch (type) {
                case FileType.File1:
                    dlg.Filter = "Krita Presets|*.kpp";
                    fileName = textBoxFile1.Text;
                    break;
                case FileType.File2:
                    dlg.Filter = "Krita Presets|*.kpp";
                    fileName = textBoxFile2.Text;
                    break;
                case FileType.Bundle1:
                    dlg.Filter = "Krita Bundles|*.bundle";
                    fileName = textBoxBundle1.Text;
                    break;
                case FileType.Bundle2:
                    dlg.Filter = "Krita Bundles|*.bundle";
                    fileName = textBoxBundle2.Text;
                    break;
            }
            if (File.Exists(fileName)) {
                dlg.FileName = fileName;
                dlg.InitialDirectory = Path.GetDirectoryName(fileName);
            }
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                resetFileName(type, dlg.FileName);
            }
        }

        private void resetFileName(FileType type, string name) {
            switch (type) {
                case FileType.File1:
                    textBoxFile1.Text = name;
                    Properties.Settings.Default.FileName1 = name;
                    break;
                case FileType.File2:
                    textBoxFile2.Text = name;
                    Properties.Settings.Default.FileName2 = name;
                    break;
                case FileType.Bundle1:
                    textBoxBundle1.Text = name;
                    Properties.Settings.Default.BundleName1 = name;
                    break;
                case FileType.Bundle2:
                    textBoxBundle2.Text = name;
                    Properties.Settings.Default.BundleName2 = name;
                    break;
                case FileType.Brush1:
                    textBoxBrush1.Text = name;
                    Properties.Settings.Default.BrushName1 = name;
                    break;
                case FileType.Brush2:
                    textBoxBrush2.Text = name;
                    Properties.Settings.Default.BrushName2 = name;
                    break;
            }
            Properties.Settings.Default.Save();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.FileName1 = textBoxFile1.Text;
            Properties.Settings.Default.FileName2 = textBoxFile2.Text;
            Properties.Settings.Default.BundleName1 = textBoxBundle1.Text;
            Properties.Settings.Default.BundleName2 = textBoxBundle2.Text;
            Properties.Settings.Default.BrushName1 = textBoxBrush1.Text;
            Properties.Settings.Default.BrushName2 = textBoxBrush2.Text;
            Properties.Settings.Default.ReorderAttributes = checkBoxReorderAttr.Checked;
            Properties.Settings.Default.PrintRawXml = checkBoxPrintRaw.Checked;
            Properties.Settings.Default.UseBundle1 = checkBoxBundle1.Checked;
            Properties.Settings.Default.UseBundle2 = checkBoxBundle2.Checked;
            Properties.Settings.Default.Save();
        }

        private void OnProcess1Click(object sender, EventArgs e) {
            process1(true);
        }

        private void OnProcess2Click(object sender, EventArgs e) {
            process2(true);
        }

        private void OnCompareClick(object sender, EventArgs e) {
            compare();
        }

        private void OnQuitCick(object sender, EventArgs e) {
            Close();
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

        private void OnBundle1CheckStateChanged(object sender, EventArgs e) {
            if (checkBoxBundle1.Checked) {
                tableLayoutPanelFile1.Visible = false;
                tableLayoutPanelBundle1.Visible = true;
            } else {
                tableLayoutPanelFile1.Visible = true;
                tableLayoutPanelBundle1.Visible = false;
            }
        }

        private void OnBrowseFile1Click(object sender, EventArgs e) {
            getFileName(FileType.File1);
        }

        private void OnBrowseFile2Click(object sender, EventArgs e) {
            getFileName(FileType.File2);
        }

        private void OnBrowseBundle1Click(object sender, EventArgs e) {
            getFileName(FileType.Bundle1);
        }

        private void OnBrowseBundle2Click(object sender, EventArgs e) {
            getFileName(FileType.Bundle2);
        }

        private void OnBrowseBrush1Click(object sender, EventArgs e) {
            string bundleName = textBoxBundle1.Text;
            if (bundleName == null || bundleName.Length == 0) {
                Utils.Utils.errMsg("Bundle 1 is not defined");
                return;
            }
            if(!File.Exists(bundleName)) {
                Utils.Utils.errMsg("Bundle 1 does not exist");
                return;
            }
            BrushesInBundleDialog dlg = new BrushesInBundleDialog(bundleName);
            // Create, show, or set visible the preferences dialog as appropriate
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (dlg.SelectedBrush != null) {
                    textBoxBrush1.Text = dlg.SelectedBrush;
                    textBoxBundle1.Text = dlg.Bundle;
                } else {
                    Utils.Utils.errMsg("No items selected");
                }
            }
        }

        private void OnBrowseBrush2Click(object sender, EventArgs e) {
            string bundleName = textBoxBundle2.Text;
            if (bundleName == null || bundleName.Length == 0) {
                Utils.Utils.errMsg("Bundle 2 is not defined");
                return;
            }
            if (!File.Exists(bundleName)) {
                Utils.Utils.errMsg("Bundle 2 does not exist");
                return;
            }
            BrushesInBundleDialog dlg = new BrushesInBundleDialog(bundleName);
            // Create, show, or set visible the preferences dialog as appropriate
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (dlg.SelectedBrush != null) {
                    textBoxBrush2.Text = dlg.SelectedBrush;
                    textBoxBundle2.Text = dlg.Bundle;
                } else {
                    Utils.Utils.errMsg("No items selected");
                }
            }
        }

        private void OnBundle2CheckStateChanged(object sender, EventArgs e) {
            if (checkBoxBundle2.Checked) {
                tableLayoutPanelFile2.Visible = false;
                tableLayoutPanelBundle2.Visible = true;
            } else {
                tableLayoutPanelFile2.Visible = true;
                tableLayoutPanelBundle2.Visible = false;
            }
        }

        private void textBoxBundle2_TextChanged(object sender, EventArgs e) {

        }
    }

}