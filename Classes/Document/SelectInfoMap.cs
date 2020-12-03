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
                    COALESCE(maps.Floor, maps.FlatsCount, maps.Entrance, NULL)
                FROM addresses, cities, maps
                WHERE CONCAT(City, ', ', Street, ' ' , Home) = @address
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

// https://stackoverflow.com/questions/59695041/how-do-i-coalesce-nulls-across-multiple-rows-in-bigquery

//SELECT
//    maps.Floor,
//    maps.FlatsCount,
//    maps.Entrance
//FROM
//    addresses,
//    cities,
//    maps
//WHERE CONCAT(City, ', ', Street, ' ' , Home) = 'Высокая гора, Большая Красная 214'
//AND
//    addresses.Address_Id = maps.Address_Id
//AND
//    addresses.City_id = cities.City_Id

//SELECT maps.Address_Id,
//    Sum( Isnull(maps.Floor, 0) )      OVER(PARTITION BY maps.Address_id ORDER BY maps.Address_id),
//    Sum( Isnull(maps.FlatsCount, 0) ) OVER(PARTITION BY maps.Address_id ORDER BY maps.Address_id),
//    Sum( Isnull(maps.Entrance, 0) )   OVER(PARTITION BY maps.Address_id ORDER BY maps.Address_id)
//FROM maps
//GROUP BY maps.Address_id

//SELECT id,
//    Sum(Isnull(red, 0)) OVER(partition BY id ORDER BY id),        
//    Sum(Isnull(buy, 0)) OVER(partition BY id  ORDER BY id),        
//    Sum(Isnull(bsw, 0)) OVER(partition BY id  ORDER BY id)
//FROM Table1GROUP  
//BY id 

//SELECT maps.Address_Id,
//    Sum(COALESCE(maps.Floor, 0)) OVER(PARTITION BY maps.Address_id ORDER BY maps.Address_id),
//    Sum(COALESCE(maps.FlatsCount, 0)) OVER(PARTITION BY maps.Address_id ORDER BY maps.Address_id),
//    Sum(COALESCE(maps.Entrance, 0)) OVER(PARTITION BY maps.Address_id ORDER BY maps.Address_id)
//FROM maps
//GROUP BY maps.Address_id;

//SELECT maps.Address_Id,
//    Sum(COALESCE(red, 0)) OVER(partition BY maps.Address_Id ORDER BY maps.Address_Id),        
//    Sum(COALESCE(buy, 0)) OVER(partition BY maps.Address_Id  ORDER BY maps.Address_Id),        
//    Sum(COALESCE(bsw, 0)) OVER(partition BY maps.Address_Id  ORDER BY maps.Address_Id)
//FROM Table1GROUP  
//GROUP BY maps.Address_Id
