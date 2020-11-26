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

            Catalogs.GetCreate(connection);
            Cities.GetCreate(connection);
            Adresses.GetCreate(connection);
            Registers.GetCreate(connection);

            List<InfoCatalog> CatalogsInsert = Catalogs.GetFill();
            List<InfoCity> CitiesList = Cities.GetFill();
            List<InfoAddress> AddressesList = Adresses.GetFill(connection);
            List<InfoRegistry> RegistersList = Registers.GetFill(connection);

            Catalogs.GetInsert(CatalogsInsert, connection);
            Cities.GetInsert(CitiesList, connection);
            Adresses.GetInsert(AddressesList, connection);
            Registers.GetInsert(RegistersList, connection);
            
            //Document.GetCreateDocs(connection);

            //db.Clear();

            Application.Exit();
        }
    }
}
