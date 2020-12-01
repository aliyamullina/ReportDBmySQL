using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Node
    {
        /// <summary>
        /// Возвращает все адреса из БД: City, Street, Home, Catalog
        /// </summary>
        public static List<InfoNode> SelectAddresses(MySqlConnection connection)
        {
            List<InfoNode> nodeList = new List<InfoNode>();

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
                        InfoNode infoNodeList = new InfoNode();
                        infoNodeList.Address += dataReader["City"].ToString();
                        infoNodeList.Address += ", " + dataReader["Street"].ToString();
                        infoNodeList.Address += " " + dataReader["Home"].ToString();

                        nodeList.Add(infoNodeList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return nodeList;
        }
    }
}
