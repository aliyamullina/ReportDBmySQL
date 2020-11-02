using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            DB db = new DB();

            db.CreateTableCities();
            List<CityInfo> CitiesList = getFillCities();
            db.InsertTableCities(CitiesList);

            db.CreateTableAdresses();
            List<AddressInfo> addressesList = getFolderAddressInfo();
            db.InsertTableAdresses(addressesList);

            Application.Exit();
        }

        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию 
        /// </summary>
        /// <returns>folderAdress</returns>
        private static List<AddressInfo> getFolderAddressInfo()
        {
            List<AddressInfo> folderAdress = new List<AddressInfo>();
            FolderBrowserDialog folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };
            DialogResult dialog = folderDlg.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                _ = folderDlg.RootFolder;
                string[] allfolders = Directory.GetDirectories(PathToFolder);
                string city_id = "1";

                // Неправильно обрезает двойные пробелы 
                // Ак. вместо Ак. Королева
                // О. вместо О. Кошевого
                // Проспект вместо Проспект Победы
                // 
                foreach (var path in allfolders)
                {
                    var pathTrim = path.Substring(path.LastIndexOf("\\")).Replace("\\", string.Empty);
                    var street = pathTrim.Substring(0, pathTrim.IndexOf(" "));
                    var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                    folderAdress.Add(new AddressInfo(street, home, city_id));
                }
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

        // Из папки в mysql
        // Из mysql в массив
        // Mассив передать в макет word с адресом в имени
    }
}
