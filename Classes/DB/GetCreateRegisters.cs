using MySql.Data.MySqlClient;
using System;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Создается таблица Registers в БД
        /// </summary>
        public void GetCreateRegisters()
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Registers
                (
                    Registry_Id INT AUTO_INCREMENT PRIMARY KEY, 
                    Catalog_id INT(5) NOT NULL,
                    Apartment VARCHAR(15) NOT NULL,
                    Model VARCHAR(30) NOT NULL,
                    Serial VARCHAR(30) NOT NULL
                );",
                connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
