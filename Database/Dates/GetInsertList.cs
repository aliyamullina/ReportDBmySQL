using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Dates
    {
        /// <summary>
        /// Заполнение таблицы Dates в БД
        /// </summary>
        public static void GetInsertList(in List<InfoDate> dateList, MySqlConnection connection)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"INSERT INTO dates(Date) VALUES (@date)", connection))
            {
                connection.Open();
                foreach (var item in dateList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@date", item.Date);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
