using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        private void button1_Click(object sender, System.EventArgs e)
        {
            
            DB db = new DB();

            db.CreateTableCatalogs();
            List<CatalogInfo> CatalogsList = getFillcatalog();
            db.InsertTableCatalogs(CatalogsList);

            
            db.CreateTableCities();
            List<CityInfo> CitiesList = getFillCities();
            db.InsertTableCities(CitiesList);

            
            db.CreateTableAdresses();
            List<AddressInfo> addressesList = getFillAddresses();
            db.InsertTableAdresses(addressesList);

            CreateDoc();

            Application.Exit();
        }

        /// <summary>
        /// Папка с папками, передает пути в коллекцию CatalogInfo
        /// </summary>
        private static List<CatalogInfo> getFillcatalog()
        {
            List<CatalogInfo> catalogsList = new List<CatalogInfo>();
  
            FolderBrowserDialog folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };
            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                string[] cI = Directory.GetDirectories(PathToFolder);
               
                foreach (var c in cI) { catalogsList.Add(new CatalogInfo(c, PathToFolder)); }
            }
            return catalogsList;
        }

        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        private static List<AddressInfo> getFillAddresses()
        {
            List<AddressInfo> folderAdress = new List<AddressInfo>();

            string[] cI = { };

            string city_id = "1";
            string catalog_id = "1";

            foreach (var path in cI)
            {
                var pathTrim = path.Substring(path.LastIndexOf("\\")).Replace("\\", string.Empty);
                var street = pathTrim.Substring(0, pathTrim.IndexOf(" "));
                var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                folderAdress.Add(new AddressInfo(street, home, city_id, catalog_id));
            }
            return folderAdress;
        }

        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        private static List<CityInfo> getFillCities()
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
        public static void CreateDoc()
        {
                
        }
    }
}
