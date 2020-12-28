using MySql.Data.MySqlClient;
using System;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        /// <summary>
        /// Создается таблица Adresses в БД
        /// </summary>
        public static void CreateTable(MySqlConnection connection)
        {
            using (MySqlCommand command = new MySqlCommand(@"
            CREATE TABLE IF NOT EXISTS Addresses(
                Address_Id      INT AUTO_INCREMENT PRIMARY KEY, 
                Street          VARCHAR(30) NOT NULL, 
                Home            VARCHAR(10), 
                City_id         INT REFERENCES Cities(City_id),
                Catalog_id      INT REFERENCES Catalogs(Catalog_id)
            )", connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
