using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        public static void GetID(in int catalog_id, ref List<InfoCatalog> oneCatalogPath, MySqlConnection connection)
        {
            GetFill(out List<InfoAddress> addressesList, catalog_id, ref oneCatalogPath);
            GetInsert(in addressesList, connection);
        }
    }
}
