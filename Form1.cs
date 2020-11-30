using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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

            List<InfoMapAddress> InfoMapAddresses = Maps.SelectAddresses(connection);

            foreach (InfoMapAddress item in InfoMapAddresses)
            {
                var lvi = new ListViewItem(new[] { item.Address});
                listView1.Items.Add(lvi);
            }

            listView1.Refresh();

            //Maps.GetFill();

            //Document.CreateDocs(connection);

            //db.Clear();

            //Application.Exit();
        }
    }
}
