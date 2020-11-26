using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        public static void GetID(MySqlConnection connection, int catalog_id)
        {
            List<InfoRegistry> RegistersList = GetFill(connection, catalog_id);
            GetInsert(RegistersList, connection);
        }
    }
}
