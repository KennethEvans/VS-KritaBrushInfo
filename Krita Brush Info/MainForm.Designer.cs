namespace KritaBrushInfo {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelFile1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFile1 = new System.Windows.Forms.Label();
            this.textBoxFile1 = new System.Windows.Forms.TextBox();
            this.buttonBrowse1 = new System.Windows.Forms.Button();
            this.tableLayoutPanelFile2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFile2 = new System.Windows.Forms.Label();
            this.textBoxFile2 = new System.Windows.Forms.TextBox();
            this.buttonBrowse2 = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonProcess1 = new System.Windows.Forms.Button();
            this.buttonProcess2 = new System.Windows.Forms.Button();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.flowLayoutReorderAttr = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxReorderAttr = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelTop.SuspendLayout();
            this.tableLayoutPanelFile1.SuspendLayout();
            this.tableLayoutPanelFile2.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.flowLayoutReorderAttr.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.AutoSize = true;
            this.tableLayoutPanelTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTop.ColumnCount = 1;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.Controls.Add(this.tableLayoutPanelFile1, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.tableLayoutPanelFile2, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.textBoxInfo, 3, 0);
            this.tableLayoutPanelTop.Controls.Add(this.flowLayoutPanelButtons, 4, 0);
            this.tableLayoutPanelTop.Controls.Add(this.flowLayoutReorderAttr, 2, 0);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 5;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1652, 1063);
            this.tableLayoutPanelTop.TabIndex = 1;
            // 
            // tableLayoutPanelFile1
            // 
            this.tableLayoutPanelFile1.AutoSize = true;
            this.tableLayoutPanelFile1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFile1.ColumnCount = 3;
            this.tableLayoutPanelFile1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFile1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFile1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFile1.Controls.Add(this.labelFile1, 0, 0);
            this.tableLayoutPanelFile1.Controls.Add(this.textBoxFile1, 1, 0);
            this.tableLayoutPanelFile1.Controls.Add(this.buttonBrowse1, 2, 0);
            this.tableLayoutPanelFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFile1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelFile1.Name = "tableLayoutPanelFile1";
            this.tableLayoutPanelFile1.RowCount = 1;
            this.tableLayoutPanelFile1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFile1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanelFile1.Size = new System.Drawing.Size(1646, 48);
            this.tableLayoutPanelFile1.TabIndex = 2;
            // 
            // labelFile1
            // 
            this.labelFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFile1.AutoSize = true;
            this.labelFile1.BackColor = System.Drawing.SystemColors.Control;
            this.labelFile1.Location = new System.Drawing.Point(3, 0);
            this.labelFile1.Name = "labelFile1";
            this.labelFile1.Size = new System.Drawing.Size(93, 48);
            this.labelFile1.TabIndex = 1;
            this.labelFile1.Text = "File 1:";
            this.labelFile1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxFile1
            // 
            this.textBoxFile1.ContextMenuStrip = this.contextMenuStrip;
            this.textBoxFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFile1.Location = new System.Drawing.Point(102, 3);
            this.textBoxFile1.Name = "textBoxFile1";
            this.textBoxFile1.Size = new System.Drawing.Size(1416, 38);
            this.textBoxFile1.TabIndex = 0;
            // 
            // buttonBrowse1
            // 
            this.buttonBrowse1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonBrowse1.AutoSize = true;
            this.buttonBrowse1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBrowse1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBrowse1.Location = new System.Drawing.Point(1524, 3);
            this.buttonBrowse1.Name = "buttonBrowse1";
            this.buttonBrowse1.Size = new System.Drawing.Size(119, 42);
            this.buttonBrowse1.TabIndex = 1;
            this.buttonBrowse1.Text = "Browse";
            this.buttonBrowse1.UseVisualStyleBackColor = false;
            this.buttonBrowse1.Click += new System.EventHandler(this.OnBrowseFile1Click);
            // 
            // tableLayoutPanelFile2
            // 
            this.tableLayoutPanelFile2.AutoSize = true;
            this.tableLayoutPanelFile2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFile2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelFile2.ColumnCount = 3;
            this.tableLayoutPanelFile2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFile2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFile2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFile2.Controls.Add(this.labelFile2, 0, 0);
            this.tableLayoutPanelFile2.Controls.Add(this.textBoxFile2, 1, 0);
            this.tableLayoutPanelFile2.Controls.Add(this.buttonBrowse2, 2, 0);
            this.tableLayoutPanelFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFile2.Location = new System.Drawing.Point(3, 57);
            this.tableLayoutPanelFile2.Name = "tableLayoutPanelFile2";
            this.tableLayoutPanelFile2.RowCount = 2;
            this.tableLayoutPanelFile2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFile2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelFile2.Size = new System.Drawing.Size(1646, 68);
            this.tableLayoutPanelFile2.TabIndex = 3;
            // 
            // labelFile2
            // 
            this.labelFile2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFile2.AutoSize = true;
            this.labelFile2.BackColor = System.Drawing.SystemColors.Control;
            this.labelFile2.Location = new System.Drawing.Point(3, 0);
            this.labelFile2.Name = "labelFile2";
            this.labelFile2.Size = new System.Drawing.Size(93, 48);
            this.labelFile2.TabIndex = 1;
            this.labelFile2.Text = "File 2:";
            this.labelFile2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxFile2
            // 
            this.textBoxFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFile2.Location = new System.Drawing.Point(102, 3);
            this.textBoxFile2.Name = "textBoxFile2";
            this.textBoxFile2.Size = new System.Drawing.Size(1416, 38);
            this.textBoxFile2.TabIndex = 0;
            // 
            // buttonBrowse2
            // 
            this.buttonBrowse2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonBrowse2.AutoSize = true;
            this.buttonBrowse2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBrowse2.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBrowse2.Location = new System.Drawing.Point(1524, 3);
            this.buttonBrowse2.Name = "buttonBrowse2";
            this.buttonBrowse2.Size = new System.Drawing.Size(119, 42);
            this.buttonBrowse2.TabIndex = 1;
            this.buttonBrowse2.Text = "Browse";
            this.buttonBrowse2.UseVisualStyleBackColor = false;
            this.buttonBrowse2.Click += new System.EventHandler(this.OnBrowseFile2Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.ContextMenuStrip = this.contextMenuStrip;
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInfo.Location = new System.Drawing.Point(3, 179);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInfo.Size = new System.Drawing.Size(1646, 827);
            this.textBoxInfo.TabIndex = 0;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelButtons.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonProcess1);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonProcess2);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonCompare);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonQuit);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(500, 1012);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(651, 48);
            this.flowLayoutPanelButtons.TabIndex = 0;
            this.flowLayoutPanelButtons.WrapContents = false;
            // 
            // buttonProcess1
            // 
            this.buttonProcess1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonProcess1.AutoSize = true;
            this.buttonProcess1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonProcess1.Location = new System.Drawing.Point(3, 3);
            this.buttonProcess1.Name = "buttonProcess1";
            this.buttonProcess1.Size = new System.Drawing.Size(204, 42);
            this.buttonProcess1.TabIndex = 0;
            this.buttonProcess1.Text = "Process File 1";
            this.buttonProcess1.UseVisualStyleBackColor = true;
            this.buttonProcess1.Click += new System.EventHandler(this.OnProcess1Click);
            // 
            // buttonProcess2
            // 
            this.buttonProcess2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonProcess2.AutoSize = true;
            this.buttonProcess2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonProcess2.Location = new System.Drawing.Point(213, 3);
            this.buttonProcess2.Name = "buttonProcess2";
            this.buttonProcess2.Size = new System.Drawing.Size(204, 42);
            this.buttonProcess2.TabIndex = 1;
            this.buttonProcess2.Text = "Process File 2";
            this.buttonProcess2.UseVisualStyleBackColor = true;
            this.buttonProcess2.Click += new System.EventHandler(this.OnProcess2Click);
            // 
            // buttonCompare
            // 
            this.buttonCompare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCompare.AutoSize = true;
            this.buttonCompare.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCompare.Location = new System.Drawing.Point(423, 3);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(141, 42);
            this.buttonCompare.TabIndex = 2;
            this.buttonCompare.Text = "Compare";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.OnCompareClick);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonQuit.AutoSize = true;
            this.buttonQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonQuit.Location = new System.Drawing.Point(570, 3);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(78, 42);
            this.buttonQuit.TabIndex = 3;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.OnQuitCick);
            // 
            // flowLayoutReorderAttr
            // 
            this.flowLayoutReorderAttr.AutoSize = true;
            this.flowLayoutReorderAttr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutReorderAttr.Controls.Add(this.checkBoxReorderAttr);
            this.flowLayoutReorderAttr.Location = new System.Drawing.Point(3, 131);
            this.flowLayoutReorderAttr.Name = "flowLayoutReorderAttr";
            this.flowLayoutReorderAttr.Size = new System.Drawing.Size(475, 42);
            this.flowLayoutReorderAttr.TabIndex = 4;
            // 
            // checkBoxReorderAttr
            // 
            this.checkBoxReorderAttr.AutoSize = true;
            this.checkBoxReorderAttr.Checked = true;
            this.checkBoxReorderAttr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReorderAttr.Location = new System.Drawing.Point(3, 3);
            this.checkBoxReorderAttr.Name = "checkBoxReorderAttr";
            this.checkBoxReorderAttr.Size = new System.Drawing.Size(469, 36);
            this.checkBoxReorderAttr.TabIndex = 0;
            this.checkBoxReorderAttr.Text = "Reorder Attributes Alphabetically";
            this.checkBoxReorderAttr.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOverview,
            this.toolStripMenuItemAbout});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(219, 96);
            // 
            // toolStripMenuItemOverview
            // 
            this.toolStripMenuItemOverview.Name = "toolStripMenuItemOverview";
            this.toolStripMenuItemOverview.Size = new System.Drawing.Size(218, 46);
            this.toolStripMenuItemOverview.Text = "Overview";
            this.toolStripMenuItemOverview.Click += new System.EventHandler(this.onOverviewClick);
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(218, 46);
            this.toolStripMenuItemAbout.Text = "About";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.OnAboutClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1652, 1063);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Krita Brush Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.tableLayoutPanelFile1.ResumeLayout(false);
            this.tableLayoutPanelFile1.PerformLayout();
            this.tableLayoutPanelFile2.ResumeLayout(false);
            this.tableLayoutPanelFile2.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.flowLayoutReorderAttr.ResumeLayout(false);
            this.flowLayoutReorderAttr.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonProcess1;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFile1;
        private System.Windows.Forms.Label labelFile1;
        private System.Windows.Forms.TextBox textBoxFile1;
        private System.Windows.Forms.Button buttonBrowse1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFile2;
        private System.Windows.Forms.Label labelFile2;
        private System.Windows.Forms.TextBox textBoxFile2;
        private System.Windows.Forms.Button buttonBrowse2;
        private System.Windows.Forms.Button buttonProcess2;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutReorderAttr;
        private System.Windows.Forms.CheckBox checkBoxReorderAttr;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOverview;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
    }
}

