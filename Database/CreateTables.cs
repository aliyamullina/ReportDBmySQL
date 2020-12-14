using MySql.Data.MySqlClient;
using System;

namespace ReportDBmySQL
{
    public partial class Database
    {
        public static void CreateTable(MySqlConnection connection)
        {
            Catalogs.CreateTable(connection);
            Cities.CreateTable(connection);
            Adresses.CreateTable(connection);
            Registers.CreateTable(connection);
            Maps.CreateTable(connection);
        }
    }
}
