namespace KritaBrushInfo {
    partial class BrushesInBundleDialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrushesInBundleDialog));
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBundle = new System.Windows.Forms.TableLayoutPanel();
            this.labelBundle = new System.Windows.Forms.Label();
            this.textBoxBundle = new System.Windows.Forms.TextBox();
            this.buttonBundleBrowse = new System.Windows.Forms.Button();
            this.listBoxBrushes = new System.Windows.Forms.ListBox();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.tableLayoutPanelTop.SuspendLayout();
            this.tableLayoutPanelBundle.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.AutoSize = true;
            this.tableLayoutPanelTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTop.ColumnCount = 1;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.Controls.Add(this.tableLayoutPanelBundle, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.listBoxBrushes, 0, 1);
            this.tableLayoutPanelTop.Controls.Add(this.flowLayoutPanelButtons, 0, 2);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 3;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1062, 450);
            this.tableLayoutPanelTop.TabIndex = 0;
            // 
            // tableLayoutPanelBundle
            // 
            this.tableLayoutPanelBundle.AutoSize = true;
            this.tableLayoutPanelBundle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBundle.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelBundle.ColumnCount = 3;
            this.tableLayoutPanelBundle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBundle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBundle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBundle.Controls.Add(this.labelBundle, 0, 0);
            this.tableLayoutPanelBundle.Controls.Add(this.textBoxBundle, 1, 0);
            this.tableLayoutPanelBundle.Controls.Add(this.buttonBundleBrowse, 2, 0);
            this.tableLayoutPanelBundle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBundle.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelBundle.Name = "tableLayoutPanelBundle";
            this.tableLayoutPanelBundle.RowCount = 2;
            this.tableLayoutPanelBundle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBundle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBundle.Size = new System.Drawing.Size(1056, 48);
            this.tableLayoutPanelBundle.TabIndex = 6;
            // 
            // labelBundle
            // 
            this.labelBundle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBundle.AutoSize = true;
            this.labelBundle.BackColor = System.Drawing.SystemColors.Control;
            this.labelBundle.Location = new System.Drawing.Point(3, 0);
            this.labelBundle.Name = "labelBundle";
            this.labelBundle.Size = new System.Drawing.Size(113, 48);
            this.labelBundle.TabIndex = 1;
            this.labelBundle.Text = "Bundle:";
            this.labelBundle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxBundle
            // 
            this.textBoxBundle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBundle.Location = new System.Drawing.Point(122, 3);
            this.textBoxBundle.Name = "textBoxBundle";
            this.textBoxBundle.Size = new System.Drawing.Size(806, 38);
            this.textBoxBundle.TabIndex = 0;
            // 
            // buttonBundleBrowse
            // 
            this.buttonBundleBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonBundleBrowse.AutoSize = true;
            this.buttonBundleBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBundleBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBundleBrowse.Location = new System.Drawing.Point(934, 3);
            this.buttonBundleBrowse.Name = "buttonBundleBrowse";
            this.buttonBundleBrowse.Size = new System.Drawing.Size(119, 42);
            this.buttonBundleBrowse.TabIndex = 1;
            this.buttonBundleBrowse.Text = "Browse";
            this.buttonBundleBrowse.UseVisualStyleBackColor = false;
            this.buttonBundleBrowse.Click += new System.EventHandler(this.OnBrowseClick);
            // 
            // listBoxBrushes
            // 
            this.listBoxBrushes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxBrushes.FormattingEnabled = true;
            this.listBoxBrushes.ItemHeight = 31;
            this.listBoxBrushes.Location = new System.Drawing.Point(3, 57);
            this.listBoxBrushes.Name = "listBoxBrushes";
            this.listBoxBrushes.Size = new System.Drawing.Size(1056, 336);
            this.listBoxBrushes.TabIndex = 8;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelButtons.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonFind);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonCancel);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonOk);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(336, 399);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(390, 48);
            this.flowLayoutPanelButtons.TabIndex = 7;
            this.flowLayoutPanelButtons.WrapContents = false;
            // 
            // buttonFind
            // 
            this.buttonFind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonFind.AutoSize = true;
            this.buttonFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonFind.Location = new System.Drawing.Point(3, 3);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(192, 42);
            this.buttonFind.TabIndex = 0;
            this.buttonFind.Text = "Find Brushes";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.OnFindClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Location = new System.Drawing.Point(201, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(114, 42);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.Location = new System.Drawing.Point(321, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(66, 42);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.OnOkClick);
            // 
            // BrushesInBundleDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 450);
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrushesInBundleDialog";
            this.Text = "Brushes in Bundle";
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.tableLayoutPanelBundle.ResumeLayout(false);
            this.tableLayoutPanelBundle.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBundle;
        private System.Windows.Forms.Label labelBundle;
        private System.Windows.Forms.TextBox textBoxBundle;
        private System.Windows.Forms.Button buttonBundleBrowse;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ListBox listBoxBrushes;
    }
}