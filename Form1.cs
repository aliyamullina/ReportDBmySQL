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

            // Вставлять значения из 2Гис
            // Найти каталоги, где нет отчета ппо
            // Выдать список адресов для 2гиса)

            // Выбрать 1 папку или несколько

            // Переименование файла: добавить слово Реестр к xlsx рядом с актом в папке

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
