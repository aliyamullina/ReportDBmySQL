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

            db.CreateCities();
            List<InfoCity> CitiesList = DatabaseTable.GetFillCities();
            db.InsertCities(CitiesList);

            db.CreateCatalogs();
            List<InfoCatalog> catalogsInsert = DatabaseTable.GetFillCatalogs();
            db.InsertCatalogs(catalogsInsert);

            db.CreateRegisters();
            List<InfoRegistry> RegistersList = DatabaseTable.GetFillRegisters(db);
            db.InsertRegisters(RegistersList);

            db.CreateAdresses();
            List<InfoAddress> addressesList = DatabaseTable.GetFillAddresses(db);
            db.InsertAdresses(addressesList);

            CreateDocument.GetCreateDocs(db);

            db.Clear();

            Application.Exit();
        }
    }
}
