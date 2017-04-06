using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;

namespace XMI
{
    public partial class Options : Form
    {
        public string defDir;
        public string serv;
        public Options()
        {
            InitializeComponent();
            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(Application.StartupPath + @"\DB.xml", FileMode.Open);
            xdoc.Load(rfile);
            XmlElement co = (XmlElement)xdoc.GetElementsByTagName("dir")[0];
            XmlElement co2 = (XmlElement)xdoc.GetElementsByTagName("server")[0];
            rfile.Close();
            defDir = co.InnerText;
            serv = co2.InnerText;
            if (File.Exists(defDir + @"\servers.txt"))
            {
                string[] lineOfContents = File.ReadAllLines(defDir + @"\servers.txt");
                foreach (var line in lineOfContents)
                {
                    string[] tokens = line.Split(',');
                    server.Items.Add(tokens[0]);
                }
            }
        }
        private static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void Options_Load(object sender, EventArgs e)
        {
            dirO.Text = defDir;
            server.Text = serv;
        }

        private void ribbonMenuButton1_Click(object sender, EventArgs e)
        {
            if (dirO.Text[dirO.Text.Length - 1] != 92)
                dirO.Text += "\\";
            XmlDocument xdoc = new XmlDocument();
            FileStream up = new FileStream(Application.StartupPath + @"\DB.xml", FileMode.Open);
            xdoc.Load(up);
            XmlNodeList list = xdoc.GetElementsByTagName("dir");
            XmlElement cu = (XmlElement)xdoc.GetElementsByTagName("dir")[0];
            XmlElement cu2 = (XmlElement)xdoc.GetElementsByTagName("server")[0];
            cu.InnerText = dirO.Text;
            cu2.InnerText = server.Text;
            up.Close();
            xdoc.Save(Application.StartupPath + @"\DB.xml");
            //Properties.Settings.Default.path = dirO.Text;
            //Properties.Settings.Default.serv = server.Text;
            //Properties.Settings.Default.Save();
                //UpdateSetting("path", dirO.Text);
            //UpdateSetting("server", server.Text);
            MessageBox.Show("Settings has been updated successfully");
            //Properties.Settings.Default.Database1ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=False";
        }

        private void pdir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog stdp = new FolderBrowserDialog ();
            if (stdp.ShowDialog() == DialogResult.OK)
                dirO.Text = stdp.SelectedPath + "\\";
        }

    }
}
