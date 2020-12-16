using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Возвращает все адреса из БД: City, Street, Home, Catalog
        /// </summary>
        public static void GetSelect(out List<InfoDocument> documentsList, MySqlConnection connection)
        {
            documentsList = new List<InfoDocument>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.Street, 
                    addresses.Home,
                    catalogs.catalog
                FROM 
                    cities,
                    addresses,
                    catalogs
                WHERE 
                    addresses.City_id = cities.City_Id
                AND 
                    addresses.Catalog_id = catalogs.Catalog_Id
                ", connection))
            {
                connection.Open();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        documentsList.Add(
                            new InfoDocument(
                                dataReader["City"].ToString() + ", " + dataReader["Street"].ToString() + " " + dataReader["Home"].ToString(),
                                dataReader["Catalog"].ToString()
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
