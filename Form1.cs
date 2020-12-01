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
            List<InfoMapAddress> InfoMapAddresses = Maps.SelectAddresses(connection);

            // Подузел
            List<InfoMap> mapsList = Maps.GetFill();

            //получить список адресов
            //к нему добавить список из карты
            //сохранить в бд

            // https://stackoverflow.com/questions/40009277/speed-up-the-loading-a-list-of-strings-to-a-treeview

            LoadTree(InfoMapAddresses, mapsList);

            //Maps.GetFill();


        }

        private void LoadTree(List<InfoMapAddress> InfoMapAddresses, List<InfoMap> mapsList)
        {
            // Code Using Linq
            TreeNode addressList = new TreeNode("addressList", InfoMapAddresses.Select(x => new TreeNode(x.Address)).ToArray());
            TreeNode childList = new TreeNode("addressList", mapsList.Select(x => new TreeNode(x.Floor)).ToArray());

            //parent nodes
            treeView1.Nodes.AddRange(new[] {
            new TreeNode("Address", new TreeNode[] { addressList, childList })
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
