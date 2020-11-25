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
            DB db = new DB();

            db.CreateCities();
            List<InfoCity> CitiesList = GetFill.GetFillCities();
            db.GetInsertCities(CitiesList);

            db.CreateCatalogs();
            List<InfoCatalog> catalogsInsert = GetFill.GetFillCatalogs();
            db.InsertCatalogs(catalogsInsert);

            db.CreateRegisters();
            List<InfoRegistry> RegistersList = GetFill.GetFillRegisters(db);
            db.GetInsertRegisters(RegistersList);

            db.CreateAdresses();
            List<InfoAddress> addressesList = GetFill.GetFillAddresses();
            db.GetInsertAdresses(addressesList);

            GetCreateDoc.GetCreateDocs();

            db.DatabaseClear();

            Application.Exit();
        }
    }
}
