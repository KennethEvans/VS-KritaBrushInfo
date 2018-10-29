using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        public String curFileName = "No file specified";
        public String presetText = "";

        public MainForm() {
            InitializeComponent();
        }

        private void getInfo(String fileName) {
            if (fileName == null || fileName.Length == 0) {
                return;
            }
            String output = "";
            curFileName = fileName;
            presetText = "";
            textBoxInfo.Text = "processing " + fileName + " ...\n\n";
            Process process = new Process();
            StringBuilder outputStringBuilder = new StringBuilder();
            bool success = false;
            try {
                process.StartInfo.FileName = EXIFTOOL_NAME;
                //process.StartInfo.WorkingDirectory = args.ExeDirectory;
                process.StartInfo.Arguments = fileName;
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

        private void processXml1(String xmlString) {
            if (presetText == null || presetText.Length == 0) {
                textBoxInfo.AppendText("\nThe preset element is not defined");
                return;
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            XmlNodeList parentNode = xmlDoc.GetElementsByTagName("listS");
            foreach (XmlNode childrenNode in parentNode) {
                textBoxInfo.AppendText(childrenNode.SelectSingleNode("//field1").Value);
            }
        }

        private void processXml2(String xmlString) {
            if (presetText == null || presetText.Length == 0) {
                textBoxInfo.AppendText("\nThe preset element is not defined");
                return;
            }

            XDocument doc = XDocument.Parse(xmlString);
            var col = from dummy in doc.DescendantNodes() select dummy;
            foreach (var myvar in col) {
                XNode node = (XNode)myvar;
                if (node.NodeType == XmlNodeType.Text) {
                    textBoxInfo.AppendText("Type = [" + node.NodeType + "] Value = " + node.ToString());
                    textBoxInfo.AppendText(Environment.NewLine);
                } else {
                    //XElement xdoc = new XElement((node as XElement).Name, (node as XElement).Value);
                    //textBoxInfo.AppendText("Type = [" + xdoc.NodeType + "] Name = " + xdoc.Name);
                }
            }
        }

        private void processXml(String xmlString) {
            String nl = Environment.NewLine;
            if (presetText == null || presetText.Length == 0) {
                textBoxInfo.AppendText("\nThe preset element is not defined");
                return;
            }

            XDocument doc = XDocument.Parse(xmlString);
            StringBuilder info;
            foreach (XElement element in doc.Descendants("param")) {
                info = new StringBuilder();
                info.Append(element.Attribute("name").Value);
                info.Append(" [").Append(element.Attribute("type").Value).Append("]");
                info.Append(nl);
                info.Append("   ").Append(element.Value);
                info.Append(nl);
                textBoxInfo.AppendText(info.ToString());
            }
        }

        private void OnProcessClick(object sender, EventArgs e) {
            getInfo(DEFAULT_FILE_NAME);
        }

        private void OnQuitCick(object sender, EventArgs e) {
            Close();
        }
    }
}