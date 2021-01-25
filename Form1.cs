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

        private void Button1_Click(object sender, EventArgs e)
        {
            bool withoutReportsSearch;
            if (checkBox1.Checked == true) { withoutReportsSearch = true; }
            else { withoutReportsSearch = false; }

            int numericUpDown = (int)numericUpDown1.Value;

            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            db.Clear();

            Database.CreateTables(connection);

            Catalogs.GetFillList(in withoutReportsSearch, in numericUpDown, out List <InfoCatalog> сatalogsList, out List<InfoCatalog> сatalogsListLater, out string openFolder);
            Catalogs.GetInsertList(in сatalogsList, connection);

            Cities.GetFillList(in openFolder, out List<InfoCity> citiesList);
            Cities.GetInsertList(in citiesList, connection);

            Maps.SelectAddresses(connection, out List<InfoMap> nodeList);
            //Maps.GetXMLFindList(ref nodeList);
            Maps.LoadTree(treeView1, ref nodeList);

            if (сatalogsListLater != null) 
            { 
                MessageBox.Show(string.Join(Environment.NewLine, сatalogsListLater.Select(cl => cl.Catalog.ToString())), "Нет реестра", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void TreeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string floor = null; string flatscount = null; string entrance = null;
            string address = e.Node.Parent.Text;

            var childCount = e.Node.Parent.Nodes.Count;
            var index = e.Node.Parent.Nodes.IndexOf(e.Node);
            var child = e.Label;

            // Если не содержит
            if (e.Label.Contains("Введите количество") == false) 
                //System.NullReferenceException: "Ссылка на объект не указывает на экземпляр объекта."
                //System.Windows.Forms.NodeLabelEditEventArgs.Label.get вернул null
            {
                switch (index)
                {
                    case 0:
                        floor = child;
                        break;
                    case 1:
                        flatscount = child;
                        break;
                    case 2:
                        entrance = child;
                        break;
                }
            }

            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            List<InfoMap> mapListEdit = new List<InfoMap> { new InfoMap(address, floor, flatscount, entrance) };
            Maps.GetInsertList(in mapListEdit, connection);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            Maps.GetXMLSelectList(out List<InfoMap> mapListInsert, connection);
            Maps.GetXMLInsertList(ref mapListInsert);

            var documentTemplate = @"C:\Users\User1_106\Desktop\template.docx";

            Document.GetSelectList(out List<InfoDocument> documentsList, connection);
            Document.Create(in documentsList, in documentTemplate, connection);

            db.Clear();
            Application.Exit();
        }
    }
}
