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

            Database.CreateTable(connection);

            List<InfoCity> CitiesList = Cities.GetFill();
            Cities.GetInsert(CitiesList, connection);

            List<InfoCatalog> CatalogsInsert = Catalogs.GetFill();
            Catalogs.GetInsert(CatalogsInsert, connection);

            Document.GetCreateDocs(connection);

            db.Clear();

            Application.Exit();
        }
    }
}
