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
            List<InfoNode> nodeList = Node.SelectAddresses(connection);

            LoadTree(treeView1, nodeList);

            //Maps.GetFill();

        }

        public static void LoadTree(TreeView treeView1, List<InfoNode> nodeList)
        {
            // ​5 этажей, 60, В доме 4 подъезда
            //Address
            //    - Floor
            //    - FlatsCount
            //    - Entrance

            treeView1.Nodes.Clear();

            List<TreeNode> TestNodes = new List<TreeNode>();

            foreach (InfoNode item in nodeList)
            {
                //List<TreeNode> parent = new List<TreeNode>();

                List<TreeNode> child = new List<TreeNode>();

                child.Add(new TreeNode(item.Floor, child.ToArray()));
                child.Add(new TreeNode(item.FlatsCount, child.ToArray()));
                child.Add(new TreeNode(item.Entrance, child.ToArray()));

                TestNodes.Add(new TreeNode(item.Address, child.ToArray()));

            }

            treeView1.Nodes.AddRange(TestNodes.ToArray());
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
