namespace KritaBrushInfo {
    partial class PreferencesDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxExifTool = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelExifExe = new System.Windows.Forms.TableLayoutPanel();
            this.labelExifExe = new System.Windows.Forms.Label();
            this.textBoxExifExe = new System.Windows.Forms.TextBox();
            this.buttonBrowseExifExe = new System.Windows.Forms.Button();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelTop.SuspendLayout();
            this.groupBoxExifTool.SuspendLayout();
            this.tableLayoutPanelExifExe.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.AutoSize = true;
            this.tableLayoutPanelTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTop.ColumnCount = 1;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.Controls.Add(this.groupBoxExifTool, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.flowLayoutPanelButtons, 0, 1);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 2;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1135, 170);
            this.tableLayoutPanelTop.TabIndex = 0;
            // 
            // groupBoxExifTool
            // 
            this.groupBoxExifTool.AutoSize = true;
            this.groupBoxExifTool.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxExifTool.Controls.Add(this.tableLayoutPanelExifExe);
            this.groupBoxExifTool.Location = new System.Drawing.Point(3, 3);
            this.groupBoxExifTool.Name = "groupBoxExifTool";
            this.groupBoxExifTool.Size = new System.Drawing.Size(1126, 85);
            this.groupBoxExifTool.TabIndex = 0;
            this.groupBoxExifTool.TabStop = false;
            this.groupBoxExifTool.Text = "ExifTool";
            // 
            // tableLayoutPanelExifExe
            // 
            this.tableLayoutPanelExifExe.AutoSize = true;
            this.tableLayoutPanelExifExe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelExifExe.ColumnCount = 3;
            this.tableLayoutPanelExifExe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelExifExe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelExifExe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelExifExe.Controls.Add(this.labelExifExe, 0, 0);
            this.tableLayoutPanelExifExe.Controls.Add(this.textBoxExifExe, 1, 0);
            this.tableLayoutPanelExifExe.Controls.Add(this.buttonBrowseExifExe, 2, 0);
            this.tableLayoutPanelExifExe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelExifExe.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanelExifExe.Name = "tableLayoutPanelExifExe";
            this.tableLayoutPanelExifExe.RowCount = 1;
            this.tableLayoutPanelExifExe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelExifExe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanelExifExe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanelExifExe.Size = new System.Drawing.Size(1120, 48);
            this.tableLayoutPanelExifExe.TabIndex = 3;
            // 
            // labelExifExe
            // 
            this.labelExifExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelExifExe.AutoSize = true;
            this.labelExifExe.BackColor = System.Drawing.SystemColors.Control;
            this.labelExifExe.Location = new System.Drawing.Point(3, 0);
            this.labelExifExe.Name = "labelExifExe";
            this.labelExifExe.Size = new System.Drawing.Size(188, 48);
            this.labelExifExe.TabIndex = 1;
            this.labelExifExe.Text = "ExifTool .exe:";
            this.labelExifExe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.labelExifExe, "The ExifToo executable.  Use  exiftool.exe, not exiftool(-k).exe.");
            // 
            // textBoxExifExe
            // 
            this.textBoxExifExe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxExifExe.Location = new System.Drawing.Point(197, 3);
            this.textBoxExifExe.Name = "textBoxExifExe";
            this.textBoxExifExe.Size = new System.Drawing.Size(795, 38);
            this.textBoxExifExe.TabIndex = 0;
            // 
            // buttonBrowseExifExe
            // 
            this.buttonBrowseExifExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonBrowseExifExe.AutoSize = true;
            this.buttonBrowseExifExe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBrowseExifExe.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBrowseExifExe.Location = new System.Drawing.Point(998, 3);
            this.buttonBrowseExifExe.Name = "buttonBrowseExifExe";
            this.buttonBrowseExifExe.Size = new System.Drawing.Size(119, 42);
            this.buttonBrowseExifExe.TabIndex = 1;
            this.buttonBrowseExifExe.Text = "Browse";
            this.toolTip.SetToolTip(this.buttonBrowseExifExe, "Browse for the ExifTool executable.");
            this.buttonBrowseExifExe.UseVisualStyleBackColor = false;
            this.buttonBrowseExifExe.Click += new System.EventHandler(this.OnBrowseExifExeClick);
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelButtons.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonCancel);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonReset);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonSave);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(407, 94);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(321, 73);
            this.flowLayoutPanelButtons.TabIndex = 1;
            this.flowLayoutPanelButtons.WrapContents = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(114, 42);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.toolTip.SetToolTip(this.buttonCancel, "Cancel without saving.");
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnCancelButtonClicked);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReset.AutoSize = true;
            this.buttonReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReset.Location = new System.Drawing.Point(123, 3);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(99, 42);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.Text = "Reset";
            this.toolTip.SetToolTip(this.buttonReset, "Rest ti the stored preferences.");
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.OnResetButtonClicked);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSave.AutoSize = true;
            this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSave.Location = new System.Drawing.Point(228, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 42);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.toolTip.SetToolTip(this.buttonSave, "Save the values as the new Preferences.");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnSaveButtonClicked);
            // 
            // PreferencesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 170);
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Name = "PreferencesDialog";
            this.Text = "Preferences";
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.groupBoxExifTool.ResumeLayout(false);
            this.groupBoxExifTool.PerformLayout();
            this.tableLayoutPanelExifExe.ResumeLayout(false);
            this.tableLayoutPanelExifExe.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.GroupBox groupBoxExifTool;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExifExe;
        private System.Windows.Forms.Label labelExifExe;
        private System.Windows.Forms.TextBox textBoxExifExe;
        private System.Windows.Forms.Button buttonBrowseExifExe;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ToolTip toolTip;
    }
}