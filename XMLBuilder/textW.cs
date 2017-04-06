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
using System.Xml;
using System.Xml.Linq;

namespace XMI
{
    public partial class textW : Form
    {
        public string path = "";
        public textW()
        {
            InitializeComponent();            
        }
        public System.Diagnostics.Process p = new System.Diagnostics.Process();
        private void box_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            p = System.Diagnostics.Process.Start("IExplore.exe", e.LinkText);
        }
        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {   //click event
                //MessageBox.Show("you got it!");
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                MenuItem menuItem = new MenuItem("Cut");
                menuItem.Click += new EventHandler(CutAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy");
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.MenuItems.Add(menuItem);
                //menuItem = new MenuItem("Paste");
                //menuItem.Click += new EventHandler(PasteAction);
                //contextMenu.MenuItems.Add(menuItem);

                box.ContextMenu = contextMenu;
            }
        }
        void CutAction(object sender, EventArgs e)
        {
            box.Cut();
        }
        void CopyAction(object sender, EventArgs e)
        {
            Clipboard.SetText(box.SelectedText);
        }

        void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                box.Text
                    += Clipboard.GetText(TextDataFormat.Text).ToString();
            }
        }

        private void textW_Load(object sender, EventArgs e)
        {
            if (box.Text.Contains("PerformTransaction?txId"))
                autoFill.Visible = true;
            this.BringToFront();
        }

        private void textW_SizeChanged(object sender, EventArgs e)
        {

        }

        private void autoFill_Click(object sender, EventArgs e)
        {
            Form1 temp=new Form1();
            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(Application.StartupPath + @"\DB.xml", FileMode.Open);
            xdoc.Load(rfile);
            XmlElement co = (XmlElement)xdoc.GetElementsByTagName("dir")[0];
            rfile.Close();
            string defDir = co.InnerText;
            temp.defDir = defDir;
            string URL = temp.tagSearch(box.Text, "mpiHostedPageUrl");
             temp.createAutoVBSM(URL);
        }

        private void save_Click(object sender, EventArgs e)
        {
            try{
                File.WriteAllText(path, box.Text, Encoding.GetEncoding("UTF-8"));
            }
            finally
            {
                MessageBox.Show("Sucuessfully updated:\n" +path);
            }

        }  
    }
}
