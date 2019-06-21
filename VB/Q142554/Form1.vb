Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Nodes.Operations

Namespace Q142554
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Function CreateTable() As DataTable
			Dim table As New DataTable()
			Dim dataRow As DataRow
			table.Columns.Add("ID", GetType(System.Int32))
			table.Columns.Add("ID_2", GetType(System.Int32))
			table.Columns.Add("Name", GetType(System.String))
			table.Columns.Add("Priority", GetType(System.String))
			dataRow = table.NewRow()
			dataRow("ID") = 1
			dataRow("ID_2") = 0
			dataRow("Name") = "Project A"
			dataRow("Priority") = "High"
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("ID") = 2
			dataRow("ID_2") = 1
			dataRow("Name") = "Deliverable 1"
			dataRow("Priority") = "Normal"
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("ID") = 3
			dataRow("ID_2") = 2
			dataRow("Name") = "This task is mine A"
			dataRow("Priority") = "High"
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("ID") = 4
			dataRow("ID_2") = 2
			dataRow("Name") = "This task isn't mine"
			dataRow("Priority") = "Low"
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("ID") = 5
			dataRow("ID_2") = 0
			dataRow("Name") = "Project B"
			dataRow("Priority") = "Normal"
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("ID") = 6
			dataRow("ID_2") = 5
			dataRow("Name") = "This task is mine B"
			dataRow("Priority") = "High"
			table.Rows.Add(dataRow)

			Return table
		End Function
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			treeList1.DataSource = CreateTable()
		End Sub

		Private Sub OnTreeListBeforeCheckNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CheckNodeEventArgs) Handles treeList1.BeforeCheckNode
			e.State = (If(e.PrevState = CheckState.Checked, CheckState.Unchecked, CheckState.Checked))
		End Sub

		Private Sub OnTreeListAfterCheckNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles treeList1.AfterCheckNode
			SetCheckedChildNodes(e.Node, e.Node.CheckState)
			SetCheckedParentNodes(e.Node, e.Node.CheckState)
		End Sub

		Private Sub SetCheckedChildNodes(ByVal node As TreeListNode, ByVal check As CheckState)
			For i As Integer = 0 To node.Nodes.Count - 1
				node.Nodes(i).CheckState = check
				SetCheckedChildNodes(node.Nodes(i), check)
			Next i
		End Sub
		Private Sub SetCheckedParentNodes(ByVal node As TreeListNode, ByVal check As CheckState)
			If node.ParentNode IsNot Nothing Then
				Dim b As Boolean = False
				Dim state As CheckState
				For i As Integer = 0 To node.ParentNode.Nodes.Count - 1
					state = CType(node.ParentNode.Nodes(i).CheckState, CheckState)
					If Not check.Equals(state) Then
						b = Not b
						Exit For
					End If
				Next i
				node.ParentNode.CheckState = If(b, CheckState.Indeterminate, check)
				SetCheckedParentNodes(node.ParentNode, check)
			End If
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			Dim operation As New CalcCheckedNodesOperation()
			treeList1.NodesIterator.DoOperation(operation)
			UpdateList(operation)
		End Sub

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			Dim operation As New CalcCheckedChildrenOperation(treeList1.FocusedNode)
			treeList1.NodesIterator.DoOperation(operation)
			UpdateList(operation)
		End Sub

		Private Sub UpdateList(ByVal operation As CalcCheckedNodesOperation)
			listBoxControl1.Items.Clear()
			listBoxControl1.Items.AddRange(operation.CheckedNodes.ToArray())
		End Sub
	End Class

	Public Class CalcCheckedNodesOperation
		Inherits TreeListOperation

'INSTANT VB NOTE: The field checkedNodes was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private checkedNodes_Renamed As New List(Of String)()
		Public ReadOnly Property CheckedNodes() As List(Of String)
			Get
				Return checkedNodes_Renamed
			End Get
		End Property
		Public Overrides Sub Execute(ByVal node As TreeListNode)
			If node.CheckState = CheckState.Checked Then
				checkedNodes_Renamed.Add(DirectCast(node(node.TreeList.Columns(0)), String))
			End If
		End Sub
	End Class

	Public Class CalcCheckedChildrenOperation
		Inherits CalcCheckedNodesOperation

		Private parent As TreeListNode
		Private isCalculationStart As Boolean = False
		Public Sub New(ByVal parent As TreeListNode)
			Me.parent = parent
		End Sub
		Public Overrides Sub Execute(ByVal node As TreeListNode)
			If node.HasAsParent(parent) Then
				MyBase.Execute(node)
			End If
		End Sub
		Public Overrides Function CanContinueIteration(ByVal node As TreeListNode) As Boolean
			If isCalculationStart AndAlso Not node.HasAsParent(parent) Then
				Return False
			End If
			If node Is parent Then
				isCalculationStart = True
			End If
			Return True
		End Function
		Public Overrides Function NeedsVisitChildren(ByVal node As TreeListNode) As Boolean
			Return node Is parent OrElse node.HasAsParent(parent) OrElse parent.HasAsParent(node)
		End Function
	End Class
End Namespace