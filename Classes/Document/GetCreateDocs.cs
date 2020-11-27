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
            var documentTemplate = @"C:\Users\User1_106\Desktop\template.docx";

            List<InfoDocument> infoDocuments = GetInfoDocument(connection);

            foreach (InfoDocument info in infoDocuments)
            {
                var fN = info.Address;

                var fC = info.Catalog;

                string filePath = GetDocumentTemplate(documentTemplate, fN, fC);

                GetFillDoc(fN, filePath, connection);
            }
        }
    }
}
