using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Возвращает все адреса из БД
        /// </summary>
        public static List<InfoDocumentAddress> GetDocAddresses(MySqlConnection connection)
        {
            List<InfoDocumentAddress> documentAddresses = new List<InfoDocumentAddress>();

            // Тут запросить сразу Catalog и Registry? Или id?

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
                        InfoDocumentAddress documentAddressesList = new InfoDocumentAddress();
                        documentAddressesList.Address += dataReader["City"].ToString();
                        documentAddressesList.Address += ", " + dataReader["Street"].ToString();
                        documentAddressesList.Address += " " + dataReader["Home"].ToString();
                        documentAddresses.Add(documentAddressesList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return documentAddresses;
        }
    }
}
