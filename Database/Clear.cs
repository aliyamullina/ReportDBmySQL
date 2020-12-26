using MySql.Data.MySqlClient;
using System;

namespace ReportDBmySQL
{
    public partial class Database
    {
        /// <summary>
        /// Очистка общей таблицы
        /// </summary>
        public void Clear()
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("DROP TABLE cities, addresses, dates, catalogs, registers, maps;", connection))
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
