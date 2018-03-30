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
using SimpleBMSTable.TableGenerators;

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
            //Safety measure: Set directory to executable path
            Directory.SetCurrentDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            using(StreamWriter sw = new StreamWriter("data.json"))
            using(JsonWriter jw = new JsonTextWriter(sw))
            {
                JObject data = JObject.FromObject(tables);
                data.Add("path", LR2path);

                data.WriteTo(jw);
            }
        }

        private void ButtonLoadTable_Click(object sender, EventArgs e)
        {
            try
            {
                string tablename = ComboBoxTable.Items[ComboBoxTable.SelectedIndex].ToString();

                TagEditor editor = new TagEditor(LR2path, tables[tablename]);
                CustomFolderGenerator gen = new CustomFolderGenerator(tables[tablename]);
                editor.AssignTags();
                //TODO: Allow a hard update to force regenerate the table
                if(!gen.IsTableExists())
                    gen.GenerateTable();

                MessageBox.Show("Table loaded successfully\n\n" +
                                               "You can use the difficulty tables by adding \"CustomFolder\" to LR2",
                                               "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                //TODO: Make more descriptive errors
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDeleteTable_Click(object sender, EventArgs e)
        {
            try
            {
                string tablename = ComboBoxTable.Items[ComboBoxTable.SelectedIndex].ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete table \"" + tablename + "\"?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                {

                    TagEditor editor = new TagEditor(LR2path, tables[tablename]);
                    CustomFolderGenerator gen = new CustomFolderGenerator(tables[tablename]);
                    editor.RemoveTags();
                    gen.DeleteTable();

                    // Remove combo box entry
                    ComboBoxTable.Items.RemoveAt(ComboBoxTable.SelectedIndex);

                    // Remove table entry from private objects
                    tables.Remove(tablename);
                    usedurls.Remove(tablename);

                    MessageBox.Show("Table removed successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Simple forces folder regeneration. Does not do tagging
        private void ButtonRegenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string tablename = ComboBoxTable.Items[ComboBoxTable.SelectedIndex].ToString();
                CustomFolderGenerator gen = new CustomFolderGenerator(tables[tablename]);
                gen.GenerateTable();
                MessageBox.Show("Table folders successfully regenerated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    JObject dataobject = (JObject)JsonConvert.DeserializeObject(data);
                    //Get path
                    LR2path = dataobject["path"].Value<string>();
                    //Get tables
                    foreach(KeyValuePair<string, JToken> kv in dataobject)
                    {
                        //Ignore keys that are "path"
                        if(kv.Key != "path")
                        {
                            tables.Add(kv.Key, kv.Value.ToObject<BMSTable>());
                        }
                    }

                    //Put table names in the combobox and usedurl's set
                    foreach(string name in tables.Keys)
                    {
                        ComboBoxTable.Items.Add(name);
                        usedurls.Add(name);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error loading data file\nThis should be fixed after the application closes",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
