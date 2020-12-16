using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        public static void GetID(MySqlConnection connection, int catalog_id, List<InfoCatalog> path)
        {
            List<InfoRegistry> registersList = new List<InfoRegistry>();
            GetFill(ref registersList, catalog_id, path);
            GetInsert(ref registersList, connection);
        }
    }
}
