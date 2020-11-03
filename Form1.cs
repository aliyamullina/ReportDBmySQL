using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Действие по клику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, System.EventArgs e)
        {
            
            DB db = new DB();

            db.CreateTableCatalogs();
            List<CatalogInfo> catalogsInsert = GetFillcatalog();
            db.InsertTableCatalogs(catalogsInsert);

            //List<CatalogInfo> catalogsSelect = new List<CatalogInfo>();
            db.Select();


            db.CreateTableCities();
            List<CityInfo> CitiesList = GetFillCities();
            db.InsertTableCities(CitiesList);


            db.CreateTableAdresses();
            List<AddressInfo> addressesList = GetFillAddresses();
            db.InsertTableAdresses(addressesList);

            CreateDoc();

            Application.Exit();
        }

        /// <summary>
        /// Папка с папками, передает пути в коллекцию CatalogInfo
        /// </summary>
        private static List<CatalogInfo> GetFillcatalog()
        {
            List<CatalogInfo> catalogsInsert = new List<CatalogInfo>();
  
            FolderBrowserDialog folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };
            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                string[] cI = Directory.GetDirectories(PathToFolder);
               
                foreach (var c in cI) { catalogsInsert.Add(new CatalogInfo(c, PathToFolder)); }
            }
            return catalogsInsert;
        }

        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        private static List<AddressInfo> GetFillAddresses()
        {

            

            List<AddressInfo> folderAdress = new List<AddressInfo>();

            //string city_id = "1";

            //Получить Catalog.catalog
            

            //foreach (CatalogInfo path in catalogsSelect)
           // {
               // Console.WriteLine(path);
                /*var pathTrim = path.Substring(path.LastIndexOf("\\")).Replace("\\", string.Empty);
                var street = pathTrim.Substring(0, pathTrim.IndexOf(" "));
                var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                folderAdress.Add(new AddressInfo(street, home, city_id, catalog_id));*/
            //}

            return folderAdress;
        }

        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        private static List<CityInfo> GetFillCities()
        {
            List<CityInfo> citiesList = new List<CityInfo>();
            string[] citiesArray = { "Казань", "Нурлат", "Чистополь", "Высокая гора" };
            
            foreach (var city in citiesArray)
            {
                citiesList.Add(new CityInfo(city));
            }
            return citiesList;
        }

        /// <summary>
        /// Принимает путь, создает файлы
        /// </summary>
        private static void CreateDoc()
        {
                
        }
    }
}
