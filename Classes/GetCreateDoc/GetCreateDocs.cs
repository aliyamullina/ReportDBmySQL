using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class GetCreateDoc
    {
        /// <summary>
        /// Принимает путь до файла, редактирует его
        /// </summary>
        public static void GetCreateDocs()
        {
            var originalFilePath = @"C:\Users\User1_106\Desktop\template.docx";

            DB db = new DB();

            List<InfoDocumentAddress> fullAddresses = db.GetDocAddresses();

            foreach (InfoDocumentAddress fileName in fullAddresses)
            {
                var fN = fileName.Address;

                List<InfoDocumentCatalog> fileCatalog = db.GetDocCatalog(fN);


                var fC = string.Join("", fileCatalog.Select(x => x.Catalog));

                //var fT = fileTable.Select(x => x.City + " " + x.Street + " " + x.Home + " " + x.Apartment + " " + x.Model + " " + x.Serial).ToList();

                string filePath = GetTemplateDoc(originalFilePath, fN, fC);

                GetFillDoc(fN, filePath, db);
            }
            Console.WriteLine();
        }
    }
}
