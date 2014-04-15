/*
 * XML Class  ��Written by ZhangChuan
 * #####  not throw out any exception ####### 
 * So Notice That��
 * 1.xmlfile must be the right filename of your xml file.
 * 2.for some methods with no initxml(),initxml before call this.
 * 3.for some methods with no disposexml(),dipose after;
 * 4.�����ε��ö�û��dispose������Ϊͬһ���ĵ�������
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
        /// ��ʼ��xml�ļ�
        /// </summary>
        /// <param name="xmlfile">�ļ�·��</param>
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
        /// ���keyָ����value
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
        /// ���keyָ����value
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
        /// ��ö����ͬ�ڵ�� keyָ����value
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
        /// ��õ������
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
        /// ��ö������
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
        /// ��ñ�ǩ������,����ָ����ֵ �� ��abc ee='1'>2 ��/abc��ͨ����ǩabc��ָ��ee���� 2,1
        /// ��ǩ�����ݵĽ�����һ����ֵ��
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
        /// ����ڵ� ֱ��������������ڱ����¼��
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
                if (nodecount <= 0)//ֵΪ0
                {
                    xr.Close();
                    addNode(a, b, value);
                    return;
                }
                else if (nodecount >= maxnode)//ֵ�Ѿ�������
                {
                    //ֵλ��
                    int valuePos = hasNode(value, nlist);
                    if (valuePos > 0)//�����ֵ�ˣ��Ҳ����ڵ�һ������������
                    {
                        for (int i = valuePos; i > 0; i--)
                        {
                            nlist[i].InnerText = nlist[i - 1].InnerText;
                        }
                        nlist[0].InnerText = value;
                    }
                    if (valuePos == -1)//ֵ������
                    {
                        for (int i = maxnode - 1; i > 0; i--)
                        {
                            nlist[i].InnerText = nlist[i - 1].InnerText;
                        }
                        nlist[0].InnerText = value;
                    }
                }
                else//ֵ��û��
                {

                    //ֵλ��
                    int valuePos = hasNode(value, nlist);
                    if (valuePos > 0)//�����ֵ�ˣ��Ҳ����ڵ�һ������������
                    {
                        for (int i = valuePos; i > 0; i--)
                        {
                            nlist[i].InnerText = nlist[i - 1].InnerText;
                        }
                        nlist[0].InnerText = value;
                    }
                    if (valuePos == -1)//ֵ������
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
        /// ��д�����ڵ�
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
                if (xn.InnerText == value)//����Ѿ�����
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        /// <summary>
        /// ɾ���ӽڵ�
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
        /// ��ӽڵ�
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
        /// ��ӽڵ� -- ���ı��ĵ�������
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
        /// ���������Ľڵ� -- ʹ��ǰ�����ȳ�ʼ��
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
        /// �������еĽڵ� -- ʹ��ǰ�����ȳ�ʼ��
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
        /// ����ͬ�����ڵ���ӽڵ��б����ӽڵ�������Ҳһ����
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
