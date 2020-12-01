using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

            treeView1.Nodes.Add("Загрузка...");
            Task.Run(() => LoadTree());

            //Maps.GetFill();


        }

        private void LoadTree()
        {
            throw new NotImplementedException();
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
