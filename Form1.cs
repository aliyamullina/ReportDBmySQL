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

            foreach (InfoNode parent in nodeList)
            {
                TreeNode nodeHead = treeView1.Nodes.Add(parent.Address);

                foreach (var child in nodeList)
                {
                    TreeNode FloorNode = nodeHead.Nodes.Add(child.Floor);
                    TreeNode FlatsNode = nodeHead.Nodes.Add(child.FlatsCount);
                }
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
