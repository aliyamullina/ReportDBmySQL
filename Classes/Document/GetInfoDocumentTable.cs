using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Возвращает ресстр для текущего адреса в БД
        /// </summary>
        public static List<InfoDocumentTable> GetInfoDocumentTable(string address, MySqlConnection connection)
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
                WHERE CONCAT(City, ', ',Street, ' ' ,Home) LIKE @address
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
                command.Parameters.AddWithValue("@address", "%" + address + "%");
                command.ExecuteNonQuery();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        InfoDocumentTable documentTableList = new InfoDocumentTable();
                        // InfoCity
                        documentTableList.City = dataReader["City"].ToString();
                        // InfoAddress
                        documentTableList.Street = dataReader["Street"].ToString();
                        documentTableList.Home = dataReader["Home"].ToString();
                        // InfoRegistry
                        documentTableList.Apartment = dataReader["Apartment"].ToString();
                        documentTableList.Model = dataReader["Model"].ToString();
                        documentTableList.Serial = dataReader["Serial"].ToString();

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
