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
                    addresses.RegisterAddress_id = registers.RegisterAddress_id
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
    }
}
