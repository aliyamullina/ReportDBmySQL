using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        public static void GetID(MySqlConnection connection, int catalog_id)
        {
            List<InfoAddress> AddressesList = GetFill(connection, catalog_id);
            GetInsert(AddressesList, connection);
        }
    }
}
