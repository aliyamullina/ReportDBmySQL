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

                Table table = new Table();
                getFillTable(WordDoc, table, fT);

                using (StreamWriter sw = new StreamWriter(WordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
                WordDoc.MainDocumentPart.Document.Save();
                WordDoc.Close();
            }
        }

        /// <summary>
        /// Создание и заполнение таблицы
        /// </summary>
        private static void getFillTable(WordprocessingDocument WordDoc, Table table, List<string> fT)
        {
            // №п/п	Нас.пункт	Улица	№дома	№ кв.	Тип ПУ	№ПУ	Комментарии

            // Создайте объект TableProperties и укажите информацию о его границах.
            TableProperties tblProp = new TableProperties(
                new TableBorders
                (
                    new TopBorder()                 { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 24 },
                    new BottomBorder()              { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 24 },
                    new LeftBorder()                { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 24 },
                    new RightBorder()               { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 24 },
                    new InsideHorizontalBorder()    { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 24 },
                    new InsideVerticalBorder()      { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 24 }
                )
            );

            // Добавьте объект TableProperties в пустую таблицу
            table.AppendChild<TableProperties>(tblProp);

            // Создайте ряд
            TableRow tr = new TableRow();

            // Создайте ячейку
            TableCell tc1 = new TableCell();

            // Укажите свойство ширины ячейки таблицы
            tc1.Append(new TableCellProperties
                (
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" })
                );

            // Укажите содержимое ячейки таблицы
            tc1.Append(new Paragraph(new Run(new Text("some text"))));

            // Добавить ячейку таблицы в строку таблицы
            tr.Append(tc1);

            // Создайте вторую ячейку таблицы, скопировав значение OuterXml первой ячейки таблицы
            TableCell tc2 = new TableCell(tc1.OuterXml);

            // Добавить ячейку таблицы в строку таблицы.
            tr.Append(tc2);

            // Добавить строку таблицы в таблицу.
            table.Append(tr);

            // Приложите таблицу к документу.
            WordDoc.MainDocumentPart.Document.Body.Append(table);
        }
    }
}
