<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1140)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/Q142554/Form1.cs) (VB: [Form1.vb](./VB/Q142554/Form1.vb))**
* [Program.cs](./CS/Q142554/Program.cs) (VB: [Program.vb](./VB/Q142554/Program.vb))
<!-- default file list end -->
# How to obtain checked nodes


<p>Starting with the 12.1.2 version, you can use the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraTreeListTreeListOptionsBehavior_AllowRecursiveNodeCheckingtopic"><u>TreeListOptionsBehavior.AllowRecursiveNodeChecking</u></a> option instead of this sample approach. </p><p>You can use this example in versions older than 12.1.2.<br />
This example demonstrates how to obtain checked nodes from the TreeList. To accomplish this task, you need to create your own TreeListOperation descendant and override its Execute method. Then, call the TreeList.NodesIterator.DoOperation method, and pass the new instance of your TreeListOperation descendant as a parameter. The TreeListNodesIterator iterates through all nodes and calls the Execute method for each node. So, you need simply check the CheckState property of this node and perform necessary operations. For example, you can implement an integer property CheckedNodesCount in your TreeListOperation descendant and increment its value from the Execute method if the CheckState property of the current node is CheckState.Checked. After you call the DoOperation method, this property will return the number of checked nodes.</p><p>Also, you can override the CanContinueIteration and NeedsVisitChildren methods to perform more complex operations. For example, iterate only through child nodes of a particular parent.</p>

<br/>


