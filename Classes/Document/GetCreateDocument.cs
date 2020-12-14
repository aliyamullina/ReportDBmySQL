﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Принимает путь до файла, редактирует его
        /// </summary>
        public static void GetCreateDocument(MySqlConnection connection)
        {
            var documentTemplate = @"C:\Users\User1_106\Desktop\template.docx";

            List<InfoDocument> infoDocuments = GetSelectDocument(connection);

            foreach (InfoDocument info in infoDocuments)
            {
                var fN = info.Address;

                var fC = info.Catalog;

                string filePath = GetCopyTemplate(documentTemplate, fN, fC);

                GetFillDocument(fN, filePath, connection);
            }
        }
    }
}