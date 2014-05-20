using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace CCPlistEditor
{
    public class LanguageItem
    {
        public string name { get; set; }
        public string text { get; set; }
        public string tooltip { get; set; }
        public string error { get; set; }
        public LanguageItem()
        {
            tooltip = name = text = "";
            error = "";
        }
    }
    public class  DString
    {
        public string name { get; set; }
        public string text { get; set; }
    }
    public class LanguageListView
    {
        public string Name { get; set; }
        public List<LanguageItem> Groups { get; set; }
        public List<LanguageItem> Columns { get; set; }
        public LanguageListView()
        {
            Groups = new List<LanguageItem>();
            Columns = new List<LanguageItem>();
        }
    }
    public class LanguageForm
    {
        public string Name { get; set; }
        public List<LanguageItem> Controls { get; set; }
        public List<LanguageItem> Menus { get; set; }
        public List<LanguageItem> Toolbars { get; set; }
        public List<LanguageListView> ListViews { get; set; }
        public LanguageForm()
        {
            Controls = new List<LanguageItem>();
            Menus = new List<LanguageItem>();
            ListViews = new List<LanguageListView>();
            Toolbars = new List<LanguageItem>();
        }
    }
    
    public class CLanguage
    {
        #region 用于获取界面上菜单和控件的文字信息
        /// <summary>
        /// 获取界面上全部控件的文字信息
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="parentlist"></param>
        /// <returns></returns>
        public List<LanguageItem> GetAllControls(Control parent, List<LanguageItem> parentlist)
        {
            if (parentlist == null)
            {
                parentlist = new List<LanguageItem>();
                parentlist.Add(GetLItem(parent.Name, parent.Text, ""));
            }
            foreach (Control ctrl in parent.Controls)
            {
                parentlist.Add(GetLItem(ctrl.Name, ctrl.Text, ""));
                GetAllControls(ctrl, parentlist);
            }
            return parentlist;
        }
        /// <summary>
        /// 获取主菜单的文字信息
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public List<LanguageItem> GetMenuItems(MenuStrip menu)
        {
            List<LanguageItem> list = new List<LanguageItem>();
            foreach (ToolStripItem toolitem in menu.Items)
            {
                if (toolitem.GetType() == typeof(ToolStripSeparator))
                    continue;
                ToolStripMenuItem item = (ToolStripMenuItem)toolitem;
                list.Add(GetLItem(item.Name, item.Text, item.ToolTipText));
                GetSubMenuitems(list, item);
            }
            return list;
        }
        /// <summary>
        /// 获取交互式菜单的文字信息
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public List<LanguageItem> GetMenuItems(ContextMenuStrip menu)
        {
            List<LanguageItem> list = new List<LanguageItem>();
            foreach (ToolStripItem toolitem in menu.Items)
            {
                if (toolitem.GetType() == typeof(ToolStripSeparator))
                    continue;
                ToolStripMenuItem item = (ToolStripMenuItem)toolitem;
                list.Add(GetLItem(item.Name, item.Text, item.ToolTipText));
                GetSubMenuitems(list, item);
            }
            return list;
        }
        /// <summary>
        /// 获得子菜单的文字信息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parent"></param>
        private void GetSubMenuitems(List<LanguageItem> list, ToolStripMenuItem parent)
        {
            foreach (ToolStripItem toolitem in parent.DropDownItems)
            {
                if (toolitem.GetType() == typeof(ToolStripSeparator))
                    continue;
                ToolStripMenuItem item = (ToolStripMenuItem)toolitem;
                if (item == null)
                    continue;

                list.Add(GetLItem(item.Name,item.Text,item.ToolTipText));
                GetSubMenuitems(list, item);
            }
        }
        public List<LanguageItem> GetToolStripItems(Control parent, string toolbarname)
        {
            ToolStrip toolbar = parent.Controls[toolbarname] as ToolStrip;
            if(toolbar == null)
            {
                return null;
            }
            List<LanguageItem> items = new List<LanguageItem>();
            foreach (ToolStripItem toolitem in toolbar.Items)
            {
                if (toolitem.GetType() == typeof(ToolStripSeparator))
                    continue;
                if (toolitem.GetType() == typeof(ToolStripSplitButton))
                {
                    items.Add(GetLItem(toolitem.Name, toolitem.Text, toolitem.ToolTipText));
                    GetSubToolbaritems(items, (ToolStripSplitButton)toolitem);
                }
                if (toolitem.GetType() == typeof(ToolStripButton))
                {
                    items.Add(GetLItem(toolitem.Name, toolitem.Text, toolitem.ToolTipText));
                }
            }
            return items;
        }

        private void GetSubToolbaritems(List<LanguageItem> list, ToolStripSplitButton parent)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    list.Add(GetLItem(item.Name, item.Text, item.ToolTipText));
                    GetSubMenuitems(list, (ToolStripMenuItem)item);
                }
                
            }
        }
        /// <summary>
        /// 获得ListView中的文字信息（列）
        /// </summary>
        /// <param name="lvParent"></param>
        /// <returns></returns>
        public List<LanguageItem> GetListViewColumns(ListView lvParent)
        {
            List<LanguageItem> list = new List<LanguageItem>();
            if (lvParent != null)
            {
                foreach (ColumnHeader col in lvParent.Columns)
                {
                    list.Add(GetLItem(col.Index.ToString(), col.Text, ""));
                }

            }
            return list;

        }
        /// <summary>
        /// 获得ListView中的文字信息（分组）
        /// </summary>
        /// <param name="lvParent"></param>
        /// <returns></returns>
        public List<LanguageItem> GetListViewGroups(ListView lvParent)
        {
            List<LanguageItem> list = new List<LanguageItem>();
            if (lvParent != null)
            {
                foreach (ListViewGroup group in lvParent.Groups)
                {
                    list.Add(GetLItem(group.Name, group.Header, ""));
                }

            }
            return list;

        }
        private LanguageItem GetLItem(string name, string text, string tooltip)
        {
            LanguageItem lanItem = new LanguageItem();
            lanItem.name = name;
            lanItem.text = text;
            lanItem.tooltip = tooltip;
            return lanItem;
        }
        #endregion

        #region 通过语言文件获取字符串
        readonly string strError = "ERROR, NO such language file for ({0}) or some items are missing.";
        /// <summary>
        /// 获得配置中的语言列表
        /// </summary>
        public List<LanguageItem> GetLanguageList()
        {
            string lanCfgFilePath = Application.StartupPath + "\\Language\\languages.xml";//多语言列表配置文件
            
            if (File.Exists(lanCfgFilePath))
            {
                Cxml xmlLanguage = new Cxml(lanCfgFilePath);
                List<List<string>> languageList =  xmlLanguage.getNodesEx("Languages/Language", new string[] { "name", "code","tooltip" });
                if (languageList == null)
                    return null;
                List<LanguageItem> resultList = new List<LanguageItem>();
                foreach (List<string> lang in languageList)
                {
                    LanguageItem lanItem = new LanguageItem();
                    lanItem.text = lang[1];
                    lanItem.name = lang[2];
                    lanItem.tooltip = lang[3];
                    resultList.Add(lanItem);
                }
                return resultList;
            }
            return null;
        }

        public List<LanguageForm> Forms { get; set; }
        public List<DString> Dynamics { get; set; }
        public CLanguage()
        {
            Forms = new List<LanguageForm>();
            Dynamics = new List<DString>();
        }
        public string GetDynamicString(string code, string language)
        {
            if (Dynamics == null || Dynamics.Count <= 0)
            {
                return string.Format(strError,language);
            }
            foreach (DString langItem in Dynamics)
            {
                if (langItem.name == code)
                {
                    return langItem.text;
                }
            }
            return string.Format(strError, language);
        }        
        #endregion
        #region XML的序列化和反序列化

        /// <summary>
        /// 序列化为XML字符串
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            string strSource = "";
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(CLanguage), new Type[] { typeof(LanguageItem) });
                Stream stream = new MemoryStream();
                s.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin); //定位到流的开头
                using (StreamReader reader = new StreamReader(stream))
                {
                    strSource = reader.ReadToEnd();
                }
                stream.Close();
                stream.Dispose();
            }
            catch
            {
                return "";
            }

            return strSource;
        }
        /// <summary>
        /// 序列化为XML字符串，并保存
        /// </summary>
        /// <returns></returns>
        public void Serialize(string savetofile)
        {
            try
            {
                FileStream streamWriter = File.Create(savetofile);
                XmlSerializer s = new XmlSerializer(typeof(CLanguage), new Type[] { typeof(LanguageItem) });
                Stream stream = new MemoryStream();
                s.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin); //定位到流的开头
                while (stream.Position<stream.Length)
                {
             
                   streamWriter.WriteByte((byte)stream.ReadByte());
                }

                stream.Close();
                stream.Dispose();
                streamWriter.Close();
            }
            catch
            {
            }

        }

        /// <summary>
        /// 反序列化ＸＭＬ字符串为对象
        /// </summary>
        /// <param name="xmlSource"></param>
        /// <returns></returns>
        public static CLanguage Deserialize(string filename)
        {

            CLanguage obj = new CLanguage();
            if (filename.Trim() == "") return obj;
            try
            {
                XmlSerializer x = new XmlSerializer(typeof(CLanguage), new Type[] { typeof(LanguageItem) });
                // Create a TextReader to read the file. 
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                TextReader reader = new StreamReader(fs);
                obj = (CLanguage)x.Deserialize(reader);
                reader.Close();
                fs.Close();
                fs.Dispose();
            }
            catch
            {
                return null;
            }
            return obj;
        }

        #endregion

        public void TransForm(Form frm, string menu = null, string[] listview = null)
        {
            LanguageForm frmLan = new LanguageForm();
            frmLan.Name = frm.Name;
            frmLan.Controls = this.GetAllControls(frm, null);
            if (menu != null)
            {
                frmLan.Menus = this.GetMenuItems((MenuStrip)frm.Controls[menu]);
            }

            if (listview != null)
            {
                foreach (string s in listview)
                {
                    LanguageListView lv = new LanguageListView();
                    Control[] ctrls = frm.Controls.Find(s, true);
                    if (ctrls.Length <= 0)
                    {
                        continue;
                    }
                    ListView lv1 = ctrls[0] as ListView;
                    
                    lv.Name = lv1.Name;
                    lv.Columns = this.GetListViewColumns(lv1);
                    lv.Groups = this.GetListViewGroups(lv1);
                    frmLan.ListViews.Add(lv);
                }
            }
            
            this.Forms.Add(frmLan);
            frm.Dispose();
        }
    }
}
