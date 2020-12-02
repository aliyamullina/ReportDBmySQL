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

            foreach (TreeNode node in treeView1.Nodes)
            {
                nodeListEdit.Add(node.Name);
            }

            return nodeListEdit;
        }
    }
}
