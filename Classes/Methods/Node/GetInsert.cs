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
            VALUES (@floor, @flatscount, @entrance);
            SELECT LAST_INSERT_ID();
            SELECT 
                    addresses.Address_id
            FROM 
                    addresses,
                    cities
            WHERE CONCAT(City, ', ',Street, ' ' ,Home) = @address
            AND
                VALUES (@floor, @flatscount, @entrance);
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
//INSERT INTO maps(Floor, FlatsCount, Entrance) VALUES('7 этажей', '89 квартир', '2 подъезда');
//SELECT LAST_INSERT_ID();

//INSERT INTO maps(Floor, FlatsCount, Entrance, Address_Id) 
//VALUES('7 этажей', '89 квартир', '2 подъезда',
//(SELECT addresses.Address_id FROM addresses, cities 
//WHERE CONCAT(City, ', ', Street, ' ', Home) = 'Высокая гора, Большая Красная 214'));


