﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        /// <summary>
        /// Заполнение таблицы Adresses в БД
        /// </summary>
        public static void GetInsertList(in List<InfoAddress> addressesList, MySqlConnection connection)
        {
            try
            {
                // Добавляет повторно, нет проверки на существование записи
                using (MySqlCommand command = new MySqlCommand(@"
                INSERT INTO addresses(Street, Home, Part, City_id) 
                VALUES (@street, @home, @part, @city_id)",
                    connection))
                {
                    foreach (var item in addressesList)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@street", item.Street);
                        command.Parameters.AddWithValue("@home", item.Home);
                        command.Parameters.AddWithValue("@part", item.Part);
                        command.Parameters.AddWithValue("@city_id", item.City_id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
