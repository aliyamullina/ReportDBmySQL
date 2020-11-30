using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Создание и заполнение таблицы
        /// </summary>
        private static void GetFillTable(WordprocessingDocument WordDoc, string fN, MySqlConnection connection)
        {
            Table table = new Table();
            CreateTableProperties(table);
            GetFillTableHead(table);
            GetFillTableBody(table, fN, connection);
            WordDoc.MainDocumentPart.Document.Body.Append(table);
        }
    }
}
