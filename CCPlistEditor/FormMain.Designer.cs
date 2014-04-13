namespace CCPlistEditor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewAdvControl = new Aga.Controls.Tree.TreeViewAdv();
            this.nodeIcon = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
            this.nodeTextBox = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.panelDateEditor = new System.Windows.Forms.Panel();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.txtBoxDateName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelDictEditor = new System.Windows.Forms.Panel();
            this.txtBoxDictName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelBoolEditor = new System.Windows.Forms.Panel();
            this.chkBoxBoolValue = new System.Windows.Forms.CheckBox();
            this.txtBoxBoolName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelNumberEditor = new System.Windows.Forms.Panel();
            this.txtBoxNumberValue = new System.Windows.Forms.TextBox();
            this.txtBoxNumberName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelStringEditor = new System.Windows.Forms.Panel();
            this.txtBoxStringValue = new System.Windows.Forms.TextBox();
            this.txtBoxStringName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPublicProperty = new System.Windows.Forms.GroupBox();
            this.btnApplyType = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBoxNodeType = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.publishToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.undoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.addStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDatetimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addArrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.labelErrorMsg = new System.Windows.Forms.Label();
            this.timerErrorMsg = new System.Windows.Forms.Timer(this.components);
            this.imageListToolbar = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelDateEditor.SuspendLayout();
            this.panelDictEditor.SuspendLayout();
            this.panelBoolEditor.SuspendLayout();
            this.panelNumberEditor.SuspendLayout();
            this.panelStringEditor.SuspendLayout();
            this.groupBoxPublicProperty.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewAdvControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelDateEditor);
            this.splitContainer1.Panel2.Controls.Add(this.panelDictEditor);
            this.splitContainer1.Panel2.Controls.Add(this.panelBoolEditor);
            this.splitContainer1.Panel2.Controls.Add(this.panelNumberEditor);
            this.splitContainer1.Panel2.Controls.Add(this.panelStringEditor);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxPublicProperty);
            this.splitContainer1.Size = new System.Drawing.Size(831, 495);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeViewAdvControl
            // 
            this.treeViewAdvControl.AllowDrop = true;
            this.treeViewAdvControl.AsyncExpanding = true;
            this.treeViewAdvControl.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewAdvControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewAdvControl.DefaultToolTipProvider = null;
            this.treeViewAdvControl.DisplayDraggingNodes = true;
            this.treeViewAdvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewAdvControl.DragDropMarkColor = System.Drawing.Color.Black;
            this.treeViewAdvControl.LineColor = System.Drawing.SystemColors.ControlDark;
            this.treeViewAdvControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewAdvControl.Model = null;
            this.treeViewAdvControl.Name = "treeViewAdvControl";
            this.treeViewAdvControl.NodeControls.Add(this.nodeIcon);
            this.treeViewAdvControl.NodeControls.Add(this.nodeTextBox);
            this.treeViewAdvControl.SelectedNode = null;
            this.treeViewAdvControl.SelectionMode = Aga.Controls.Tree.TreeSelectionMode.MultiSameParent;
            this.treeViewAdvControl.ShowNodeToolTips = true;
            this.treeViewAdvControl.Size = new System.Drawing.Size(202, 495);
            this.treeViewAdvControl.TabIndex = 1;
            this.treeViewAdvControl.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewAdvControl_ItemDrag);
            this.treeViewAdvControl.SelectionChanged += new System.EventHandler(this.treeViewAdvControl_SelectionChanged);
            this.treeViewAdvControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewAdvControl_DragDrop);
            this.treeViewAdvControl.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewAdvControl_DragOver);
            // 
            // nodeIcon
            // 
            this.nodeIcon.DataPropertyName = "Image";
            this.nodeIcon.LeftMargin = 1;
            this.nodeIcon.ParentColumn = null;
            this.nodeIcon.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Clip;
            // 
            // nodeTextBox
            // 
            this.nodeTextBox.DataPropertyName = "Text";
            this.nodeTextBox.EditEnabled = true;
            this.nodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeTextBox.IncrementalSearchEnabled = true;
            this.nodeTextBox.LeftMargin = 3;
            this.nodeTextBox.ParentColumn = null;
            // 
            // panelDateEditor
            // 
            this.panelDateEditor.Controls.Add(this.timePicker);
            this.panelDateEditor.Controls.Add(this.datePicker);
            this.panelDateEditor.Controls.Add(this.txtBoxDateName);
            this.panelDateEditor.Controls.Add(this.label9);
            this.panelDateEditor.Controls.Add(this.label10);
            this.panelDateEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDateEditor.Location = new System.Drawing.Point(0, 337);
            this.panelDateEditor.Name = "panelDateEditor";
            this.panelDateEditor.Size = new System.Drawing.Size(625, 68);
            this.panelDateEditor.TabIndex = 6;
            // 
            // timePicker
            // 
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(523, 19);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(90, 22);
            this.timePicker.TabIndex = 4;
            this.timePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(364, 19);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(153, 22);
            this.datePicker.TabIndex = 3;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // txtBoxDateName
            // 
            this.txtBoxDateName.Location = new System.Drawing.Point(85, 21);
            this.txtBoxDateName.Name = "txtBoxDateName";
            this.txtBoxDateName.Size = new System.Drawing.Size(172, 22);
            this.txtBoxDateName.TabIndex = 2;
            this.txtBoxDateName.Leave += new System.EventHandler(this.txtBoxDateName_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Value";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Name";
            // 
            // panelDictEditor
            // 
            this.panelDictEditor.Controls.Add(this.txtBoxDictName);
            this.panelDictEditor.Controls.Add(this.label7);
            this.panelDictEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDictEditor.Location = new System.Drawing.Point(0, 269);
            this.panelDictEditor.Name = "panelDictEditor";
            this.panelDictEditor.Size = new System.Drawing.Size(625, 68);
            this.panelDictEditor.TabIndex = 4;
            // 
            // txtBoxDictName
            // 
            this.txtBoxDictName.Location = new System.Drawing.Point(85, 21);
            this.txtBoxDictName.Name = "txtBoxDictName";
            this.txtBoxDictName.Size = new System.Drawing.Size(172, 22);
            this.txtBoxDictName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name";
            // 
            // panelBoolEditor
            // 
            this.panelBoolEditor.Controls.Add(this.chkBoxBoolValue);
            this.panelBoolEditor.Controls.Add(this.txtBoxBoolName);
            this.panelBoolEditor.Controls.Add(this.label6);
            this.panelBoolEditor.Controls.Add(this.label5);
            this.panelBoolEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBoolEditor.Location = new System.Drawing.Point(0, 201);
            this.panelBoolEditor.Name = "panelBoolEditor";
            this.panelBoolEditor.Size = new System.Drawing.Size(625, 68);
            this.panelBoolEditor.TabIndex = 3;
            // 
            // chkBoxBoolValue
            // 
            this.chkBoxBoolValue.AutoSize = true;
            this.chkBoxBoolValue.Location = new System.Drawing.Point(364, 24);
            this.chkBoxBoolValue.Name = "chkBoxBoolValue";
            this.chkBoxBoolValue.Size = new System.Drawing.Size(54, 20);
            this.chkBoxBoolValue.TabIndex = 3;
            this.chkBoxBoolValue.Text = "YES";
            this.chkBoxBoolValue.UseVisualStyleBackColor = true;
            this.chkBoxBoolValue.CheckedChanged += new System.EventHandler(this.chkBoxBoolValue_CheckedChanged);
            // 
            // txtBoxBoolName
            // 
            this.txtBoxBoolName.Location = new System.Drawing.Point(85, 21);
            this.txtBoxBoolName.Name = "txtBoxBoolName";
            this.txtBoxBoolName.Size = new System.Drawing.Size(172, 22);
            this.txtBoxBoolName.TabIndex = 2;
            this.txtBoxBoolName.Leave += new System.EventHandler(this.txtBoxBoolName_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Name";
            // 
            // panelNumberEditor
            // 
            this.panelNumberEditor.Controls.Add(this.txtBoxNumberValue);
            this.panelNumberEditor.Controls.Add(this.txtBoxNumberName);
            this.panelNumberEditor.Controls.Add(this.label4);
            this.panelNumberEditor.Controls.Add(this.label3);
            this.panelNumberEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNumberEditor.Location = new System.Drawing.Point(0, 133);
            this.panelNumberEditor.Name = "panelNumberEditor";
            this.panelNumberEditor.Size = new System.Drawing.Size(625, 68);
            this.panelNumberEditor.TabIndex = 1;
            // 
            // txtBoxNumberValue
            // 
            this.txtBoxNumberValue.Location = new System.Drawing.Point(364, 21);
            this.txtBoxNumberValue.Name = "txtBoxNumberValue";
            this.txtBoxNumberValue.Size = new System.Drawing.Size(249, 22);
            this.txtBoxNumberValue.TabIndex = 3;
            this.txtBoxNumberValue.Leave += new System.EventHandler(this.txtBoxNumberValue_Leave);
            // 
            // txtBoxNumberName
            // 
            this.txtBoxNumberName.Location = new System.Drawing.Point(85, 21);
            this.txtBoxNumberName.Name = "txtBoxNumberName";
            this.txtBoxNumberName.Size = new System.Drawing.Size(172, 22);
            this.txtBoxNumberName.TabIndex = 2;
            this.txtBoxNumberName.Leave += new System.EventHandler(this.txtBoxNumberName_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // panelStringEditor
            // 
            this.panelStringEditor.Controls.Add(this.txtBoxStringValue);
            this.panelStringEditor.Controls.Add(this.txtBoxStringName);
            this.panelStringEditor.Controls.Add(this.label2);
            this.panelStringEditor.Controls.Add(this.label1);
            this.panelStringEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStringEditor.Location = new System.Drawing.Point(0, 65);
            this.panelStringEditor.Name = "panelStringEditor";
            this.panelStringEditor.Size = new System.Drawing.Size(625, 68);
            this.panelStringEditor.TabIndex = 0;
            // 
            // txtBoxStringValue
            // 
            this.txtBoxStringValue.Location = new System.Drawing.Point(364, 21);
            this.txtBoxStringValue.Name = "txtBoxStringValue";
            this.txtBoxStringValue.Size = new System.Drawing.Size(249, 22);
            this.txtBoxStringValue.TabIndex = 3;
            this.txtBoxStringValue.Leave += new System.EventHandler(this.txtBoxStringValue_Leave);
            // 
            // txtBoxStringName
            // 
            this.txtBoxStringName.Location = new System.Drawing.Point(85, 21);
            this.txtBoxStringName.Name = "txtBoxStringName";
            this.txtBoxStringName.Size = new System.Drawing.Size(172, 22);
            this.txtBoxStringName.TabIndex = 2;
            this.txtBoxStringName.Leave += new System.EventHandler(this.txtBoxStringName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // groupBoxPublicProperty
            // 
            this.groupBoxPublicProperty.Controls.Add(this.btnApplyType);
            this.groupBoxPublicProperty.Controls.Add(this.label8);
            this.groupBoxPublicProperty.Controls.Add(this.cmbBoxNodeType);
            this.groupBoxPublicProperty.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxPublicProperty.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPublicProperty.Name = "groupBoxPublicProperty";
            this.groupBoxPublicProperty.Size = new System.Drawing.Size(625, 65);
            this.groupBoxPublicProperty.TabIndex = 5;
            this.groupBoxPublicProperty.TabStop = false;
            this.groupBoxPublicProperty.Text = "Change item type";
            // 
            // btnApplyType
            // 
            this.btnApplyType.Location = new System.Drawing.Point(206, 24);
            this.btnApplyType.Name = "btnApplyType";
            this.btnApplyType.Size = new System.Drawing.Size(51, 23);
            this.btnApplyType.TabIndex = 2;
            this.btnApplyType.Text = "Apply";
            this.btnApplyType.UseVisualStyleBackColor = true;
            this.btnApplyType.Click += new System.EventHandler(this.btnApplyType_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Type";
            // 
            // cmbBoxNodeType
            // 
            this.cmbBoxNodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxNodeType.FormattingEnabled = true;
            this.cmbBoxNodeType.Items.AddRange(new object[] {
            "dict",
            "array",
            "string",
            "number",
            "bool",
            "datetime"});
            this.cmbBoxNodeType.Location = new System.Drawing.Point(85, 24);
            this.cmbBoxNodeType.Name = "cmbBoxNodeType";
            this.cmbBoxNodeType.Size = new System.Drawing.Size(102, 24);
            this.cmbBoxNodeType.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.publishToolStripButton,
            this.undoToolStripButton,
            this.redoToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator2,
            this.addToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // publishToolStripButton
            // 
            this.publishToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.publishToolStripButton.Image = global::CCPlistEditor.Properties.Resources.publish;
            this.publishToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.publishToolStripButton.Name = "publishToolStripButton";
            this.publishToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.publishToolStripButton.Text = "publish";
            // 
            // undoToolStripButton
            // 
            this.undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoToolStripButton.Image = global::CCPlistEditor.Properties.Resources.undo;
            this.undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolStripButton.Name = "undoToolStripButton";
            this.undoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.undoToolStripButton.Text = "undo";
            this.undoToolStripButton.Click += new System.EventHandler(this.undoToolStripButton_Click);
            // 
            // redoToolStripButton
            // 
            this.redoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoToolStripButton.Image = global::CCPlistEditor.Properties.Resources.redo;
            this.redoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoToolStripButton.Name = "redoToolStripButton";
            this.redoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.redoToolStripButton.Text = "redo";
            this.redoToolStripButton.Click += new System.EventHandler(this.redoToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStringToolStripMenuItem,
            this.addNumberToolStripMenuItem,
            this.addBoolToolStripMenuItem,
            this.addDatetimeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addArrayToolStripMenuItem,
            this.addDictionaryToolStripMenuItem});
            this.addToolStripButton.Image = global::CCPlistEditor.Properties.Resources.addbutton;
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(32, 22);
            this.addToolStripButton.Text = "Add";
            this.addToolStripButton.ButtonClick += new System.EventHandler(this.addToolStripButton_ButtonClick);
            // 
            // addStringToolStripMenuItem
            // 
            this.addStringToolStripMenuItem.Name = "addStringToolStripMenuItem";
            this.addStringToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.addStringToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.addStringToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addStringToolStripMenuItem.Text = "Add String";
            this.addStringToolStripMenuItem.Click += new System.EventHandler(this.addStringToolStripMenuItem_Click);
            // 
            // addNumberToolStripMenuItem
            // 
            this.addNumberToolStripMenuItem.Name = "addNumberToolStripMenuItem";
            this.addNumberToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.addNumberToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addNumberToolStripMenuItem.Text = "Add Number";
            this.addNumberToolStripMenuItem.Click += new System.EventHandler(this.addNumberToolStripMenuItem_Click);
            // 
            // addBoolToolStripMenuItem
            // 
            this.addBoolToolStripMenuItem.Name = "addBoolToolStripMenuItem";
            this.addBoolToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.addBoolToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addBoolToolStripMenuItem.Text = "Add Bool";
            this.addBoolToolStripMenuItem.Click += new System.EventHandler(this.addBoolToolStripMenuItem_Click);
            // 
            // addDatetimeToolStripMenuItem
            // 
            this.addDatetimeToolStripMenuItem.Name = "addDatetimeToolStripMenuItem";
            this.addDatetimeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.addDatetimeToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addDatetimeToolStripMenuItem.Text = "Add DateTime";
            this.addDatetimeToolStripMenuItem.Click += new System.EventHandler(this.addDatetimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
            // 
            // addArrayToolStripMenuItem
            // 
            this.addArrayToolStripMenuItem.Name = "addArrayToolStripMenuItem";
            this.addArrayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.addArrayToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addArrayToolStripMenuItem.Text = "Add Array";
            this.addArrayToolStripMenuItem.Click += new System.EventHandler(this.addArrayToolStripMenuItem_Click);
            // 
            // addDictionaryToolStripMenuItem
            // 
            this.addDictionaryToolStripMenuItem.Name = "addDictionaryToolStripMenuItem";
            this.addDictionaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.addDictionaryToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addDictionaryToolStripMenuItem.Text = "Add Dictionary";
            this.addDictionaryToolStripMenuItem.Click += new System.EventHandler(this.addDictionaryToolStripMenuItem_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = global::CCPlistEditor.Properties.Resources.deletebutton;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // labelErrorMsg
            // 
            this.labelErrorMsg.BackColor = System.Drawing.SystemColors.Info;
            this.labelErrorMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelErrorMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMsg.Location = new System.Drawing.Point(0, 520);
            this.labelErrorMsg.Name = "labelErrorMsg";
            this.labelErrorMsg.Size = new System.Drawing.Size(831, 37);
            this.labelErrorMsg.TabIndex = 2;
            this.labelErrorMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelErrorMsg.Visible = false;
            // 
            // timerErrorMsg
            // 
            this.timerErrorMsg.Interval = 3000;
            this.timerErrorMsg.Tick += new System.EventHandler(this.timerErrorMsg_Tick);
            // 
            // imageListToolbar
            // 
            this.imageListToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolbar.ImageStream")));
            this.imageListToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolbar.Images.SetKeyName(0, "dict");
            this.imageListToolbar.Images.SetKeyName(1, "array");
            this.imageListToolbar.Images.SetKeyName(2, "boolean");
            this.imageListToolbar.Images.SetKeyName(3, "datetime");
            this.imageListToolbar.Images.SetKeyName(4, "number");
            this.imageListToolbar.Images.SetKeyName(5, "text");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(831, 557);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.labelErrorMsg);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property List Editor For Windows";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelDateEditor.ResumeLayout(false);
            this.panelDateEditor.PerformLayout();
            this.panelDictEditor.ResumeLayout(false);
            this.panelDictEditor.PerformLayout();
            this.panelBoolEditor.ResumeLayout(false);
            this.panelBoolEditor.PerformLayout();
            this.panelNumberEditor.ResumeLayout(false);
            this.panelNumberEditor.PerformLayout();
            this.panelStringEditor.ResumeLayout(false);
            this.panelStringEditor.PerformLayout();
            this.groupBoxPublicProperty.ResumeLayout(false);
            this.groupBoxPublicProperty.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Aga.Controls.Tree.TreeViewAdv treeViewAdvControl;
        private Aga.Controls.Tree.NodeControls.NodeStateIcon nodeIcon;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox;
        private System.Windows.Forms.Panel panelBoolEditor;
        private System.Windows.Forms.CheckBox chkBoxBoolValue;
        private System.Windows.Forms.TextBox txtBoxBoolName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelNumberEditor;
        private System.Windows.Forms.TextBox txtBoxNumberValue;
        private System.Windows.Forms.TextBox txtBoxNumberName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelStringEditor;
        private System.Windows.Forms.TextBox txtBoxStringValue;
        private System.Windows.Forms.TextBox txtBoxStringName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton addToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem addStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBoolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addArrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addDictionaryToolStripMenuItem;
        private System.Windows.Forms.Panel panelDictEditor;
        private System.Windows.Forms.TextBox txtBoxDictName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxPublicProperty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBoxNodeType;
        private System.Windows.Forms.Button btnApplyType;
        private System.Windows.Forms.Label labelErrorMsg;
        private System.Windows.Forms.Timer timerErrorMsg;
        private System.Windows.Forms.ToolStripMenuItem addDatetimeToolStripMenuItem;
        private System.Windows.Forms.Panel panelDateEditor;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox txtBoxDateName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ImageList imageListToolbar;
        private System.Windows.Forms.ToolStripButton publishToolStripButton;
        private System.Windows.Forms.ToolStripButton undoToolStripButton;
        private System.Windows.Forms.ToolStripButton redoToolStripButton;

    }
}

