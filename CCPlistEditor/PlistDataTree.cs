using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCPlistEditor
{

    public class PlistDataTree
    {
        public List<PlistNodeData> nodeList = new List<PlistNodeData>();
        public Dictionary<string, List<string>> nodeRelationship = new Dictionary<string, List<string>>();
        public string rootkey;
        long index = 0;
        public void AddRootNode(PlistNodeData root)
        {
            nodeList.Add(root);
            root.uniquekey = makeUniqueKey();
            rootkey = root.uniquekey;
        }
        public void AddPlistNodeData(PlistNodeData parent, PlistNodeData child)
        {
            foreach (PlistNodeData node in nodeList)
            {
                if (node.uniquekey == parent.uniquekey)
                {
                    child.uniquekey = makeUniqueKey();
                    nodeList.Add(child);
                    
                    if (!nodeRelationship.ContainsKey(parent.uniquekey))
                    {
                        List<string> childList = new List<string>();
                        childList.Add(child.uniquekey);
                        nodeRelationship.Add(parent.uniquekey, childList);
                    }
                    else
                    {
                        List<string> childList = nodeRelationship[parent.uniquekey];
                        childList.Add(child.uniquekey);
                        nodeRelationship[parent.uniquekey] = childList;
                    }
                    
                    return;
                }
            }
            throw new Exception("parent node not find, this could not happen.");
        }
        public void ClearTree()
        {
            index = 0;
            rootkey = "";
            nodeList.Clear();
            nodeRelationship.Clear();
        }
        private string makeUniqueKey()
        {
            index++;
            return string.Format("uuid_plistdatatree_{0}", index - 1);
        }

        public PlistNodeData GetDataByUniqueKey(string key)
        {
            foreach(PlistNodeData data in nodeList)
            {
                if(data.uniquekey == key)
                {
                    return data;
                }
            }
            return null;
        }
    }
}
