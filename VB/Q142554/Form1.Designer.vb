Namespace Q142554
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			Me.colName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.colPriority = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
			Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.panelControl2 = New DevExpress.XtraEditors.PanelControl()
			Me.listBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelControl1.SuspendLayout()
			CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelControl2.SuspendLayout()
			CType(Me.listBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' treeList1
			' 
			Me.treeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() { Me.colName, Me.colPriority})
			Me.treeList1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList1.Location = New System.Drawing.Point(0, 0)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.OptionsBehavior.AllowIndeterminateCheckState = True
			Me.treeList1.OptionsView.ShowCheckBoxes = True
			Me.treeList1.ParentFieldName = "ID_2"
			Me.treeList1.Size = New System.Drawing.Size(373, 398)
			Me.treeList1.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.treeList1.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.OnTreeListBeforeCheckNode);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.treeList1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.OnTreeListAfterCheckNode);
			' 
			' colName
			' 
			Me.colName.Caption = "Name"
			Me.colName.FieldName = "Name"
			Me.colName.Name = "colName"
			Me.colName.Visible = True
			Me.colName.VisibleIndex = 0
			Me.colName.Width = 198
			' 
			' colPriority
			' 
			Me.colPriority.Caption = "Priority"
			Me.colPriority.FieldName = "Priority"
			Me.colPriority.Name = "colPriority"
			Me.colPriority.Visible = True
			Me.colPriority.VisibleIndex = 1
			Me.colPriority.Width = 197
			' 
			' panelControl1
			' 
			Me.panelControl1.Controls.Add(Me.simpleButton2)
			Me.panelControl1.Controls.Add(Me.simpleButton1)
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panelControl1.Location = New System.Drawing.Point(0, 398)
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(373, 36)
			Me.panelControl1.TabIndex = 1
			' 
			' simpleButton2
			' 
			Me.simpleButton2.Location = New System.Drawing.Point(130, 5)
			Me.simpleButton2.Name = "simpleButton2"
			Me.simpleButton2.Size = New System.Drawing.Size(134, 23)
			Me.simpleButton2.TabIndex = 1
			Me.simpleButton2.Text = "Show Selected Children"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(5, 5)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(119, 23)
			Me.simpleButton1.TabIndex = 0
			Me.simpleButton1.Text = "Show Selected Nodes"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			' 
			' panelControl2
			' 
			Me.panelControl2.Controls.Add(Me.listBoxControl1)
			Me.panelControl2.Dock = System.Windows.Forms.DockStyle.Right
			Me.panelControl2.Location = New System.Drawing.Point(373, 0)
			Me.panelControl2.Name = "panelControl2"
			Me.panelControl2.Size = New System.Drawing.Size(241, 434)
			Me.panelControl2.TabIndex = 2
			' 
			' listBoxControl1
			' 
			Me.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.listBoxControl1.Location = New System.Drawing.Point(2, 2)
			Me.listBoxControl1.Name = "listBoxControl1"
			Me.listBoxControl1.Size = New System.Drawing.Size(237, 430)
			Me.listBoxControl1.TabIndex = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(614, 434)
			Me.Controls.Add(Me.treeList1)
			Me.Controls.Add(Me.panelControl1)
			Me.Controls.Add(Me.panelControl2)
			Me.Name = "Form1"
			Me.Text = "Form1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.Form1_Load);
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelControl1.ResumeLayout(False)
			CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelControl2.ResumeLayout(False)
			CType(Me.listBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents treeList1 As DevExpress.XtraTreeList.TreeList
		Private colName As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private colPriority As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private panelControl1 As DevExpress.XtraEditors.PanelControl
		Private WithEvents simpleButton2 As DevExpress.XtraEditors.SimpleButton
		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private panelControl2 As DevExpress.XtraEditors.PanelControl
		Private listBoxControl1 As DevExpress.XtraEditors.ListBoxControl
	End Class
End Namespace

