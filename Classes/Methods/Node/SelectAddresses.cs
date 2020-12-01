using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Node
    {
        /// <summary>
        /// Возвращает все адреса из БД: City, Street, Home, Catalog
        /// </summary>
        public static List<TreeNode> SelectAddresses(MySqlConnection connection)
        {
            List<TreeNode> nodeList = new List<TreeNode>();

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
                        TreeNode infoNodeList = new TreeNode();
                        infoNodeList.Address += dataReader["City"].ToString();
                        infoNodeList.Address += ", " + dataReader["Street"].ToString();
                        infoNodeList.Address += " " + dataReader["Home"].ToString();

                        infoNodeList.Floor = "Введите количество этажей";
                        infoNodeList.FlatsCount = "Введите количество квартир";
                        infoNodeList.Entrance = "Введите количество подъездов";

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
