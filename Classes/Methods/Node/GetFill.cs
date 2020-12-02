using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Node
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static List<InfoNode> GetFill(TreeView treeView1)
        {
            List<InfoNode> nodeListEdit = new List<InfoNode>();

            // c# treeView after edit site:stackoverflow.com
            treeView1.BeginInvoke(new MethodInvoker(treeView1.Sort));

            //foreach (TreeNode node in treeView1.Nodes)
            //{
            //    string text = node.Text;
            //    nodeListEdit.AddRange(text);
            //    Console.WriteLine();
            //}

            return nodeListEdit;
        }
    }
}
