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
            MySql.Data.MySqlClient.MySqlConnection connection = db.GetConnection();

            Cities.GetCreate(connection);
            List<InfoCity> CitiesList = Cities.GetFill();
            Cities.GetInsert(CitiesList, connection);

            Catalogs.GetCreate(connection);
            List<InfoCatalog> catalogsInsert = Catalogs.GetFill();
            Catalogs.GetInsert(catalogsInsert, connection);

            Registers.GetCreate(connection);
            List<InfoRegistry> RegistersList = Registers.GetFill(connection);
            Registers.GetInsert(RegistersList, connection);

            Adresses.GetCreate(connection);
            List<InfoAddress> addressesList = Adresses.GetFill(connection);
            Adresses.GetInsert(addressesList, connection);

            //Document.GetCreateDocs();

            //db.Clear();

            Application.Exit();
        }
    }
}
