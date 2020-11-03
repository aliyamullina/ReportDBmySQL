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

            db.CreateTableCities();
            List<CityInfo> CitiesList = getFillCities();
            db.InsertTableCities(CitiesList);

            db.CreateTableCatalogs();
            List<CatalogInfo> CatalogsList = getFillCatalogs();
            db.InsertTableCatalogs(CatalogsList);

            db.CreateTableAdresses();
            List<AddressInfo> addressesList = getFillAddresses();
            db.InsertTableAdresses(addressesList);

            CreateDoc();

            Application.Exit();
        }

        /// <summary>
        /// Папка с папками, передает пути и передает в коллекцию  CatalogInfo
        /// </summary>
        private static void catalogInfo (ref string[] allfolders)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };
            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                _ = folderDlg.RootFolder;
                allfolders = Directory.GetDirectories(PathToFolder);
            }
        }

        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        private static List<AddressInfo> getFillAddresses()
        {
            List<AddressInfo> folderAdress = new List<AddressInfo>();

            string[] cI = { };
            catalogInfo(ref cI);

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
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        private static List<CatalogInfo> getFillCatalogs()
        {
            List<CatalogInfo> catalogsList = new List<CatalogInfo>();
            string[] catalogsArray = { 
                @"C:\Users\User1_106\Google Диск\Github\сдаем без успд и с УСПД подписанные акты\3\",
                @"C:\Users\User1_106\Google Диск\Github\сдаем без успд и с УСПД подписанные акты\3\",
                @"C:\Users\User1_106\Google Диск\Github\сдаем без успд и с УСПД подписанные акты\3\",
                @"C:\Users\User1_106\Google Диск\Github\сдаем без успд и с УСПД подписанные акты\3\"
            };

            foreach (var c in catalogsArray)
            {
                catalogsList.Add(new CatalogInfo(c));
            }
            return catalogsList;
        }

        /// <summary>
        /// Принимает путь, создает файлы
        /// </summary>
        public static void CreateDoc()
        {
                
        }
    }
}
