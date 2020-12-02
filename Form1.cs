using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            //Database.CreateTable(connection);
            //Database.GetFillTable(connection);

            List<InfoNode> nodeList = Node.SelectAddresses(connection);

            Node.LoadTree(treeView1, nodeList);

            //List<InfoNode> nodeListEdit = Node.GetFill(treeView1);

            //Node.GetInsert(nodeListEdit, connection);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            Document.CreateDocs(connection);

            //db.Clear();

            Application.Exit();
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //Список для добавления в БД
            List<InfoNode> nodeListEdit = new List<InfoNode>();

            string floor = null; string flatscount = null; string entrance = null;

            string address = e.Node.Parent.Text;

            //Общее число элементов
            var childCount = e.Node.Parent.Nodes.Count;

            //Индекс  элемента
            var index = e.Node.Parent.Nodes.IndexOf(e.Node);

            //Текст элемента
            var child = e.Label;

            // Если не содержит
            if (e.Label.Contains("Введите количество") == false) 
            {
                switch (index)
                {
                    case 0:
                        floor = child;
                        break;
                    case 1:
                        flatscount = child;
                        break;
                    case 2:
                        entrance = child;
                        break;
                }
            }

            nodeListEdit.Add(new InfoNode(address, floor, flatscount, entrance));

            Console.WriteLine();
        }
    }
}
