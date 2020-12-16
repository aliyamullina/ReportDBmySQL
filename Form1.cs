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

            List<InfoCatalog> сatalogsList = new List<InfoCatalog>();
            Catalogs.GetFill(ref сatalogsList, withoutReportsSearch, connection);
            Catalogs.GetInsert(ref сatalogsList, connection);

            List<InfoMap> nodeList = new List<InfoMap>();
            Maps.SelectAddresses(ref nodeList, connection);
            Maps.LoadTree(treeView1, ref nodeList);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            List<InfoDocument> documentsList = new List<InfoDocument>();
            Document.Create(ref documentsList, connection);

            db.Clear();

            Application.Exit();
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            
            List<InfoMap> mapListEdit = new List<InfoMap>();

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

            mapListEdit.Add(new InfoMap(address, floor, flatscount, entrance));

            Database db = new Database();
            MySqlConnection connection = db.GetConnection();

            Maps.GetInsert(mapListEdit, connection);
        }
    }
}
