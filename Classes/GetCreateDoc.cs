using DocumentFormat.OpenXml.Packaging;
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

            // Все доступные адреса
            List<InfoDocumentAddress> fullAddresses = db.GetDocumentAddresses();

            foreach (InfoDocumentAddress fileName in fullAddresses)
            {
                List<InfoDocumentCatalog> fileCatalog = db.GetDocumentCatalog(fileName.Address);

                var fN = fileName.Address;

                var fC = string.Join("", fileCatalog.Select(x => x.Catalog));

                List<InfoDocumentTable> fileTable = db.GetDocumentTable(fC);

                var fT = fileTable.Select(x => x.City + " " + x.Street + " " + x.Home + " " + x.Apartment + " " + x.Model + " " + x.Serial).ToList();

                // Создается файл по шаблону
                var filePath = fC + @"\Отчет ППО " + fN + ".docx";
                File.Copy(originalFilePath, filePath);

                // Берет готовый doc, редактирует
                using (WordprocessingDocument WordDoc = WordprocessingDocument.Open(filePath, isEditable: true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(WordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    Regex AddressText = new Regex("AddressInfo");
                    docText = AddressText.Replace(docText, fN);

                    Regex TableText = new Regex("TableInfo");
                    //docText = TableText.Replace(docText, fT);

                    using (StreamWriter sw = new StreamWriter(WordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                    WordDoc.MainDocumentPart.Document.Save();
                    WordDoc.Close();

                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
