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

            // По клику на узел обрабатывать изменения в БД и запрещать менять (окрашивать в серый)

            //node.Name
            //node.Nodes

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
            MessageBox.Show("Argg!");
        }
    }
}
