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
            db.InsertCities(CitiesList);

            db.CreateCatalogs();
            List<InfoCatalog> catalogsInsert = GetFill.GetFillCatalogs();
            db.InsertCatalogs(catalogsInsert);

            db.CreateRegisters();
            List<InfoRegistry> RegistersList = GetFill.GetFillRegisters(db);
            db.InsertRegisters(RegistersList);

            db.CreateAdresses();
            List<InfoAddress> addressesList = GetFill.GetFillAddresses(db);
            db.InsertAdresses(addressesList);

            GetCreateDoc.GetCreateDocs(db);

            db.DatabaseClear();

            Application.Exit();
        }
    }
}
