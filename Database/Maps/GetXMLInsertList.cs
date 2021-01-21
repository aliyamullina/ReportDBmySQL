using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Вносит данные адреса в XML файл
        /// </summary>
        public static void GetXMLInsertList(out List<InfoMap> mapListInsert, MySqlConnection connection)
        {
            mapListInsert = new List<InfoMap>();
        }
    }
}
