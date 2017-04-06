using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMI
{
    public partial class editQLinks : Form
    {
        public Form1 mainFo;
        public editQLinks(Form1 mainF)
        {
            InitializeComponent();
            for (int i = 1; i < 21;i++ )
                listBox1.Items.Add(ConfigurationManager.AppSettings["button" + i.ToString()] + " | " + ConfigurationManager.AppSettings["button" + i.ToString() + "L"]);
            mainFo = mainF;
        }
        private static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void reset_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex<0)
            {
                MessageBox.Show("No row selected,please select one");
                return;
            }                
            //UpdateSetting("button" + (listBox1.SelectedIndex + 1).ToString(), "button" + (listBox1.SelectedIndex + 1).ToString());
            string buttonS = "button" + (listBox1.SelectedIndex + 1).ToString();
            UpdateSetting(buttonS, "");
            UpdateSetting(buttonS + "L", "");
            listBox1.Items[listBox1.SelectedIndex] = ConfigurationManager.AppSettings[buttonS] + " | " + ConfigurationManager.AppSettings[buttonS + "L"];
            mainFo.Controls.Find(buttonS, true).FirstOrDefault().Text = "";
        }

    }
}
