Imports Microsoft.VisualBasic
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

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'treeListDataBaseDataSet.Table1' table. You can move, or remove it, as needed.
			Me.table1TableAdapter.Fill(Me.treeListDataBaseDataSet.Table1)

		End Sub

		Private Sub OnTreeListBeforeCheckNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CheckNodeEventArgs) Handles treeList1.BeforeCheckNode
			If e.PrevState = CheckState.Checked Then
				e.State = (CheckState.Unchecked)
			Else
				e.State = (CheckState.Checked)
			End If
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
					If (Not check.Equals(state)) Then
						b = Not b
						Exit For
					End If
				Next i
				If b Then
					node.ParentNode.CheckState = CheckState.Indeterminate
				Else
					node.ParentNode.CheckState = check
				End If
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
		Private checkedNodes_Renamed As List(Of String) = New List(Of String)()
		Public ReadOnly Property CheckedNodes() As List(Of String)
			Get
				Return checkedNodes_Renamed
			End Get
		End Property
		Public Overrides Sub Execute(ByVal node As TreeListNode)
			If node.CheckState = CheckState.Checked Then
				checkedNodes_Renamed.Add(CStr(node(node.TreeList.Columns(0))))
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
			If isCalculationStart AndAlso (Not node.HasAsParent(parent)) Then
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