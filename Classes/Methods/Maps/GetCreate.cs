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
                (Map_Id INT AUTO_INCREMENT PRIMARY KEY, 
                Floor VARCHAR(30) NOT NULL,
                FlatsCount VARCHAR(30) NOT NULL,
                Entrance VARCHAR(30) NOT NULL
                );", connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

