using MySql.Data.MySqlClient;
using System;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        /// <summary>
        /// Создается таблица Registers в БД
        /// </summary>
        public static void CreateTable(MySqlConnection connection)
        {
            using (MySqlCommand command = new MySqlCommand(@"
            CREATE TABLE IF NOT EXISTS Registers
            (
                Registry_Id     INT AUTO_INCREMENT PRIMARY KEY, 
                Catalog_id      INT(5) NOT NULL,
                Apartment       VARCHAR(15) NOT NULL,
                Model           VARCHAR(30) NOT NULL,
                Serial          VARCHAR(30) NOT NULL
            );",
            connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
