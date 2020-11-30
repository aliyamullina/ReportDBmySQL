using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Создается список данных карты для адресов
        /// </summary>
        public static void GetID(MySqlConnection connection, List<InfoAddress> AddressesList)
        {
            List<InfoMap> MapList = GetFill(AddressesList);
            GetInsert(MapList, connection);
        }
    }
}
