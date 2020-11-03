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

            CreateDoc();

            Application.Exit();
        }

        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию 
        /// </summary>
        /// <returns>folderAdress</returns>
        private static List<CatalogInfo> getFolderAddressInfo(List<CatalogInfo> folderPuth)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };
            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                _ = folderDlg.RootFolder;
                string[] allfolders = Directory.GetDirectories(PathToFolder);

                foreach (var path in allfolders) { 
                    folderPuth.Add(new CatalogInfo(path));
                }
            }
            return folderPuth;
        }

        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию 
        /// </summary>
        /// <returns>folderAdress</returns>
        private static List<AddressInfo> getFolderAddressInfo(List<AddressInfo> folderAdress)
        {
            string city_id = "1";

            foreach (var path in allfolders)
            {
                var pathTrim = path.Substring(path.LastIndexOf("\\")).Replace("\\", string.Empty);
                var street = pathTrim.Substring(0, pathTrim.IndexOf(" "));
                var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                folderAdress.Add(new AddressInfo(street, home, city_id));
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
            var originalFilePath = @"C:\Users\User1_106\Google Диск\Github\Files\template.docx";

            var Path = @"C:\Users\User1_106\Google Диск\Github\Files\";
            var Format = ".docx";

            List<string> modifiedFiles = new List<string>()
             {
                    "Казань, Большая 80",
                    "Казань, Подлужная 40",
                    "Казань, Подлужная 50",
                    "Казань, Волгоградская 29",
             };

            var modifiedFilesPath = modifiedFiles.Select(x => Path + x + Format).ToList();

            var res = modifiedFilesPath.Zip(modifiedFiles, (n, w) => new { Puth = n, Name = w });

            foreach (var item in res)
            {

                File.Copy(originalFilePath, item.Puth, true);


                using (WordprocessingDocument WordDoc = WordprocessingDocument.Open(item.Puth, isEditable: true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(WordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    Regex regexText = new Regex("AddressInfo"); docText = regexText.Replace(docText, item.Name);

                    using (StreamWriter sw = new StreamWriter(WordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                    WordDoc.MainDocumentPart.Document.Save();
                    WordDoc.Close();
                }
                
            }
        }
    }
}
