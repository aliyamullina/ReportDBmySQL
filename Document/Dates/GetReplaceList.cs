using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReportDBmySQL
{
    public partial class Dates
    {
        /// <summary>
        /// Добавляет в doc данные по карте
        /// </summary>
        public static void GetReplaceList(in List<DateTime> documentDate, ref string docText)
        {
            foreach (DateTime item in documentDate)
            {
                docText = new Regex("DateInfo").Replace(docText, item.Date.ToString("dd.MM.yyyy"));
            }
        }
    }
}
