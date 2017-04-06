using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;

namespace XMI.DAL
{
    public sealed class XMLCategory
    {
        private XMLCategory() { 
    }
        static DataSet ds = new DataSet();
        static DataView dv = new DataView();
        public static DataView t = new DataView();
        
        public static void save()
        {
            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(Application.StartupPath + @"\DB.xml", FileMode.Open);
            xdoc.Load(rfile);
            XmlElement co = (XmlElement)xdoc.GetElementsByTagName("dir")[0];
            rfile.Close();
            string defDir = co.InnerText;
                //ds.WriteXml(Application.StartupPath + "\\XML\\Category.xml", XmlWriteMode.WriteSchema);
                ds.WriteXml(defDir + "\\XML\\Category.xml", XmlWriteMode.WriteSchema);                

        }        
        public static void Insert(string tags,string task,string path,string plan,string profile)
        {
            SelectAll();
            DataRow dr = dv.Table.NewRow();
            int temp = dv.Table.Rows.Count;
            int count = 0;
            for (int i = 0; i < temp; i++)
                if (Convert.ToInt32(dv.Table.Rows[i][0]) > count)
                    count = Convert.ToInt32(dv.Table.Rows[i][0]);
            count++;
            dr[0] = count;
            dr[1] = tags;
            dr[2] = task;
            dr[3] = profile;
            dr[4] = path;
            dr[5] = plan;
            dv.Table.Rows.Add(dr);
            save();
        }
        public static void Update(string categoryID, string CategoryName)
        {
            DataRow dr = Select(categoryID);
            dr[1] = CategoryName;
            save();
        }

        public static void Delete(string categoryID)
        {
            SelectAll();
            dv.RowFilter = "id='" + categoryID + "'";
            if(dv.Count == 0)
            {
                MessageBox.Show("Record was not found,please check the XML");
                dv.RowFilter = "";
                return;
            }
            dv.Sort = "id";
            dv.Delete(0);
            dv.RowFilter = "";
            save();
        }

        public static DataRow Select(string categoryID)
        {
            dv.RowFilter = "id='" + categoryID + "'";
            dv.Sort = "id";
            DataRow dr = null;
            if (dv.Count > 0)
            {
                dr = dv[0].Row;
            }
            dv.RowFilter = "";
            return dr;
        }
        public static DataView SelectM(string catId)
        {
            dv.RowFilter = "id LIKE '%" + catId + "%' or tags LIKE '%" + catId + "%' or task LIKE '%" + catId + "%'";
            dv.Sort = "id";
            return dv;
        }
        public static DataView SelectT(string catId)
        {
            dv.RowFilter = "task = '" + catId + "'";
            dv.Sort = "id";
            return dv;
        }

        public static DataView SelectAll()
        {
            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(Application.StartupPath + @"\DB.xml", FileMode.Open);
            xdoc.Load(rfile);
            XmlElement co = (XmlElement)xdoc.GetElementsByTagName("dir")[0];
            rfile.Close();
            string defDir = co.InnerText;
            ds.Clear();
            ds.ReadXml(defDir + "\\XML\\Category.xml", XmlReadMode.ReadSchema);
            dv = ds.Tables[0].DefaultView;
            t = ds.Tables[0].DefaultView; ;
            return dv;
        }
        public static DataView refresh()
        {
            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(Application.StartupPath + @"\DB.xml", FileMode.Open);
            xdoc.Load(rfile);
            XmlElement co = (XmlElement)xdoc.GetElementsByTagName("dir")[0];
            rfile.Close();
            string defDir = co.InnerText;
            ds.Clear();
            ds.ReadXml(defDir + "\\XML\\Category.xml", XmlReadMode.ReadSchema);
            dv.RowFilter = "";
            dv = ds.Tables[0].DefaultView;
            return dv;
        }
    }
}