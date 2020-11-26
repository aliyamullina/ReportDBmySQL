using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Text.RegularExpressions;

namespace ReportDBmySQL
{
    public partial class CreateDocument
    {
        /// <summary>
        /// Берет готовый doc, редактирует
        /// </summary>
        private static void GetFillDoc(string fN, string filePath, DB db)
        {
            using (WordprocessingDocument WordDoc = WordprocessingDocument.Open(filePath, isEditable: true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(WordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                docText = new Regex("AddressInfo").Replace(docText, fN);

                using (StreamWriter sw = new StreamWriter(WordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }

                GetFillTable(WordDoc, fN, db);
                
                WordDoc.MainDocumentPart.Document.Save();
                WordDoc.Close();
            }
        }
    }
}
