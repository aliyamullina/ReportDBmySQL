﻿using DocumentFormat.OpenXml.Packaging;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Действие по клику
        /// </summary>
        private void Button1_Click(object sender, System.EventArgs e)
        {
            
            DB db = new DB();

            db.CreateTableCatalogs();
            List<InfoCatalog> catalogsInsert = GetFillCatalog.Get();
            db.InsertTableCatalogs(catalogsInsert);

            db.CreateTableCities();
            List<InfoCity> CitiesList = GetFillCities.Get();
            db.InsertTableCities(CitiesList);

            db.CreateTableRegisters();
            List<InfoRegistry> RegistersList = GetFillRegisters.Get();
            db.InsertTableRegisters(RegistersList);

            db.CreateTableAdresses();
            List<InfoAddress> addressesList = GetFillAddresses.Get();
            db.InsertTableAdresses(addressesList);

            GetCreateDoc.Create();

            db.ClearAddressInfoDB();

            Application.Exit();
        }
    }
}
