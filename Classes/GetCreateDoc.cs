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

            List<InfoDocumentAddress> fullAddresses = db.GetDocumentAddresses();

            foreach (InfoDocumentAddress fileName in fullAddresses)
            {
                var fN = fileName.Address;

                List<InfoDocumentCatalog> fileCatalog = db.GetDocumentCatalog(fN);
                List<InfoDocumentTable> fileTable = db.GetDocumentTable(fN);

                var fC = string.Join("", fileCatalog.Select(x => x.Catalog));

                var fT = fileTable.Select(x => x.City + " " + x.Street + " " + x.Home + " " + x.Apartment + " " + x.Model + " " + x.Serial).ToList();

                string filePath = getCreateDoc(originalFilePath, fN, fC);

                getReplaceDoc(fN, filePath);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Создается файл по шаблону
        /// </summary>
        /// <param name="originalFilePath"></param>
        /// <param name="fN"></param>
        /// <param name="fC"></param>
        /// <returns></returns>
        private static string getCreateDoc(string originalFilePath, string fN, string fC)
        {
            var filePath = fC + @"\Отчет ППО " + fN + ".docx";
            File.Copy(originalFilePath, filePath);
            return filePath;
        }

        /// <summary>
        /// Берет готовый doc, редактирует
        /// </summary>
        /// <param name="fN"></param>
        /// <param name="filePath"></param>
        private static void getReplaceDoc(string fN, string filePath)
        {
            using (WordprocessingDocument WordDoc = WordprocessingDocument.Open(filePath, isEditable: true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(WordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                docText = new Regex("AddressInfo").Replace(docText, fN);

                // Одно слово заменить списком
                // docText = new Regex("TableInfo").Replace(docText, fT);



                using (StreamWriter sw = new StreamWriter(WordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
                WordDoc.MainDocumentPart.Document.Save();
                WordDoc.Close();

                Console.WriteLine();
            }
        }
    }
}
