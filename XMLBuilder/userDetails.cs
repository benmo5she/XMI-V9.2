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

namespace XMI
{
    public partial class userDetails : Form
    {
        string[,] files;
        Form1 mainFo;
        public userDetails(string[,] files2,Form1 f1)
        {
            InitializeComponent();
            files = files2;
            mainFo = f1;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            string[] dets = { server.Text, user.Text, password.Text, terminal.Text, mid.Text };
            this.Hide();
           mainFo.multipleTrans(files,1,dets);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userDetails_Load(object sender, EventArgs e)
        {
            server.Text = Properties.Settings.Default.serv;
            user.Text = ConfigurationManager.AppSettings["user"];
            password.Text = ConfigurationManager.AppSettings["pass"];
            terminal.Text = ConfigurationManager.AppSettings["terminal"];
        }
    }
}
