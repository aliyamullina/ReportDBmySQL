using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Добавляет в doc данные по карте
        /// </summary>
        public static void GetFill(in List<InfoMap> documentMap, ref string docText)
        {
            foreach (InfoMap map in documentMap)
            {
                docText = new Regex("FloorInfo").Replace(docText, map.Floor);
                docText = new Regex("FlatsCountInfo").Replace(docText, map.FlatsCount);
                docText = new Regex("EntranceInfo").Replace(docText, map.Entrance);
            }
        }
    }
}
