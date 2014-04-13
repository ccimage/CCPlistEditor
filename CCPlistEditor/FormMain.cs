using Aga.Controls.Tree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CCPlistEditor
{
    public partial class FormMain : Form
    {
        #region property for data exchange
        private TreeModel _model;
        #endregion

        #region settings/temp variants for application
        bool haveUnsavedChanges = false;
        #endregion
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            // hide edit panels
            HideEditPanels();

            // init tree view control
            InitTreeView();
            RefreshButtonState();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseWithoutSave())
            {
                e.Cancel = true;
            }
        }
        #region TreeView
        void InitTreeView()
        {
            treeViewAdvControl.NodeMouseClick += new EventHandler<TreeNodeAdvMouseEventArgs>(treeViewAdvControle_NodeMouseClick);
            _model = new TreeModel();
            _model.NodesChanged += _model_NodesChanged;
            treeViewAdvControl.Model = _model;
        }
        private PlistNodeData InitNodeData(string nodename)
        {
            Constant.NodeTypeDefine nodetype = GetTypeFromName(nodename);

            return InitNodeData(nodetype, nodename);
        }
        private PlistNodeData InitNodeData(Constant.NodeTypeDefine nodetype, string key)
        {
            PlistNodeData data = new PlistNodeData();
            data.nodeType = nodetype;
            data.key = key;
            return data;
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
        private Node AddRoot(string nodename)
        {
            Node node = new PlistNode(nodename);
            _model.Nodes.Add(node);
            return node;
        }

        private Node AddChild(Node parent, string nodename)
        {
            Node node = new PlistNode(nodename);
            parent.Nodes.Add(node);
            return node;
        }
        #endregion
        #region tree view events
        void _model_NodesChanged(object sender, TreeModelEventArgs e)
        {
            UpdateDataKey();
        }
        private void treeViewAdvControle_NodeMouseClick(object sender, TreeNodeAdvMouseEventArgs e)
        {
            //Console.WriteLine("NodeMouseClick at " + e.Node.Index.ToString());
        }
        private void treeViewAdvControl_SelectionChanged(object sender, EventArgs e)
        {
            RefreshButtonState();
            RefreshEditPanel();
        }
        private void UpdateDataKey()
        {
            TreeNodeAdv nodeadv = treeViewAdvControl.SelectedNode;
            if(nodeadv != null)
            {
                PlistNodeData data = GetNodeData(nodeadv);
                data.key = (nodeadv.Tag as Node).Text;
                RefreshKey(data);
            }
        }
        #endregion

        #region Command Control 
        private void HideEditPanels()
        {
            foreach (Control ctrl in splitContainer1.Panel2.Controls)
            {
                if (ctrl is Panel)
                {
                    ctrl.Visible = false;
                }
            }
        }
        private void RefreshButtonState()
        {
            deleteToolStripButton.Enabled = (treeViewAdvControl.SelectedNode != null);
        }
        private void RefreshEditPanel()
        {
            HideEditPanels();
            if(treeViewAdvControl.SelectedNode == null)
            {
                return;
            }
            PlistNodeData data = GetNodeData(treeViewAdvControl.SelectedNode);
            if(data == null)
            {
                _DataNULLException();
            }
            bool isArray = false;
            PlistNodeData datatemp = GetNodeData(treeViewAdvControl.SelectedNode.Parent);
            if (datatemp != null)
            {
                isArray = datatemp.nodeType == Constant.NodeTypeDefine.array;
            }
            
            ShowEditPanel(data, isArray);
            int index = cmbBoxNodeType.Items.IndexOf(GetNameFromType(data.nodeType));
            if(index >= 0)
            {
                cmbBoxNodeType.SelectedIndex = index;
            }
        }
        private void ShowEditPanel(PlistNodeData data, bool isArray = false)
        {
            switch(data.nodeType)
            {
                case Constant.NodeTypeDefine.dict:
                    panelDictEditor.Visible = true;
                    txtBoxDictName.Text = data.key;
                    break;
                case Constant.NodeTypeDefine.datetime:
                    panelDateEditor.Visible = true;
                    txtBoxDateName.Text = data.key;
                    datePicker.Value = data.value_date;
                    timePicker.Value = data.value_date;
                    txtBoxDateName.Enabled = !isArray;
                    break;
                case Constant.NodeTypeDefine.boolean:
                    panelBoolEditor.Visible = true;
                    txtBoxBoolName.Text = data.key;
                    chkBoxBoolValue.Checked = data.value_bool;
                    txtBoxBoolName.Enabled = !isArray;
                    break;
                case Constant.NodeTypeDefine.number:
                    panelNumberEditor.Visible = true;
                    txtBoxNumberName.Text = data.key;
                    txtBoxNumberValue.Text = data.value_number.ToString();
                    txtBoxNumberName.Enabled = !isArray;
                    break;
                case Constant.NodeTypeDefine.text:
                    panelStringEditor.Visible = true;
                    txtBoxStringName.Text = data.key;
                    txtBoxStringValue.Text = data.value_string;
                    txtBoxStringName.Enabled = !isArray;
                    break;
                default:
                    return;
            }
        }
        private void RefreshKey(PlistNodeData data)
        {
            switch (data.nodeType)
            {
                case Constant.NodeTypeDefine.dict:
                    txtBoxDictName.Text = data.key;
                    break;
                case Constant.NodeTypeDefine.array:
                    //
                    break;
                case Constant.NodeTypeDefine.boolean:
                    txtBoxBoolName.Text = data.key;
                    break;
                case Constant.NodeTypeDefine.number:
                    txtBoxNumberName.Text = data.key;
                    break;
                case Constant.NodeTypeDefine.text:
                    txtBoxStringName.Text = data.key;
                    break;
                case Constant.NodeTypeDefine.datetime:
                    txtBoxDateName.Text = data.key;
                    break;
                default:
                    return;
            }
        }
        private void RefreshTreeIcon(Constant.NodeTypeDefine nodeType)
        {
            Node nodeSelected = (treeViewAdvControl.SelectedNode.Tag as Node);
            nodeSelected.Image = imageListToolbar.Images[nodeType.ToString()];
        }
        #endregion

        #region Command Control Events        
        #region Toolbar & Menu
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (CloseWithoutSave())
            {
                treeViewAdvControl.BeginUpdate();
                _model.Nodes.Clear();
                treeViewAdvControl.EndUpdate();
                haveUnsavedChanges = false;
            }
        }
        private void addDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNode();
        }

        private void addToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            addStringToolStripMenuItem_Click(null, null);
        }
        private void addStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNode("string");
        }

        private void addNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNode("number");
        }
        private void addBoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNode("bool");
        }
        private void addArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNode("array");
        }
        private void addDatetimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNode("datetime");
        }
        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (treeViewAdvControl.SelectedNode == null)
            {
                return;
            }
            (treeViewAdvControl.SelectedNode.Tag as Node).Parent = null;
            haveUnsavedChanges = true;
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (!CloseWithoutSave())
            {
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(plist file *.plist)|*.plist";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                treeViewAdvControl.BeginUpdate();
                _model.Nodes.Clear();
                XDocument xmldoc = XDocument.Load(dlg.FileName);
                if (xmldoc != null || xmldoc.Root.Name.LocalName == "dict")
                {
                    XDocParser(xmldoc);
                }
                treeViewAdvControl.EndUpdate();
            }

        }
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
        #region save file
        bool SaveFile()
        {
            toolStrip1.Focus();

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(plist file *.plist)|*.plist";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XDocument xmldoc = XDocument.Load(Application.StartupPath + "\\empty.plist");
                XElement child = new XElement("dict");
                xmldoc.Root.Add(child);

                foreach (TreeNodeAdv nodeadv in treeViewAdvControl.Root.Children)
                {
                    FetchNodeData(nodeadv, child, false);
                }

                if (xmldoc.DocumentType != null)
                {
                    xmldoc.DocumentType.InternalSubset = null;
                }
                //xmldoc.Save(Console.Out);
                xmldoc.Save(dlg.FileName);
                haveUnsavedChanges = false;
                return true;
            }
            return false;
        }
        void FetchNodeData(TreeNodeAdv parentNode, XElement xmlElm, bool parentIsArray)
        {
            PlistNodeData data = GetNodeData(parentNode);
            if (data == null)
            {
                _DataNULLException();
            }

            if (data.nodeType == Constant.NodeTypeDefine.dict)
            {
                XElement dict = AddDictItem(xmlElm, data.key, parentIsArray);
                foreach (TreeNodeAdv nodeadvchild in parentNode.Children)
                {
                    FetchNodeData(nodeadvchild, dict, false);
                }
            }
            else if (data.nodeType == Constant.NodeTypeDefine.array)
            {
                XElement array = AddArrayContainerItem(xmlElm, data.key, parentIsArray);
                foreach (TreeNodeAdv nodeadvchild in parentNode.Children)
                {
                    PlistNodeData childdata = GetNodeData(nodeadvchild);
                    FetchNodeData(nodeadvchild, array, true);
                }
            }
            else if (data.nodeType == Constant.NodeTypeDefine.boolean)
            {
                if(!parentIsArray)
                {
                    xmlElm.Add(new XElement("key", data.key));
                }
                
                if (data.value_bool)
                {
                    xmlElm.Add(new XElement("true"));
                }
                else
                {
                    xmlElm.Add(new XElement("false"));
                }
            }
            else
            {
                AddValueItem(xmlElm, data, parentIsArray);
            }
        }
        bool HaveUnsavedContent()
        {
            return haveUnsavedChanges;
        }
        bool CloseWithoutSave()
        {
            if (HaveUnsavedContent())
            {
                System.Windows.Forms.DialogResult res = MessageBox.Show("Do you want to save the file before close it?",
                "WARNING: File not save", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    return SaveFile();
                }
                else if (res == System.Windows.Forms.DialogResult.No)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (treeViewAdvControl.SelectedNode == null)
            {
                ShowErrorMsg("nothing selected.");
                return;
            }

            CCClipBoard clip = CCClipBoard.SingletonInstance();
            clip.SaveToPrivateClip(treeViewAdvControl.SelectedNode, null);

            (treeViewAdvControl.SelectedNode.Tag as Node).Parent = null;
            haveUnsavedChanges = true;
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            if(treeViewAdvControl.SelectedNode == null)
            {
                ShowErrorMsg("nothing selected.");
                return;
            }

            CCClipBoard clip = CCClipBoard.SingletonInstance();
            clip.SaveToPrivateClip(treeViewAdvControl.SelectedNode, null);
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            CCClipBoard clip = CCClipBoard.SingletonInstance();

            if(treeViewAdvControl.SelectedNode == null)
            {
                if(clip.PasteClip(_model, imageListToolbar))
                {
                    haveUnsavedChanges = true;
                }
                return;
            }
            Node parent = treeViewAdvControl.SelectedNode.Tag as Node;
            PlistNodeData data = GetNodeData(treeViewAdvControl.SelectedNode);
            if (!CheckAddNodePossible(data.nodeType))
            {
                ShowErrorMsg("Can not add child node here.");
                return;
            }

            if (clip.PasteClip(treeViewAdvControl.SelectedNode, imageListToolbar))
            {
                haveUnsavedChanges = true;
            }
        }

        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            ShowErrorMsg("function/feature not finished.");
        }

        private void redoToolStripButton_Click(object sender, EventArgs e)
        {
            ShowErrorMsg("function/feature not finished.");
        }
        #region
        void AddNode(string nodename = "")
        {
            if (string.IsNullOrEmpty(nodename))
            {
                nodename = "dict";
            }
            Node nodeAdded = null;
            if (treeViewAdvControl.SelectedNode != null)
            {
                Node parent = treeViewAdvControl.SelectedNode.Tag as Node;
                PlistNodeData data = GetNodeData(treeViewAdvControl.SelectedNode);
                if (!CheckAddNodePossible(data.nodeType))
                {
                    ShowErrorMsg("Can not add child node here.");
                    return;
                }
                nodeAdded = AddChild(parent, nodename);
            }
            else
            {
                nodeAdded = AddRoot(nodename);
            }
            PlistNodeData nodedata = InitNodeData(nodename);
            nodeAdded.Tag = nodedata;
            nodeAdded.Image = imageListToolbar.Images[nodedata.nodeType.ToString()];
            haveUnsavedChanges = true;
        }
        bool CheckAddNodePossible(Constant.NodeTypeDefine selectedType)
        {
            if (selectedType == Constant.NodeTypeDefine.dict || selectedType == Constant.NodeTypeDefine.array)
            {
                return true;
            }
            return false;
        }
        Constant.NodeTypeDefine GetTypeFromName(string name)
        {
            Constant.NodeTypeDefine nodetype = Constant.NodeTypeDefine.unknown;
            switch (name)
            {
                case "dict":
                    nodetype = Constant.NodeTypeDefine.dict;
                    break;
                case "string":
                    nodetype = Constant.NodeTypeDefine.text;
                    break;
                case "number":
                case "integer":
                case "real":
                    nodetype = Constant.NodeTypeDefine.number;
                    break;
                case "bool":
                    nodetype = Constant.NodeTypeDefine.boolean;
                    break;
                case "array":
                    nodetype = Constant.NodeTypeDefine.array;
                    break;
                case "datetime":
                case "date":
                    nodetype = Constant.NodeTypeDefine.datetime;
                    break;
                default:
                    nodetype = Constant.NodeTypeDefine.unknown;
                    break;
            }
            return nodetype;
        }
        #endregion
        #endregion
        #region Editor Panel
        private void btnApplyType_Click(object sender, EventArgs e)
        {
            if (cmbBoxNodeType.SelectedIndex < 0)
            {
                return;
            }
            if (treeViewAdvControl.SelectedNode == null)
            {
                ShowErrorMsg("Not any node is selected.");
                return;
            }
            Constant.NodeTypeDefine newtype = GetTypeFromName(cmbBoxNodeType.SelectedItem.ToString());
            PlistNodeData data = GetNodeData(treeViewAdvControl.SelectedNode);
            if(data.nodeType == newtype)
            {
                return;
            }
            object oldvalue = data.GetOldValue();
            data.nodeType = newtype;
            data.SetNewValue(oldvalue);
            RefreshEditPanel();
            RefreshTreeIcon(newtype);
        }
        private void txtBoxStringValue_Leave(object sender, EventArgs e)
        {
            if (treeViewAdvControl.SelectedNode == null)
            {
                return;
            }
            TreeNodeAdv nodeadv = treeViewAdvControl.SelectedNode;

            PlistNodeData data = GetNodeData(nodeadv);
            if (data.value_string != txtBoxStringValue.Text)
            {
                data.value_string = txtBoxStringValue.Text;
                haveUnsavedChanges = true;
            }
        }
        private void txtBoxStringName_Leave(object sender, EventArgs e)
        {
            UpdateKey(sender as TextBox);
        }
        private void txtBoxNumberValue_Leave(object sender, EventArgs e)
        {
            if (treeViewAdvControl.SelectedNode == null)
            {
                return;
            }

            decimal num = 0;
            if (!decimal.TryParse(txtBoxNumberValue.Text, out num))
            {
                txtBoxNumberValue.Text = "0";
                ShowErrorMsg("It's not a number.");
                return;
            }


            TreeNodeAdv nodeadv = treeViewAdvControl.SelectedNode;
            PlistNodeData data = GetNodeData(nodeadv);
            if (data.value_number != num)
            {
                data.value_number = num;
                haveUnsavedChanges = true;
            }
        }
        private void txtBoxNumberName_Leave(object sender, EventArgs e)
        {
            UpdateKey(sender as TextBox);
        }
        private void chkBoxBoolValue_CheckedChanged(object sender, EventArgs e)
        {
            if (treeViewAdvControl.SelectedNode == null)
            {
                return;
            }
            TreeNodeAdv nodeadv = treeViewAdvControl.SelectedNode;
            PlistNodeData data = GetNodeData(nodeadv);
            data.value_bool = chkBoxBoolValue.Checked;
            haveUnsavedChanges = true;
        }
        private void txtBoxBoolName_Leave(object sender, EventArgs e)
        {
            UpdateKey(sender as TextBox);
        }
        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            if (treeViewAdvControl.SelectedNode == null)
            {
                return;
            }
            TreeNodeAdv nodeadv = treeViewAdvControl.SelectedNode;
            PlistNodeData data = GetNodeData(nodeadv);
            data.value_date = datePicker.Value.Date.AddHours(timePicker.Value.Hour)
                .AddMinutes(timePicker.Value.Minute).AddSeconds(timePicker.Value.Second);
            haveUnsavedChanges = true;
        }
        private void txtBoxDateName_Leave(object sender, EventArgs e)
        {
            UpdateKey(sender as TextBox);
        }
        void UpdateKey(TextBox txtBox)
        {
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                txtBox.Undo();
                ShowErrorMsg("Node name can not be null.");
                return;
            }
            if (treeViewAdvControl.SelectedNode == null)
            {
                return;
            }
            TreeNodeAdv nodeadv = treeViewAdvControl.SelectedNode;
            (nodeadv.Tag as Node).Text = txtBox.Text;
            haveUnsavedChanges = true;
        }
        string GetNameFromType(Constant.NodeTypeDefine type)
        {
            string name = "";
            switch (type)
            {
                case Constant.NodeTypeDefine.dict:
                    name = "dict";
                    break;
                case Constant.NodeTypeDefine.text:
                    name = "string";
                    break;
                case Constant.NodeTypeDefine.number:
                    name = "number";
                    break;
                case Constant.NodeTypeDefine.boolean:
                    name = "bool";
                    break;
                case Constant.NodeTypeDefine.array:
                    name = "array";
                    break;
                case Constant.NodeTypeDefine.datetime:
                    name = "datetime";
                    break;
                default:
                    break;
            }
            return name;
        }
        #endregion
        #region Drag & Drop
        private void treeViewAdvControl_DragDrop(object sender, DragEventArgs e)
        {
            TreeViewAdv _tree = treeViewAdvControl;
            _tree.BeginUpdate();

            TreeNodeAdv[] nodes = (TreeNodeAdv[])e.Data.GetData(typeof(TreeNodeAdv[]));
            Node dropNode = _tree.DropPosition.Node.Tag as Node;
            if (_tree.DropPosition.Position == NodePosition.Inside)
            {
                foreach (TreeNodeAdv n in nodes)
                {
                    (n.Tag as Node).Parent = dropNode;
                }
                _tree.DropPosition.Node.IsExpanded = true;
            }
            else
            {
                Node parent = dropNode.Parent;
                Node nextItem = dropNode;
                if (_tree.DropPosition.Position == NodePosition.After)
                    nextItem = dropNode.NextNode;

                foreach (TreeNodeAdv node in nodes)
                    (node.Tag as Node).Parent = null;

                int index = -1;
                index = parent.Nodes.IndexOf(nextItem);
                foreach (TreeNodeAdv node in nodes)
                {
                    Node item = node.Tag as Node;
                    if (index == -1)
                        parent.Nodes.Add(item);
                    else
                    {
                        parent.Nodes.Insert(index, item);
                        index++;
                    }
                }
            }

            _tree.EndUpdate();
        }
        private void treeViewAdvControl_ItemDrag(object sender, ItemDragEventArgs e)
        {
            treeViewAdvControl.DoDragDropSelectedNodes(DragDropEffects.Move);
        }
        private void treeViewAdvControl_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNodeAdv[])) && treeViewAdvControl.DropPosition.Node != null)
            {
                TreeNodeAdv[] nodes = e.Data.GetData(typeof(TreeNodeAdv[])) as TreeNodeAdv[];
                TreeNodeAdv parent = treeViewAdvControl.DropPosition.Node;
                if (treeViewAdvControl.DropPosition.Position != NodePosition.Inside)
                    parent = parent.Parent;

                foreach (TreeNodeAdv node in nodes)
                    if (!CheckNodeParent(parent, node))
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }

                e.Effect = e.AllowedEffect;
            }
        }
        private bool CheckNodeParent(TreeNodeAdv parent, TreeNodeAdv node)
        {
            while (parent != null)
            {
                if (node == parent)
                    return false;
                else
                    parent = parent.Parent;
            }
            return true;
        }
        #endregion
        private void timerErrorMsg_Tick(object sender, EventArgs e)
        {
            labelErrorMsg.Visible = false;
            timerErrorMsg.Enabled = false;
        }
        #endregion

        #region Read/write xml
        private XElement AddDictItem(XElement parent, string name, bool parentIsArray)
        {
            if(!parentIsArray)
            {
                parent.Add(new XElement("key", name));
            }
            
            XElement child = new XElement("dict");
            parent.Add(child);
            return child;
        }
        private XElement AddArrayContainerItem(XElement parent, string name, bool parentIsArray)
        {
            if (!parentIsArray)
            {
                parent.Add(new XElement("key", name));
            }

            XElement child = new XElement("array");
            parent.Add(child);
            return child;
        }
        private void AddValueItem(XElement parent, PlistNodeData data, bool parentIsArray)
        {
            if(!parentIsArray)
            {
                parent.Add(new XElement("key", data.key));
            }

            XElement child = new XElement(GetKeyPlainText(data));
            switch (data.nodeType)
            {
                case Constant.NodeTypeDefine.boolean:
                    child.SetValue(data.value_bool);
                    break;
                case Constant.NodeTypeDefine.number:
                    child.SetValue(data.value_number);
                    break;
                case Constant.NodeTypeDefine.text:
                    if (data.value_string != null)
                    {
                        child.SetValue(data.value_string);
                    }

                    break;
                case Constant.NodeTypeDefine.datetime:
                    child.SetValue(data.value_date.ToUniversalTime().ToString(Constant.datetimeformat));
                    break;
                default:
                    return;
            }
            parent.Add(child);
        }
 
        private string GetKeyPlainText(PlistNodeData data)
        {
            if (data.nodeType == Constant.NodeTypeDefine.boolean)
            {
                return "bool";
            }
            else if (data.nodeType == Constant.NodeTypeDefine.text)
            {
                return "string";
            }
            else if (data.nodeType == Constant.NodeTypeDefine.number)
            {
                long d = 0;
                if (long.TryParse(data.value_number.ToString(), out d))
                {
                    return "integer";
                }
                else
                {
                    return "real";
                }
            }
            else if (data.nodeType == Constant.NodeTypeDefine.datetime)
            {
                return "date";
            }
            return data.nodeType.ToString();
        }
        private void XDocParser(XDocument xmldoc)
        {
            XElement topdict = xmldoc.Root.Element("dict");

            XElementParser(topdict);
        }
        private bool XElementParser(XElement xelement, Node parent = null)
        {
            if (xelement == null)
            {
                return false;
            }
            foreach (XElement xe in xelement.Elements())
            {
                if (xe.Name.LocalName == "key")
                {
                    if (xe.ElementsAfterSelf().Count() <= 0)
                    {
                        MessageBox.Show("File must be not correct. Please check it.");
                        return false;
                    }
                    string key = xe.Value;
                    XElement xeValue = xe.ElementsAfterSelf().First();
                    Node node = DataParser(key, xeValue, parent);
                    if (xeValue.Name.LocalName == "dict")
                    {
                        XElementParser(xeValue, node);
                    }
                    else if (xeValue.Name.LocalName == "array")
                    {
                        ArrayParser(xeValue, node);
                    }
                }
            }
            return true;
        }
        private void ArrayParser(XElement xelement, Node parent = null)
        {
            foreach (XElement xe in xelement.Elements())
            {
                Node node = DataParser("item", xe, parent);
                if (xe.Name.LocalName == "dict")
                {
                    XElementParser(xe, node);
                }
                else if (xe.Name.LocalName == "array")
                {
                    ArrayParser(xe, node);
                }
            }
        }
        private Node DataParser(string key, XElement xe, Node parent = null)
        {
            Node nodeAdded = parent == null ? AddRoot(key) : AddChild(parent, key);
            Constant.NodeTypeDefine nodetype = GetTypeFromName(xe.Name.LocalName);
            PlistNodeData data = InitNodeData(nodetype, key);
            switch (nodetype)
            {
                case Constant.NodeTypeDefine.boolean:
                    data.value_bool = Convert.ToBoolean(xe.Value);
                    break;
                case Constant.NodeTypeDefine.number:
                    data.value_number = Convert.ToDecimal(xe.Value);
                    break;
                case Constant.NodeTypeDefine.text:
                    data.value_string = xe.Value;
                    break;
                case Constant.NodeTypeDefine.datetime:
                    data.value_date = Convert.ToDateTime(xe.Value);
                    break;
                default:
                    break;
            }
            nodeAdded.Tag = data;
            nodeAdded.Image = imageListToolbar.Images[data.nodeType.ToString()];
            return nodeAdded;
        }
        #endregion

        #region exceptions
        void _DataNULLException()
        {
            throw new Exception("UNKOWN EXCEPTION : data is missing in the selected node!");
        }
        void ShowErrorMsg(string error)
        {
            timerErrorMsg.Enabled = false;
            labelErrorMsg.Text = error;
            labelErrorMsg.Visible = true;
            timerErrorMsg.Enabled = true;
        }
        #endregion 
    }
}
