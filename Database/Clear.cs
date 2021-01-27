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
            using (MySqlCommand command = new MySqlCommand("DROP TABLE IF EXISTS cities, addresses, dates, catalogs, acts, registers, maps;", connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
