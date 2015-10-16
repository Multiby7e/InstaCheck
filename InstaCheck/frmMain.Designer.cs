namespace InstaCheck
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabUsernames = new System.Windows.Forms.TabPage();
            this.listUsernames = new System.Windows.Forms.ListView();
            this.colUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnBot = new System.Windows.Forms.ToolStripMenuItem();
            this.loadUsernamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCredits = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.chk_inst = new AetherCheckBox();
            this.chk_twi = new AetherCheckBox();
            this.tabMain.SuspendLayout();
            this.tabUsernames.SuspendLayout();
            this.menuSettings.SuspendLayout();
            this.tabCredits.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabUsernames);
            this.tabMain.Controls.Add(this.tabCredits);
            this.tabMain.Location = new System.Drawing.Point(0, 37);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(382, 209);
            this.tabMain.TabIndex = 32;
            // 
            // tabUsernames
            // 
            this.tabUsernames.Controls.Add(this.listUsernames);
            this.tabUsernames.Location = new System.Drawing.Point(4, 22);
            this.tabUsernames.Name = "tabUsernames";
            this.tabUsernames.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsernames.Size = new System.Drawing.Size(374, 183);
            this.tabUsernames.TabIndex = 0;
            this.tabUsernames.Text = "Usernames";
            this.tabUsernames.UseVisualStyleBackColor = true;
            // 
            // listUsernames
            // 
            this.listUsernames.BackColor = System.Drawing.Color.White;
            this.listUsernames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listUsernames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUsername,
            this.colStatus});
            this.listUsernames.ContextMenuStrip = this.menuSettings;
            this.listUsernames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listUsernames.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listUsernames.ForeColor = System.Drawing.Color.Black;
            this.listUsernames.FullRowSelect = true;
            this.listUsernames.GridLines = true;
            this.listUsernames.Location = new System.Drawing.Point(3, 3);
            this.listUsernames.Name = "listUsernames";
            this.listUsernames.Size = new System.Drawing.Size(368, 177);
            this.listUsernames.TabIndex = 32;
            this.listUsernames.UseCompatibleStateImageBehavior = false;
            this.listUsernames.View = System.Windows.Forms.View.Details;
            // 
            // colUsername
            // 
            this.colUsername.Text = "Username";
            this.colUsername.Width = 181;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 177;
            // 
            // menuSettings
            // 
            this.menuSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBot,
            this.loadUsernamesToolStripMenuItem});
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(133, 48);
            // 
            // btnBot
            // 
            this.btnBot.Name = "btnBot";
            this.btnBot.Size = new System.Drawing.Size(132, 22);
            this.btnBot.Text = "Start";
            this.btnBot.Click += new System.EventHandler(this.btnBot_Click);
            // 
            // loadUsernamesToolStripMenuItem
            // 
            this.loadUsernamesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnClear,
            this.btnExport});
            this.loadUsernamesToolStripMenuItem.Name = "loadUsernamesToolStripMenuItem";
            this.loadUsernamesToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.loadUsernamesToolStripMenuItem.Text = "Usernames";
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(107, 22);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClear
            // 
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(107, 22);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(107, 22);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabCredits
            // 
            this.tabCredits.Controls.Add(this.label2);
            this.tabCredits.Controls.Add(this.label1);
            this.tabCredits.Location = new System.Drawing.Point(4, 22);
            this.tabCredits.Name = "tabCredits";
            this.tabCredits.Size = new System.Drawing.Size(374, 149);
            this.tabCredits.TabIndex = 2;
            this.tabCredits.Text = "Credits";
            this.tabCredits.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "www.hackforums.net";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coded by: Multibyte";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 249);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(382, 22);
            this.statusStrip1.TabIndex = 33;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 17);
            this.lblStatus.Text = "Waiting...";
            // 
            // chk_inst
            // 
            this.chk_inst.Checked = false;
            this.chk_inst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_inst.EnabledCalc = true;
            this.chk_inst.Location = new System.Drawing.Point(85, 12);
            this.chk_inst.Name = "chk_inst";
            this.chk_inst.Size = new System.Drawing.Size(75, 19);
            this.chk_inst.TabIndex = 35;
            this.chk_inst.Text = "Instagram";
            // 
            // chk_twi
            // 
            this.chk_twi.Checked = false;
            this.chk_twi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_twi.EnabledCalc = true;
            this.chk_twi.Location = new System.Drawing.Point(4, 12);
            this.chk_twi.Name = "chk_twi";
            this.chk_twi.Size = new System.Drawing.Size(75, 19);
            this.chk_twi.TabIndex = 34;
            this.chk_twi.Text = "Twitter";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 271);
            this.Controls.Add(this.chk_inst);
            this.Controls.Add(this.chk_twi);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(390, 230);
            this.Name = "frmMain";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstaCheck - A simple Instagram checker";
            this.tabMain.ResumeLayout(false);
            this.tabUsernames.ResumeLayout(false);
            this.menuSettings.ResumeLayout(false);
            this.tabCredits.ResumeLayout(false);
            this.tabCredits.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabUsernames;
        internal System.Windows.Forms.ColumnHeader colUsername;
        internal System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.TabPage tabCredits;
        private System.Windows.Forms.ContextMenuStrip menuSettings;
        private System.Windows.Forms.ToolStripMenuItem btnBot;
        private System.Windows.Forms.ToolStripMenuItem loadUsernamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        internal System.Windows.Forms.ListView listUsernames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private AetherCheckBox chk_twi;
        private AetherCheckBox chk_inst;
    }
}

