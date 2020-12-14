using DocumentFormat.OpenXml.Packaging;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Добавляет в doc данные по карте
        /// </summary>
        private static string GetFillDocMap(string fN, MySqlConnection connection, string docText)
        {
            List<InfoMap> documentMap = GetSelectInfoMap(fN, connection);

            foreach (InfoMap map in documentMap)
            {
                docText = new Regex("FloorInfo").Replace(docText, map.Floor);
                docText = new Regex("FlatsCountInfo").Replace(docText, map.FlatsCount);
                docText = new Regex("EntranceInfo").Replace(docText, map.Entrance);
            }

            return docText;
        }
    }
}
