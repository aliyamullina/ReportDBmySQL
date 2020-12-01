using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Опредалять город

        // Находить дату

        // Найти каталоги, где нет отчета ппо

        // Выбрать 1 папку или несколько

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            //Database.CreateTable(connection);
            //Database.GetFillTable(connection);

            // Узел
            List<TreeNode> nodeList = Node.SelectAddresses(connection);

            LoadTree(treeView1, nodeList);

            //Maps.GetFill();

        }

        public static void LoadTree(TreeView treeView1, List<TreeNode> nodeList)
        {
            // ​5 этажей, 60, В доме 4 подъезда
            //Address
            //    - Floor
            //    - FlatsCount
            //    - Entrance

            //TreeNode Address = new TreeNode("Address", nodeList.Select(x => new TreeNode(x.Address)).ToArray());

            //TreeNodeCollection Floor = new TreeNode("Floor", nodeList.Select(x => new TreeNode(x.Floor)).ToArray());
            //TreeNodeCollection FlatsCount = new TreeNode("FlatsCount", nodeList.Select(x => new TreeNode(x.FlatsCount)).ToArray());
            //TreeNodeCollection Entrance = new TreeNode("Entrance", nodeList.Select(x => new TreeNode(x.Entrance)).ToArray());

            //treeView1.Nodes.AddRange(new[] 
            //{ 
            //    Floor, FlatsCount, Entrance 
            //});

            //TreeNodeCollection items;
            //TreeNode treeNode = items.Add(food.Item1);

            List<TreeNode> treeNodeList = new List<TreeNode>();

            foreach (TreeNode n in nodeList)
            {
                treeNodeList.Add(n);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            Document.CreateDocs(connection);

            db.Clear();

            Application.Exit();
        }

    }
}
