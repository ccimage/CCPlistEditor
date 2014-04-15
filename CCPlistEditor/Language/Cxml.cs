/*
 * XML Class  ，Written by ZhangChuan
 * #####  not throw out any exception ####### 
 * So Notice That：
 * 1.xmlfile must be the right filename of your xml file.
 * 2.for some methods with no initxml(),initxml before call this.
 * 3.for some methods with no disposexml(),dipose after;
 * 4.如果多次调用都没有dispose，则视为同一个文档操作。
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;

namespace CCPlistEditor
{
    public class Cxml
    {
        private string xmlfile;

        private XmlTextReader xr;
        private XmlDocument xd;
        /// <summary>
        /// 初始化xml文件
        /// </summary>
        /// <param name="xmlfile">文件路径</param>
        public Cxml(string xmlfile)
        {
            this.xmlfile = xmlfile;
        }
        public void InitXml()
        {
            try
            {
                xr = new XmlTextReader(xmlfile);
                xd = new XmlDocument();
                xr.WhitespaceHandling = WhitespaceHandling.None;
                xd.Load(xr);
            }
            catch
            {
                
            }
        }
        public void DisposeXml()
        {
            try
            {
                xr.Close();
                xd.Save(xmlfile);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 获得key指定的value
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string getAttrib(string nodename, string key)
        {
            try
            {
                InitXml();

                XmlNode xn = xd.SelectSingleNode(nodename);
                xr.Close();
                return xn.Attributes[key].Value.ToLower();
            }
            catch
            {
            }
            return "";
        }
        /// <summary>
        /// 获得key指定的value
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public void setAttrib(string nodename, string key,string value)
        {
            try
            {
                InitXml();
                XmlNode xn = xd.SelectSingleNode(nodename);
                xn.Attributes[key].Value=value;
                xr.Close();
                xd.Save(xmlfile); 
            }
            catch
            {
            }
        }
        /// <summary>
        /// 获得多个相同节点的 key指定的value
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string[] getAttribs(string nodename, string key)
        {
            try
            {
                InitXml();
                
                XmlNodeList xnl = xd.SelectNodes(nodename);
                string[] attrs =new string[xnl.Count];
                for(int i=0;i<xnl.Count;i++)
                {
                    attrs[i] = xnl[i].Attributes[key].Value;
                }
                xr.Close();
                return attrs;
            }
            catch
            {
            }
            return null;
        }
        /// <summary>
        /// 获得单条结果
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public string getInfo(string nodename)
        {
            try
            {
                InitXml();
                XmlNode xmlnd =  xd.SelectSingleNode(nodename);
                if (xmlnd == null)
                    return "";
                string resultstring = xmlnd.InnerText;
                xr.Close();
                 return resultstring;
            }
            catch
            {
            }
            return "";
        }
        /// <summary>
        /// 获得多条结果
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public string[] getNodes(string nodename)
        {
            try
            {
                InitXml();
                XmlNodeList nlist = xd.SelectNodes(nodename);
                string[] resultstring = new string[nlist.Count];
                for (int i = 0; i < nlist.Count; i++)
                {
                    resultstring[i] = nlist[i].InnerText;
                }
                xr.Close();
                return resultstring;
            }
            catch
            {
            }
            return null;
        }
        /// <summary>
        /// 获得标签的内容,包括指定的值 如 ＜abc ee='1'>2 ＜/abc＞通过标签abc和指定ee返回 2,1
        /// 标签无内容的将包括一个空值。
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public List<List<string>> getNodesEx(string nodename,string[] valueNames)
        {
            try
            {
                InitXml();
                XmlNodeList nlist = xd.SelectNodes(nodename);
                List<List<string>> resultList = new List<List<string>>();
                for (int i = 0; i < nlist.Count; i++)
                {
                    List<string> values = new List<string>();
                    values.Add(nlist[i].InnerText);
                    foreach (string tag in valueNames)
                    {
                        values.Add(nlist[i].Attributes[tag].Value);
                    }
                    resultList.Add(values);
                }
                xr.Close();
                return resultList;
            }
            catch
            {
            }
            return null;
        }
        /// <summary>
        /// 保存节点 直到最大数量（用于保存记录）
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="value"></param>
        /// <param name="maxnode"></param>
        public void saveNode(string nodename, string value,int maxnode)
        {
            try
            {
                InitXml();
                XmlNodeList nlist = xd.SelectNodes(nodename);
                int nodecount = nlist.Count;
                string a = nodename.Substring(0, nodename.LastIndexOf("/"));
                string b = nodename.Substring(nodename.LastIndexOf("/") + 1);
                if (nodecount <= 0)//值为0
                {
                    xr.Close();
                    addNode(a, b, value);
                    return;
                }
                else if (nodecount >= maxnode)//值已经存满了
                {
                    //值位置
                    int valuePos = hasNode(value, nlist);
                    if (valuePos > 0)//如果有值了，且不是在第一个，重新排序
                    {
                        for (int i = valuePos; i > 0; i--)
                        {
                            nlist[i].InnerText = nlist[i - 1].InnerText;
                        }
                        nlist[0].InnerText = value;
                    }
                    if (valuePos == -1)//值不存在
                    {
                        for (int i = maxnode - 1; i > 0; i--)
                        {
                            nlist[i].InnerText = nlist[i - 1].InnerText;
                        }
                        nlist[0].InnerText = value;
                    }
                }
                else//值还没满
                {

                    //值位置
                    int valuePos = hasNode(value, nlist);
                    if (valuePos > 0)//如果有值了，且不是在第一个，重新排序
                    {
                        for (int i = valuePos; i > 0; i--)
                        {
                            nlist[i].InnerText = nlist[i - 1].InnerText;
                        }
                        nlist[0].InnerText = value;
                    }
                    if (valuePos == -1)//值不存在
                    {
                        XmlNode newxn = xd.CreateNode(XmlNodeType.Element, b, "");
                        newxn.InnerText = value;
                        nlist[0].ParentNode.InsertBefore(newxn, nlist[0]);
                    }
                }
                xr.Close();
                xd.Save(xmlfile);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 改写单个节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="value"></param>
        public void saveNode(string nodename, string value)
        {
            try
            {
                InitXml();
                XmlNode xn = xd.SelectSingleNode(nodename);
                xn.InnerText = value;
                xr.Close();
                xd.Save(xmlfile); 
            }
            catch
            {
            }
        }

        private int hasNode(string value, XmlNodeList nlist)
        {
            int i = 0;
            foreach (XmlNode xn in nlist)
            {
                if (xn.InnerText == value)//如果已经存在
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        /// <summary>
        /// 删除子节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public int deleteNodes(string nodename)
        {
            try
            {
                InitXml();
                XmlNodeList nlist = xd.SelectNodes(nodename);
                if (nlist.Count >= 1)
                {
                    for (int i = nlist.Count - 1; i >= 0; i--)
                        nlist.Item(i).RemoveAll();
                }
                xr.Close();
                xd.Save(xmlfile);
                return nlist.Count;
            }
            catch
            {
            }
            return 0;
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="fieldname"></param>
        /// <param name="value"></param>
        public void addNode(string nodename, string fieldname, string value)
        {
            try
            {
                InitXml();
                XmlNode xn = getNode(nodename, fieldname);
                xn.InnerText = value;
                DisposeXml();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 添加节点 -- 不改变文档上下文
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="fieldname"></param>
        /// <param name="value"></param>
        public void addNode(XmlNode xn, string fieldname, string value)
        {
            try
            {
                XmlNode newchild = xd.CreateNode(XmlNodeType.Element, fieldname, "");
                newchild.InnerText = value;
                xn.AppendChild(newchild);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 返回新增的节点 -- 使用前必须先初始化
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="fieldname"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public XmlNode getNode(string nodename, string fieldname)
        {
            try
            {
                XmlNode xn = xd.SelectSingleNode(nodename);
                XmlNode newxn = xd.CreateNode(XmlNodeType.Element, fieldname, "");
                xn.AppendChild(newxn);   
                return newxn;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 返回已有的节点 -- 使用前必须先初始化
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="fieldname"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public XmlNode getNode(string nodename)
        {
            try
            {
                XmlNode xn = xd.SelectSingleNode(nodename);                
                xr.Close();
                return xn;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 返回同名父节点的子节点列表。（子节点数必须也一样）
        /// </summary>
        /// <param name="nodename"></param>
        /// <returns></returns>
        public DataTable getNodelist(string nodename)
        {
            try
            {
                InitXml();
                XmlNodeList nlist = xd.SelectNodes(nodename);
                DataTable dt = new DataTable("dtlist");
                
                if (nlist.Count > 0)
                {
                    foreach(XmlNode child in nlist[0].ChildNodes)
                    {
                            dt.Columns.Add(child.Attributes["key"].Value);
                    }
                    foreach (XmlNode xn in nlist)
                    {
                        object[] row = new object[xn.ChildNodes.Count];
                        for (int i = 0; i < row.Length; i++)
                        {
                            row[i] = xn.ChildNodes[i].Attributes["value"].Value;
                        }
                        dt.Rows.Add(row);
                    }
                }
                xr.Close();
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
