using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KritaBrushInfo {
    public partial class PreferencesDialog : Form {
        public PreferencesDialog() {
            InitializeComponent();
        }

        private void reset() {
            reset();
        }

        private void save() {

        }

        private void OnCancelButtonClicked(object sender, EventArgs e) {
            save();
            this.DialogResult = DialogResult.Cancel;
            this.Visible = false;
        }

        private void OnResetButtonClicked(object sender, EventArgs e) {

        }

        private void OnSaveButtonClicked(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Visible = false;
        }
    }

}
