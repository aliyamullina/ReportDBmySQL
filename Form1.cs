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
            List<CatalogInfo> catalogsInsert = GetFillcatalog();
            db.InsertTableCatalogs(catalogsInsert);

            db.CreateTableCities();
            List<CityInfo> CitiesList = GetFillCities();
            db.InsertTableCities(CitiesList);

            db.CreateTableRegisters();
            List<RegistryInfo> RegistersList = GetFillRegisters();
            db.InsertTableRegisters(RegistersList);

            db.CreateTableAdresses();
            List<AddressInfo> addressesList = GetFillAddresses();
            db.InsertTableAdresses(addressesList);

            CreateDoc();

            //db.ClearAddressInfoDB();

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
            //foreach (var pathExcel in path)
            //{

            //    pathExcelArray = System.IO.Directory.GetFiles(pathExcel, "Реестр*");

            //    //var puth = @"C:\Users\User1_106\Desktop\Реестр Татарстан 8.xlsx";

            //    Console.WriteLine(c);
            //}
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
        private static List<RegistryInfo> GetFillRegisters()
        {
            DB DBObject = new DB();
            List<CatalogInfo> path = DBObject.GetCatalogList();
            List<RegistryInfo> registersListTable = new List<RegistryInfo>();

            foreach (CatalogInfo c in path)
            {
                OfficeUtility.GetExcelTableRead(c.Catalog, out registersListTable);
            }

            return registersListTable;
        }

        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        private static List<AddressInfo> GetFillAddresses()
        {
            DB DBObject = new DB();
            List<CatalogInfo> path = DBObject.GetCatalogList();
            List<AddressInfo> folderAdress = new List<AddressInfo>();
            int city_id = 5;
            int catalog_id = 0;

            foreach (CatalogInfo c in path)
            {
                var pathTrim = c.Catalog.Substring(c.Catalog.LastIndexOf("\\")).Replace("\\", string.Empty);
                var street = pathTrim.Substring(0, pathTrim.LastIndexOf(" "));
                var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                catalog_id++;
                folderAdress.Add(new AddressInfo(street, home, city_id, catalog_id));
            }
            return folderAdress;
        }
        /// <summary>
        /// Принимает путь до файла, редактирует его
        /// </summary>
        public static void CreateDoc()
        {
            DB yourDBObject = new DB();
            List<DocumentInfo> AddressDocList = yourDBObject.GetDocumentList();

            var originalFilePath = @"C:\Users\User1_106\Desktop\template.docx";

            // Путь x.Save - если в корень
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
            Console.WriteLine();
        }
        }

}
