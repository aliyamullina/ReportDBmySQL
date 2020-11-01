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
            fillCities();
            fillAdressses();
            Application.Exit();
        }

        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом. Добавляет в коллекцию
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
                string city = "1";
                foreach (var path in allfolders)
                {
                    var pathTrim = path.Substring(path.LastIndexOf("\\")).Replace("\\", string.Empty);
                    var street = pathTrim.Substring(0, pathTrim.IndexOf(" "));
                    var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                    folderAdress.Add(new AddressInfo(city, street, home));
                }
            }
            return folderAdress;
        }

        /// <summary>
        /// Из коллекции в БД
        /// </summary>
        private void fillCities()
        {
            string[] citiesArray = { "Казань", "Нурлат", "Чистополь", "Высокая гора" };
            List <CityInfo> citiesList = new List<CityInfo>();

            foreach (var city in citiesArray)
            {
                citiesList.Add(new CityInfo(city));
            }

            DB db = new DB();
            db.CreateTableCities();


            //db.InsertTableCities();

            // Как передать данные из List в Mysql?
        }

        /// <summary>
        /// Из коллекции в БД
        /// </summary>
        private void fillAdressses()
        {
            DB db = new DB();
            db.CreateTableAdresses();

            db.InsertTableAdresses();

            //_ = getFolderAddressInfo();

            /*DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("");*/
        }


        // Из папки в mysql
        // Из mysql в массив
        // Mассив передать в макет word с адресом в имени
    }
}
