using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Node
    {
        /// <summary>
        /// Address
        /// - Floor ​5 этажей
        /// - FlatsCount 60
        /// - Entrance В доме 4 подъезда
        /// </summary>
        public static List<TreeNode> LoadTree(TreeView treeView1, List<InfoNode> nodeList)
        {
            treeView1.Nodes.Clear();
            treeView1.LabelEdit = true;

            List<TreeNode> TestNodes = new List<TreeNode>();

            foreach (InfoNode item in nodeList)
            {
                List<TreeNode> child = new List<TreeNode>
                {
                    new TreeNode(item.Floor),
                    new TreeNode(item.FlatsCount),
                    new TreeNode(item.Entrance)
                };

                TestNodes.Add(new TreeNode(item.Address, child.ToArray()));
            }

            treeView1.Nodes.AddRange(TestNodes.ToArray());

            return TestNodes;
        }
    }
}
