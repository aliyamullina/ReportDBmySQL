using MySql.Data.MySqlClient;
using System;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Очистка общей таблицы
        /// </summary>
        public void DBClear()
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("DROP TABLE cities, addresses, catalogs, registers;", connection))
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
