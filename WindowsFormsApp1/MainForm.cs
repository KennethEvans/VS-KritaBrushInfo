using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

        public String fileName1 = "";
        public String fileName2 = "";
        public String presetText = "";

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

        private void getInfo(String fileName) {
            if (fileName == null || fileName.Length == 0) {
                return;
            }
            String output = "";
            presetText = "";
            textBoxInfo.Text = fileName + NL + NL;
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
                textBoxInfo.AppendText("\nError running process: " + ex.Message);
            } finally {
                process.Close();
            }
            if (success) {
                if (output == null || output.Length == 0) {
                    textBoxInfo.AppendText("No output produced");
                    return;
                }
                // Find the preset
                int start = output.IndexOf("<Preset ");
                int end = output.LastIndexOf("</Preset>");
                if (start == -1 || end == -1) {
                    textBoxInfo.AppendText("Cannot find Preset element");
                    return;
                }
                int len = output.Length;
                presetText = output.Substring(start, end - start + 9);
                processXml(presetText);
            } else {
                textBoxInfo.AppendText("\nProcess failed\nThe output is:\n");
                textBoxInfo.AppendText(output);
            }
        }

        private void processXml(String xmlString) {
            if (xmlString == null || xmlString.Length == 0) {
                textBoxInfo.AppendText("\nThe preset element is not defined");
                return;
            }

            XDocument doc = XDocument.Parse(xmlString);
            StringBuilder info;
            KritaPresetParam param = null;
            foreach (XElement element in doc.Descendants("param")) {
                param = new KritaPresetParam(element);
                paramsCur.Add(param);
                if (!param.Err) {
                    textBoxInfo.AppendText(param.info());
                } else {
                    textBoxInfo.AppendText(param.ErrorMessage);
                }
                //info = new StringBuilder();
                //info.Append(element.Attribute("name").Value);
                //info.Append(" [").Append(element.Attribute("type").Value).Append("]");
                //info.Append(NL);
                //info.Append("   ").Append(element.Value);
                //info.Append(NL);
                //textBoxInfo.AppendText(info.ToString());
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
            getInfo(fileName1);
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
            getInfo(fileName2);
        }

        private void OnCompareClick(object sender, EventArgs e) {
            getInfo(DEFAULT_FILE_NAME);
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

    }
}