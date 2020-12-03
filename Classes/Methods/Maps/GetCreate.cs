﻿using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Создается таблица карты
        /// </summary>
        public static void GetCreate(MySqlConnection connection)
        {
            using (MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Maps
                (Map_id INT AUTO_INCREMENT PRIMARY KEY, 
                Floor VARCHAR(30),
                FlatsCount VARCHAR(30),
                Entrance VARCHAR(30)
                );", connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}


