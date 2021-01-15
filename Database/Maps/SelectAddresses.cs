using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Возвращает все адреса из БД: City, Street, Home
        /// </summary>
        public static void SelectAddresses(MySqlConnection connection, out List<InfoMap> nodeList)
        {
            nodeList = new List<InfoMap>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.Street, 
                    addresses.Home,
                    addresses.Part
                FROM 
                    cities,
                    addresses
                WHERE 
                    addresses.City_id = cities.City_Id
                ", connection))
            {
                connection.Open();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        nodeList.Add(
                            new InfoMap(
                                dataReader["City"].ToString() + ", " + dataReader["Street"].ToString() + " " + dataReader["Home"].ToString() + " " + dataReader["Part"].ToString(),
                                "Введите количество этажей", 
                                "Введите количество квартир", 
                                "Введите количество подъездов"
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
