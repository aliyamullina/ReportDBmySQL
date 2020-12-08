using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Database
    {
        public static void GetFillTable(MySqlConnection connection, bool withoutReportsSearch)
        {
            List<InfoCity> CitiesList = Cities.GetFill();
            Cities.GetInsert(CitiesList, connection);

            List<InfoCatalog> CatalogsInsert = Catalogs.GetFill(withoutReportsSearch);
            Catalogs.GetInsert(CatalogsInsert, connection);
        }
    }
}
