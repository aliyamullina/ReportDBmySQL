using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Принимает путь до файла, редактирует его
        /// </summary>
        public static void GetCreateDocs(MySqlConnection connection)
        {
            var originalFilePath = @"C:\Users\User1_106\Desktop\template.docx";

            List<InfoDocumentAddress> fullAddresses = GetDocAddresses(connection);

            foreach (InfoDocumentAddress fileName in fullAddresses)
            {
                var fN = fileName.Address;

                List<InfoDocumentCatalog> fileCatalog = GetDocCatalogs(fN, connection);


                var fC = string.Join("", fileCatalog.Select(x => x.Catalog));

                //var fT = fileTable.Select(x => x.City + " " + x.Street + " " + x.Home + " " + x.Apartment + " " + x.Model + " " + x.Serial).ToList();

                string filePath = GetTemplateDoc(originalFilePath, fN, fC);

                GetFillDoc(fN, filePath, connection);
            }
            Console.WriteLine();
        }
    }
}
