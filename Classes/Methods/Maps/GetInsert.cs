using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Заполнение таблицы Maps в БД
        /// </summary>
        public static void GetInsert(List<InfoMap> mapsList, MySqlConnection connection)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"
                INSERT INTO maps(Floor, ApartmentCount, Entrance) 
                VALUES (@floor, @apartmentcounr, @entrance)
                ", connection))
            {
                connection.Open();
                foreach (var item in mapsList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@floor", item.Floor);
                    command.Parameters.AddWithValue("@apartmentcount", item.ApartmentCount);
                    command.Parameters.AddWithValue("@entrance", item.Entrance);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
