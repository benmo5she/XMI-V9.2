using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMI
{
    public partial class sanityList : Form
    {
        public string defDir;
        public sanityList(string def)
        {
            InitializeComponent();
            defDir = def;
        }

        private void sanityList_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("J102");
            checkedListBox1.Items.Add("J4");
            checkedListBox1.Items.Add("Transmit Terminal");
            checkedListBox1.Items.Add("Refund Deal");
            checkedListBox1.Items.Add("Cancel Deal");
            checkedListBox1.Items.Add("Inquire Transaction");
            checkedListBox1.Items.Add("Tamal");
            checkedListBox1.Items.Add("Invoice4u");
            for(int i=0;i<8;i++)
                checkedListBox1.SetItemCheckState(i, CheckState.Indeterminate);
            if (File.Exists(defDir + @"\sanityTests.txt"))
                {
                    try
                    {
                        string[] lineOfContents = File.ReadAllLines(defDir + @"\sanityTests.txt");
                        foreach (var line in lineOfContents)
                        {
                            string[] tokens = line.Split('|');
                            if (tokens[1] == "1")
                                checkedListBox1.Items.Add(tokens[0], true);
                            else
                                checkedListBox1.Items.Add(tokens[0], false);
                        }
                    }
                    catch
                    {

                    }
                }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex > 7)
            {
                var allLines = File.ReadAllLines(defDir + @"\sanityTests.txt");
                var filteredLines = allLines.Where(x => !x.Contains(checkedListBox1.SelectedItem.ToString()));
                filteredLines = filteredLines.Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(defDir + @"\sanityTests.txt", filteredLines.TakeWhile(x=> x.Length>1));
                checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
                MessageBox.Show("Successfully deleted");
            }
            else
                MessageBox.Show("Cannot delete basic tests");
        }

        private void save_Click(object sender, EventArgs e)
        {
            string temp = "";
            if (File.Exists(defDir + @"\sanityTests.txt"))
            {
                string[] lineOfContents = File.ReadAllLines(defDir + @"\sanityTests.txt");
                for (int i = 8; i < checkedListBox1.Items.Count; i++)
                {
                    foreach (var line in lineOfContents)
                    {
                        if(!line.Contains(checkedListBox1.Items[i].ToString()))
                            continue;
                        string[] tokens = line.Split('|');
                        temp += tokens[0] + "|";
                        if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                            temp+="1";
                        else
                            temp+="0";
                        temp+="|" + tokens[2];
                        break;
                  }
                    temp+=Environment.NewLine;
                }
                temp = temp.Substring(0, temp.Length - 2);
                File.WriteAllText(defDir + @"\sanityTests.txt", temp);
                MessageBox.Show("Changes saved successfully.");
            }
        }
        public DialogResult ShowInputDialog(ref string input, string head)
        {
            System.Drawing.Size size = new System.Drawing.Size(320, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = head;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            if (result == DialogResult.OK)
                input = textBox.Text;
            return result;
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Add new test
            string temp = "";
            OpenFileDialog stdp = new OpenFileDialog();
            if (stdp.ShowDialog() == DialogResult.OK)
            {
                string fname = stdp.FileName.Substring(stdp.FileName.LastIndexOf('\\')+1);
                string input2 = fname.Substring(0,fname.IndexOf('.'));
                ShowInputDialog(ref input2, "Enter test name:");                
                if (new FileInfo(defDir + @"\sanityTests.txt").Length > 0)
                    temp += Environment.NewLine;
                temp += input2 + '|' + '0' + '|' + stdp.FileName;
                File.AppendAllText(defDir + @"\sanityTests.txt", temp);
                checkedListBox1.Items.Add(input2);
            }
        }
    }
}
