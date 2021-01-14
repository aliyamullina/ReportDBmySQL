using MySql.Data.MySqlClient;
using System;

namespace ReportDBmySQL
{
    public partial class Database
    {
        public static void CreateTables(MySqlConnection connection)
        {
            Opens.CreateTable(connection);
            Catalogs.CreateTable(connection);
            Cities.CreateTable(connection);
            Dates.CreateTable(connection);
            Adresses.CreateTable(connection);
            Acts.CreateTable(connection);
            Registers.CreateTable(connection);
            Maps.CreateTable(connection);
        }
    }
}
