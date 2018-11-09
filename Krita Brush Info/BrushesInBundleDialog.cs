using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace KritaBrushInfo {
    public partial class BrushesInBundleDialog : Form {
        private string selected;
        private string bundle;

        public string SelectedBrush { get => selected; set => selected = value; }
        public string Bundle { get => bundle; set => bundle = value; }

        public BrushesInBundleDialog(string bundleName) {
            InitializeComponent();

            textBoxBundle.Text = bundleName;
            textBoxBundle.Select(0, 0);
            find();
        }

        private void OnBrowseClick(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select a Bundle";
            dlg.Filter = "Krita Bundles|*.bundle";
            string fileName = textBoxBundle.Text;
            // Set initial directory
            if (File.Exists(fileName)) {
                dlg.FileName = fileName;
                dlg.InitialDirectory = Path.GetDirectoryName(fileName);
            }
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textBoxBundle.Text = dlg.FileName;
                find();
            }
        }

        private void find() {
            listBoxBrushes.DataSource = null;
            string name = textBoxBundle.Text;
            if (name == null || name.Length == 0) {
                Utils.Utils.errMsg("Bundle is not defined");
                return;
            }
            if (!File.Exists(name)) {
                Utils.Utils.errMsg(name + " does not exist");
                return;
            }
            // Get the preset file from the bundle
            try {
                List<string> items = new List<string>();
                using (ZipArchive archive = ZipFile.OpenRead(name)) {
                    foreach (ZipArchiveEntry entry in archive.Entries) {
                        if (entry.Name.ToLower().EndsWith(".kpp")) {
                            items.Add(entry.Name);
                        }
                    }
                }
                items.Sort();
                listBoxBrushes.DataSource = items;
            } catch (Exception ex) {
                Utils.Utils.excMsg("Failed to get brushes", ex);
                return;
            }
        }

        private void OnFindClick(object sender, EventArgs e) {
            find();
        }

        private void OnCancelClick(object sender, EventArgs e) {
            selected = null;
            bundle = textBoxBundle.Text;
            this.DialogResult = DialogResult.Cancel;
            this.Visible = false;
        }

        private void OnOkClick(object sender, EventArgs e) {
            selected = listBoxBrushes.GetItemText(listBoxBrushes.SelectedItem);
            bundle = textBoxBundle.Text;
            this.DialogResult = DialogResult.OK;
            this.Visible = false;
        }
    }
}
