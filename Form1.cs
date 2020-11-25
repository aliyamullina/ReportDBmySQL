﻿using System.Collections.Generic;
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
            DB db = new DB();

            db.GetCreateTableCities();
            List<InfoCity> CitiesList = GetFill.GetFillCities();
            db.GetInsertTableCities(CitiesList);

            db.CreateCatalogs();
            List<InfoCatalog> catalogsInsert = GetFill.GetFillCatalogs();
            db.InsertCatalogs(catalogsInsert);

            db.CreateTableRegisters();
            List<InfoRegistry> RegistersList = GetFill.GetFillRegisters(db);
            db.InsertTableRegisters(RegistersList);

            db.CreateTableAdresses();
            List<InfoAddress> addressesList = GetFill.GetFillAddresses();
            db.InsertTableAdresses(addressesList);

            //GetCreateDoc.Create();

            //db.ClearAddressInfoDB();

            Application.Exit();
        }
    }
}
