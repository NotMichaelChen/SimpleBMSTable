using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SimpleBMSTable.TableInfo;

namespace SimpleBMSTable
{
    public partial class MainWindow : Form
    {
        //Path of LR2 Executable
        string LR2path;
        //Set of URLs that are already added
        HashSet<string> usedurls;
        //Each table is associated with its name to make name lookups from the combobox fast
        Dictionary<string, BMSTable> tables;

        public MainWindow()
        {
            LR2path = "";
            usedurls = new HashSet<string>();
            tables = new Dictionary<string, BMSTable>();

            InitializeComponent();

            this.LoadTables();
        }

        private void selectLR2FolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LR2PathSelector win2 = new LR2PathSelector(LR2path);
            DialogResult result = win2.ShowDialog();
            if(result == DialogResult.OK)
            {
                LR2path = win2.LR2Path;
            }
        }

        private void ButtonLoadURL_Click(object sender, EventArgs e)
        {
            string url = TextBoxURL.Text;

            if(usedurls.Contains(url))
            {
                MessageBox.Show("Error: Table already loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    BMSTable downloadedtable = new BMSTable(url);

                    usedurls.Add(url);
                    tables.Add(downloadedtable.TableName, downloadedtable);
                    ComboBoxTable.Items.Add(downloadedtable.TableName);
                    TextBoxURL.Text = "";

                    MessageBox.Show("Table added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    //TODO: Make more descriptive errors
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ComboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update the table when we select it
            try
            {
                string tablename = ComboBoxTable.Items[ComboBoxTable.SelectedIndex].ToString();
                tables[tablename].UpdateTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Save tables to "data.json" when application closes
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            using(StreamWriter sw = new StreamWriter("data.json"))
            using(JsonWriter jw = new JsonTextWriter(sw))
            {
                JObject data = JObject.FromObject(tables);
                data.Add("path", LR2path);

                data.WriteTo(jw);
            }
        }

        //Loads tables from "data.json" if it exists
        private void LoadTables()
        {
            try
            {
                if(File.Exists("data.json"))
                {
                    string data = File.ReadAllText("data.json");
                    tables = JsonConvert.DeserializeObject<Dictionary<string, BMSTable>>(data);
                    //TODO: Fix hack
                    tables.Remove("path");

                    JObject dataobject = (JObject)JsonConvert.DeserializeObject(data);
                    LR2path = dataobject["path"].Value<string>();

                    foreach(string name in tables.Keys)
                    {
                        ComboBoxTable.Items.Add(name);
                        usedurls.Add(name);
                    }
                }
            }
            catch
            {
                //Ensure something gets assigned to tables
                tables = new Dictionary<string, BMSTable>();
                MessageBox.Show("Error loading data file\nThis should be fixed after the application closes",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
