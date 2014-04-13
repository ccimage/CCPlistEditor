using Aga.Controls.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCPlistEditor
{
    public class CCClipBoard
    {
        #region clipboard space
        PlistDataTree tree = new PlistDataTree();
        #endregion
        //singleton
        static CCClipBoard _clip = new CCClipBoard();
        private CCClipBoard()
        {

        }
        public static CCClipBoard SingletonInstance()
        {
            return _clip;
        }
        public void SaveToPrivateClip(TreeNodeAdv selectedNode, TreeNodeAdv parentNode)
        {
            PlistNodeData data = GetNodeData(selectedNode);
            PlistNodeData dataParent = GetNodeData(parentNode);
            if(parentNode == null)
            {
                tree.ClearTree();
                tree.AddRootNode(data);
            }
            else
            {
                tree.AddPlistNodeData(dataParent, data);
            }

            if (data.nodeType == Constant.NodeTypeDefine.dict || data.nodeType == Constant.NodeTypeDefine.array)
            {
                foreach (TreeNodeAdv nodeadvchild in selectedNode.Children)
                {
                    SaveToPrivateClip(nodeadvchild, selectedNode);
                }
            }
        }
        public bool PasteClip(TreeModel model, System.Windows.Forms.ImageList imagelist)
        {
            if (string.IsNullOrEmpty(tree.rootkey))
            {
                return false;
            }
            PlistNodeData data = tree.GetDataByUniqueKey(tree.rootkey);
            Node parentNode = new PlistNode(data.key);
            model.Nodes.Add(parentNode);
            parentNode.Image = imagelist.Images[data.nodeType.ToString()];
            parentNode.Tag = data.DeepCopy();
            foreach (string key in tree.nodeRelationship.Keys)
            {
                if (key == tree.rootkey)
                {
                    List<string> childrenkey = tree.nodeRelationship[key];
                    foreach (string childkey in childrenkey)
                    {
                        DrawChildNode(parentNode, tree.GetDataByUniqueKey(childkey),imagelist);
                    }
                }
            }

            return true;
        }
        public bool PasteClip(TreeNodeAdv selectedNode, System.Windows.Forms.ImageList imagelist)
        {
            if(string.IsNullOrEmpty(tree.rootkey))
            {
                return false;
            }
            Node parentNode = selectedNode.Tag as Node;
            DrawChildNode(parentNode, tree.GetDataByUniqueKey(tree.rootkey), imagelist);

            return true;
        }
        private void DrawChildNode(Node parentNode, PlistNodeData data, System.Windows.Forms.ImageList imagelist)
        {
            Node nodeAdded = new PlistNode(data.key);
            parentNode.Nodes.Add(nodeAdded);
            nodeAdded.Tag = data.DeepCopy();
            nodeAdded.Image = imagelist.Images[data.nodeType.ToString()];
            if(!tree.nodeRelationship.ContainsKey(data.uniquekey))
            {
                return;
            }
            foreach(string key in tree.nodeRelationship.Keys)
            {
                if(key == data.uniquekey)
                {
                    List<string> childrenkey = tree.nodeRelationship[key];
                    foreach(string childkey in childrenkey)
                    {
                        DrawChildNode(nodeAdded, tree.GetDataByUniqueKey(childkey), imagelist);
                    }
                }
            }
        }
        PlistNodeData GetNodeData(TreeNodeAdv nodeadv)
        {
            if (nodeadv != null && nodeadv.Tag != null)
            {
                Node node = nodeadv.Tag as Node;
                if (node.Tag != null)
                {
                    PlistNodeData data = node.Tag as PlistNodeData;
                    return data;
                }
            }
            return null;
        }
    }
}
