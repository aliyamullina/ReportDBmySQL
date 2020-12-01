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

            List<InfoNode> nodeList = Node.SelectAddresses(connection);

            Node.LoadTree(treeView1, nodeList);

            // c# treeView after edit site:stackoverflow.com
            // https://stackoverflow.com/questions/10364580/getting-treenode-text-after-an-edit
            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.nodelabelediteventargs.label?redirectedfrom=MSDN&view=net-5.0#System_Windows_Forms_NodeLabelEditEventArgs_Label
            // https://stackoverflow.com/questions/5868790/saving-content-of-a-treeview-to-a-file-and-load-it-later
            treeView1.BeginInvoke(new MethodInvoker(treeView1.Sort));

            //List<InfoNode> nodeListEdit; 

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

    }
}
