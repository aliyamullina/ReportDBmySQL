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

                //fileCatalog.Select(x=>x.Catalog);
                //fileName.Address;

                IEnumerable<string> fC = fileCatalog.Select(x => x.Catalog);
                string fN = fileName.Address;

                foreach (var pn in fC.Zip(fN, (p, n) => new { fC = p, fN = n }))
                {
                    //var filePuth = fullAddressCatalog.Select(x => x.Catalog + @"\Отчет ППО " + x.City + ", " + x.Street + " " + x.Home + ".docx").Distinct().ToList();
                    string filePath = pn.fC + @"\Отчет ППО " + pn.fN + ".docx";

                    File.Copy(originalFilePath, filePath);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            List<InfoDocument> AddressDocList = db.GetDocumentList();

            //var table = AddressDocList.Select(x => x.City + " " + x.Street + " " + x.Home + " " + x.Apartment + " " + x.Model + " " + x.Serial).ToList();

            //foreach (var pn in filePuth.Zip(fileName, (p, n) => new { filePuth = p, fileName = n }))
            //{
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
