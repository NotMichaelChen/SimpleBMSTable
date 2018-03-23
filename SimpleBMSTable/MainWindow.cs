using System;
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
    public partial class MainWindow : Form
    {
        string LR2FolderPath;

        public MainWindow()
        {
            LR2FolderPath = "";
            InitializeComponent();
        }

        private void selectLR2FolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LR2PathSelector win2 = new LR2PathSelector(LR2FolderPath);
            DialogResult result = win2.ShowDialog();
            if(result == DialogResult.OK)
            {
                LR2FolderPath = win2.LR2Path;
            }
        }
    }
}
