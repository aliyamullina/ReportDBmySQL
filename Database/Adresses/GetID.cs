using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        public static void GetID(MySqlConnection connection, int catalog_id, ref List<InfoCatalog> oneCatalogPath)
        {
            GetFill(out List<InfoAddress> addressesList, catalog_id, ref oneCatalogPath);
            GetInsert(in addressesList, connection);
        }
    }
}
