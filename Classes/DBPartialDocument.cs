using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Возвращает все адреса из БД
        /// </summary>
        public List<InfoDocumentAddress> GetDocumentAddresses()
        {
            List<InfoDocumentAddress> documentAddresses = new List<InfoDocumentAddress>();

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


        /// <summary>
        /// Возвращает каталог для текущего адреса в БД
        /// </summary>
        public List<InfoDocumentCatalog> GetDocumentCatalog(string address)
        {
            List<InfoDocumentCatalog> documentCatalog = new List<InfoDocumentCatalog>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
                    catalogs.catalog
                FROM 
                    addresses,
                    catalogs,
                    cities
                WHERE CONCAT(City, ', ',Street, ' ' ,Home) LIKE @address
                AND 
                    addresses.Catalog_id = catalogs.Catalog_Id
                AND
                    addresses.City_id = cities.City_Id

                ", connection))
            {
                connection.Open();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@address", "%" + address + "%");
                command.ExecuteNonQuery();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        InfoDocumentCatalog documentCatalogList = new InfoDocumentCatalog();

                        documentCatalogList.Catalog += dataReader["Catalog"].ToString();
                        documentCatalog.Add(documentCatalogList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return documentCatalog;
        }

        /// <summary>
        /// Возвращает ресстр для текущего адреса в БД
        /// </summary>
        public List<InfoDocumentTable> GetDocumentList()
        {
            List<InfoDocumentTable> addressSelect = new List<InfoDocumentTable>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.Street, 
                    addresses.Home,
                    registers.Apartment,
                    registers.Model,
                    registers.Serial
                FROM 
                    addresses,
                    cities,
                    registers
                WHERE 
                    addresses.City_id = cities.City_Id
                AND
                    addresses.Catalog_id = registers.Catalog_Id
                ", connection))
            {
                connection.Open();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        InfoDocumentTable addressFullList = new InfoDocumentTable();
                        // InfoCity
                        addressFullList.City = dataReader["City"].ToString();
                        // InfoAddress
                        addressFullList.Street = dataReader["Street"].ToString();
                        addressFullList.Home = dataReader["Home"].ToString();
                        // InfoRegistry
                        addressFullList.Apartment = dataReader["Apartment"].ToString();
                        addressFullList.Model = dataReader["Model"].ToString();
                        addressFullList.Serial = dataReader["Serial"].ToString();

                        addressSelect.Add(addressFullList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return addressSelect;
        }
    }
}
