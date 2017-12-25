using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Xml;
using System.Collections;
using XMI.Bussines;
using System.Net;
using System.Threading;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Xml.Schema;
using System.Security.Cryptography;
using System.Diagnostics;
using Microsoft.Win32;


namespace XMI
{
    public partial class Form1 : Form
    {
        public string xmlPath = "";
        public Category cat;
        public string[] XMLS=new string[100];
        public int flag = 0;
        public string defDir;
        public string serv;
        public string[,] sanityTests = new string[20, 2];        
        public Form1()
        {            
            InitializeComponent();
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            XMLD.SelectAll();
            updateButtons();
            fileList getX2 = new fileList(this);            
            getX2.TopLevel = false;
            getX2.Height = 286;
            getX2.Width = 650;
            getX2.FormBorderStyle = FormBorderStyle.None;
            getX2.Top = panel1.Top  - 502;
            getX2.Left = panel1.Left;
            panel1.Controls.Add(getX2);
            getX2.Show();
        }
        public void updateButtons()
        {
            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(Application.StartupPath+@"\DB.xml", FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList list = xdoc.GetElementsByTagName("Button");
            string[,] buttons = new string[40,2];
            int i;
            for (i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xdoc.GetElementsByTagName("Button")[i];
                XmlElement add = (XmlElement)xdoc.GetElementsByTagName("Value")[i];
                    buttons[i, 0] = cl.GetAttribute("Name");
                    buttons[i,1] = add.InnerText;
            }
            rfile.Close();
            List<Button> bt = buttons1.Controls.OfType<Button>().ToList();
            //bt = bt.OrderBy(Button => Button.Text).ToList();
            //ttest1
            bt = bt.OrderBy(Button => Button.Name.Substring(6)).ToList();
            //MessageBox.Show(Properties.Settings.Default.Buttons[0]);
            //MessageBox.Show("Hello");
            i = 0;
            //buttons1.Controls.OfType<Button>().ToList().ForEach(button =>
            bt.ForEach(button =>
            {
                    //val=temp.Substring(2).Split('|')[2];
                if (i < list.Count)
                {
                    button.Text = buttons[i, 0];
                    button.Tag = buttons[i, 1];
                    //MessageBox.Show(button.Text);
                }
                else
                {
                    button.Text = "";
                    button.Tag = "";
                    //MessageBox.Show(button.Text);
                }
                    //button.MouseDown += new MouseEventHandler(changeFave);
                    //ANOTHER TEST
                    i++;
            });
            bt = buttons2.Controls.OfType<Button>().ToList();
            bt = bt.OrderBy(Button => Button.Name.Substring(6)).ToList();
            bt.ForEach(button =>
            //buttons2.Controls.OfType<Button>().ToList().ForEach(button =>
            {
                //val=temp.Substring(2).Split('|')[2];
                if (i < list.Count)
                {
                    button.Text = buttons[i, 0];
                    button.Tag = buttons[i, 1];
                   // MessageBox.Show(button.Text);
                }
                else
                {
                    button.Text = "";
                    button.Tag = "";
                   // MessageBox.Show(button.Text);
                }
                //button.MouseDown += new MouseEventHandler(changeFave);
                i++;
            });
        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        public void loadXML(string path)
        {
            if (path == "")
                return;
            if(!File.Exists(path))
            {
                MessageBox.Show("Cant find:\n" + path);
                return;
            }
            string text = System.IO.File.ReadAllText(path, Encoding.GetEncoding("UTF-8"));
            /*if (text.IndexOf("<ashrait>") < 0 && !(path.Substring(path.Length - 3, 3) == "vbs"))
                {
                    int temp = text.IndexOf("int_in=");
                    int temp2 = text.IndexOf('"', temp);
                    text = text.Substring(temp + 7, temp2 - (temp + 7));
                }*/
            int countAsh = Regex.Matches(text, "<ashrait>").Count;
            if(path.Substring(path.Length-3,3) == "vbs")
            {                
                int first = text.IndexOf(@"""", text.IndexOf("URL")) + 1;
                int last = text.IndexOf(@"""",first+1);
                string str2;
                server.Text = text.Substring(first, last - first);
                first=text.IndexOf("user=")+5;
                last=text.IndexOf(@"""",first);
                user.Text=text.Substring(first, last - first);
                first = text.IndexOf("password=") + 9;
                last = text.IndexOf(@"""", first);
                password.Text = text.Substring(first, last - first);
                if (text.Contains("terminal &"))
                {
                    first = text.IndexOf("terminal =") + 9;
                    first = text.IndexOf(@"""", first) + 1;
                    last = text.IndexOf(@"""", first);
                    str2 = text.Substring(first, last - first);                    
                    first = text.IndexOf("<terminalNumber>")+ 16;
                    last = text.IndexOf("</terminalNumber>");
                    text = text.Remove(first, last - first);
                    text=text.Replace("<terminalNumber>", "<terminalNumber>" + str2);
                }
                if (text.Contains("& mpi_mid"))
                {
                    first = text.IndexOf("mpi_mid") + 6;
                    first = text.IndexOf(@"""", first) + 1;
                    last = text.IndexOf(@"""", first);
                    str2 = text.Substring(first, last - first);
                    first = text.IndexOf("<mid>") + 5;
                    last = text.IndexOf("</mid>");
                    text = text.Remove(first, last - first);
                    text = text.Replace("<mid>", "<mid>" + str2);
                }
                if (text.Contains("<uniqueid>"))
                {
                    first = text.IndexOf("<uniqueid>")+10;
                    last = text.IndexOf("</uniqueid>");
                    text=text.Remove(first, last - first);
                }
            
            int f = text.IndexOf("<ashrait>");
            int l = text.IndexOf("</ashrait>") + 10;
            if (f < 0)
            {
                int temp = text.IndexOf("int_in=");
                int temp2 = text.IndexOf('"', temp);
                text = text.Substring(temp + 7, temp2 - (temp + 7));
            }else
                text = text.Substring(f, l - f);
            }
            while (XMLS[(int)numericUpDown1.Value].Length > 0)
            {
                numericUpDown1.Value++;
                if(numericUpDown1.Value>=100)
                {
                    MessageBox.Show("Too many requests,max 100");
                    return;
                }
            }                
            XMLS[(int)numericUpDown1.Value] = text;
            XMLD.Text = XMLS[(int)numericUpDown1.Value];
          /*  int j=0;
            do
            {
                if (XMLS[j].Length<1)
                {
                   int first = text.IndexOf("<ashrait>");
                    int last = text.IndexOf("</ashrait>") + 10;
                    text = text.Substring(first, last - first);
                    XMLS[j] = text;
                    XMLD.Text = XMLS[0];
                    return;
                }
                if(j>=99)
                {
                    MessageBox.Show("Too many requests(maximum 100");
                    return;
                }
                j++;                
            } while (j < 100);  */          
        }

        public void loadVBS(string path)
        {
            if(!File.Exists(path))
            {
                MessageBox.Show("Problem reading: \n" + path + "\nPlease validate the file");
                return;
            }
            //string text = System.IO.File.ReadAllText(path, Encoding.GetEncoding("UTF-8"));
            string text = System.IO.File.ReadAllText(path, Encoding.GetEncoding("UTF-8"));
            if(text.IndexOf("ashrait")<0)
            {
                int temp = text.IndexOf("int_in=");
                int temp2 = text.IndexOf('"', temp);
                XMLD.Text = text.Substring(temp + 7, temp2 - (temp + 7));
                return;
            }
            if(!text.Contains("URL"))
            {
                XMLD.Text = text;
            }
            int first = text.IndexOf(@"""", text.IndexOf("URL")) + 1;
            int last = text.IndexOf(@"""", first + 1);
            string str2;
            server.Text = text.Substring(first, last - first);
            first = text.IndexOf("user=") + 5;
            last = text.IndexOf(@"""", first);
            user.Text = text.Substring(first, last - first);
            first = text.IndexOf("password=") + 9;
            last = text.IndexOf(@"""", first);
            password.Text = text.Substring(first, last - first);
            if (text.Contains("terminal &"))
            {
                first = text.IndexOf("terminal =") + 9;
                first = text.IndexOf(@"""", first) + 1;
                last = text.IndexOf(@"""", first);
                str2 = text.Substring(first, last - first);
                first = text.IndexOf("<terminalNumber>") + 16;
                last = text.LastIndexOf("</terminalNumber>");
                text = text.Remove(first, last - first);
                text = text.Replace("<terminalNumber>", "<terminalNumber>" + str2);
            }
            if (text.Contains("& mpi_mid"))
            {
                first = text.IndexOf("mpi_mid") + 6;
                first = text.IndexOf(@"""", first) + 1;
                last = text.IndexOf(@"""", first);
                str2 = text.Substring(first, last - first);
                first = text.IndexOf("<mid>") + 5;
                last = text.LastIndexOf("</mid>");
                text = text.Remove(first, last - first);
                text = text.Replace("<mid>", "<mid>" + str2);
            }
            if (text.Contains("<uniqueid>"))
            {
                first = text.IndexOf("<uniqueid>") + 10;
                last = text.LastIndexOf("</uniqueid>");
                text = text.Remove(first, last - first);
            }
            /*if (text.Contains("<uniqueid>"))
            {
                first = text.IndexOf("<uniqueid>")+10;
                last = text.LastIndexOf("</uniqueid>");
                text=text.Remove(first, last - first);
                text=text.Replace("<uniqueid>", "<uniqueid>" + DateTime.Now.TimeOfDay.ToString());
            }*/
            first = text.IndexOf("<ashrait>");
            last = text.LastIndexOf("</ashrait>") + 10;
            str2 = text.Substring(first, last - first);
            XMLD.Text = str2;
            return;
        }
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                loadXML(file);
        }

        public string reqS(string xmlR, string tagToGet, string serverB, ref string resp)
        {
            String result = "";
            String poststring = "user=" + user.Text + "&password=" + password.Text + "&int_in=";
            poststring += xmlR;
            //StreamWriter myWriter = null;
            byte[] bytes = Encoding.Default.GetBytes(poststring);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(serverB);
            objRequest.Method = "POST";
            objRequest.ContentLength = poststring.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse objResponse;
            try
            {
                Stream writer = objRequest.GetRequestStream();
                writer.Write(bytes, 0, bytes.Length);
                objResponse = (HttpWebResponse)objRequest.GetResponse();
               // myWriter = new StreamWriter(objRequest.GetRequestStream());
                //myWriter.Write(poststring);
            }
            catch (Exception e)
            {
                return "Http error: " + e.Message;
                //return e.Message;
            }
            finally
            {
                //Make sure to check timeout
                //if (writer != null)
               //     writer.Close();
            }
            //Try to get response bug transmit
            //HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr =
               new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            XmlDocument doc = new XmlDocument();
            try
            {
                if(result.Contains("<"))
                    doc.LoadXml(result);
            }
            catch (Exception e)
            {
                return "The transactions has failed,debug error:\n" + e.Message;
            }
            finally
            {
                doc.WriteTo(tx);
            }
            string strXmlText = sw.ToString();
            resp = strXmlText;
            //string response = doc.GetElementsByTagName("result")[0].InnerText;
            string response = "";
            if (result.Contains("<"))
                response = tagSearch(result, "result");
            else
                response = result.Substring(0, 3);
            if (response != "000" && response!= "1000")
                return "The transaction has failed due to code:" + response;
            if (!result.Contains("<"))
                return response;
            //response = doc.GetElementsByTagName(tagToGet)[0].InnerText;
            response = tagSearch(result, tagToGet);
            if (response.Length < 1)
                return ("The tag: " + tagToGet + " returned with no value");  
            return response;
        }
        public string reqS2(string xmlR, string tagToGet, string tag2, ref string tran, string serverB, ref string resp)
        {
            String result = "";
            String poststring = "user=" + user.Text + "&password=" + password.Text + "&int_in=";
            poststring += xmlR;
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(serverB);
            objRequest.Method = "POST";
            objRequest.ContentLength = poststring.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(poststring);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr =
               new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            doc.WriteTo(tx);
            string strXmlText = sw.ToString();
            resp = strXmlText;
            string response = doc.GetElementsByTagName("result")[0].InnerText;
            if (response != "000" && response != "1000")
                return "The transaction has failed due to code:" + response;
            tran = doc.GetElementsByTagName(tag2)[0].InnerText;
            if(!doc.OuterXml.Contains(tagToGet))
                return "";
            /*XmlNodeList nodes = doc.GetElementsByTagName(tagToGet);
            foreach (XmlNode n in nodes)
            {
                response = n.InnerText;
            }*/
            response = doc.GetElementsByTagName(tagToGet)[0].InnerText;
            if (response.Length < 1)
                return ("The tag: " + tagToGet + " returned with no value");          
            return response;
        }
        public void multipleTrans(string[,] files,int useOrg,string[] details)
        {
            int count = files.GetLength(0);
            string results="";
            string log="";
            for (int i = 0; i < count; i++)
            {
                String result = "";
                loadXML(files[i, 1]);
                if (useOrg == 1)
                {
                    server.Text = details[0];
                    user.Text = details[1];
                    password.Text = details[2];
                    if (XMLD.Text.IndexOf("<terminalNumber>") > -1)
                    {
                        int f = XMLD.Text.IndexOf("<terminalNumber>") + 16;
                        int l = XMLD.Text.IndexOf("</terminalNumber>");
                        XMLD.Text = XMLD.Text.Remove(f, l - f);
                        XMLD.Text = XMLD.Text.Replace("<terminalNumber>", "<terminalNumber>" + details[3]);
                    }
                    if (XMLD.Text.IndexOf("<mid>") > -1)
                    {
                        int f = XMLD.Text.IndexOf("<mid>") + 5;
                        int l = XMLD.Text.IndexOf("</mid>");
                        XMLD.Text = XMLD.Text.Remove(f, l - f);
                        XMLD.Text = XMLD.Text.Replace("<mid>", "<mid>" + details[4]);
                    }
                }
                if (XMLD.Text.Contains("<uniqueid>"))
                {
                    int first = XMLD.Text.IndexOf("<uniqueid>") + 10;
                    int last = XMLD.Text.LastIndexOf("</uniqueid>");
                    XMLD.Text = XMLD.Text.Remove(first, last - first);
                    XMLD.Text = XMLD.Text.Replace("<uniqueid>", "<uniqueid>" + DateTime.Now.TimeOfDay.ToString());
                }  
                String poststring = "user=" + user.Text + "&password=" + password.Text + "&int_in=";
                poststring += XMLD.Text;
                //StreamWriter myWriter = null;
                byte[] bytes = Encoding.UTF8.GetBytes(poststring);
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(server.Text);
                objRequest.Method = "POST";
                objRequest.ContentLength = poststring.Length;
                objRequest.ContentType = "application/x-www-form-urlencoded";

                try
                {
                    Stream writer = objRequest.GetRequestStream();
                    writer.Write(bytes, 0, bytes.Length);
                    //myWriter = new StreamWriter(objRequest.GetRequestStream());
                    //myWriter.Write(poststring);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
                finally
                {
                    //myWriter.Close();
                }

                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader sr =
                   new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }
                int start=result.IndexOf("<ashrait>");
                int end=result.IndexOf("</ashrait>");
                if (start < 0)
                {
                    string resp = result.Substring(0, 3);
                    results += "Test: " + files[i, 0] + " received status of: " + resp + "\n";
                    log += "test: " + files[i, 0] + ":" + Environment.NewLine + result + Environment.NewLine + Environment.NewLine;
                    ClearTextBoxes();
                }
                else
                {
                    result = result.Substring(start, end + 10 - start);
                    StringWriter sw = new StringWriter();
                    XmlTextWriter tx = new XmlTextWriter(sw);
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);
                    doc.WriteTo(tx);
                    string strXmlText = sw.ToString();
                    if (tagSearch(strXmlText, "mpiHostedPageUrl")!="")
                    {
                        createAutoVBSM(tagSearch(strXmlText, "mpiHostedPageUrl"));
                        System.Threading.Thread.Sleep(7000);
                    }
                    log += "tranId: " + doc.GetElementsByTagName("tranId")[0].InnerText + Environment.NewLine + strXmlText + Environment.NewLine + Environment.NewLine;
                    string response = doc.GetElementsByTagName("result")[0].InnerText;
                    results += "Test: " + files[i, 0] + " received status of: " + response + "\n";
                    ClearTextBoxes();
                    numericUpDown1.Value = 0;
                }
            }
                        //DialogResult result = MessageBox.Show("Do you want to use the script original connection?", "Warning",
//MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        DialogResult ask = MessageBox.Show(results + "\n" + "Would you like to watch the log?", "Results",
MessageBoxButtons.YesNo);
                        if (ask == DialogResult.Yes)
                        {
                            string dir = defDir + "log.txt";
                            StreamWriter sw;
                            sw=File.CreateText(dir);
                            sw.Write(log);
                            sw.Close();
                            System.Diagnostics.Process.Start(dir);
                        }
                        numericUpDown1.Value = 0;
                        return;
        }
        public void createAPITransaction(string name)
        {
            String result = "";
            String poststring = "user=" + user.Text + "&password=" + password.Text + "&int_in=";

            poststring += XMLD.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(poststring);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(server.Text);
            objRequest.Method = "POST";
            objRequest.ContentLength = bytes.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";
            objRequest.KeepAlive = false;
            HttpWebResponse objResponse;
            try
            {
                Stream writer = objRequest.GetRequestStream();
                writer.Write(bytes, 0, bytes.Length);
                objResponse = (HttpWebResponse)objRequest.GetResponse();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("resolv"))
                {
                    string hosts = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
                    string tcheck = File.ReadAllText(hosts);
                    string scheck = e.Message.Substring(e.Message.IndexOf("'") + 1, e.Message.LastIndexOf("'") - e.Message.IndexOf("'") - 1);
                    if(!tcheck.Contains(scheck))
                    {
                    DialogResult ask = MessageBox.Show("It seems that the server: " + scheck + " is missing from the hosts file,would you like to add it?", "Add host?",
MessageBoxButtons.YesNo);
                    if (ask == DialogResult.Yes)
                    {
                        Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts"));
                        /*try
                        {
                            using (StreamWriter w = File.AppendText(hosts))
                            {
                                w.WriteLine(Environment.NewLine + "10.0.0." + scheck.Substring(2, 3) + " " + scheck);
                                w.Close();
                                createAPITransaction(name);
                                return;
                            }
                        }*
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }*/
                    }                    
                    }
                }
                else
                {
                    MessageBox.Show(e.Message);
                    return;
                }
                return;
            }
            finally
            {
                
                   // writer.Close();
            }            
            using (StreamReader sr =
               new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
                        textW getX = new textW();
                        getX.StartPosition = FormStartPosition.Manual;
                        getX.Left = this.Left + 335;
                        getX.Top = this.Top;
            if(result[0]!='<')
            {
                if(result.Substring(0,3)=="000")
                {
                   getX.symbol.Image = XMI.Properties.Resources.approved;
                   getX.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    getX.symbol.Image = XMI.Properties.Resources.denined;
                    getX.BackColor = System.Drawing.Color.IndianRed;
                }
                return;
             }            
            string strXmlText = result;
            while (strXmlText.IndexOf(">http")>-1)
            {
                int hts = strXmlText.IndexOf(">http")+1;
                int hte = strXmlText.IndexOf("<", hts);
                string sub = strXmlText.Substring(hts, hte - hts);
                strXmlText = strXmlText.Replace(sub, " " + sub + " ");
            }
            string te = Application.OpenForms.OfType<textW>().Count().ToString();
            if (Application.OpenForms.OfType<textW>().Count() == 1)
            {
                Application.OpenForms.OfType<textW>().First().Close();
                return;
            }
            string val = tagSearch("validation");
            string inv = tagSearch("invoiceResponseName");
            int inq = XMLD.Text.IndexOf("inquireTransactions");
            int transInq = XMLD.Text.IndexOf("transmitInquire");
            string def  = tagSearch(result,"result");
            string TI = tagSearch(result, "result");
            string comm = tagSearch("command");
            string mpi = "";
            int tmp = -1;
            if(val=="txnsetup")
            {
                string response = tagSearch(strXmlText, "mpiHostedPageUrl");
                string resp2 = tagSearch(strXmlText, "token");
                if(response.IndexOf("http")>=0 && resp2!="")
                {
                    getX.symbol.Image = XMI.Properties.Resources.approved;
                    getX.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    getX.symbol.Image = XMI.Properties.Resources.denined;
                    getX.BackColor = System.Drawing.Color.IndianRed;
                }
                getX.box.Text = strXmlText;                
                getX.Show();
                organizeXML(getX.box);
                getX.box.SelectionStart = 0;
                return;
            }else if(inv!="")
            {
                string response = tagSearch(strXmlText, "invoiceDocUrl");
                if (response.IndexOf("http") >= 0)
                {
                    getX.symbol.Image = XMI.Properties.Resources.approved;
                    getX.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    getX.symbol.Image = XMI.Properties.Resources.denined;
                    getX.BackColor = System.Drawing.Color.IndianRed;
                }
                getX.box.Text = strXmlText;
                getX.Show();
                organizeXML(getX.box);
                getX.box.SelectionStart = 0;
                return;
            }
            else if (comm == "transmitterminal")
            {
                if (TI == "1000")
                {
                    getX.symbol.Image = XMI.Properties.Resources.approved;
                    getX.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    getX.symbol.Image = XMI.Properties.Resources.denined;
                    getX.BackColor = System.Drawing.Color.IndianRed;
                }
            }
            else if(transInq>-1)
            {                
                if(TI=="1000")
                {
                    getX.symbol.Image = XMI.Properties.Resources.approved;
                    getX.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    getX.symbol.Image = XMI.Properties.Resources.denined;
                    getX.BackColor = System.Drawing.Color.IndianRed;
                }
            }
            else if (inq >-1)
            {
                int mp = result.IndexOf("mpiTransactionId");
                if (mp > -1)
                {
                    mpi = tagSearch(result, "mpiTransactionId");
                }
                else if (XMLD.Text.IndexOf("mpiTransactionId")<0)
                {
                    string response = tagSearch(result, "totalMatch");
                    if (response == "")
                        tmp = 0;
                    else
                        tmp = Convert.ToInt32(response);
                }
                if (tmp > 0 || mpi!="")
                {
                    getX.symbol.Image = XMI.Properties.Resources.approved;
                    getX.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    getX.symbol.Image = XMI.Properties.Resources.denined;
                    getX.BackColor = System.Drawing.Color.IndianRed;
                }
                getX.box.Text = strXmlText;
                getX.Show();
                organizeXML(getX.box);
                getX.box.SelectionStart = 0;
                return;
            }           
            else if (def=="000" || def=="1000")
            {
                getX.symbol.Image = XMI.Properties.Resources.approved;
                getX.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                getX.symbol.Image = XMI.Properties.Resources.denined;
                getX.BackColor = System.Drawing.Color.IndianRed;
            }
            getX.box.Text = strXmlText;
            getX.Show();
            organizeXML(getX.box);
            getX.box.SelectionStart = 0;
            return;
        }
        public void createVBS(string dir)
        {
            string output = XMLD.Text;
            output = output.Replace("\n", "");
            //output = output.Replace(" ", "");
            StreamWriter sw;
            sw = File.CreateText(dir);
            string outputv;
            outputv = "Randomize" + Environment.NewLine + Environment.NewLine + "URL = \"" + server.Text.ToString() + "\"" + Environment.NewLine +"strUser = \"user=" + user.Text.ToString() + "\"" + Environment.NewLine + "strPass = \"password=" + password.Text.ToString() + "\"";
            outputv += Environment.NewLine + Environment.NewLine+ "int_in = \"int_in=" + output + "\"";
            outputv += Environment.NewLine + Environment.NewLine + "Set DOMDoc = CreateObject(\"MSXML2.DOMDocument\")" + Environment.NewLine + "Set XMLHTTP = CreateObject(\"WinHttp.WinHttpRequest.5.1\")" + Environment.NewLine + "DOMDoc.loadXML(strSendData)";
            outputv += Environment.NewLine + Environment.NewLine + "strSendData = URL & \"?\" & strUser & \"&\" & strPass & \"&\" & int_in" + Environment.NewLine + Environment.NewLine + "XMLHTTP.Open \"GET\", strSendData, False" + Environment.NewLine + "XMLHTTP.setRequestHeader \"Content-type\", \"application/x-www-form-urlencoded\"";
            outputv += Environment.NewLine + "WScript.Echo strSendData" + Environment.NewLine + "XMLHTTP.send strSendData" + Environment.NewLine + "WScript.Echo XMLHTTP.responseText";
            if(output[0]=='<')
            {
                output += Environment.NewLine + Environment.NewLine + "resp = XMLHTTP.responseText" + Environment.NewLine + "loc1 = InStr(resp,\"<mpiHostedPageUrl>\")" + Environment.NewLine;
                outputv += Environment.NewLine + "loc2 = InStr(resp,\"</mpiHostedPageUrl>\")" + Environment.NewLine + Environment.NewLine + "redirect = mid(resp, loc1+18, loc2-loc1-18)" + Environment.NewLine + "WScript.Echo redirect" + Environment.NewLine + Environment.NewLine + "explr = \"iexplore.exe \" & redirect" + Environment.NewLine + Environment.NewLine;
                outputv += "Set WshShell = WScript.CreateObject(\"WScript.Shell\")" + Environment.NewLine + "Return = WshShell.Run(explr, 1)" + Environment.NewLine;
            }
            outputv += Environment.NewLine + "XMLHTTP = null";
            sw.Write(outputv);
            sw.Close();
            //System.Diagnostics.Process.Start(dir);
        }
        public void createAutoVBS(string token)
        {
           // string output = XMLD.Text;
            //output = output.Replace("\n", "");
            //output = output.Replace(" ", "");
            StreamWriter sw;
            string dir = defDir + @"\defaultXML\autoMPI.vbs";
            Stream temp = File.OpenRead(dir);
            sw = File.CreateText(dir);
            string outputv;
            outputv = "Option Explicit\nDim core\nDim browser\nSet core    = CreateObject(\"OpenTwebst.Core\")\nSet browser = core.StartBrowser(\"https://cgmpiuat.creditguard.co.il//CGMPI_Server/PerformTransaction?txId=" + token + "\")\n\n";
            outputv+="Call browser.FindElement(\"input text\", \"id=Track2CardNo\").InputText(\"12312312\")\n";
            outputv+="Call browser.FindElement(\"select\",\"id=expYear\").Select(\"2020\")\n";
            outputv+="Call browser.FindElement(\"select\", \"id=expMonth\").Select(\"08\")\n";
            outputv+="Call browser.FindElement(\"input text\", \"id=cvv\").InputText(\"123\")\n";
            outputv+="Call browser.FindElement(\"input text\", \"id=personalId\").InputText(\"000000000\")\n";
            outputv += "Call browser.FindElement(\"input submit\", \"id=submitBtn\").Click()" + Environment.NewLine;
            outputv += "WScript.Sleep 1000" + Environment.NewLine;
            outputv += "WScript.Echo \"The J106 has finished,press submit to perform inquire\"";
            sw.Write(outputv);
            sw.Close();
            System.Diagnostics.Process.Start(dir);
        }
        public void createAutoVBSM(string URL)
        {
            // string output = XMLD.Text;
            //output = output.Replace("\n", "");
            //output = output.Replace(" ", "");
            StreamWriter sw;
            string dir = defDir + @"\defaultXML\autoMPI.vbs";
            URL = URL.Replace(" ", "");
            //var fileContents = System.IO.File.ReadAllText(dir);

           // fileContents = fileContents.Replace('@' + URL + '@', URL);
            //System.IO.File.WriteAllText(dir, fileContents);
            string content=File.ReadAllText(dir);
            content = content.Replace("@URL@", URL);
            Random rnd = new Random();
            int tmp = rnd.Next(100);
            string tempF=dir.Replace("autoMPI", "autoMPI" + tmp);
            File.Create(tempF).Dispose();            
            using (TextWriter tw = new StreamWriter(tempF))
            {
                tw.WriteLine(content);
                tw.Close();
            }
            //Thread.Sleep(2000);
            /*sw = File.CreateText(dir);
            string outputv;
            outputv = "Option Explicit\nDim core\nDim browser\nSet core    = CreateObject(\"OpenTwebst.Core\")\nSet browser = core.StartBrowser(\"" + URL + "\")\n\n";
            outputv += "Call browser.FindElement(\"input text\", \"id=Track2CardNo\").InputText(\"12312312\")\n";
            outputv += "Call browser.FindElement(\"select\",\"id=expYear\").Select(\"2020\")\n";
            outputv += "Call browser.FindElement(\"select\", \"id=expMonth\").Select(\"08\")\n";
            outputv += "Call browser.FindElement(\"input text\", \"id=cvv\").InputText(\"123\")\n";
            outputv += "Call browser.FindElement(\"input text\", \"id=personalId\").InputText(\"000000000\")\n";
            outputv += "Call browser.FindElement(\"input submit\", \"id=submitBtn\").Click()" + Environment.NewLine;
            outputv += "WScript.Sleep 3000" + Environment.NewLine;
            outputv += "Call browser.Close()";
            //outputv += "WScript.Echo \"The J106 has finished,press submit to perform inquire\"";
            sw.Write(outputv);
            sw.Close();*/
            System.Diagnostics.Process.Start(tempF);
            Thread.Sleep(2000);
            File.Delete(tempF);
        }
        public string cardType()
        {
            string typeC="";
            if (tagSearch("cardNo").Length > 36)
                typeC = "track2";
            if (tagSearch("cardNo").Length == 16 && tagSearch("cardNo")[0] == '1' && tagSearch("cardNo")[1] == '0')
                return "cardId";
            else
                return "Normal";
            return typeC;
        }
        public void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox && control.Name != "user" && control.Name != "password" && control.Name != "terminal" && control.Name != "task")
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
            XMLD.Text = "";
        }
        public DialogResult ShowInputDialog(ref string input,string head)
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
            if(result==DialogResult.OK)
                input = textBox.Text;
            return result;
        }

        public void Form1_Load(object sender, EventArgs e)
        {            
            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(Application.StartupPath + @"\DB.xml", FileMode.Open);
            xdoc.Load(rfile);
            XmlElement co = (XmlElement)xdoc.GetElementsByTagName("dir")[0];
            XmlElement co2 = (XmlElement)xdoc.GetElementsByTagName("server")[0];
            rfile.Close();
            defDir = co.InnerText;
            validator();
            serv = co2.InnerText;
            //server.Text = Properties.Settings.Default.serv;
            server.Text = serv;
            user.Text = "sanity";
            password.Text = "Admin123.";
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            server.AutoCompleteCustomSource = acsc;
            server.AutoCompleteMode = AutoCompleteMode.None;
            server.AutoCompleteSource = AutoCompleteSource.CustomSource;
            listBox1.LostFocus+=new EventHandler(listBox1_LostFocus);
            //Load the servers to the box for autocomplete
            //List<string> stl=new List<string>();
            if (File.Exists(defDir + @"\servers.txt"))
            {
                string[] lineOfContents = File.ReadAllLines(defDir + @"\servers.txt");
                foreach (var line in lineOfContents)
                {
                    string[] tokens = line.Split('|');
                    server.Items.Add(tokens[0]);
                    acsc.Add(tokens[0]);
              //      stl.Add(tokens[0]);
                }
                //server.Values = stl.ToArray();
            }
            if (defDir == "")
            {
                string tempPath = "";
                MessageBox.Show("No working directory was selected please choose one now.");
                FolderBrowserDialog stdp = new FolderBrowserDialog();
                if (stdp.ShowDialog() == DialogResult.OK)
                {
                    tempPath = stdp.SelectedPath + "\\";
                    UpdateSetting("path", tempPath);
                    this.Activate();
                }
                else
                    Application.Exit();
            }
            string pa = defDir;
            if(pa[pa.Length-1]!=92)
                UpdateSetting("path",pa+"\\");
            //bgColor.Value = Convert.ToInt32(ConfigurationManager.AppSettings["bgColor"]);
            xdoc = new XmlDocument();
            rfile = new FileStream(Application.StartupPath + @"\DB.xml", FileMode.Open);
            xdoc.Load(rfile);
            co = (XmlElement)xdoc.GetElementsByTagName("bgColor")[0];
            rfile.Close();
            bgColor.Value = Int32.Parse(co.InnerText);
            //bgColor.Value = Convert.ToInt32(Properties.Settings.Default.bgco);
            this.CenterToScreen();
            buttons1.Controls.OfType<Button>().ToList().ForEach(button =>
            {
                if ((string)button.Tag != "auto")
                {
                    //button.Tag = new Stopwatch();
                    button.MouseDown += new MouseEventHandler(changeFave);
                    //button.MouseUp += new MouseEventHandler(button_MouseUp);
                }
            });
            buttons2.Controls.OfType<Button>().ToList().ForEach(button =>
            {
                if ((string)button.Tag != "auto")
                {
                    //button.Tag = new Stopwatch();
                    button.MouseDown += new MouseEventHandler(changeFave);
                    //button.MouseUp += new MouseEventHandler(button_MouseUp);
                }
            });
            for (int i = 0; i < 100; i++)
                XMLS[i] = "";
            //server.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public string tagSearch(string tag)
          {
              if (!XMLD.Text.Contains(tag))
                  return "";
              string st = "<" + tag + ">";
              string en = "</" + tag + ">";
            int st2=XMLD.Text.IndexOf(st)+st.Length;
            string sub = XMLD.Text.Substring(st2, XMLD.Text.IndexOf(en) - st2);
            return sub;
/*            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(XMLD.Text));
            while(reader.Read())
            {
                if (reader.Name == tag)
                    return reader.ReadString().ToLowerInvariant();

            }
            return "";*/
        }
        public string tagSearch(string xdata,string tag)
        {
            if (!xdata.Contains(tag))
                return "";
            string st = "<" + tag + ">";
            string en = "</" + tag + ">";
            int st2 = xdata.IndexOf(st) + st.Length;
            string sub = xdata.Substring(st2, xdata.IndexOf(en) - st2);
            return sub;
        }
        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }

        }
        public void submit_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<textW>().Count() == 1)
            {
                Application.OpenForms.OfType<textW>().First().Close();
            }
            XMLS[(int)numericUpDown1.Value] = XMLD.Text;
            int i = 1;
            addToServers();
            for (i = 1; i < 100;i++ )
            {
                if(XMLS[i].Length>0)
                {                   
                    runSet();
                    return;
                }
            }
                XMLD.Text = XMLS[0];
                if (flag == 1)
                {
                    MessageBox.Show("Another request is proccessed,please wait");
                    return;
                }
                if (XMLD.Text.Length == 0)
                {
                    MessageBox.Show("Empty XML! you should write something...");
                    return;
                }
                if (XMLD.Text[0] != '<')
                {
                    intToServer(XMLD.Text);
                    return;
                }
                try
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(XMLD.Text);
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Invalid XML format, please check for mistakes");
                    return;
                }
                flag = 1;
                XMLD.Text = uniqId(XMLD.Text);
                XMLD.Text = replaceCardId(XMLD.Text);                
                /*if (XMLD.Text.Contains("<ccDate>"))
                {
                    Date today = Date.Today;
                    int first = XMLD.Text.IndexOf("<ccDate>") + 7;
                    int last = XMLD.Text.LastIndexOf("</ccDate>");
                    XMLD.Text = XMLD.Text.Remove(first, last - first);
                    XMLD.Text = XMLD.Text.Replace("<ccDate>", "<ccDate>" + DateTime.Now.TimeOfDay.ToString());
                }*/
                load loadX = new load();
                Task.Factory.StartNew(() =>
                {
                    loadX.ShowDialog();
                });
                Thread.Sleep(2000);
                createAPITransaction("tempDeal");
                Invoke(new MethodInvoker(() =>
                {
                    loadX.Close();
                }));

                flag = 0;
                i++;
        }
        public void save_Click(object sender, EventArgs e)
        {
            if (XMLD.Text.Length == 0)
            {
                MessageBox.Show("Empty XML! you should write something...");
                return;
            }
            if (!File.Exists(defDir + "\\XML\\Category.xml"))
            {
                MessageBox.Show("Cant access:\n" + defDir + "\\XML\\Category.xml" + "\nPlease make sure you have the proper premission and that the file is named correctly.");
                return;
            }
            addToServers();
               if (task.Text == "")
               {
                   string input = "";
                   ShowInputDialog(ref input, "Enter task number:");
                   task.Text = input;
                   if (task.Text == "")
                       return;
               }
               string taskN = task.Text; 
               string input2 = "";
               ShowInputDialog(ref input2, "Enter Desirable tags seperated with ','");
               string tags = input2;
               string input3 = "doDeal";
               ShowInputDialog(ref input3, "Enter desired file name");
               string fname = input3;
               if (fname == "")
                   fname = "doDeal";
               string dir = defDir + @"\" + taskN + @"\" + fname + ".vbs";
               cat = new Category();
               cat.tags = tags;
               cat.task = taskN;               
               int countF = 0;
               if (!Directory.Exists(defDir + taskN))
                   Directory.CreateDirectory(defDir + taskN);   
               while(File.Exists(dir))
               {
                   DialogResult result2 = MessageBox.Show("The file:\n" + dir + "\nallready exists,overwrite or make a copy?\nNo for new copy Yes to overwrite", "Overwrite file?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                   if (result2 == DialogResult.No)
                   {
                       dir = defDir + @"\" + taskN + @"\" + fname + countF.ToString() + ".vbs";
                       countF++;
                   }
                   else if ((result2 == DialogResult.Yes))
                       break;
                   else
                       return;
               }
               numericUpDown1.Value = 0;
               createVBS(dir);
               cat.xmlPath = dir;
               for (int i = 1; i < 100;i++ )
               {
                   if(XMLS[i].Length>0)
                   {
                       dir = defDir + @"\" + taskN + @"\" + fname + i + ".vbs";
                       while(File.Exists(dir))
                           dir = defDir + @"\" + taskN + @"\" + fname + (i+1).ToString() + ".vbs";
                       numericUpDown1.Value = i;
                       createVBS(dir);
                       cat.xmlPath += "|" + dir;
                   }
               }               
               cat.testPlan = "";        
               cat.profile = "shva";
               CategoryList.InsertCategory(cat);
               MessageBox.Show("Successfully added to the DB");
        }
        public void reset_Click(object sender, EventArgs e)
        {
            XMLD.Text = "";
            for (int i = 0; i < 100; i++)
                XMLS[i] = "";
            numericUpDown1.Value = 0;
        }
        public void options_Click(object sender, EventArgs e)
        {
            Options getX = new Options();
            getX.Location = new Point(this.Location.X + 260, this.Location.Y + 100);
            string te = Application.OpenForms.OfType<Options>().Count().ToString();
            if (Application.OpenForms.OfType<Options>().Count() == 1)
            {
                Application.OpenForms.OfType<Options>().First().Close();
            }
            else
            {
                getX.BackColor = this.BackColor;
                getX.Show();
            }
        }
        public void intToServer(string intI)
        {
            String result = "";
            String poststring = "user=" + user.Text +
                                  "&password=" + password.Text +
                                  "&int_in=" + intI;
            StreamWriter myWriter = null;

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(server.Text);
            objRequest.Method = "POST";
            objRequest.ContentLength = poststring.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(poststring);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr =
               new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();

                sr.Close();
            }
            MessageBox.Show(result);
        }

        private void sanityB_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<sanity>().Count() == 1)
            {
                MessageBox.Show("A test is already running.");
                return;
            }

            string serverS="";
            string j4;
            string invTranId="";
            string log = "";
            string tlog="";
            sanity san = new sanity();
            san.BackColor = this.BackColor;
            san.Show();
            Thread backgroundThread = new Thread(
    new ThreadStart(() =>
    {
        if (server.InvokeRequired)
        {
            server.Invoke(new MethodInvoker(delegate { serverS = server.Text; }));
            
        }
        //Add custom Checks
        string[] lineOfContents = File.ReadAllLines(defDir + @"\sanityTests.txt");
        int count = 0;
        int tmp = lineOfContents.ToString().Length;
        string[,] tests = new string[tmp, 2];
        foreach (var line in lineOfContents)
        {                        
            if(line.Length>0)
            {
              string[] tokens = line.Split('|');
              if (tokens[1] == "1")
              {
                  tests[count, 0] = tokens[0];
                  tests[count, 1] = tokens[2];                      
                      Label txt = new Label();
                      txt.Font = new Font(san.invoiceL.Font.Name, san.invoiceL.Font.Size);
                      PictureBox tst = new PictureBox();
                      tst.Image = XMI.Properties.Resources.LIM_ContentProcAni_Final_Transparent_BG;
                      tst.Width = 33;
                      tst.Height = 34;
                      txt.AutoSize = true;
                      tst.Top = san.invoice.Top + (count+1)*50;
                      tst.Left = san.invoice.Left;
                      txt.Text = txt.Name = tests[count, 0] + "L";
                      tst.Name = "IMAGE" + tests[count, 0];
                      txt.Top = san.invoiceL.Top + (count+1)*50;
                      txt.Left = san.invoiceL.Left;
                      san.panel1.BeginInvoke(new Action(() => san.panel1.Controls.Add(tst)));
                      san.panel1.BeginInvoke(new Action(() => san.panel1.Controls.Add(txt)));
                      san.panel1.BeginInvoke(new Action(() => san.panel1.Update()));
                      count++;
                               }
                        }
                    }
    
        //san.panel1.BeginInvoke(new Action(() =>((Label)san.panel1.Controls.Find("txt", true)[0]).Text = "try"));
        string output = "";
        string xmlToSend = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanJ102.xml", Encoding.GetEncoding("UTF-8"));        
         string tempR = reqS(xmlToSend, "cardId", serverS,ref tlog);
         if (san.IsDisposed)
             return;
         try { 
        if(tempR.Substring(0, 2) == "Un")
        {            
            MessageBox.Show("Timed out,please make sure the server is up and the address is valid");
            san.BeginInvoke(new Action(() => san.Close()));
            Thread.CurrentThread.Abort();
            return;
        }  
         if (tempR.Substring(0, 2) == "Th")
         {
             san.J102.BeginInvoke(new Action(() => san.J102.Image = XMI.Properties.Resources.errorS));
             san.J102.BeginInvoke(new Action(() => san.J102L.Text = "J102 - status: " + tempR)); //.Substring(tempR.Length - 3, 3)
             output += "The tokenisation transaction has failed due to code: " + tempR + "\n"; //.Substring(tempR.Length - 3, 3)
         }
         else
         {
             san.J102.BeginInvoke(new Action(() => san.J102.Image = XMI.Properties.Resources.Farm_Fresh_accept));
             san.J102.BeginInvoke(new Action(() => san.J102L.Text = "J102 - cardId: " + tempR));
             output += "The tokenization transaction was successfull,and received the following token: " + tempR + "\n";
         }
         log += "J102:" + Environment.NewLine + tlog + Environment.NewLine +Environment.NewLine +Environment.NewLine;
        //Do the first j4
         xmlToSend = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanJ4.xml", Encoding.GetEncoding("UTF-8"));
         xmlToSend = xmlToSend.Replace("@cardId@", tagSearch(tlog, "cardId"));
         tempR = reqS(xmlToSend, "tranId", serverS,ref tlog);
         if (san.IsDisposed)
             return;
         if (tempR.Substring(0, 2) == "Th")
         {
             san.J41.BeginInvoke(new Action(() => san.J41.Image = XMI.Properties.Resources.errorS));
             san.J41.BeginInvoke(new Action(() => san.J41L.Text = "J4 - status: " + tempR)); //.Substring(tempR.Length - 3, 3)
             output += "The J4 transactions has failed due to code: " + tempR + "\n"; //.Substring(tempR.Length - 3, 3)
         }
         else
         {
             output += "The J4 transaction proccessed successfully and received the id of: " + tempR + "\n";
             san.J41.BeginInvoke(new Action(() => san.J41.Image = XMI.Properties.Resources.Farm_Fresh_accept));
             san.J41.BeginInvoke(new Action(() => san.J41L.Text = "J4 - tranId: " + tempR));
         }
         log += "J4:" + Environment.NewLine + tlog + Environment.NewLine +Environment.NewLine;
         //Transmit the terminal
             xmlToSend = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanTransmit.xml", Encoding.GetEncoding("UTF-8"));
             string transmit = reqS(xmlToSend, "transmitId", serverS, ref tlog);
             if (san.IsDisposed)
                 return;
             if (transmit.Substring(0, 2) == "Th")
             {
                 output += "The transmittion attempt has failed due to code: " + transmit + "\n"; //.Substring(tempR.Length - 3, 3)
                 san.transmit.BeginInvoke(new Action(() => san.transmit.Image = XMI.Properties.Resources.errorS));
                 san.transmit.BeginInvoke(new Action(() => san.transmitL.Text = "transmit - status: " + transmit)); //.Substring(tempR.Length - 3, 3)
             }
             else
             {
                 output += "The terminal has transmitted successfully, with the transmit id " + transmit + "\n";
                 san.transmit.BeginInvoke(new Action(() => san.transmit.Image = XMI.Properties.Resources.Farm_Fresh_accept));
                 san.transmit.BeginInvoke(new Action(() => san.transmitL.Text = "transmit - ID: " + transmit));
             }
             log += "Transmit terminal:" + Environment.NewLine + tlog + Environment.NewLine + Environment.NewLine;
         //Refund our transaction if successfully transmitted
         xmlToSend = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanRefund.xml", Encoding.GetEncoding("UTF-8"));
         xmlToSend = xmlToSend.Replace("@tranId@", tempR);
         tempR = reqS(xmlToSend, "tranId", serverS,ref tlog);
         if (san.IsDisposed)
             return;
         if (tempR.Substring(0, 2) == "Th")
         {
             output += "The refund has failed due to code: " + tempR + "\n"; //.Substring(tempR.Length - 3, 3)
             san.refund.BeginInvoke(new Action(() => san.refund.Image = XMI.Properties.Resources.errorS));
             san.refund.BeginInvoke(new Action(() => san.refundL.Text = "refundDeal - status: " + tempR)); //.Substring(tempR.Length - 3, 3)
             j4 = "";
         }
         else
         {
             j4 = tempR;
             output += "The refund has been proccessed successfull and received the id of: " + tempR + "\n";
             san.refund.BeginInvoke(new Action(() => san.refund.Image = XMI.Properties.Resources.Farm_Fresh_accept));
             san.refund.BeginInvoke(new Action(() => san.refundL.Text = "refundDeal - tranId: " + tempR));
         }
         log += "Refund:" + Environment.NewLine + tlog + Environment.NewLine +Environment.NewLine;
        //cancel our refund
         xmlToSend = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanCancel.xml", Encoding.GetEncoding("UTF-8"));
         xmlToSend = xmlToSend.Replace("@tranId@",tagSearch(tlog, "tranId"));
         tempR = reqS(xmlToSend, "tranId", serverS,ref tlog);
        if (san.IsDisposed)
            return;
        if (tempR.Substring(0, 2) == "Th")
        {
            output += "The cancel attempt has failed due to code: " + tempR + "\n"; //.Substring(tempR.Length - 3, 3)
            san.cancelD.BeginInvoke(new Action(() => san.cancelD.Image = XMI.Properties.Resources.errorS));
            san.cancelD.BeginInvoke(new Action(() => san.cancelDL.Text = "cancelDeal - status: " + tempR)); //.Substring(tempR.Length - 3, 3)
        }
        else
        {
            output += "The transaction was canceled successfully, with the cancel transaction: " + tempR + "\n";
            san.cancelD.BeginInvoke(new Action(() => san.cancelD.Image = XMI.Properties.Resources.Farm_Fresh_accept));
            san.cancelD.BeginInvoke(new Action(() => san.cancelDL.Text = "cancelDeal - tranId: " + tempR));
        }
        log += "Cancel:" + Environment.NewLine + tlog + Environment.NewLine +Environment.NewLine;
        //inquireTransaction
        xmlToSend = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanInquire.xml", Encoding.GetEncoding("UTF-8"));
        xmlToSend = xmlToSend.Replace("@tranId@", tagSearch(tlog, "tranId"));
        tempR = reqS(xmlToSend, "tranId", serverS,ref tlog);
        if (san.IsDisposed)
            return;
        if (tempR.Substring(0, 2) == "Th")
        {
            output += "The inquire attempt has failed due to code: " + tempR + "\n"; //.Substring(tempR.Length - 3, 3)
            san.inquire.BeginInvoke(new Action(() => san.inquire.Image = XMI.Properties.Resources.errorS));
            san.inquire.BeginInvoke(new Action(() => san.inquireL.Text = "Inquire - status: " + tempR)); //.Substring(tempR.Length - 3, 3)
        }
        else
        {
            output += "The inquire was proccessed sucessfully with the id of: " + tempR + "\n";
            san.inquire.BeginInvoke(new Action(() => san.inquire.Image = XMI.Properties.Resources.Farm_Fresh_accept));
            san.inquire.BeginInvoke(new Action(() => san.inquireL.Text = "Inquire - tranId: " + tempR));
        }
        log += "Inquire:" + Environment.NewLine + tlog + Environment.NewLine +Environment.NewLine;
        //Tamal
        xmlToSend = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanTamal.xml", Encoding.GetEncoding("UTF-8"));
        xmlToSend = xmlToSend.Replace("@date@", DateTime.Now.ToString("yyyy-MM-dd"));
        tempR = reqS2(xmlToSend, "invoiceDocUrl", "tranId", ref invTranId, serverS,ref tlog);
        if (tempR == "")
            tempR = tagSearch(tlog, "invoiceResponseName");
            //tempR = tagSearch(XMLD.Text, "invoiceResponseName");
            //tempR = reqS(xmlToSend, "invoiceResponseName", serverS,ref tlog);   
        if (tempR == "")
            tempR = "No Invoice support on terminal/server";
         if (san.IsDisposed)
             return;
         if (tempR.Substring(0, 2) != "ht")
         {
             san.tamal.BeginInvoke(new Action(() => san.tamal.Image = XMI.Properties.Resources.errorS));
             san.tamal.BeginInvoke(new Action(() => san.tamalL.Text = "tamal - Failed: " + tempR));
             output += "The tamal invoice production has failed due to: " + tempR + "\n";
         }
         else
         {
             san.tamal.BeginInvoke(new Action(() => san.tamal.Image = XMI.Properties.Resources.Farm_Fresh_accept));
             san.tamal.BeginInvoke(new Action(() => san.tamL = tempR));
             san.tamal.BeginInvoke(new Action(() => san.tamalL.Text = "tamal tran - " + invTranId));
             output += "The tamal invoice was produced successfully(click the link to get the produced invoice\n";
         }
         log += "Tamal:" + Environment.NewLine + tlog + Environment.NewLine +Environment.NewLine;
        //Invoice
         xmlToSend = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanInvoice.xml", Encoding.GetEncoding("UTF-8"));
         xmlToSend = xmlToSend.Replace("@date@", DateTime.Now.ToString("yyyy-MM-dd"));
         tempR = reqS2(xmlToSend, "invoiceDocUrl","tranId",ref invTranId, serverS,ref tlog);
        if(tempR == "")
            tempR = tagSearch(tlog, "invoiceResponseName");
        if (tempR == "")
            tempR = "No support for invoice on this terminal/server";
            //tempR = tagSearch(XMLD.Text, "invoiceResponseName");
            //tempR = reqS(xmlToSend, "invoiceResponseName", serverS,ref tlog);         
         if (san.IsDisposed)
             return;
         if (tempR.Substring(0, 2) != "ht")
         {
             san.invoice.BeginInvoke(new Action(() => san.invoice.Image = XMI.Properties.Resources.errorS));
             san.invoice.BeginInvoke(new Action(() => san.invoiceL.Text = "invoice - Failed: " + tempR));
             output += "The invoice4u invoice production has failed due to: " + tempR + "\n";
         }
         else
         {
             san.invoice.BeginInvoke(new Action(() => san.invoice.Image = XMI.Properties.Resources.Farm_Fresh_accept));
             san.invoice.BeginInvoke(new Action(() => san.invL = tempR));
             san.invoice.BeginInvoke(new Action(() => san.invoiceL.Text = "invoice4u tran - " + invTranId));
             output += "The invoice4u invoice was produced successfully(click the link to get the produced invoice\n";
         }
         log += "Invoice:" + Environment.NewLine + tlog + Environment.NewLine +Environment.NewLine;    
  
             //Start custom checks
             for(int i=0;i<count;i++)
             {
                this.BeginInvoke(new Action(() => reset_Click(null, null)));
                 string tmpX="";
                 this.BeginInvoke(new Action(() => tmpX= server.Text));
                 string tmpX2="";
                 this.BeginInvoke(new Action(() => tmpX2= user.Text));
                 string tmpX3 = "";
                 this.BeginInvoke(new Action(() => tmpX3=password.Text));
                 this.BeginInvoke(new Action(() => loadXML(tests[i, 1])));
                 this.BeginInvoke(new Action(() => server.Text = tmpX));
                 this.BeginInvoke(new Action(() => user.Text = tmpX2));
                 this.BeginInvoke(new Action(() => password.Text = tmpX3));
                 this.BeginInvoke(new Action(() => xmlToSend = XMLD.Text));
                 this.BeginInvoke(new Action(() => reset_Click(null, null)));
                 /*xmlToSend = System.IO.File.ReadAllText(tests[i,1], Encoding.GetEncoding("UTF-8"));
                 xmlToSend = "<ashrait>" + GetStringBetween(xmlToSend,"<ashrait>", "</ashrait>") + "</ashrait>";
                 //Add replace tags function to handle special requests.
                 xmlToSend = xmlToSend.Replace("@cardId@", tagSearch(tlog, "cardId"));*/
                 tempR = reqS(xmlToSend, "tranId", serverS, ref tlog);
                 if (san.IsDisposed)
                     return;
                 if (tempR.Substring(0, 2) == "Th")
                 {
                     foreach (object p in this.Controls)
                     {
                         if (p.GetType() == typeof(PictureBox))
                             if (((PictureBox)p).Name == "IMAGE" + tests[i, 0])
                                 san.J41.BeginInvoke(new Action(() => ((PictureBox)p).Image = XMI.Properties.Resources.errorS));
                     }
                     san.BeginInvoke(new Action(() => san.panel1.Controls.Find(tests[i, 0] + "L", true)[0].Text = tests[i, 0] + " - status: " + tempR));
                     output += "The J4 transactions has failed due to code: " + tempR + "\n";
                     //san.panel1.Update();
                 }
                 else
                 {
                     output += "The transaction proccessed successfully and received the id of: " + tempR + "\n";
                     foreach (object p in san.panel1.Controls)
                     {
                         if (p.GetType() == typeof(PictureBox))
                             if (((PictureBox)p).Name == "IMAGE" + tests[i, 0])
                                 san.J41.BeginInvoke(new Action(() => ((PictureBox)p).Image = XMI.Properties.Resources.Farm_Fresh_accept));
                     }
                     san.BeginInvoke(new Action(() => san.panel1.Controls.Find(tests[i, 0] + "L", true)[0].Text = tests[i, 0] + " - tranId: " + tempR));
                     //san.panel1.Update();
                 }
                 log += "J4:" + Environment.NewLine + tlog + Environment.NewLine + Environment.NewLine;
             }



         DialogResult ask = MessageBox.Show("Would you like to watch the log?", "Review log?",
MessageBoxButtons.YesNo);
         if (ask == DialogResult.Yes)
         {
             string dir = defDir + "log.txt";
             StreamWriter sw;
             sw = File.CreateText(dir);
             sw.Write(log);
             sw.Close();
             System.Diagnostics.Process.Start(dir);
         }
         }
         catch (Exception te)
         {
             MessageBox.Show("Exception caught: " + te);
         }
    }
));
            backgroundThread.Start();
        }
        private void loadXMLB_Click(object sender, EventArgs e)
        {
             OpenFileDialog stdp = new OpenFileDialog();
             if (stdp.ShowDialog() == DialogResult.OK)
             {
                 loadXML(stdp.FileName);
                 //organizeXML();
             }
        }

        private void dBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(defDir + "\\XML\\Category.xml"))
            {
                MessageBox.Show("Cant access:\n" + defDir + "\\XML\\Category.xml" + "\nPlease make sure you have the proper premission and that the file is named correctly.");
                return;
            } 
            if(panel1.Visible == false)
                panel1.Visible = true;
            else
                panel1.Visible = false;
        }

        public void changeFave(object sender, MouseEventArgs e)
        {
            string val=((Button)sender).Tag.ToString();
            string nam = ((Button)sender).Text;
            if (e.Button == MouseButtons.Left)
            {          
                setButton(val,nam);
            }
            if (e.Button == MouseButtons.Right)
            {
                if (val.Length < 1)
                    return;
                DialogResult ask = MessageBox.Show("Would you like to reset the button?", "Delete Button?",
MessageBoxButtons.YesNo);
                if (ask == DialogResult.Yes)
                {
                    FileStream rfile = new FileStream(Application.StartupPath+@"\DB.xml", FileMode.Open);
                    XmlDocument tdoc = new XmlDocument();
                    tdoc.Load(rfile);
                    XmlNodeList list = tdoc.GetElementsByTagName("Button");
                    for (int i = 0; i < list.Count; i++)
                    {
                        XmlElement cl = (XmlElement)tdoc.GetElementsByTagName("Button")[i];
                        if (cl.GetAttribute("Name") == nam)
                        {
                            tdoc.DocumentElement.RemoveChild(cl);
                        }
                    }
                    rfile.Close();
                    tdoc.Save(Application.StartupPath+@"\DB.xml");
                    //MessageBox.Show(val);
                   // Properties.Settings.Default.Buttons.Remove(nam + '|' + val);
                    //Properties.Settings.Default.Save();
                    //Properties.Settings.Default.Upgrade();
                    //MessageBox.Show(Properties.Settings.Default.Buttons[0]);
                    updateButtons();
                    /*UpdateSetting(((Button)sender).Name, "");
                    UpdateSetting(((Button)sender).Name + "L", "");
                    ((Button)sender).Text = "";*/
                }
            }
            else return;
        }

        private void int_in_Click(object sender, EventArgs e)
        {
            string dir = defDir;
            string path = Path.Combine(dir, "testCards.txt");
            if (!File.Exists(path))
            {
                MessageBox.Show("Missing testCards file from the default directory");
                return;
            }
            textW getX = new textW();
            getX.Location = new Point(this.Location.X + 260, this.Location.Y + 100);
            string te = Application.OpenForms.OfType<textW>().Count().ToString();
            if (Application.OpenForms.OfType<textW>().Count() == 1)
            {
                Application.OpenForms.OfType<textW>().First().Close();
            }
            else
            {
                getX.box.Text = System.IO.File.ReadAllText(path,Encoding.GetEncoding("ISO-8859-8"));
                getX.BackColor = this.BackColor;
                getX.Show();
            }
        }
        private static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            //AppSettingsSection appSettings = configuration.AppSettings;
            //appSettings.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToLocalUser;
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");            
        }

        public void setButton(string val,string nam)
        {
            if(val.Length<1)
            {
                OpenFileDialog stdp = new OpenFileDialog();
                //if (stdp.ShowDialog() == DialogResult.OK && stdp.FileName.Substring(stdp.FileName.Length - 3, 3) == "xml")
                if (stdp.ShowDialog() == DialogResult.OK && stdp.FileName.Length > 0)
                {
                    val = stdp.FileName;
                    string input = "button";
                    ShowInputDialog(ref input, "Enter a name for the button:");
                    XmlDocument xd = new XmlDocument();
                    FileStream lfile = new FileStream(Path.Combine(Application.StartupPath+@"\DB.xml"), FileMode.Open);
                    xd.Load(lfile);
                    XmlElement cl = xd.CreateElement("Button");
                    cl.SetAttribute("Name",input);
                    XmlElement na = xd.CreateElement("Value");
                    XmlText natext = xd.CreateTextNode(val);
                    na.AppendChild(natext);
                    cl.AppendChild(na);
                    xd.DocumentElement.AppendChild(cl);
                    lfile.Close();
                    xd.Save(Path.Combine(Application.StartupPath+@"\DB.xml"));
                    /*Properties.Settings.Default.Buttons.Add(input + '|' + val);
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Upgrade();*/
                    updateButtons();
                    //UpdateSetting(buttonI + "L", buttonL);
                    //UpdateSetting(buttonI, input);
                    //loadXML(buttonL);
                }
            }
            else if(val[0]!='$')
            {
                string[] temp = { server.Text, user.Text, password.Text };
                loadXML(val);
                server.Text = temp[0];
                user.Text = temp[1];
                password.Text = temp[2];
                if (!XMLD.Text.Contains("mid"))
                    return;
                string[] lineOfContents = File.ReadAllLines(defDir + @"\servers.txt");
                foreach (var line in lineOfContents)
                {
                    if (line.Contains(server.Text) && line.Contains('|'))
                    {
                        string tmid = line.Substring(line.IndexOf('|') + 1);
                        string matchCodeTag = @"\<mid\>(.*?)\</mid\>";
                        string replaceWith = "<mid>"+ tmid + "</mid>";
                        XMLD.Text = Regex.Replace(XMLD.Text, matchCodeTag, replaceWith);
                        break;
                    }
                }
            }
            else
            {
                switch (val)
                {
                    case "$J4Inquire$":
                        J4Inquire();
                        break;
                    case "$InquireMPI$":
                        inquireMPI();
                        break;
                    case "$J4Cancel$":
                        J4Cancel();
                        break;
                    case "$J4Refund$":
                        J4Refund();
                        break;
                    case "$addInv$":
                        addInv();
                        break;
                    case "$cardIdJ4$":
                        cardIdJ4();
                        break;
                    case "$refundInv$":
                        refundInv();
                        break;
                    case "$J9J109$":
                        J9J109();
                        break;
                    case "$transmitInq$":
                        transmitInq();
                        break;
                    case "$shiftTrans$":
                        shiftTrans();
                        break;
                    case "$cardNo$":
                        cardNo();
                        break;
                }
            }
        }

        /*public void setButton(string buttonI,string buttonL)
        {
            if(buttonL=="")
            {
             OpenFileDialog stdp = new OpenFileDialog();
                 //if (stdp.ShowDialog() == DialogResult.OK && stdp.FileName.Substring(stdp.FileName.Length - 3, 3) == "xml")
                 if (stdp.ShowDialog() == DialogResult.OK && stdp.FileName.Length>0)
                 {
                     buttonL = stdp.FileName;
                     string input = "button";
                     ShowInputDialog(ref input, "Enter a name for the button:");
                     UpdateSetting(buttonI + "L", buttonL);
                     UpdateSetting(buttonI, input);
                     loadXML(buttonL);
                 }                    
           }else
            {
                string[] temp = {server.Text,user.Text,password.Text};
                loadXML(buttonL);
                server.Text = temp[0];
                user.Text = temp[1];
                password.Text = temp[2];
            }
                
            updateButtons();
        }*/
     
        public class HighlightColors
        {
            public static Color HC_NODE = Color.Firebrick;
            public static Color HC_STRING = Color.Blue;
            public static Color HC_ATTRIBUTE = Color.Red;
            public static Color HC_COMMENT = Color.GreenYellow;
            public static Color HC_INNERTEXT = Color.Blue;
        }
        public Color colorCh(string check)
        {
            string result=check.Replace("<","");
            result = result.Replace(">", "");
            result = result.Replace("/", "");
            result=result.ToLowerInvariant();
            switch(result)
            {
                case "cardno":
                    return Color.Red;
                case "mid":
                    return Color.Green;
                case "total":
                    return Color.Olive;
                case "validation":
                    return Color.Indigo;
                case "mpivalidation":
                    return Color.Orange;
                case "authnumber":
                    return Color.Navy;
                case "terminal":
                    return Color.BlueViolet;
                case "cardid":
                    return Color.LightSalmon;
                case "result":
                    return Color.SteelBlue;
                case "<tranid":
                    return Color.Gold;
                case "totalmatch":
                    return Color.LightGray;
                case "shiftid1":
                    return Color.SeaGreen;
                case "shiftid2":
                    return Color.DarkKhaki;
                case "shiftid3":
                    return Color.Crimson;
                case "invoicedocurl":
                    return Color.BurlyWood;
                case "invoicecreationcode":
                    return Color.OrangeRed;
                case "shifttxndate":
                    return Color.Peru;
                case "shiftstartdate":
                    return Color.MediumSlateBlue;
                case "shiftenddate":
                    return Color.DodgerBlue;
                case "mpihostedpageUrl":
                    return Color.Goldenrod;
                case "token":
                    return Color.Sienna;
                case "invoicedocnumber":
                    return Color.LightSalmon;
            }
            return Color.Black;
        }
        public static void HighlightRTF(RichTextBox rtb)
        {
            int k = 0;

            string str = rtb.Text;

            int st, en;
            int lasten = -1;
            while (k < str.Length)
            {
                st = str.IndexOf('<', k);

                if (st < 0)
                    break;

                if (lasten > 0)
                {
                    rtb.Select(lasten + 1, st - lasten - 1);
                    rtb.SelectionColor = HighlightColors.HC_INNERTEXT;
                }

                en = str.IndexOf('>', st + 1);
                if (en < 0)
                    break;

                k = en + 1;
                lasten = en;

                if (str[st + 1] == '!')
                {
                    rtb.Select(st + 1, en - st - 1);
                    rtb.SelectionColor = HighlightColors.HC_COMMENT;
                    continue;

                }
                String nodeText = str.Substring(st + 1, en - st - 1);


                bool inString = false;

                int lastSt = -1;
                int state = 0;
                /* 0 = before node name
                 * 1 = in node name
                   2 = after node name
                   3 = in attribute
                   4 = in string
                   */
                int startNodeName = 0, startAtt = 0;
                for (int i = 0; i < nodeText.Length; ++i)
                {
                    if (nodeText[i] == '"')
                        inString = !inString;

                    if (inString && nodeText[i] == '"')
                        lastSt = i;
                    else
                        if (nodeText[i] == '"')
                        {
                            rtb.Select(lastSt + st + 2, i - lastSt - 1);
                            rtb.SelectionColor = HighlightColors.HC_STRING;
                        }

                    switch (state)
                    {
                        case 0:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startNodeName = i;
                                state = 1;
                            }
                            break;
                        case 1:
                            if (Char.IsWhiteSpace(nodeText, i))
                            {
                                rtb.Select(startNodeName + st, i - startNodeName + 1);
                                rtb.SelectionColor = HighlightColors.HC_NODE;
                                state = 2;
                            }
                            break;
                        case 2:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startAtt = i;
                                state = 3;
                            }
                            break;

                        case 3:
                            if (Char.IsWhiteSpace(nodeText, i) || nodeText[i] == '=')
                            {
                                rtb.Select(startAtt + st, i - startAtt + 1);
                                rtb.SelectionColor = HighlightColors.HC_ATTRIBUTE;
                                state = 4;
                            }
                            break;
                        case 4:
                            if (nodeText[i] == '"' && !inString)
                                state = 2;
                            break;


                    }

                }
                if (state == 1)
                {
                    rtb.Select(st + 1, nodeText.Length);
                    rtb.SelectionColor = HighlightColors.HC_NODE;
                }                
            }
        }
        public void colorTags(RichTextBox rtb)
        {
            //string[] checks = {"<cardNo>","</cardNo>","validation","mpiValidation","authNumber","mid","terminal","cardId","result","tranId","totalMatch","shiftId1","shiftId2","shiftId3","invoiceDocUrl","invoiceCreationCode","shiftTxnDate","shiftStartDate","shiftEndDate","mpiHostedPageUrl","token"};
            string[] checks = {"<tranId>","/tranId>","<cardNo>","</cardNo>", "validation", "mpiValidation", "authNumber", "mid", "terminal", "cardId", "result", "totalMatch", "shiftId1", "shiftId2", "shiftId3", "invoiceDocUrl", "invoiceCreationCode", "shiftTxnDate", "shiftStartDate", "shiftEndDate", "mpiHostedPageUrl", "token","invoiceDocNumber"};
            for (int i = 0; i < checks.Length;i++ )
            {
                int first = rtb.Text.IndexOf(checks[i]);
                while (first > -1)
                {
                    int start = first - 2;
                    start = rtb.Text.IndexOf("<",start);
                    //int start = rtb.Text.IndexOf(checks[i])-1;
                    int end = rtb.Text.IndexOf(">", start)+1;
                    rtb.Select(start, end - start);
                    rtb.SelectionColor = colorCh(checks[i]);
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
                    rtb.SelectionStart = rtb.SelectionStart + rtb.SelectionLength;
                    rtb.SelectionLength = 0;
                    rtb.SelectionFont = rtb.Font;
                    first = rtb.Text.IndexOf(checks[i],first+2);
                }
            }

        }
        public void organizeXML(RichTextBox rtb)
        {
            if (rtb.Text.Length < 1 || rtb.Text[0] != '<')
                return;
            if(rtb.Text.Contains('&'))
            {
                rtb.Text = rtb.Text.Replace("&", "XMIAP");
            }
            try
            {
                XDocument xDocument = XDocument.Parse(rtb.Text);
                rtb.Text = xDocument.ToString();
                if (rtb.Text.Contains("XMIAP"))
                {
                    rtb.Text = rtb.Text.Replace("XMIAP", "&");
                }
                colorTags(rtb);
            }
            catch (Exception e1)
            {
                MessageBox.Show("Invalid XML format, please check for mistakes\n" + e1.ToString());
                //MessageBox.Show(e1.ToString());
            }
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            organizeXML(XMLD);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (((UpDownBase)sender).Text=="")
            {
                reset_Click(null, null);
                numericUpDown1.Value = 0;
                return;
            }
            XMLS[Convert.ToInt32( ((UpDownBase)sender).Text)]=XMLD.Text;
            XMLD.Text = XMLS[(int)numericUpDown1.Value];
        }
        public class RibbonColor
        {

            #region Constructors
            public RibbonColor(Color color)
            {
                rc = color.R;
                gc = color.G;
                bc = color.B;
                ac = color.A;

                HSV();
            }

            public RibbonColor(uint alpha, int hue, int saturation, int brightness)
            {
                hc = hue;
                sc = saturation;
                vc = brightness;
                ac = alpha;

                GetColor();
            }
            #endregion

            #region Alpha
            private uint ac = 0; //Alpha > -1
            public uint AC { get { return ac; } set { System.Math.Min(value, 255); } }
            #endregion

            #region RGB
            private int rc = 0, gc = 0, bc = 0; //RGB Components > -1 

            public int RC { get { return rc; } set { rc = System.Math.Min(value, 255); } }
            public int GC { get { return gc; } set { gc = System.Math.Min(value, 255); } }
            public int BC { get { return bc; } set { bc = System.Math.Min(value, 255); } }


            public Color GetColor()
            {

                int conv;
                double hue, sat, val;
                int basis;

                hue = (float)hc / 100.0f;
                sat = (float)sc / 100.0f;
                val = (float)vc / 100.0f;

                if ((float)sc == 0) // Gray Colors
                {
                    conv = (int)(255.0f * val);
                    rc = gc = bc = conv;
                    return Color.FromArgb((int)rc, (int)gc, (int)bc);
                }

                basis = (int)(255.0f * (1.0 - sat) * val);

                switch ((int)((float)hc / 60.0f))
                {
                    case 0:
                        rc = (int)(255.0f * val);
                        gc = (int)((255.0f * val - basis) * (hc / 60.0f) + basis);
                        bc = (int)basis;
                        break;

                    case 1:
                        rc = (int)((255.0f * val - basis) * (1.0f - ((hc % 60) / 60.0f)) + basis);
                        gc = (int)(255.0f * val);
                        bc = (int)basis;
                        break;

                    case 2:
                        rc = (int)basis;
                        gc = (int)(255.0f * val);
                        bc = (int)((255.0f * val - basis) * ((hc % 60) / 60.0f) + basis);
                        break;

                    case 3:
                        rc = (int)basis;
                        gc = (int)((255.0f * val - basis) * (1.0f - ((hc % 60) / 60.0f)) + basis);
                        bc = (int)(255.0f * val);
                        break;

                    case 4:
                        rc = (int)((255.0f * val - basis) * ((hc % 60) / 60.0f) + basis);
                        gc = (int)basis;
                        bc = (int)(255.0f * val);
                        break;

                    case 5:
                        rc = (int)(255.0f * val);
                        gc = (int)basis;
                        bc = (int)((255.0f * val - basis) * (1.0f - ((hc % 60) / 60.0f)) + basis);
                        break;
                }
                return Color.FromArgb((int)ac, (int)rc, (int)gc, (int)bc);

            }

            public uint GetRed()
            {
                return GetColor().R;
            }

            public uint GetGreen()
            {
                return GetColor().G;
            }

            public uint GetBlue()
            {
                return GetColor().B;
            }

            #endregion

            #region HSV

            private int hc = 0, sc = 0, vc = 0;

            public float HC { get { return hc; } set { hc = (int)System.Math.Min(value, 359); hc = (int)System.Math.Max(hc, 0); } }
            public float SC { get { return sc; } set { sc = (int)System.Math.Min(value, 100); sc = (int)System.Math.Max(sc, 0); } }
            public float VC { get { return vc; } set { vc = (int)System.Math.Min(value, 100); vc = (int)System.Math.Max(vc, 0); } }

            public enum C { Red, Green, Blue, None }
            private int maxval = 0, minval = 0;
            private C CompMax, CompMin;

            private void HSV()
            {
                hc = this.GetHue();
                sc = this.GetSaturation();
                vc = this.GetBrightness();
            }

            public void CMax()
            {
                if (rc > gc)
                {
                    if (rc < bc) { maxval = bc; CompMax = C.Blue; }
                    else { maxval = rc; CompMax = C.Red; }
                }
                else
                {
                    if (gc < bc) { maxval = bc; CompMax = C.Blue; }
                    else { maxval = gc; CompMax = C.Green; }
                }
            }

            public void CMin()
            {
                if (rc < gc)
                {
                    if (rc > bc) { minval = bc; CompMin = C.Blue; }
                    else { minval = rc; CompMin = C.Red; }
                }
                else
                {
                    if (gc > bc) { minval = bc; CompMin = C.Blue; }
                    else { minval = gc; CompMin = C.Green; }
                }

            }

            public int GetBrightness()  //Brightness is from 0 to 100
            {
                CMax(); return 100 * maxval / 255;
            }

            public int GetSaturation() //Saturation from 0 to 100
            {
                CMax(); CMin();
                if (CompMax == C.None)
                    return 0;
                else if (maxval != minval)
                {
                    Decimal d_sat = Decimal.Divide(minval, maxval);
                    d_sat = Decimal.Subtract(1, d_sat);
                    d_sat = Decimal.Multiply(d_sat, 100);
                    return Convert.ToUInt16(d_sat);
                }
                else
                {
                    return 0;
                }

            }

            public int GetHue()
            {
                CMax(); CMin();

                if (maxval == minval)
                {
                    return 0;
                }
                else if (CompMax == C.Red)
                {
                    if (gc >= bc)
                    {
                        Decimal d1 = Decimal.Divide((gc - bc), (maxval - minval));
                        return Convert.ToUInt16(60 * d1);
                    }
                    else
                    {
                        Decimal d1 = Decimal.Divide((bc - gc), (maxval - minval));
                        d1 = 60 * d1;
                        return Convert.ToUInt16(360 - d1);
                    }
                }
                else if (CompMax == C.Green)
                {
                    if (bc >= rc)
                    {
                        Decimal d1 = Decimal.Divide((bc - rc), (maxval - minval));
                        d1 = 60 * d1;
                        return Convert.ToUInt16(120 + d1);
                    }
                    else
                    {
                        Decimal d1 = Decimal.Divide((rc - bc), (maxval - minval));
                        d1 = 60 * d1;
                        return Convert.ToUInt16(120 - d1);
                    }


                }
                else if (CompMax == C.Blue)
                {
                    if (rc >= gc)
                    {
                        Decimal d1 = Decimal.Divide((rc - gc), (maxval - minval));
                        d1 = 60 * d1;
                        return Convert.ToUInt16(240 + d1);
                    }
                    else
                    {
                        Decimal d1 = Decimal.Divide((gc - rc), (maxval - minval));
                        d1 = 60 * d1;
                        return Convert.ToUInt16(240 - d1);
                    }
                }
                else
                {
                    return 0;
                }
            }  //Hue from 0 to 100

            #endregion

            #region Methods

            public bool IsDark()
            {
                if (BC > 50)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public void IncreaseBrightness(int val)
            {
                this.VC = this.VC + val;

            }

            public void SetBrightness(int val)
            {
                this.VC = val;

            }

            public void IncreaseHue(int val)
            {
                this.HC = this.HC + val;

            }

            public void SetHue(int val)
            {
                this.HC = val;

            }

            public void IncreaseSaturation(int val)
            {
                this.SC = this.SC + val;

            }

            public void SetSaturation(int val)
            {
                this.SC = val;

            }

            public Color IncreaseHSV(int h, int s, int b)
            {
                this.HC = this.HC + h;
                this.SC = this.SC + s;
                this.VC = this.VC + b;
                return GetColor();
            }

            #endregion

        }
        public void ColorUpdate()
        {
            int H = bgColor.Value;
            int S = 22;
            int B = 94;
            RibbonColor color = new RibbonColor(255, Convert.ToUInt16(H), Convert.ToUInt16(S), Convert.ToUInt16(B));
                    this.BackColor = color.GetColor();
                    this.BackColor = Color.FromArgb(this.BackColor.R, this.BackColor.G, this.BackColor.B);
                    this.Refresh();
                    //UpdateSetting("bgColor",H.ToString());
                    XmlDocument xdoc = new XmlDocument();
                    FileStream up = new FileStream(Application.StartupPath + @"\DB.xml", FileMode.Open);
                    xdoc.Load(up);
                    XmlNodeList list = xdoc.GetElementsByTagName("bgColor");
                    XmlElement cu = (XmlElement)xdoc.GetElementsByTagName("bgColor")[0];
                    cu.InnerText = H.ToString();
                    up.Close();
                    xdoc.Save(Application.StartupPath + @"\DB.xml");
                    //Properties.Settings.Default.bgco = H;
                    //Properties.Settings.Default.Save();
            //In case needed the default blue was 209
        }
        
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //hc = trackBar1.Value;
            ColorUpdate();
        }

        private void panel3_Scroll(object sender, ScrollEventArgs e)
        {
            MessageBox.Show(e.ScrollOrientation.ToString());
        }

        private void bscroll_ValueChanged(object sender, EventArgs e)
        {
            if(bscroll.Value==1)
            {
                buttons2.Visible = false;
                buttons1.Visible = true;
            }
            else
            {
                buttons1.Visible = false;
                buttons2.Visible = true;
            }
        }

        private void J4Inquire()
        {
            string temp="";
            loadXML(defDir + @"\defaultXML\doDeal.xml");
            if (XMLD.Text.Length < 1)
                return;
            string term=tagSearch("terminalNumber");
            string temp2=reqS(XMLD.Text,"tranId",server.Text,ref temp);
            if (temp2[0] == 'T')
            {
                ClearTextBoxes();
                MessageBox.Show(temp2);
                return;
            }
            XMLD.Text = "<ashrait><request><command>inquireTransactions</command><inquireTransactions><terminalNumber>" + term + "</terminalNumber><tranId>" + temp2 + "</tranId></inquireTransactions></request></ashrait>";
            MessageBox.Show("Press submit to inquireTransactions: " + temp2);
        }

        public void inquireMPI()
        {
            string temp = "";
            string[] temp2 = { server.Text, user.Text, password.Text };
            loadXML(defDir + @"\defaultXML\J106_mpi.vbs");
            user.Text = temp2[1];
            server.Text = temp2[0];
            password.Text = temp2[2];
            if (!XMLD.Text.Contains("mid"))
                return;
            string[] lineOfContents = File.ReadAllLines(defDir + @"\servers.txt");
            foreach (var line in lineOfContents)
            {
                if (line.Contains(server.Text) && line.Contains('|'))
                {
                    string tmid = line.Substring(line.IndexOf('|') + 1);
                    string matchCodeTag = @"\<mid\>(.*?)\</mid\>";
                    string replaceWith = "<mid>" + tmid + "</mid>";
                    XMLD.Text = Regex.Replace(XMLD.Text, matchCodeTag, replaceWith);
                    break;
                }
            }            
            if (XMLD.Text.Contains("<uniqueid>"))
            {
                int first = XMLD.Text.IndexOf("<uniqueid>") + 10;
                int last = XMLD.Text.LastIndexOf("</uniqueid>");
                XMLD.Text = XMLD.Text.Remove(first, last - first);
                XMLD.Text = XMLD.Text.Replace("<uniqueid>", "<uniqueid>" + DateTime.Now.TimeOfDay.ToString());
            }
            string token = reqS(XMLD.Text, "token", server.Text, ref temp);
            if (token.Length<1)
            {
                ClearTextBoxes();
                MessageBox.Show(token);
                return;
            }
            createAutoVBSM(tagSearch(temp, "mpiHostedPageUrl"));
            //createAutoVBS(token);
            string req = "<ashrait><request><command>inquireTransactions</command><inquireTransactions><terminalNumber>" + tagSearch(XMLD.Text, "terminalNumber") + "</terminalNumber><mainTerminalNumber/><queryName>mpiTransaction</queryName><mid>" + tagSearch(XMLD.Text, "mid") + "</mid><mpiTransactionId>" + token + "</mpiTransactionId></inquireTransactions></request></ashrait>";
            XMLD.Text = req;            
        }

        public void J4Cancel()
        {
            string temp = "";
            loadXML(defDir + @"\defaultXML\doDeal.xml");
            string term = tagSearch("terminalNumber");
            string temp2 = reqS(XMLD.Text, "tranId", server.Text, ref temp);
            if (temp2[0] == 'T')
            {
                ClearTextBoxes();
                MessageBox.Show(temp2);
                return;
            }
            XMLD.Text = "<ashrait><request><command>cancelDeal</command><cancelDeal><terminalNumber>" + term + "</terminalNumber><tranId>" + temp2 + "</tranId></cancelDeal></request></ashrait>";
            MessageBox.Show("Success: " + temp2 + " submit to cancel the transaction");
        }

        public void J4Refund()
        {
            string temp = "";
            loadXML(defDir + @"\defaultXML\doDeal.xml");
            string term = tagSearch("terminalNumber");
            string total = tagSearch("total");
            string temp2 = reqS(XMLD.Text, "tranId", server.Text, ref temp);
            if (temp2[0] == 'T')
            {
                ClearTextBoxes();
                MessageBox.Show(temp2);
                return;
            }
            XMLD.Text = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanTransmit.xml", Encoding.GetEncoding("UTF-8"));
            int first = XMLD.Text.IndexOf("<terminalNumber>") + 16;
            int last = XMLD.Text.IndexOf("</terminalNumber>");
            XMLD.Text = XMLD.Text.Remove(first, last - first);
            XMLD.Text = XMLD.Text.Replace("<terminalNumber>", "<terminalNumber>" + term);
            load loadX = new load();
            Task.Factory.StartNew(() =>
            {
                loadX.ShowDialog();
            });
            Thread.Sleep(2000);
            string transmit = reqS(XMLD.Text, "transmitId", server.Text, ref temp);
            Invoke(new MethodInvoker(() =>
            {
                loadX.Close();
            }));
            /*Loading getX = new Loading();
            getX.StartPosition = FormStartPosition.CenterScreen;
            getX.Show();
            Application.DoEvents();
            string transmit = reqS(XMLD.Text, "transmitId", server.Text, ref temp);*/
            if (transmit[0] == 'T')
            {
                ClearTextBoxes();
                MessageBox.Show(transmit);
                return;
            }
            //getX.Close();
            XMLD.Text = "<ashrait><request><command>refundDeal</command><refundDeal><terminalNumber>" + term + "</terminalNumber><tranId>" + temp2 + "</tranId><total>" + total + "</total></refundDeal></request></ashrait>";
            MessageBox.Show("Success: " + temp2 + " with transmit: " + transmit + " press submit to refund it.");
        }
        public string transmit(string term)
        {
            string temp = "";
            XMLD.Text = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanTransmit.xml", Encoding.GetEncoding("UTF-8"));                            
            int first = XMLD.Text.IndexOf("<terminalNumber>") + 16;
            int last = XMLD.Text.IndexOf("</terminalNumber>");
            XMLD.Text = XMLD.Text.Remove(first, last - first);
            XMLD.Text = XMLD.Text.Replace("<terminalNumber>", "<terminalNumber>" + term);
            /*Loading getX = new Loading();
            getX.StartPosition = FormStartPosition.CenterScreen;
            getX.Show();
            Application.DoEvents();*/
            load loadX = new load();
            Task.Factory.StartNew(() =>
            {
                loadX.ShowDialog();
            });
            Thread.Sleep(2000);
            string transmit = reqS(XMLD.Text, "transmitId", server.Text, ref temp);
            Invoke(new MethodInvoker(() =>
            {
                loadX.Close();
            }));
            //string transmit = reqS(XMLD.Text, "transmitId", server.Text, ref temp);
            if (!System.Char.IsDigit(transmit[0]))
            {
                ClearTextBoxes();
            }
            //getX.Close();
            return transmit;
        }
        public string refund(string atran)
        {
            string temp = "";
            loadXML(defDir + @"\defaultXML\sanRefund.xml");
            string term = tagSearch("terminalNumber");
            XMLD.Text = XMLD.Text.Replace("@tranId@", atran);
            string temp2 = reqS(XMLD.Text, "tranId", server.Text, ref temp);
            string res= tagSearch(temp,"result");
            if (res!= "000")
            {
                ClearTextBoxes();
                return "The transactions has failed due to code" + res;
            }
            return temp2;
        }
        public void addInv()
        {
            string temp = "";
            loadXML(defDir + @"\defaultXML\doDeal.xml");            
            string temp2 = reqS(XMLD.Text, "tranId", server.Text, ref temp);
            if(temp2[0]=='T')
            {
                ClearTextBoxes();
                MessageBox.Show(temp2);                
                return;
            }
            loadXML(defDir + @"\defaultXML\addInv.xml");
            int first = XMLD.Text.IndexOf("<invoiceAtranId>") + 16;
            int last = XMLD.Text.IndexOf("</invoiceAtranId>");
            XMLD.Text = XMLD.Text.Remove(first, last - first);
            XMLD.Text = XMLD.Text.Replace("<invoiceAtranId>", "<invoiceAtranId>" + temp2);
            first = XMLD.Text.IndexOf("<ccDate>") + 8;
            last = XMLD.Text.IndexOf("</ccDate>");
            XMLD.Text = XMLD.Text.Remove(first, last - first);
            XMLD.Text = XMLD.Text.Replace("<ccDate>", "<ccDate>" + DateTime.Today.ToString("yyyy-MM-dd"));
            MessageBox.Show("Success: " + temp2 + " press submit to addInvoice");
        }

        public void cardIdJ4()
        {
            string temp = "";
            loadXML(defDir + @"\defaultXML\sanJ102.xml");
            string term = tagSearch("terminalNumber");
            string temp2 = reqS(XMLD.Text, "cardId", server.Text, ref temp);
            if (!System.Char.IsDigit(temp2[0]))
            {
                ClearTextBoxes();
                MessageBox.Show(temp2);
                return;
            }
            loadXML(defDir + @"\defaultXML\doDeal.xml");
            int f,en;
            if(XMLD.Text.Contains("cardId"))
            {
                f = XMLD.Text.IndexOf("<cardId>");
                en = XMLD.Text.IndexOf("</cardId>") + 9;
                XMLD.Text = XMLD.Text.Remove(f, en - f);
            }
            if (XMLD.Text.Contains("cardNo"))
            {
                f = XMLD.Text.IndexOf("<cardNo>");
                en = XMLD.Text.IndexOf("</cardNo>") + 9;
                XMLD.Text = XMLD.Text.Remove(f, en - f);
            }
            XMLD.Text = XMLD.Text.Replace("<doDeal>","<doDeal>\n<cardId>" + temp2 + "</cardId>");
            MessageBox.Show("Token: " + temp2 + " press submit for J4");
        }

        public void refundInv()
        {
            string temp = "";
            loadXML(defDir + @"\defaultXML\sanTamal.xml");
            XMLD.Text = XMLD.Text.Replace("@date@", DateTime.Today.ToString("yyyy-MM-dd"));
            string temp2 = reqS(XMLD.Text, "tranId", server.Text, ref temp);
            string term = tagSearch("terminalNumber");
            if (!System.Char.IsDigit(temp2[0]))
            {
                ClearTextBoxes();
                MessageBox.Show(temp2);
                return;
            }            
            string tmp = tagSearch(temp, "invoiceDocUrl");
            if(tmp.Length<1 || tmp[0]!='h')
            {
                MessageBox.Show("The original invoice has failed due to code: " + tagSearch(temp,"invoiceCreationCode"));
                return;
            }
            string transm = transmit(term);
            if(!System.Char.IsDigit(transm[0]))
            {
                MessageBox.Show(transm);
                return;
            }
            temp2 = refund(temp2);
            if (!System.Char.IsDigit(temp2[0]))
            {
                ClearTextBoxes();
                MessageBox.Show(temp2);
                return;
            }
            XMLD.Text = "<ashrait><request><command>refundCgInvoice</command><refundCgInvoice><invoiceAtranId>" + temp2 + "</invoiceAtranId><invoice><createInvoice>1</createInvoice></invoice></refundCgInvoice></request></ashrait>";
            MessageBox.Show("Success: " + temp2 + " press submit to perform addRefundInvoice");
        }

        public void J9J109()
        {
            string temp = "";
            loadXML(defDir + @"\defaultXML\j9.xml");            
            string temp2 = reqS(XMLD.Text, "tranId", server.Text, ref temp);
            string term = tagSearch("terminalNumber");
            if (!System.Char.IsDigit(temp2[0]))
            {
                ClearTextBoxes();
                MessageBox.Show(temp2);
                return;
            }
            XMLD.Text = XMLD.Text.Replace("AutoCommHold", "autoCommRelease");
            XMLD.Text = XMLD.Text.Replace("</doDeal>", "<tranId>"+temp2+"</tranId></doDeal>");
            MessageBox.Show("Success: " + temp2 + " submit for J109");
        }

        public void transmitInq()
        {
            string temp = System.IO.File.ReadAllText(defDir + @"\defaultXML\sanTransmit.xml", Encoding.GetEncoding("UTF-8"));
            temp = tagSearch(temp,"terminalNumber");
            string transm = transmit(temp);
            if(transm[0]=='h')
            {
                MessageBox.Show(transm);
                return;
            }
            XMLD.Text = "<ashrait><request><command>transmitInquire</command><transmitInquire><terminalNumber>" + temp + "</terminalNumber><transmitId>" + transm + "</transmitId></transmitInquire></request></ashrait>";
            MessageBox.Show("transmitId: " + transm + " submit for inquire");
        }

        public void shiftTrans()
        {            
            string temp = "";
            loadXML(defDir + @"\defaultXML\shiftTran.xml");            
            string temp2 = reqS(XMLD.Text, "tranId", server.Text, ref temp);
            string term = tagSearch("terminalNumber");
            if (temp2[0] == 'T')
            {
                ClearTextBoxes();
                MessageBox.Show(temp2);
                return;
            }
            loadXML(defDir + @"\defaultXML\shiftTransmit.xml");
            MessageBox.Show("Success: " + temp2 + " submit from transmit");
        }

        public void passw()
        {
            byte[] plaintext = Encoding.UTF8.GetBytes("test");

            // Generate additional entropy (will be used as the Initialization vector)
            byte[] entropy = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(entropy);
            }
            //string ProtectedData = "test";            
            byte[] ciphertext = ProtectedData.Protect(plaintext, entropy,
                DataProtectionScope.CurrentUser);
            MessageBox.Show(Encoding.UTF8.GetString(ciphertext));
            string dir = defDir + "pass.txt";
            //string s = Encoding.UTF8.GetString(ciphertext);
            File.WriteAllBytes(dir, ciphertext);
            System.Diagnostics.Process.Start(dir);
            byte[] bb = File.ReadAllBytes(dir);
            byte[] plaintext2= ProtectedData.Unprotect(bb, entropy,
    DataProtectionScope.CurrentUser);
            MessageBox.Show(Encoding.UTF8.GetString(plaintext2));
        }

        private void button34_Click(object sender, EventArgs e)
        {
            passw();
        }

        private void button_hover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            //ToolTip1.SetToolTip((Button)sender, ConfigurationManager.AppSettings[((Button)sender).Name + "L"]);
            ToolTip1.SetToolTip((Button)sender,((Button)sender).Tag.ToString());
        }

        private void button32_hover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip((Button)sender, defDir + @"\defaultXML\doDeal.xml");
        }

        private void button31_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip((Button)sender, defDir + @"\defaultXML\J106_mpi.vbs");
        }

        private void button27_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip((Button)sender, defDir + @"\defaultXML\sanInvoice.xml");
        }

        private void button26_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip((Button)sender, defDir + @"\defaultXML\sanJ102.xml");
        }

        private void button25_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip((Button)sender, defDir + @"\defaultXML\j9.xml");
        }

        private void button24_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip((Button)sender, defDir + @"\defaultXML\sanTransmit.xml");            
        }

        private void button23_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip((Button)sender, defDir + @"\defaultXML\shiftTran.xml");
        }
        private void J102_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip((Button)sender, defDir + @"\defaultXML\sanJ102.xml");
        }

        public void cardNo()
        {
            loadXML(defDir + @"\defaultXML\sanJ102.xml");
            string temp="";
            string temp2 = reqS(XMLD.Text, "cardId", server.Text, ref temp);
            if(temp2=="" || !System.Char.IsDigit(temp2[0]))
            {
                MessageBox.Show("The J102 has failed due to: " + tagSearch(temp, "result"));
                XMLD.Text = "";
                return;
            }
            loadXML(defDir + @"\defaultXML\J201.xml");
            XMLD.Text = XMLD.Text.Replace("<cardId>", "<cardId>" + temp2);
            MessageBox.Show("J102 was successfull and returned cardId: " + temp2 + " click submit for cardNo request");
        }

        void button_MouseDown(object sender, MouseEventArgs e)
        {
           // ((sender as Button).Tag as Stopwatch).Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xd = new XmlDocument();
            FileStream lfile = new FileStream(Application.StartupPath+@"\DB.xml", FileMode.Open);
            xd.Load(lfile);
            XmlElement cl = xd.CreateElement("Button");
            cl.SetAttribute("Name", "bent");
            XmlElement na = xd.CreateElement("Value");
            XmlText natext = xd.CreateTextNode("testTest");
            na.AppendChild(natext);
            cl.AppendChild(na);
            xd.DocumentElement.AppendChild(cl);
            lfile.Close();
            xd.Save(Application.StartupPath+@"\DB.xml");
        }

        /*public string tagsReplace(string req)
        {
            string matchCodeTag = @"\<mid\>(.*?)\</mid\>";
            string textToReplace = "[code]The Ape Men are comming[/code]";
            string replaceWith = "Keep Calm";
            string output = Regex.Replace(textToReplace, matchCodeTag, replaceWith);
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            string matchCodeTag = @"\<mid\>(.*?)\</mid\>";
            string textToReplace = "<mid>The Ape Men are comming</mid>";
            string replaceWith = "Keep Calm";
            MessageBox.Show(Regex.Replace(textToReplace, matchCodeTag, replaceWith));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(XMLS[0]);
        }

        public void runSet()
        {
            string log="";
            string response = "";
            XMLS[0] = uniqId(XMLS[0]);
            string tempR = reqS(XMLS[0], "result", server.Text, ref response);
            string summery = "";
            /*if(tempR!="000" && tempR!="1000")
            {
                MessageBox.Show("Inital transactions failed,due to code: " + tempR);
                return;
            }*/
            log += "Transaction 1:" + Environment.NewLine + response + Environment.NewLine + Environment.NewLine;
            summery += "Transaction 1: received status: " + tempR + Environment.NewLine;
            for(int i=1;i<100;i++)
            {
                if (XMLS[i].Length < 1)
                    continue;
                string XMLtoSend = XMLS[i];
                while(XMLtoSend.Contains(">@"))
                {
                    int first = XMLtoSend.IndexOf(">@")+2;
                    int last = XMLtoSend.IndexOf("@<");
                    string tag = XMLtoSend.Substring(first, last - first);
                    XMLtoSend = XMLtoSend.Replace("@" + tag + "@", tagSearch(response, tag));                    
                }
                XMLtoSend = uniqId(XMLtoSend);
                tempR = reqS(XMLtoSend, "result", server.Text, ref response);
                log += "Transaction " + (i + 1).ToString() + ":" + Environment.NewLine + response + Environment.NewLine + Environment.NewLine;;
                summery += "Transaction " + (i+1).ToString() + ": received status: " + tempR + Environment.NewLine;
            }
            if (log.Contains("http"))
                summery += "\nAt least one of the responses contain a URL,click no to open URL and yes to open log instead";
            else
                summery += "\nWould you like to watch the log?";
            DialogResult ask = MessageBox.Show(summery, "Results",MessageBoxButtons.YesNoCancel);
            if (ask == DialogResult.Yes)
            {
                string dir = defDir + "log.txt";
                StreamWriter sw;
                sw = File.CreateText(dir);
                sw.Write(log);
                sw.Close();
                System.Diagnostics.Process.Start(dir);
            }
            if(ask==DialogResult.No)
            {
                string tlog = log;
                while (tagSearch(tlog, "mpiHostedPageUrl") != "")
                {
                    createAutoVBSM(tagSearch(tlog, "mpiHostedPageUrl"));
                    int f = tlog.IndexOf("<mpiHostedPageUrl>");
                    int l = tlog.IndexOf("</mpiHostedPageUrl>");
                    l = l + "</mpiHostedPageUrl>".Length;
                    tlog = tlog.Remove(f, l - f);
                }
                while (tagSearch(tlog, "invoiceDocUrl") != "")
                {
                    Process.Start(tagSearch(tlog, "invoiceDocUrl"));
                    int f = tlog.IndexOf("<invoiceDocUrl>");
                    int l = tlog.IndexOf("</invoiceDocUrl>");
                    l = l + "</invoiceDocUrl>".Length;
                    tlog = tlog.Remove(f, l - f);
                }
            }
        }
        public string  uniqId(string text)
        {
            string temp=text;
            if (temp.Contains("<uniqueid>"))
            {
                int first = temp.IndexOf("<uniqueid>") + 10;
                int last = temp.LastIndexOf("</uniqueid>");
                temp = temp.Remove(first, last - first);
                temp = temp.Replace("<uniqueid>", "<uniqueid>" + DateTime.Now.TimeOfDay.ToString());
            }
            if (temp.Contains("<ccDate>"))
            {
                int first = temp.IndexOf("<ccDate>") + 8;
                int last = temp.LastIndexOf("</ccDate>");
                temp = temp.Remove(first, last - first);
                temp = temp.Replace("<ccDate>", "<ccDate>" + DateTime.Now.ToString("yyyy-MM-dd"));
            }
            
            return temp;
        }
        public string replaceCardId(string xmlToR)
        {
            if (!xmlToR.Contains("<cardId>"))
                return xmlToR;
            string[] lineOfContents = File.ReadAllLines(defDir + @"\servers.txt");
            foreach (var line in lineOfContents)
            {
                //int count = Regex.Matches(line, "|").Count;
                int count = line.Count(x => x == '|');
                if (line.Contains(server.Text) && count>1)
                {
                    string tmid = line.Substring(line.LastIndexOf('|') + 1);
                    string matchCodeTag = @"\<cardId\>(.*?)\</cardId\>";
                    string replaceWith = "<cardId>" + tmid + "</cardId>";
                    xmlToR = Regex.Replace(xmlToR, matchCodeTag, replaceWith);
                    break;
                }
            }
            return xmlToR;
        }

        private void serverList_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(defDir, "servers.txt"));
            /*string dir = defDir;
            string path = Path.Combine(dir, "servers.txt");
            if (!File.Exists(path))
            {
                MessageBox.Show("Missing servers file from the default directory");
                return;
            }
            textW getX = new textW();
            getX.Location = new Point(this.Location.X + 260, this.Location.Y + 100);
            string te = Application.OpenForms.OfType<textW>().Count().ToString();
            if (Application.OpenForms.OfType<textW>().Count() == 1)
            {
                Application.OpenForms.OfType<textW>().First().Close();
            }
            else
            {
                getX.box.Text = System.IO.File.ReadAllText(path, Encoding.GetEncoding("ISO-8859-8"));
                getX.BackColor = this.BackColor;
                getX.save.Visible = true;
                getX.path=path;
                getX.Show();
            }*/
        }

        private void hostsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts"));
        }
        public void addToServers()
        {
            string[] lineOfContents = File.ReadAllLines(defDir + @"\servers.txt");
            foreach (var line in lineOfContents)
            {
                if (line.Contains(server.Text))
                    return;
            }
            DialogResult result2 = MessageBox.Show("The server:\n" + server.Text + "\ndoesnt seem to be in servers.txt,would you like to add it?", "Add server?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result2 == DialogResult.Yes)
            {
                string result =Environment.NewLine + server.Text;
                if(tagSearch(XMLD.Text,"mid")!="")
                    result += "|" + tagSearch(XMLD.Text, "mid");
                if (tagSearch(XMLD.Text, "cardId") != "")
                    result += "|" + tagSearch(XMLD.Text, "cardId");
                File.AppendAllText(defDir + @"\servers.txt",result);
            }
        }

        public void validator()
        {
            try
            {
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(defDir);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Missing read/write permissions for:\n" + defDir);
            }
            try
            {
                string keyName = @"HKEY_CURRENT_USER\Software\CodeCentrix\OpenTwebst";
                string valueName = "Start Menu Folder";
                if (Registry.GetValue(keyName, valueName, null) == null)
                {
                    MessageBox.Show("Warning,seems like you dont have IE automitation installed,some features will not work in XMI(like autoFill J106).\n");
                }
            }
            catch
            {
                MessageBox.Show("No access to the registry,cannot complete validation for IE automitation,procceed at your own risk.");
            }
        }

        private void sanityB_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                sanityList tmp = new sanityList(defDir);
                //tmp.BackColor = this.BackColor;
                tmp.Show();
            }
            else
            {
                sanityB_Click(null,null);
            }
        }

        private void server_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (server.Text.Length == 0)
            {
                hideResults();
                return;
            }

            foreach (String s in server.AutoCompleteCustomSource)
            {
                if (s.Contains(server.Text))
                {
                    Console.WriteLine("Found text in: " + s);
                    listBox1.Items.Add(s);
                    listBox1.Visible = true;
                }
            }
        }
        void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            server.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
            hideResults();
        }

        void listBox1_LostFocus(object sender, System.EventArgs e)
        {
            hideResults();
        }

        void hideResults()
        {
            listBox1.Visible = false;
        }
        public string GetStringBetween(string token, string first, string second)
        {
            if (!token.Contains(first)) return "";

            var afterFirst = token.Split(new[] { first }, StringSplitOptions.None)[1];

            if (!afterFirst.Contains(second)) return "";

            var result = afterFirst.Split(new[] { second }, StringSplitOptions.None)[0];

            return result;
        }
    }
}
