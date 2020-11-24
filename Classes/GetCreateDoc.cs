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
                List<InfoDocumentTable> fileTable = db.GetDocumentTable(fN);

                var fC = string.Join("", fileCatalog.Select(x => x.Catalog));

                var fT = fileTable.Select(x => x.City + " " + x.Street + " " + x.Home + " " + x.Apartment + " " + x.Model + " " + x.Serial).ToList();

                string filePath = getTemplateDoc(originalFilePath, fN, fC);

                getFillDoc(fN, filePath, fT);
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
        private static void getFillDoc(string fN, string filePath, List<string> fT)
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
                getFillTable(WordDoc, table, fT);

                WordDoc.MainDocumentPart.Document.Save();
                WordDoc.Close();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Создание и заполнение таблицы
        /// </summary>
        private static void getFillTable(WordprocessingDocument WordDoc, Table table, List<string> fT)
        {
            TableProperties props = CreateProperties();
            
            TableStyle tableStyle = new TableStyle() { Val = "TableGrid" };

            TableWidth tableWidth = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };

            props.Append(tableStyle, tableWidth);

            table.AppendChild(props);

            // №п/п	Нас.пункт	Улица	№дома	№ кв.	Тип ПУ	№ПУ	Комментарии
            // Зеленодольск Татарстан 10 16 СО-ИБМЗ 11511

            // 8 колонок в таблице
            TableGrid tr = new TableGrid(new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn());
            table.AppendChild(tr);

            // 1 ряд в таблице
            TableRow tr1 = new TableRow();

            // Ячейки
            TableCell td1 = new TableCell(new Paragraph(new Run(new Text("№ П/П"))));
            TableCell td2 = new TableCell(new Paragraph(new Run(new Text("Нас. пункт"))));
            TableCell td3 = new TableCell(new Paragraph(new Run(new Text("Улица"))));
            TableCell td4 = new TableCell(new Paragraph(new Run(new Text("№ Дома"))));
            TableCell td5 = new TableCell(new Paragraph(new Run(new Text("№ Кв."))));
            TableCell td6 = new TableCell(new Paragraph(new Run(new Text("Тип ПУ"))));
            TableCell td7 = new TableCell(new Paragraph(new Run(new Text("№ ПУ"))));
            TableCell td8 = new TableCell(new Paragraph(new Run(new Text("Комментарии"))));

            tr1.Append(td1, td2, td3, td4, td5, td6, td7, td8);

            // Add row to the table
            table.AppendChild(tr1);

            // Приложите таблицу к документу
            WordDoc.MainDocumentPart.Document.Body.Append(table);
        }

        private static TableProperties CreateProperties()
        {
            return new TableProperties(
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
        }
    }
}
