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

            treeView1.Nodes.Add(LoadTree(nodeList));

            //Maps.GetFill();

        }

        public static TreeNode LoadTree(List<InfoNode> nodeList)
        {
            // ​5 этажей, 60, В доме 4 подъезда
            //Address
            //    - Floor
            //    - FlatsCount
            //    - Entrance

            //var rootNode = new TreeNode("Address", nodeList.Select(x => new TreeNode(x.Address)).ToArray());

            TreeNode thisnode = new TreeNode();
            TreeNode currentnode;

            foreach (var n in nodeList)
            {
                var Address = n.Address;
                var Floor = n.Floor;
                var FlatsCount = n.FlatsCount;
                var Entrance = n.Entrance;

                currentnode = thisnode;
                currentnode = currentnode.Nodes.Add(Floor, FlatsCount, Entrance);

            }
            return thisnode;
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
