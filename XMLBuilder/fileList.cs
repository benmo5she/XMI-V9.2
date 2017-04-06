using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Configuration;
using XMI.Bussines;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace XMI
{
    public partial class fileList : Form
    {
        public Form1 mainFo;
        public fileList(Form1 mainF)
        {
            InitializeComponent();
            mainFo = mainF;
        }

        private void fileList_Load(object sender, EventArgs e)
        {
            populate();
            //panel1.BackColor = this.BackColor;
            this.dataGridView1.Columns[3].Visible = false;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(255, 239, 227, 186);
            //this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;
        }



        private void fileListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                addTest_Click(sender, e);
                return;
            }
            loadX_Click(sender, e);
        }

        private void fileList_FormClosing(object sender, FormClosingEventArgs e)
        {            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            populate(search.Text);
        }

        private void runM_Click(object sender, EventArgs e)
        {                       
            string task = "";            
            mainFo.ShowInputDialog(ref task, "Enter task number to run:");
            if (task == "")
                return;
            IList temp = CategoryList.getT(task);
            DataView view = (DataView)temp;
            if(view.Count<1)
            {
                MessageBox.Show("No record has been found for this task, please check your input");
                reload();
                return;
            }
            string[,] files = new string[view.Count,2];
            for (int i = 0; i < temp.Count;i++ )
            {
                files[i, 0] = view[i][0].ToString();
                files[i,1] = view[i][4].ToString();
            }
            DialogResult result = MessageBox.Show("Do you want to use the script original connection?", "Warning",
MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                mainFo.multipleTrans(files, 0,null);
                reload();
            }
            else if (result == DialogResult.No)
            {
                userDetails getX = new userDetails(files,mainFo);
                getX.Show();
            }
            else if (result == DialogResult.Cancel)
            {
                reload();
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please choose a row to load");
                return;
            }
            if (this.dataGridView1.SelectedCells[4].Value.ToString() == "" || File.Exists(this.dataGridView1.SelectedCells[4].Value.ToString()) == false)
            {
                MessageBox.Show("No file was found,please make sure the file was not deleted");
                return;
            }
            mainFo.loadXML(this.dataGridView1.SelectedCells[4].Value.ToString()); 
            //loadXMLC(this.fileListDataGridView.SelectedCells[3].Value.ToString());

        }

        public void addPlan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please choose a row to add a plan to");
                return;
            }
            // fileListDataGridView_CellClick(sender,null);
            if (this.dataGridView1.SelectedCells[5].Value != "")
            {
                DialogResult rslt = MessageBox.Show("Test plan,allready exists,replace : " +
    this.dataGridView1.SelectedCells[5].Value + " ?", "[Confirmation]", MessageBoxButtons.YesNo);
                if (rslt == DialogResult.No)
                    return;
            }
            OpenFileDialog stdp = new OpenFileDialog();
            stdp.InitialDirectory = Properties.Settings.Default.path;
            if (stdp.ShowDialog() == DialogResult.OK)
            {
                this.dataGridView1.SelectedCells[5].Value = stdp.FileName;

            }
            CategoryList.updateXML();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please choose a row to delete");
                return;
            }
            try
            {
                MessageBox.Show(this.dataGridView1.SelectedCells[3].Value.ToString());
                DialogResult rslt = MessageBox.Show("Are sure want to delete this record no : " +
                    this.dataGridView1.SelectedCells[0].Value + " ?", "[Confirmation]", MessageBoxButtons.YesNo);
                if (rslt == DialogResult.Yes)
                {
                    
                    string item;
                    item = this.dataGridView1.SelectedCells[0].Value.ToString();
                    CategoryList.DeleteCategory(item);
                }
            }
            catch (Exception exp)
            {
                string strExp = "Record " + this.dataGridView1.SelectedCells[5].Value + " failed delete to datasource\n Message : " + exp.Message;
                MessageBox.Show(strExp, "[Status Dialog]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
             /*if (MessageBox.Show("Do you want to remove this row?", "Remove Line",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                this.dataGridView1.Rows.Remove(row);
                this.fileListBindingSource.EndEdit();
                this.fileListTableAdapter.Update(database1DataSet.fileList);
                fileListTableAdapter.Fill(this.database1DataSet.fileList);
            } */
        }

        void populate()
        {
            IList list = CategoryList.GetCategoryList();
            this.dataGridView1.DataSource = list;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (row.Cells[4].Value.ToString().Contains('|'))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 180, 238, 180);
                }
            }  
        }
        public void populate(string name)
        {
            IList list = CategoryList.getS(name);
            this.dataGridView1.DataSource = list; 
        }
        void reload()
        {
            IList list = CategoryList.refr();
            this.dataGridView1.DataSource = list; 
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CategoryList.updateXML();
        }

        private void addTest_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please choose a row to add a plan to");
                return;
            }
            // fileListDataGridView_CellClick(sender,null);
            if (this.dataGridView1.SelectedCells[5].Value != "")
            {
                System.Diagnostics.Process.Start((string)this.dataGridView1.SelectedCells[5].Value);
                return;
            }
            OpenFileDialog stdp = new OpenFileDialog();
            stdp.InitialDirectory = Properties.Settings.Default.path;
            if (stdp.ShowDialog() == DialogResult.OK)
            {
                this.dataGridView1.SelectedCells[5].Value = stdp.FileName;

            }
            CategoryList.updateXML();
            /*if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please choose a row to add a plan to");
                return;
            }
            fileListDataGridView_CellClick(sender, null);*/
        }

        private void loadX_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please choose a row to load");
                return;
            }
            string path = this.dataGridView1.SelectedCells[4].Value.ToString();
            string pathT;
            int i=0;
            int count = 0;
            foreach (char c in path)
                if (c == '|') count++;
            do
            {
                if (path.Contains('|'))
                {
                    pathT = path.Substring(0, path.IndexOf('|'));
                    path = path.Substring(path.IndexOf('|')+1);
            }else
                    pathT = path;
                if (pathT == "" || File.Exists(pathT) == false)
                {
                    MessageBox.Show("No file was found,please make sure the file was not deleted");
                    return;
                }
                    mainFo.loadXML(pathT);
                i++;                       
            }while(i<=count);
            //mainFo.numericUpDown1.Value = 0;
        }
            private void runMu_Click(object sender, EventArgs e)
        {
            string task = "";
            mainFo.ShowInputDialog(ref task, "Enter task number to run:");
            if (task == "")
                return;
            //populate(task);            
            //string cmd = "task in (" + task + ")";            
            //DataRow[] foundRows;
            IList temp = CategoryList.getT(task);
            DataView view = (DataView)temp;
            if (view.Count < 1)
            {
                MessageBox.Show("No record has been found for this task, please check your input");
                reload();
                return;
            }
            string[,] files = new string[view.Count, 2];
            for (int i = 0; i < temp.Count; i++)
            {
                files[i, 0] = view[i][0].ToString();
                files[i, 1] = view[i][4].ToString();
            }
            DialogResult result = MessageBox.Show("Do you want to use the script original connection?", "Warning",
MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                mainFo.multipleTrans(files, 0, null);                
                reload();                
            }
            else if (result == DialogResult.No)
            {
                userDetails getX = new userDetails(files, mainFo);
                getX.Show();
            }
            else if (result == DialogResult.Cancel)
            {
                reload();
            }
            mainFo.reset_Click(null, null);
            mainFo.numericUpDown1.Value = 0;
            return;
        }

        private void deleteRow_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please choose a row to delete");
                return;
            }
                string dePath=this.dataGridView1.SelectedCells[4].Value.ToString();
                DialogResult rslt = MessageBox.Show("Are you sure you want to delete this record no : " +
        this.dataGridView1.SelectedCells[0].Value + " ?", "[Confirmation]", MessageBoxButtons.YesNo);
                if (rslt == DialogResult.Yes)
                {
                    string item;
                    item = this.dataGridView1.SelectedCells[0].Value.ToString();
                    CategoryList.DeleteCategory(item);
                }
                else
                    return;
                int count = 0;
                foreach (char c in dePath)
                    if (c == '|') count++;
                string tpath;
            for(int i=0;i<=count;i++)
            {
                if (dePath.Contains('|'))
                {
                    tpath = dePath.Substring(0, dePath.IndexOf('|'));
                    dePath = dePath.Substring(dePath.IndexOf('|') + 1);
                }
                else
                    tpath = dePath;
                if (File.Exists(tpath))
                    File.Delete(tpath);
                if (Directory.Exists(Path.GetDirectoryName(tpath)))
                {
                    if (Directory.GetFiles(Path.GetDirectoryName(tpath)).Length == 0
        && Directory.GetDirectories(Path.GetDirectoryName(tpath)).Length == 0)
                    {
                        Directory.Delete(Path.GetDirectoryName(tpath));
                    }
                }
            }
            populate(search.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex.ToString());
        }
        public void testC()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (row.Cells[4].Value.ToString().Contains('|'))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 180, 238, 180);
                }
            }  
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow drow in this.dataGridView1.Rows)
            {
                if (drow.Cells[4].Value.ToString().Contains('|'))
                {
                    drow.DefaultCellStyle.BackColor = Color.FromArgb(255, 180, 238, 180);
                }
            } 
        }
    }
}
