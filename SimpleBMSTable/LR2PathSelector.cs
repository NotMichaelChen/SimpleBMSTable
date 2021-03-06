﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBMSTable
{
    public partial class LR2PathSelector : Form
    {
        private string path;

        public string LR2Path
        {
            get { return path; }
        }

        public LR2PathSelector(string p)
        {
            InitializeComponent();
            FolderTextBox.Text = p;
        }

        private void ButtonSelectFolder_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                FolderTextBox.Text = dialog.SelectedPath;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            path = FolderTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
