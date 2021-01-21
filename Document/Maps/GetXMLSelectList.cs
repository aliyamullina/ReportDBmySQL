using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Запрос данных адреса из БД в XML файл
        /// </summary>
        public static void GetXMLSelectList(out List<InfoMap> mapListInsert, MySqlConnection connection)
        {
            mapListInsert = new List<InfoMap>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.Street, 
                    addresses.Home,
                    addresses.Part,
                    maps.Address_id, 
                    GROUP_CONCAT(maps.Floor),
                    GROUP_CONCAT(maps.FlatsCount),
                    GROUP_CONCAT(maps.Entrance)
                FROM 
                    cities,
                    addresses,
                    maps
                WHERE 
                    addresses.City_id = cities.City_Id
                AND 
                    addresses.Address_Id = maps.Address_id
                GROUP BY Address_id
                ", connection))
            {
                connection.Open();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        mapListInsert.Add(
                            new InfoMap(
                                dataReader["City"].ToString() + ", " + dataReader["Street"].ToString() + " " + dataReader["Home"] + dataReader["Part"].ToString(),
                                dataReader["GROUP_CONCAT(maps.Floor)"].ToString(),
                                dataReader["GROUP_CONCAT(maps.FlatsCount)"].ToString(),
                                dataReader["GROUP_CONCAT(maps.Entrance)"].ToString()
                            )
                        );
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
        }
    }
}
