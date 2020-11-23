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
            DB db = new DB();

            // Все доступные адреса
            List<InfoDocumentAddress> InfoDocumentAddress = db.GetDocumentAddresses();

            foreach (InfoDocumentAddress a in InfoDocumentAddress)
            {
                //Поиск каталога к адресу
                var c = db.GetDocumentCatalog(a.Address);
            }

            Console.WriteLine();

            List<InfoDocument> AddressDocList = db.GetDocumentList();

            var originalFilePath = @"C:\Users\User1_106\Desktop\template.docx";

            // Путь x.Open - если в корень
            var filePuth = AddressDocList.Select(x => x.Catalog + @"\Отчет ППО " + x.City + ", " + x.Street + " " + x.Home + ".docx").Distinct().ToList();

            var fileName = AddressDocList.Select(x => x.City + ", " + x.Street + " " + x.Home).Distinct().ToList();

            var table = AddressDocList.Select(x => x.City + " " + x.Street + " " + x.Home + " " + x.Apartment + " " + x.Model + " " + x.Serial).ToList();

            Console.WriteLine();

            foreach (var pn in filePuth.Zip(fileName, (p, n) => new { filePuth = p, fileName = n }))
            {
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
