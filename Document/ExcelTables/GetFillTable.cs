using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class ExcelTables
    {
        /// <summary>
        /// Создание и заполнение таблицы
        /// </summary>
        public static void GetFillTable(WordprocessingDocument WordDoc, string fN, MySqlConnection connection)
        {
            Table table = new Table();
            CreateProperties(table);
            GetFillTableHead(table);
            GetFillTableBody(table, fN, connection);
            WordDoc.MainDocumentPart.Document.Body.Append(table);
        }
    }
}
