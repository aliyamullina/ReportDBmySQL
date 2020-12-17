using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        public static void GetID(in int catalog_id, List<InfoCatalog> path, MySqlConnection connection)
        {
            GetFillList(out List<InfoRegistry> registersList, in catalog_id, path);
            GetInsert(in registersList, connection);
        }
    }
}
