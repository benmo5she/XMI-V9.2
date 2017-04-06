using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading;

namespace XMI
{
    public partial class sanity : Form
    {
        public string tamL;
        public string invL;
        public sanity()
        {
            InitializeComponent();
        }

        private void tamalL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tamL != null)
                System.Diagnostics.Process.Start(tamL);
            else
                MessageBox.Show("Invoice either failed or is not ready");
        }

        private void invoiceL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(invL!=null)
                System.Diagnostics.Process.Start(invL);
            else
                MessageBox.Show("Invoice either failed or is not ready");
        }

        private void sanity_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


    }
}
