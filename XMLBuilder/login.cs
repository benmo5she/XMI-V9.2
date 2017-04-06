using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace XMI
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        [DllImport("advapi32.dll")]
        public static extern bool LogonUser(string name,string domain,string pass,int logType,int logpv,ref IntPtr pht);
        private void button1_Click(object sender, EventArgs e)
        {
                     IntPtr th = IntPtr.Zero;
        bool log = LogonUser(user.Text,"creditguard.co.il",pass.Text,2,0,ref th);
        if(log)
    {
        MessageBox.Show("Sucess");
    }else
{
     MessageBox.Show("error");
}
        }
    }
}
