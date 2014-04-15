using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace CCPlistEditor
{
    public class CDefines
    {
        static string _language { get; set; }
        public static string AppRootPath { get; set; }
        public static string ConfigFilePath
        {
            get
            {
                return AppRootPath + "\\appconfig.xml";
            }
        }
        /// <summary>
        /// 语言文件不存在造成字符串找不到
        /// </summary>
        public static string UnAvailableString
        {
            get
            {
                return "\r\n";
            }
        }
        /// <summary>
        /// 程序中动态调用的字符串
        /// </summary>
        public static CLanguage langInst = new CLanguage();


        public static bool SetLanguage(string lang, Form frm, ToolTip tip = null)
        {
            _language = lang;
            string languageCfg = AppRootPath + "\\Language\\" + lang + ".xml";
            CLanguage langGetNow = CLanguage.Deserialize(languageCfg);
            
            if (langGetNow == null)
            {
                MessageBox.Show(CDefines.GetDStr("MSG_NO_LANGUAGE"));
                return false;
            }
            else
            {
                langInst = langGetNow;
                foreach (LanguageForm langForm in CDefines.langInst.Forms)
                {
                    if (langForm.Name == frm.Name)
                    {
                        foreach (LanguageItem item in langForm.Controls)
                        {
                            ChangeControl(item.name, item.text, item.tooltip, frm, tip);
                        }
                        foreach (LanguageItem item in langForm.Menus)
                        {
                            ChangeMenu(item.name, item.text, item.tooltip, frm);
                        }
                        foreach (LanguageItem item in langForm.Toolbars)
                        {
                            ChangeToolbar(item.name, item.text, item.tooltip, frm);
                        }
                        foreach (LanguageListView langView in langForm.ListViews)
                        {
                            Control[] ctrls = frm.Controls.Find(langView.Name, true);
                            if (ctrls != null && ctrls.Length > 0)
                            {
                                ListView listViewFind = ctrls[0] as ListView;
                                foreach (ColumnHeader col in listViewFind.Columns)
                                {
                                    if (langView.Columns[col.Index] != null)
                                        col.Text = langView.Columns[col.Index].text;
                                }
                                foreach (ListViewGroup grp in listViewFind.Groups)
                                {
                                    grp.Header = FindGroupInListView(grp.Name, langView.Groups);
                                }
                            }
                        }
                    }
                }

                return true;
            }
            
        }
        /// <summary>
        /// 获得动态字符串
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetDStr(string code)
        {
            return langInst.GetDynamicString(code,_language);
        }
        public static string SecondsToString(long seconds)
        {
            TimeSpan span = TimeSpan.FromSeconds((double)seconds);
            return string.Format("{0}", span);
        }
        private static void ChangeControl(string id, string value, string tooltip, Form frm, ToolTip tip = null)
        {
            if (string.IsNullOrEmpty(id))
            {
                return;
            }
            if (frm.Name == id)
            {
                frm.Text = value;
                return;
            }
            Control[] ctrls = frm.Controls.Find(id, true);
            if (ctrls != null && ctrls.Length > 0)
            {
                ctrls[0].Text = value;
                if (tip != null)
                {
                    tip.SetToolTip(ctrls[0], tooltip);
                }
                
            }
        }
        private static void ChangeMenu(string id, string value, string tooltip, Form frm)
        {
            if (frm.MainMenuStrip == null)
                return;
            ToolStripItem[] menuItems = frm.MainMenuStrip.Items.Find(id, true);
            if (menuItems != null && menuItems.Length > 0)
            {
                menuItems[0].Text = value;
                menuItems[0].ToolTipText = tooltip;

            }
        }
        private static void ChangeToolbar(string id, string value,string tooltip, Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if(ctrl.GetType() == typeof(ToolStrip))
                {
                    ToolStrip toolbar = ctrl as ToolStrip;
                    
                    foreach (ToolStripItem item in toolbar.Items.Find(id, true))
                    {
                        item.Text = value;
                        item.ToolTipText = tooltip;
                        break;
                    }
                }
            }

          
             
            
        }
        private static string FindGroupInListView(string groupname, List<LanguageItem> groupitems)
        {
            foreach (LanguageItem item in groupitems)
            {
                if (item.name == groupname)
                {
                    return item.text;
                }
            }
            return "";
        }
        #region XML的序列化和反序列化

        /// <summary>
        /// 序列化为XML字符串
        /// </summary>
        /// <returns></returns>
        public static string Serialize(object classObj, Type mainType, Type[] subTypes = null)
        {
            string strSource = "";
            try
            {
                if (subTypes == null)
                {
                    subTypes = new Type[1];
                    subTypes[0] = typeof(string);
                }
                XmlSerializer s = new XmlSerializer(mainType, subTypes);
                Stream stream = new MemoryStream();
                s.Serialize(stream, classObj);
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
        /// 反序列化ＸＭＬ字符串为对象
        /// </summary>
        /// <param name="xmlSource"></param>
        /// <returns></returns>
        public static object Deserialize(string filename, Type mainType, Type[] subTypes = null)
        {
            

            if (filename.Trim() == "") return null;
            try
            {
                if (subTypes == null)
                {
                    subTypes = new Type[1];
                    subTypes[0] = typeof(string);
                }
                XmlSerializer x = new XmlSerializer(mainType, subTypes);
                // Create a TextReader to read the file. 
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                TextReader reader = new StreamReader(fs);
                object obj = x.Deserialize(reader);
                reader.Close();
                fs.Close();
                fs.Dispose();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }

}
