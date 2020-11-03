using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {

        /// <summary>
        /// Создается таблица Cities в БД
        /// </summary>
        public void CreateTableCities()
        {
            MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Cities
                (City_Id INT AUTO_INCREMENT PRIMARY KEY, 
                City VARCHAR(30) NOT NULL);",
                connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Заполнение таблицы Cities в БД
        /// </summary>
        public void InsertTableCities(List<CityInfo> citiesList)
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
