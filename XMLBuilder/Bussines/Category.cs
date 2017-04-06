using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using XMI.DAL;
using System.Data;

namespace XMI.Bussines
{
    /// <summary>
    /// Summary description for Category.
    /// </summary>
    public class Category
    {

        public string id;
        public string tags;
        public string task;
        public string xmlPath;
        public string testPlan;
        public string profile;
        public Category()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string TAGS
        {
            get { return tags; }
            set { tags = value; }
        }
        public string TASK
        {
            get { return task; }
            set { task = value; }
        }
        public string XMLPATH
        {
            get { return xmlPath; }
            set { xmlPath = value; }
        }
        public string TESTPLAN
        {
            get { return testPlan; }
            set { testPlan = value; }
        }
        public string PROFILE
        {
            get { return profile; }
            set { profile = value; }
        }
    }
    public class CategoryList
    {
        public static Category GetCategory(string categoryID)
        {
            DataRow iDr = null;
            iDr = XMLCategory.Select(categoryID);
            Category cat = null;
            if (iDr != null)
            {
                cat = new Category();
                cat.ID = iDr[0] != DBNull.Value ? iDr[0].ToString() : string.Empty; ;
                cat.TAGS = iDr[1] != DBNull.Value ? iDr[1].ToString() : string.Empty;
            }
            return cat;
        }
        public static IList GetCategoryList()
        {

            return XMLCategory.SelectAll();

        }
        public static IList refr()
        {
            return XMLCategory.refresh();
        }
        public static IList getS(string name)
        {
            return XMLCategory.SelectM(name);
        }
        public static IList getT(string name)
        {
            return XMLCategory.SelectT(name);
        }
        public static void UpdateCategory(Category cat)
        {
            XMLCategory.Update(cat.ID, cat.TAGS);
        }
        public static void updateXML()
        {
            XMLCategory.save();
        }
        public static void InsertCategory(Category cat)
        {
            XMLCategory.Insert(cat.TAGS,cat.TASK,cat.XMLPATH,cat.TESTPLAN,cat.PROFILE);
        }

        public static void DeleteCategory(string categoryID)
        {
            XMLCategory.Delete(categoryID);
        }
    }

}