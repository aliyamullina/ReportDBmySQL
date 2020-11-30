using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Возвращает ресстр для текущего адреса в БД
        /// </summary>
        public static List<InfoDocumentTable> SelectInfoDocumentTable(string fN, MySqlConnection connection)
        {
            List<InfoDocumentTable> documentTable = new List<InfoDocumentTable>();

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
                    registers,
                    catalogs
                WHERE CONCAT(City, ', ',Street, ' ' ,Home) = @address
                AND
                    catalogs.Catalog_id = registers.Catalog_Id
                AND
                    addresses.Catalog_id = catalogs.Catalog_Id
                AND
                    addresses.City_id = cities.City_Id
                ", connection))
            {
                connection.Open();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@address", fN);
                command.ExecuteNonQuery();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        InfoDocumentTable documentTableList = new InfoDocumentTable
                        {
                            // InfoCity
                            City = dataReader["City"].ToString(),
                            // InfoAddress
                            Street = dataReader["Street"].ToString(),
                            Home = dataReader["Home"].ToString(),
                            // InfoRegistry
                            Apartment = dataReader["Apartment"].ToString(),
                            Model = dataReader["Model"].ToString(),
                            Serial = dataReader["Serial"].ToString()
                        };

                        documentTable.Add(documentTableList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return documentTable;
        }
    }
}
