using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Запрос данных адреса из БД в XML файл
        /// </summary>
        public static void GetXMLSelectList(out List<InfoMap> mapListInsert, MySqlConnection connection)
        {
            mapListInsert = new List<InfoMap>();
        }
    }
}
