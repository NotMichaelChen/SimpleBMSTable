namespace SimpleBMSTable
{
    partial class MainWindow
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
            System.Windows.Forms.Label label1;
            this.ButtonLoadURL = new System.Windows.Forms.Button();
            this.TextBoxURL = new System.Windows.Forms.TextBox();
            this.ComboBoxTable = new System.Windows.Forms.ComboBox();
            this.ButtonDeleteTable = new System.Windows.Forms.Button();
            this.ButtonLoadTable = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectLR2FolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ButtonRegenerate = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 91);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 13);
            label1.TabIndex = 6;
            label1.Text = "Tables";
            // 
            // ButtonLoadURL
            // 
            this.ButtonLoadURL.Location = new System.Drawing.Point(401, 54);
            this.ButtonLoadURL.Name = "ButtonLoadURL";
            this.ButtonLoadURL.Size = new System.Drawing.Size(75, 23);
            this.ButtonLoadURL.TabIndex = 2;
            this.ButtonLoadURL.Text = "Load URL";
            this.ButtonLoadURL.UseVisualStyleBackColor = true;
            this.ButtonLoadURL.Click += new System.EventHandler(this.ButtonLoadURL_Click);
            // 
            // TextBoxURL
            // 
            this.TextBoxURL.Location = new System.Drawing.Point(13, 28);
            this.TextBoxURL.Name = "TextBoxURL";
            this.TextBoxURL.Size = new System.Drawing.Size(463, 20);
            this.TextBoxURL.TabIndex = 1;
            // 
            // ComboBoxTable
            // 
            this.ComboBoxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTable.FormattingEnabled = true;
            this.ComboBoxTable.Location = new System.Drawing.Point(13, 110);
            this.ComboBoxTable.Name = "ComboBoxTable";
            this.ComboBoxTable.Size = new System.Drawing.Size(461, 21);
            this.ComboBoxTable.TabIndex = 3;
            this.ComboBoxTable.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTable_SelectedIndexChanged);
            // 
            // ButtonDeleteTable
            // 
            this.ButtonDeleteTable.Location = new System.Drawing.Point(98, 137);
            this.ButtonDeleteTable.Name = "ButtonDeleteTable";
            this.ButtonDeleteTable.Size = new System.Drawing.Size(80, 23);
            this.ButtonDeleteTable.TabIndex = 4;
            this.ButtonDeleteTable.Text = "Delete Table";
            this.ButtonDeleteTable.UseVisualStyleBackColor = true;
            this.ButtonDeleteTable.Click += new System.EventHandler(this.ButtonDeleteTable_Click);
            // 
            // ButtonLoadTable
            // 
            this.ButtonLoadTable.Location = new System.Drawing.Point(12, 137);
            this.ButtonLoadTable.Name = "ButtonLoadTable";
            this.ButtonLoadTable.Size = new System.Drawing.Size(80, 23);
            this.ButtonLoadTable.TabIndex = 5;
            this.ButtonLoadTable.Text = "Load Table";
            this.ButtonLoadTable.UseVisualStyleBackColor = true;
            this.ButtonLoadTable.Click += new System.EventHandler(this.ButtonLoadTable_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectLR2FolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectLR2FolderToolStripMenuItem
            // 
            this.selectLR2FolderToolStripMenuItem.Name = "selectLR2FolderToolStripMenuItem";
            this.selectLR2FolderToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.selectLR2FolderToolStripMenuItem.Text = "Select LR2 Folder";
            this.selectLR2FolderToolStripMenuItem.Click += new System.EventHandler(this.selectLR2FolderToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(486, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ButtonRegenerate
            // 
            this.ButtonRegenerate.Location = new System.Drawing.Point(184, 137);
            this.ButtonRegenerate.Name = "ButtonRegenerate";
            this.ButtonRegenerate.Size = new System.Drawing.Size(108, 23);
            this.ButtonRegenerate.TabIndex = 7;
            this.ButtonRegenerate.Text = "Regenerate Folder";
            this.ButtonRegenerate.UseVisualStyleBackColor = true;
            this.ButtonRegenerate.Click += new System.EventHandler(this.ButtonRegenerate_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 372);
            this.Controls.Add(this.ButtonRegenerate);
            this.Controls.Add(label1);
            this.Controls.Add(this.ButtonLoadTable);
            this.Controls.Add(this.ButtonDeleteTable);
            this.Controls.Add(this.ComboBoxTable);
            this.Controls.Add(this.ButtonLoadURL);
            this.Controls.Add(this.TextBoxURL);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "SimpleBMSTable";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextBoxURL;
        private System.Windows.Forms.ComboBox ComboBoxTable;
        private System.Windows.Forms.Button ButtonDeleteTable;
        private System.Windows.Forms.Button ButtonLoadTable;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectLR2FolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button ButtonLoadURL;
        private System.Windows.Forms.Button ButtonRegenerate;
    }
}

