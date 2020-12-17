using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Cities
    {
        /// <summary>
        /// Заполнение таблицы Cities в БД
        /// </summary>
        public static void GetInsert(in List<InfoCity> citiesList, MySqlConnection connection)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"INSERT INTO cities(City) VALUES (@city)", connection))
            {
                connection.Open();
                foreach (var item in citiesList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@city", item.City);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
