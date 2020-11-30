using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        public static void GetID(MySqlConnection connection, int catalog_id, List<InfoCatalog> path)
        {
            List<InfoAddress> AddressesList = GetFill(catalog_id, path);
            GetInsert(AddressesList, connection);
        }
    }
}
