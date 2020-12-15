using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        public static void GetID(MySqlConnection connection, int catalog_id, ref List<InfoCatalog> oneCatalogPath)
        {
            List<InfoAddress> addressesList = new List<InfoAddress>();
            
            GetFill(ref addressesList, catalog_id, ref oneCatalogPath);
            GetInsert(ref addressesList, connection);
        }
    }
}
