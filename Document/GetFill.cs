using DocumentFormat.OpenXml.Packaging;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Берет готовый doc, редактирует
        /// </summary>
        private static void GetFill(string fN, string filePath, MySqlConnection connection)
        {
            using (WordprocessingDocument WordDoc = WordprocessingDocument.Open(filePath, isEditable: true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(WordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                docText = new Regex("AddressInfo").Replace(docText, fN);
                docText = Maps.GetFill(fN, connection, docText);

                using (StreamWriter sw = new StreamWriter(WordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }

                ExcelTables.GetFillTable(WordDoc, fN, connection);

                WordDoc.MainDocumentPart.Document.Save();
                WordDoc.Close();
            }
        }
    }
}
