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

            Adresses.CreateCities();
            List<InfoCity> CitiesList = Cities.GetFill();
            Cities.InsertCities(CitiesList);

            Adresses.CreateCatalogs();
            List<InfoCatalog> catalogsInsert = Catalogs.GetFill();
            Catalogs.InsertCatalogs(catalogsInsert);

            Adresses.CreateRegisters();
            List<InfoRegistry> RegistersList = Registers.GetFillRegisters();
            Registers.InsertRegisters(RegistersList);

            Adresses.CreateAdresses();
            List<InfoAddress> addressesList = Adresses.GetFillAddresses();
            Adresses.InsertAdresses(addressesList);

            Document.GetCreateDocs();

            db.Clear();

            Application.Exit();
        }
    }
}
