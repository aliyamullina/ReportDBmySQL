using MySql.Data.MySqlClient;
using System;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            //выбор искать без ппо и с ппо
            bool withoutReportsSearch;
            if (checkBox1.Checked == true) { withoutReportsSearch = true; }
            else { withoutReportsSearch = false; }

            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            Database.CreateTables(connection);

            Catalogs.GetFillList(out List<InfoCatalog> сatalogsList, out string openFolder, in withoutReportsSearch);
            Catalogs.GetInsertList(in сatalogsList, out int catalog_id, connection);
            Catalogs.GetSelect(out List<InfoCatalog> oneCatalogPath, in catalog_id, connection);

            //Adresses.GetID(in catalog_id, ref oneCatalogPath, connection);
            Adresses.GetFillList(out List<InfoAddress> addressesList, in catalog_id, in oneCatalogPath);
            Adresses.GetInsertList(in addressesList, connection);

            //Registers.GetID(in catalog_id, oneCatalogPath, connection);
            Registers.GetFillList(out List<InfoRegistry> registersList, in catalog_id, in oneCatalogPath);
            Registers.GetInsert(in registersList, connection);

            Cities.GetFillList(in openFolder, out List<InfoCity> citiesList);
            Cities.GetInsertList(in citiesList, connection);

            Maps.SelectAddresses(out List<InfoMap> nodeList, connection);
            Maps.LoadTree(treeView1, ref nodeList);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            var documentTemplate = @"C:\Users\User1_106\Desktop\template.docx";

            Document.GetSelect(out List<InfoDocument> documentsList, connection);
            Document.Create(ref documentsList, documentTemplate, connection);

            db.Clear();
            Application.Exit();
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string floor = null; string flatscount = null; string entrance = null;

            //Не позволяет редактировать родителя, выдает исключение
            string address = e.Node.Parent.Text;

            //Общее число элементов
            var childCount = e.Node.Parent.Nodes.Count;

            //Индекс  элемента
            var index = e.Node.Parent.Nodes.IndexOf(e.Node);

            //Текст элемента
            var child = e.Label;

            // Если не содержит
            if (e.Label.Contains("Введите количество") == false) 
                // System.NullReferenceException: "Ссылка на объект не указывает на экземпляр объекта."
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
            Maps.GetInsert(mapListEdit, connection);
        }
    }
}
