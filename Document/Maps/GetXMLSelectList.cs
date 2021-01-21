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
                    map.Floor,
                    map.FlatsCount,
                    map.Entrance
                FROM 
                    cities,
                    addresses,
                    maps
                WHERE 
                    addresses.City_id = cities.City_Id
                AND 
                    addresses.Address_Id = maps.Address_id
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
                                dataReader["Floor"].ToString(),
                                dataReader["FlatsCount"].ToString(),
                                dataReader["Entrance"].ToString()
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
