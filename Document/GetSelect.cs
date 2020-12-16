using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Возвращает все адреса из БД: City, Street, Home, Catalog
        /// </summary>
        public static List<InfoDocument> GetSelect(ref List<InfoDocument> documentsList, MySqlConnection connection)
        {
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
                        InfoDocument infoDocumentsList = new InfoDocument();
                        infoDocumentsList.Address += dataReader["City"].ToString();
                        infoDocumentsList.Address += ", " + dataReader["Street"].ToString();
                        infoDocumentsList.Address += " " + dataReader["Home"].ToString();

                        infoDocumentsList.Catalog = dataReader["Catalog"].ToString();

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
            return documentsList;
        }
    }
}
