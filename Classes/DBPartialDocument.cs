using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Извлечение из БД все связанные таблицы в List
        /// </summary>
        public List<DocumentInfo> GetDocumentList()
        {
            List<DocumentInfo> addressSelect = new List<DocumentInfo>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.Street, 
                    addresses.Home,
                    catalogs.Catalog,
                    catalogs.Open
                FROM 
                    addresses,
                    cities,
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
                        DocumentInfo addressFullList = new DocumentInfo();

                        addressFullList.City = dataReader["City"].ToString();
                        addressFullList.Street = dataReader["Street"].ToString();
                        addressFullList.Home = dataReader["Home"].ToString();
                        addressFullList.Catalog = dataReader["Catalog"].ToString();
                        addressFullList.Open = dataReader["Open"].ToString();

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
