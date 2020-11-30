using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Возвращает все адреса из БД: City, Street, Home, Catalog
        /// </summary>
        public static List<InfoMapAddress> SelectAddresses(MySqlConnection connection)
        {
            List<InfoMapAddress> InfoMapAddresses = new List<InfoMapAddress>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.Street, 
                    addresses.Home,
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
                        InfoMapAddress infoMapsList = new InfoMapAddress();
                        infoMapsList.Address += dataReader["City"].ToString();
                        infoMapsList.Address += ", " + dataReader["Street"].ToString();
                        infoMapsList.Address += " " + dataReader["Home"].ToString();

                        // Высокая гора, Большая Красная, 214 
                        // Высокая гора, Большая Красная, 216 
                        InfoMapAddresses.Add(infoMapsList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return InfoMapAddresses;
        }
    }
}
