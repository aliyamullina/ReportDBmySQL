using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections;
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
        private void Button1_Click(object sender, System.EventArgs e)
        {
            
            DB db = new DB();

            /*
            db.CreateTableCatalogs();
            List<CatalogInfo> catalogsInsert = GetFillcatalog();
            db.InsertTableCatalogs(catalogsInsert);

            db.CreateTableCities();
            List<CityInfo> CitiesList = GetFillCities();
            db.InsertTableCities(CitiesList);
            */

            db.CreateTableRegisters();
            //List<RegistryInfo> RegistersList = GetFillRegisters();
            //db.InsertTableRegisters(RegistersList);

            GetCellValue(@"C:\Users\User1_106\Desktop\Реестр Васильево Ленина 28.xlsx", "Лист1", "A8");

            /*
            db.CreateTableAdresses();
            List<AddressInfo> addressesList = GetFillAddresses();
            db.InsertTableAdresses(addressesList);

            CreateDoc();
            */
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
            return catalogsInsert;
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
            List<RegistryInfo> registersList = new List<RegistryInfo>();

            var fileName = @"C:\Users\User1_106\Desktop\Реестр Васильево Ленина 28.xlsx";

            // Откройте документ электронной таблицы для доступа только для чтения
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                // Получить ссылку на часть книги
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;

                // Находим лист с указанным именем, а затем используем это
                // Объект листа для получения ссылки на первый рабочий лист.
                Sheet theSheet = workbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == "Лист1").FirstOrDefault();

                // https://docs.microsoft.com/ru-ru/office/open-xml/how-to-retrieve-the-values-of-cells-in-a-spreadsheet

                // Получить ссылку на часть рабочего листа
                WorksheetPart worksheetPart = (WorksheetPart)(workbookPart.GetPartById(theSheet.Id));

                // Используем его свойство Worksheet для получения ссылки на ячейку
                // чей адрес соответствует указанному вами адресу
                Cell theCell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference == "A8").FirstOrDefault();

                Console.WriteLine();
            }

            var apartment = "97";
            var model = "СО-И449М";
            var serial = "0174281";

            registersList.Add(new RegistryInfo(apartment, model, serial));

            return registersList;
        }

        /// <summary>
        /// Принимает путь до файла, редактирует его
        /// </summary>
        public static void CreateDoc()
        {
            DB yourDBObject = new DB();
            List<DocumentInfo> AddressDocList = yourDBObject.GetDocumentList();

            var originalFilePath = @"C:\Users\User1_106\Desktop\template.docx";

            // Путь
            var filePuth = AddressDocList.Select(x => x.Save + @"\Отчет ППО " + x.City + ", " + x.Street + " " + x.Home + ".docx").ToList();

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
