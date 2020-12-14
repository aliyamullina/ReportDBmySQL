using MySql.Data.MySqlClient;
using System;

namespace ReportDBmySQL
{
    public partial class Database
    {
        public static void CreateTable(MySqlConnection connection)
        {
            Catalogs.GetCreate(connection);
            Cities.GetCreate(connection);
            Adresses.GetCreate(connection);
            Registers.GetCreate(connection);
            Maps.GetCreate(connection);
        }
    }
}
