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

                //var fileName = AddressDocList.Select(x => x.City + ", " + x.Street + " " + x.Home).Distinct().ToList();
                //IEnumerable<string> fileCatalog = fullAddressCatalog.Select(x => x.Catalog);

                //foreach (var pn in fileCatalog.Zip(fileName, (p, n) => new { fileCatalog = p, fileName = n }))
                //{
                //    var filePuth = fullAddressCatalog.Select(x => x.Catalog + @"\Отчет ППО " + x.City + ", " + x.Street + " " + x.Home + ".docx").Distinct().ToList();
                //    var filePuth = fullAddressCatalog.Select(x => x.Catalog + @"\Отчет ППО " + x.City + ", " + x.Street + " " + x.Home + ".docx").Distinct().ToList();
                //}
                Console.WriteLine();
            }

            Console.WriteLine();

            List<InfoDocument> AddressDocList = db.GetDocumentList();

            //var table = AddressDocList.Select(x => x.City + " " + x.Street + " " + x.Home + " " + x.Apartment + " " + x.Model + " " + x.Serial).ToList();

            //foreach (var pn in filePuth.Zip(fileName, (p, n) => new { filePuth = p, fileName = n }))
            //{
            //    // Копировал файл, давал новое имя, редактировал
            //    File.Copy(originalFilePath, pn.filePuth);

            //    // Берет готовый doc, редактирует
            //    using (WordprocessingDocument WordDoc = WordprocessingDocument.Open(pn.filePuth, isEditable: true))
            //    {
            //        string docText = null;
            //        using (StreamReader sr = new StreamReader(WordDoc.MainDocumentPart.GetStream()))
            //        {
            //            docText = sr.ReadToEnd();
            //        }

            //        Regex regexText = new Regex("AddressInfo");
            //        docText = regexText.Replace(docText, pn.fileName);

            //        using (StreamWriter sw = new StreamWriter(WordDoc.MainDocumentPart.GetStream(FileMode.Create)))
            //        {
            //            sw.Write(docText);
            //        }
            //        WordDoc.MainDocumentPart.Document.Save();
            //        WordDoc.Close();
            //    }
            //}
        }
    }
}
