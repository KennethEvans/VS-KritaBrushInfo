using System;
using System.IO;
using System.Windows.Forms;

namespace KritaBrushInfo {
    public partial class PreferencesDialog : Form {
        //private Settings settings = new Settings();

        public PreferencesDialog() {
            InitializeComponent();
            reset();
        }

        private void reset() {
            // ExifTool .exe
            string exifToolExe = textBoxExifExe.Text;
            if (exifToolExe != null) {
                textBoxExifExe.Text = Properties.Settings.Default.ExifToolExe;
            } else {
                textBoxExifExe.Text = "";
            }
        }

        private bool check() {
            // ExifTool .exe
            string exifToolExe = textBoxExifExe.Text;

            //char[] charsFile = Path.GetInvalidFileNameChars();
            //char[] charsPath = Path.GetInvalidPathChars();
            //int resFile = exifToolExe.IndexOfAny(Path.GetInvalidFileNameChars());
            //int resPath = exifToolExe.IndexOfAny(Path.GetInvalidPathChars());
            if (exifToolExe.IndexOfAny(Path.GetInvalidPathChars()) >= 0) {
                Utils.Utils.errMsg("ExifTool .exe is not a valid path");
                return false;
            }
            bool warning = false;
            string msg = "";
            // Check for non-fatal problems
            if (exifToolExe == null || exifToolExe.Length == 0) {
                msg = "ExifTool .exe is not specified";
                warning = true;
            } else if (!exifToolExe.ToLower().EndsWith(".exe")) {
                msg = "ExifTool is not an EXE file";
                warning = true;
            } else if (!File.Exists(exifToolExe)) {
                msg = "ExifTool .exe does not exist";
                warning = true;
            } else if (Path.GetFileName(exifToolExe).Contains("-k")) {
                msg = "Don't use the (-k) version";
                warning = true;
            }
            if (warning) {
                DialogResult res = MessageBox.Show(msg + "\n" + "OK to continue saving?",
                    "Potential Problem", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) {
                    return false;
                }
            }

            return true;
        }

        private bool save() {
            try {
                if (!check()) return false;

                // ExifTool .exe
                Properties.Settings.Default.ExifToolExe = textBoxExifExe.Text;

                // Save the properties
                Properties.Settings.Default.Save();
            } catch (Exception ex) {
                Utils.Utils.excMsg("Failed to save settings", ex);
                return false;
            }

            return true;
        }

        private void OnCancelButtonClicked(object sender, EventArgs e) {
            save();
            this.DialogResult = DialogResult.Cancel;
            this.Visible = false;
        }

        private void OnResetButtonClicked(object sender, EventArgs e) {
            reset();
        }

        private void OnSaveButtonClicked(object sender, EventArgs e) {
            bool res = save();
            if (res) {
                this.DialogResult = DialogResult.OK;
                this.Visible = false;
            }
        }

        private void OnBrowseExifExeClick(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Executables|*.exe";
            dlg.Title = "Select the ExifTool Executable";
            // Set initial directory
            string exifToolExe = textBoxExifExe.Text;
            if (exifToolExe != null && exifToolExe.Length > 0) {
                if (exifToolExe.IndexOfAny(Path.GetInvalidPathChars()) < 0) {
                    // Is valid path
                    string path = Path.GetDirectoryName(exifToolExe);
                    if (File.Exists(path)) {
                        dlg.InitialDirectory = path;
                    }
                }
            }
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (!File.Exists(dlg.FileName)) {
                    Utils.Utils.errMsg("File " + dlg.FileName + " does not exist");
                } else {
                    textBoxExifExe.Text = dlg.FileName;
                }
            }
        }

        ///// <summary>
        ///// Class to hold settings.
        ///// </summary>
        //public class Settings {
        //    public string ExifToolExe { get; set; }
        //}

    }


}
