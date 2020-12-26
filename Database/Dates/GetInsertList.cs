using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Dates
    {
        /// <summary>
        /// Заполнение таблицы Dates в БД
        /// </summary>
        public static void GetInsertList(in List<DateTime> dateList, MySqlConnection connection)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"INSERT INTO dates(Date) VALUES (@date)", connection))
            {
                foreach (var item in dateList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@date", item.Date);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
