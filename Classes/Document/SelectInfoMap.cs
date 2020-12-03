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
            List<InfoMap> documentTable = new List<InfoMap>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
                    maps.Floor,
                    maps.FlatsCount,
                    maps.Entrance
                FROM 
                    addresses,
                    cities,
                    maps
                WHERE CONCAT(City, ', ',Street, ' ' ,Home) = @address
                AND
                    addresses.Address_Id = maps.Address_Id
                AND
                    addresses.City_id = cities.City_Id
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

                        documentTable.Add(documentTableList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return documentTable;
        }
    }
}
