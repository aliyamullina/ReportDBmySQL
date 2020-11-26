using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Создание и заполнение таблицы
        /// </summary>
        private static void GetFillTable(WordprocessingDocument WordDoc, string fN, Adresses db)
        {
            Table table = new Table();
            GetCreateTableProperties(table);
            GetFillTableHead(table);
            GetFillTableBody(table, fN, db);
            WordDoc.MainDocumentPart.Document.Body.Append(table);
        }
    }
}
