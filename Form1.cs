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

        public static void LoadTree( TreeView treeView1, List<InfoNode> nodeList)
        {
            // ​5 этажей, 60, В доме 4 подъезда
            //Address
            //    - Floor
            //    - FlatsCount
            //    - Entrance

            TreeNode Address = new TreeNode("Address", nodeList.Select(x => new TreeNode(x.Address)).ToArray());
            TreeNode Floor = new TreeNode("Floor", nodeList.Select(x => new TreeNode(x.Floor)).ToArray());
            TreeNode FlatsCount = new TreeNode("FlatsCount", nodeList.Select(x => new TreeNode(x.FlatsCount)).ToArray());
            TreeNode Entrance = new TreeNode("Entrance", nodeList.Select(x => new TreeNode(x.Entrance)).ToArray());

            treeView1.Nodes.AddRange(new[] 
            { 
                Floor, FlatsCount, Entrance 
            });

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
