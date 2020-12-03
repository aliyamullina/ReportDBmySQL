using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Node
    {
        /// <summary>
        /// Возвращает все адреса из БД: City, Street, Home, Catalog
        /// </summary>
        public static List<InfoMap> SelectAddresses(MySqlConnection connection)
        {
            List<InfoMap> nodeList = new List<InfoMap>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.Street, 
                    addresses.Home
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
                        InfoMap infoMapList = new InfoMap();
                        infoMapList.Address += dataReader["City"].ToString();
                        infoMapList.Address += ", " + dataReader["Street"].ToString();
                        infoMapList.Address += " " + dataReader["Home"].ToString();

                        infoMapList.Floor = "Введите количество этажей";
                        infoMapList.FlatsCount = "Введите количество квартир";
                        infoMapList.Entrance = "Введите количество подъездов";

                        nodeList.Add(infoMapList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return nodeList;
        }
    }
}
