using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Возвращает ресстр для текущего адреса в БД
        /// </summary>
        public static List<InfoMap> SelectInfoMap(string fN, MySqlConnection connection)
        {
            List<InfoMap> documentMap = new List<InfoMap>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                maps.Address_id, 
                    GROUP_CONCAT(maps.Floor),  
                    GROUP_CONCAT(maps.FlatsCount), 
                    GROUP_CONCAT(maps.Entrance)
                FROM addresses, cities, maps 
                WHERE CONCAT(City, ', ', Street, ' ' , Home) = @address
                AND
                 addresses.Address_Id = maps.Address_Id
                AND
                 addresses.City_id = cities.City_Id
                GROUP BY Address_id
                ", connection))
            {
                connection.Open();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@address", fN);
                command.ExecuteNonQuery();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        InfoMap documentTableList = new InfoMap
                        {
                            Floor = dataReader["Floor"].ToString(),
                            FlatsCount = dataReader["FlatsCount"].ToString(),
                            Entrance = dataReader["Entrance"].ToString()
                        };

                        documentMap.Add(documentTableList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return documentMap;
        }
    }
}