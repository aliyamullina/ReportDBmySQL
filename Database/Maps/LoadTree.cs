﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Address
        /// - Floor ​5 этажей
        /// - FlatsCount 60 квартир
        /// - Entrance В доме 4 подъезда
        /// </summary>
        public static List<TreeNode> LoadTree(TreeView treeView1, ref List<InfoMap> nodeList)
        {
            treeView1.Nodes.Clear();
            treeView1.LabelEdit = true;

            List<TreeNode> TestNodes = new List<TreeNode>();

            foreach (InfoMap item in nodeList)
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
