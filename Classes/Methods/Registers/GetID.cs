using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        public static void GetID(MySqlConnection connection, int catalog_id, List<InfoCatalog> path)
        {
            List<InfoRegistry> RegistersList = GetFill(catalog_id, path);
            GetInsert(RegistersList, connection);
        }
    }
}
