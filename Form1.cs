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

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            // Опредалять город

            // Находить дату

            // Найти каталоги, где нет отчета ппо

            // Выбрать 1 папку или несколько

            //Database.CreateTable(connection);
            //Database.GetFillTable(connection);

            Maps.SelectAddresses(connection);

            //Form2 f2 = new Form2();
            
            //f2.Show();

            // передать List<InfoMapAddress> InfoMapAddresses в listView1 f2

            // получить из listView1 f2 в List<InfoMap> mapsList
            Maps.GetFill();

            //Document.CreateDocs(connection);

            //db.Clear();

            Application.Exit();
        }
    }
}
