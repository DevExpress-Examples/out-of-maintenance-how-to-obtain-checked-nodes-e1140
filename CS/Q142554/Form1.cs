using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace Q142554 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        DataTable CreateTable()
        {
            DataTable table = new DataTable();
            DataRow dataRow;
            table.Columns.Add("ID", typeof(System.Int32));
            table.Columns.Add("ID_2", typeof(System.Int32));
            table.Columns.Add("Name", typeof(System.String));
            table.Columns.Add("Priority", typeof(System.String));
            dataRow = table.NewRow();
            dataRow["ID"] = 1;
            dataRow["ID_2"] = 0;
            dataRow["Name"] = "Project A";
            dataRow["Priority"] = "High";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["ID"] = 2;
            dataRow["ID_2"] = 1;
            dataRow["Name"] = "Deliverable 1";
            dataRow["Priority"] = "Normal";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["ID"] = 3;
            dataRow["ID_2"] = 2;
            dataRow["Name"] = "This task is mine A";
            dataRow["Priority"] = "High";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["ID"] = 4;
            dataRow["ID_2"] = 2;
            dataRow["Name"] = "This task isn't mine";
            dataRow["Priority"] = "Low";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["ID"] = 5;
            dataRow["ID_2"] = 0;
            dataRow["Name"] = "Project B";
            dataRow["Priority"] = "Normal";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["ID"] = 6;
            dataRow["ID_2"] = 5;
            dataRow["Name"] = "This task is mine B";
            dataRow["Priority"] = "High";
            table.Rows.Add(dataRow);

            return table;
        }
        private void Form1_Load(object sender, EventArgs e) {
            treeList1.DataSource = CreateTable();
        }

        private void OnTreeListBeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e) {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void OnTreeListAfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e) {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check) {
            for (int i = 0; i < node.Nodes.Count; i++) {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        private void SetCheckedParentNodes(TreeListNode node, CheckState check) {
            if (node.ParentNode != null) {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++) {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state)) {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            CalcCheckedNodesOperation operation = new CalcCheckedNodesOperation();
            treeList1.NodesIterator.DoOperation(operation);
            UpdateList(operation);
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            CalcCheckedChildrenOperation operation = new CalcCheckedChildrenOperation(treeList1.FocusedNode);
            treeList1.NodesIterator.DoOperation(operation);
            UpdateList(operation);
        }

        private void UpdateList(CalcCheckedNodesOperation operation) {
            listBoxControl1.Items.Clear();
            listBoxControl1.Items.AddRange(operation.CheckedNodes.ToArray());
        }
    }

    public class CalcCheckedNodesOperation :TreeListOperation {
        private List<string> checkedNodes = new List<string>();
        public List<string> CheckedNodes { get { return checkedNodes; } }
        public override void Execute(TreeListNode node) {
            if (node.CheckState == CheckState.Checked) 
                checkedNodes.Add((string)node[node.TreeList.Columns[0]]);
        }
    }

    public class CalcCheckedChildrenOperation : CalcCheckedNodesOperation {
        private TreeListNode parent;
        private bool isCalculationStart = false;
        public CalcCheckedChildrenOperation(TreeListNode parent) { this.parent = parent; }
        public override void Execute(TreeListNode node) {
            if (node.HasAsParent(parent)) base.Execute(node);
        }
        public override bool CanContinueIteration(TreeListNode node) {
            if (isCalculationStart && !node.HasAsParent(parent)) return false;
            if (node == parent) isCalculationStart = true;
            return true;
        }
        public override bool NeedsVisitChildren(TreeListNode node) {
            return node == parent || node.HasAsParent(parent) || parent.HasAsParent(node);
        }
    }
}