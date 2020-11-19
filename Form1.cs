using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
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
        private void Button1_Click(object sender, System.EventArgs e)
        {
            
            DB db = new DB();

            db.CreateTableCatalogs();
            List<InfoCatalog> catalogsInsert = GetFillcatalog();
            db.InsertTableCatalogs(catalogsInsert);

            db.CreateTableCities();
            List<CityInfo> CitiesList = GetFillCities();
            db.InsertTableCities(CitiesList);

            db.CreateTableRegisters();
            List<InfoRegistry> RegistersList = GetFillRegisters();
            db.InsertTableRegisters(RegistersList);

            db.CreateTableAdresses();
            List<InfoAddress> addressesList = GetFillAddresses();
            db.InsertTableAdresses(addressesList);

            CreateDoc();

            db.ClearAddressInfoDB();

            Application.Exit();
        }

        /// <summary>
        /// Папка с папками, передает пути в коллекцию CatalogInfo
        /// </summary>
        private static List<InfoCatalog> GetFillcatalog()
        {
            List<InfoCatalog> catalogsInsert = new List<InfoCatalog>();
            FolderBrowserDialog folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };
            DialogResult dialog = folderDlg.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                string o = folderDlg.SelectedPath;
                    
                string[] cI = Directory.GetDirectories(o);

                foreach (var c in cI)
                { 
                    string[] files = new DirectoryInfo(c).GetFiles("Реестр" + "*.xlsx", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();

                    foreach (string r in files)
                    {
                        catalogsInsert.Add(new InfoCatalog(o, c, r));
                    }
                }
            }
            return catalogsInsert;
        }

        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        private static List<CityInfo> GetFillCities()
        {
            List<CityInfo> citiesList = new List<CityInfo>();
            string[] citiesArray = { "Казань", "Нурлат", "Чистополь", "Высокая гора", "Зеленодольск" };
            foreach (var city in citiesArray)
            {
                citiesList.Add(new CityInfo(city));
            }
            return citiesList;
        }

        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        private static List<InfoRegistry> GetFillRegisters()
        {
            DB DBObject = new DB();
            List<InfoCatalog> path = DBObject.GetCatalogList();
            List<InfoRegistry> registersListTable = new List<InfoRegistry>();

            foreach (InfoCatalog c in path)
            {
                OfficeUtility.GetExcelTableRead(c.Registry, out registersListTable);
                Console.WriteLine();
            }
            Console.WriteLine();
            return registersListTable;
        }

        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        private static List<InfoAddress> GetFillAddresses()
        {
            DB DBObject = new DB();
            List<InfoCatalog> path = DBObject.GetCatalogList();
            List<InfoAddress> folderAdress = new List<InfoAddress>();
            int city_id = 5;
            int catalog_id = 0;

            foreach (InfoCatalog c in path)
            {
                var pathTrim = c.Catalog.Substring(c.Catalog.LastIndexOf("\\")).Replace("\\", string.Empty);
                var street = pathTrim.Substring(0, pathTrim.LastIndexOf(" "));
                var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                catalog_id++;
                folderAdress.Add(new InfoAddress(street, home, city_id, catalog_id));
            }
            return folderAdress;
        }
        /// <summary>
        /// Принимает путь до файла, редактирует его
        /// </summary>
        public static void CreateDoc()
        {
            DB db = new DB();
            List<DocumentInfo> AddressDocList = db.GetDocumentList();

            var originalFilePath = @"C:\Users\User1_106\Desktop\template.docx";

            // Путь x.Open - если в корень
            var filePuth = AddressDocList.Select(x => x.Catalog + @"\Отчет ППО " + x.City + ", " + x.Street + " " + x.Home + ".docx").ToList();

            // Имя
            var fileName = AddressDocList.Select(x => x.City + ", " + x.Street + " " + x.Home).ToList();

            foreach (var pn in filePuth.Zip(fileName, (p, n) => new {filePuth=p,fileName=n })) { 
                // Копировал файл, давал новое имя, редактировал
                File.Copy(originalFilePath, pn.filePuth);

                // Берет готовый doc, редактирует
                using (WordprocessingDocument WordDoc = WordprocessingDocument.Open(pn.filePuth, isEditable: true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(WordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    Regex regexText = new Regex("AddressInfo");
                    docText = regexText.Replace(docText, pn.fileName);

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
