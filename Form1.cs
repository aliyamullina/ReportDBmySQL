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

            Adresses.GetCreate();
            List<InfoCity> CitiesList = Cities.GetFill();
            Cities.GetInsert(CitiesList);

            Adresses.GetCreate();
            List<InfoCatalog> catalogsInsert = Catalogs.GetFill();
            Catalogs.GetInsert(catalogsInsert);

            Adresses.GetCreate();
            List<InfoRegistry> RegistersList = Registers.GetFill();
            Registers.GetInsert(RegistersList);

            Adresses.GetCreate();
            List<InfoAddress> addressesList = Adresses.GetFill();
            Adresses.GetInsert(addressesList);

            Document.GetCreateDocs();

            db.Clear();

            Application.Exit();
        }
    }
}
