using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReportDBmySQL
{
    public partial class GetCreateDoc
    {
        /// <summary>
        /// Создается файл по шаблону
        /// </summary>
        private static string GetTemplateDoc(string originalFilePath, string fN, string fC)
        {
            var filePath = fC + @"\Отчет ППО " + fN + ".docx";

            try { 

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                File.Copy(originalFilePath, filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return filePath;
        }
    }
}
