using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReportDBmySQL
{
    class GetCreateDoc
    {
        /// <summary>
        /// Принимает путь до файла, редактирует его
        /// </summary>
        public static void Create()
        {
            var originalFilePath = @"C:\Users\User1_106\Desktop\template.docx";

            DB db = new DB();

            List<InfoDocumentAddress> fullAddresses = db.GetDocumentAddresses();

            foreach (InfoDocumentAddress fileName in fullAddresses)
            {
                var fN = fileName.Address;

                List<InfoDocumentCatalog> fileCatalog = db.GetDocumentCatalog(fN);
                

                var fC = string.Join("", fileCatalog.Select(x => x.Catalog));

                //var fT = fileTable.Select(x => x.City + " " + x.Street + " " + x.Home + " " + x.Apartment + " " + x.Model + " " + x.Serial).ToList();

                string filePath = getTemplateDoc(originalFilePath, fN, fC);

                getFillDoc(fN, filePath, db);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Создается файл по шаблону
        /// </summary>
        private static string getTemplateDoc(string originalFilePath, string fN, string fC)
        {
            var filePath = fC + @"\Отчет ППО " + fN + ".docx";
            try { 
                
                File.Copy(originalFilePath, filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                // удалить существующий файл
            }
            return filePath;
        }

        /// <summary>
        /// Берет готовый doc, редактирует
        /// </summary>
        private static void getFillDoc(string fN, string filePath, DB db)
        {
            using (WordprocessingDocument WordDoc = WordprocessingDocument.Open(filePath, isEditable: true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(WordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                docText = new Regex("AddressInfo").Replace(docText, fN);

                using (StreamWriter sw = new StreamWriter(WordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }

                Table table = new Table();
                getFillTable(table, fN, db);

                WordDoc.MainDocumentPart.Document.Body.Append(table);
                WordDoc.MainDocumentPart.Document.Save();
                WordDoc.Close();
            }
        }

        /// <summary>
        /// Создание и заполнение таблицы
        /// </summary>
        private static void getFillTable(Table table, string fN, DB db)
        {
            getCreateProperties(table);
            getFillTableHead(table);
            getFillTableBody(table, fN, db);
        }

        /// <summary>
        /// Заполнение заголовков таблицы
        /// </summary>
        private static void getFillTableHead(Table table)
        {
            TableGrid tr = new TableGrid(new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn());
            table.AppendChild(tr);

            TableRow headerRow = new TableRow();
            TableCell headerTdCount = new TableCell(new Paragraph(new Run(new Text("№ П/П"))));
            TableCell headerTdCity = new TableCell(new Paragraph(new Run(new Text("Нас. пункт"))));
            TableCell headerTdStreet = new TableCell(new Paragraph(new Run(new Text("Улица"))));
            TableCell headerTdHome = new TableCell(new Paragraph(new Run(new Text("Дом"))));
            TableCell headerTdApartment = new TableCell(new Paragraph(new Run(new Text("Кв."))));
            TableCell headerTdModel = new TableCell(new Paragraph(new Run(new Text("Тип ПУ"))));
            TableCell headerTdSerial = new TableCell(new Paragraph(new Run(new Text("№ ПУ"))));
            TableCell headerTdComment = new TableCell(new Paragraph(new Run(new Text("Комментарии"))));
            headerRow.Append(headerTdCount, headerTdCity, headerTdStreet, headerTdHome, headerTdApartment, headerTdModel, headerTdSerial, headerTdComment);
            table.AppendChild(headerRow);
        }

        /// <summary>
        /// Заполнение содержимого таблицы
        /// </summary>
        private static void getFillTableBody(Table table, string fN, DB db)
        {
            List<InfoDocumentTable> fileTable = db.GetDocumentTable(fN);

            string comment = "В 2020 году истекает срок поверки. Требуется замена";

            int count = 1;

            foreach (InfoDocumentTable iT in fileTable)
            {
                TableRow bodyRow = new TableRow();
                TableCell bodyTdCount = new TableCell(new Paragraph(new Run(new Text((count++).ToString()))));
                TableCell bodyTdCity = new TableCell(new Paragraph(new Run(new Text(iT.City))));
                TableCell bodyTdStreet = new TableCell(new Paragraph(new Run(new Text(iT.Street))));
                TableCell bodyTdHome = new TableCell(new Paragraph(new Run(new Text(iT.Home))));
                TableCell bodyTdApartment = new TableCell(new Paragraph(new Run(new Text(iT.Apartment))));
                TableCell bodyTdModel = new TableCell(new Paragraph(new Run(new Text(iT.Model))));
                TableCell bodyTdSerial = new TableCell(new Paragraph(new Run(new Text(iT.Serial))));
                TableCell bodyTdComment = new TableCell(new Paragraph(new Run(new Text(comment))));
                bodyRow.Append(bodyTdCount, bodyTdCity, bodyTdStreet, bodyTdHome, bodyTdApartment, bodyTdModel, bodyTdSerial, bodyTdComment);
                table.AppendChild(bodyRow);
            }
        }


        /// <summary>
        /// Настройки свойств для таблицы
        /// </summary>
        private static void getCreateProperties(Table table)
        {
            TableProperties props = new TableProperties(
                            new TableBorders
                            (
                                new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                            new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                            new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                            new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                            new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                            new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 }
                            )
                        );

            TableStyle tableStyle = new TableStyle() { Val = "TableGrid" };

            TableWidth tableWidth = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };

            props.Append(tableStyle, tableWidth);

            table.AppendChild(props);
        }
    }
}
