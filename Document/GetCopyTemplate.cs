using System;
using System.IO;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Создается файл по шаблону
        /// </summary>
        private static string GetCopyTemplate(string documentTemplate, string fN, string fC)
        {
            var filePath = fC + @"\Отчет ППО " + fN + ".docx";

            try { 

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                File.Copy(documentTemplate, filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return filePath;
        }
    }
}
