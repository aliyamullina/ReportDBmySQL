using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Извлечение из БД все связанные таблицы в List
        /// </summary>
        public List<InfoDocument> GetDocumentList()
        {
            List<InfoDocument> addressSelect = new List<InfoDocument>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.Street, 
                    addresses.Home,
                    catalogs.Catalog,
                    catalogs.Open,
                    registers.Apartment,
                    registers.Model,
                    registers.Serial
                FROM 
                    addresses,
                    cities,
                    catalogs,
                    registers
                WHERE 
                    addresses.City_id = cities.City_Id
                AND
                    addresses.Catalog_id = catalogs.Catalog_Id
                AND
                    addresses.Catalog_id = registers.Catalog_Id
                ", connection))
            {
                connection.Open();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        InfoDocument addressFullList = new InfoDocument();
                        // InfoCity
                        addressFullList.City = dataReader["City"].ToString();
                        // InfoAddress
                        addressFullList.Street = dataReader["Street"].ToString();
                        addressFullList.Home = dataReader["Home"].ToString();
                        // InfoCatalog
                        addressFullList.Catalog = dataReader["Catalog"].ToString();
                        addressFullList.Open = dataReader["Open"].ToString();
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

        //public List<InfoDocumentAddress> GetDocumentCatalog()
        //{
        //    List<InfoDocumentAddress> documentAddresses = new List<InfoDocumentAddress>();

        //    using (MySqlCommand command = new MySqlCommand(@"
        //        SELECT 
	       //         cities.City,
        //            addresses.Street, 
        //            addresses.Home
        //        FROM 
        //            cities,
        //            addresses
        //        WHERE 
        //            addresses.City_id = cities.City_Id
        //        ", connection))
        //    {
        //        connection.Open();

        //        using (MySqlDataReader dataReader = command.ExecuteReader())
        //        {
        //            while (dataReader.Read())
        //            {
        //                InfoDocumentAddress documentAddressesList = new InfoDocumentAddress();
        //                // InfoCity
        //                documentAddressesList.City = dataReader["City"].ToString();
        //                // InfoAddress
        //                documentAddressesList.Street = dataReader["Street"].ToString();
        //                documentAddressesList.Home = dataReader["Home"].ToString();

        //                documentAddresses.Add(documentAddressesList);
        //            }
        //            dataReader.Close();
        //        }
        //        connection.Close();
        //    }
        //    return documentAddresses;
        //}
    }
}
