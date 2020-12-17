﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Возвращает реестр для текущего адреса в БД
        /// </summary>
        public static void GetSelect(ref List<InfoMap> documentMap, string fN, MySqlConnection connection)
        {
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
                        documentMap.Add(new InfoMap(
                            fN,
                            dataReader["GROUP_CONCAT(maps.Floor)"].ToString(),
                            dataReader["GROUP_CONCAT(maps.FlatsCount)"].ToString(),
                            dataReader["GROUP_CONCAT(maps.Entrance)"].ToString()
                            ));
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
        }
    }
}