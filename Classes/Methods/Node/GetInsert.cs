using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Node
    {
        /// <summary>
        /// Заполнение таблицы Maps в БД
        /// </summary>
        public static void GetInsert(List<InfoMap> nodeListEdit, MySqlConnection connection)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"
            INSERT INTO maps(Floor, FlatsCount, Entrance, Address_Id) 
            VALUES(@floor, @flatscount, @entrance,
            (
                SELECT addresses.Address_id FROM addresses, cities
                WHERE CONCAT(City, ', ', Street, ' ', Home) = @address)
            );
            ", connection))
            {
                connection.Open();
                foreach (var item in nodeListEdit)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@address", item.Address);
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

