using DocumentFormat.OpenXml.Packaging;
using System.Collections.Generic;
using System.IO;
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            /*
            DB db = new DB();

            db.CreateTableCities();
            List<CityInfo> CitiesList = getFillCities();
            db.InsertTableCities(CitiesList);

            db.CreateTableAdresses();
            List<AddressInfo> addressesList = getFolderAddressInfo();
            db.InsertTableAdresses(addressesList);*/

            var puthRemplate = @"C:\Users\User1_106\Google Диск\Github\Files\template.docx";
            CreateDoc(puthRemplate);

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
                // Серова к1 вместо Серова 6 к1
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

  
        /// <summary>
        /// Принимает путь до файла, редактирует его
        /// </summary>
        /// <param name="document"></param>
        public static void CreateDoc(string document)
        {
            // Копировал файл, давал новое, редактировал
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                Regex regexText = new Regex("AddressInfo");
                docText = regexText.Replace(docText, "Казань, Большая 80");

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }
    }
}
