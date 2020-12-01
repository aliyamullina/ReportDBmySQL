using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Node
    {
        /// <summary>
        /// Заполнение таблицы Maps в БД
        /// </summary>
        public static void GetInsert(List<InfoNode> nodeListEdit, MySqlConnection connection)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"
            INSERT INTO maps(Floor, FlatsCount, Entrance) 
            VALUES (@floor, @flatscount, @entrance)
            ", connection))
            {
                connection.Open();
                foreach (var item in nodeListEdit)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@floor", item.Floor);
                    command.Parameters.AddWithValue("@flatscount", item.FlatsCount);
                    command.Parameters.AddWithValue("@entrance", item.Entrance);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }

}


