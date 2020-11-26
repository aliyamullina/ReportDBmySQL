﻿using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ReportDBmySQL
{
    public partial class CreateDocument
    {
        /// <summary>
        /// Создание и заполнение таблицы
        /// </summary>
        private static void GetFillTable(WordprocessingDocument WordDoc, string fN, Database db)
        {
            Table table = new Table();
            GetCreateTableProperties(table);
            GetFillTableHead(table);
            GetFillTableBody(table, fN, db);
            WordDoc.MainDocumentPart.Document.Body.Append(table);
        }
    }
}
