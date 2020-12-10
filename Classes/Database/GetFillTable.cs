using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Database
    {
        public static void GetFillTable(MySqlConnection connection, bool withoutReportsSearch)
        {
            List<InfoCatalog> CatalogsInsert = Catalogs.GetFill(withoutReportsSearch, connection);
            Catalogs.GetInsert(CatalogsInsert, connection);
        }
    }
}
