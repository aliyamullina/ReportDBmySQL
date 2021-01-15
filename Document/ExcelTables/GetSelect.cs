using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class ExcelTables
    {
        /// <summary>
        /// Возвращает ресстр для текущего адреса в БД
        /// </summary>
        public static List<InfoTable> GetSelect(string fN, MySqlConnection connection)
        {
            List<InfoTable> documentTable = new List<InfoTable>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
                    cities.City,
                    addresses.Street, 
                    addresses.Home,
                    addresses.Part,
                    registers.Apartment,
                    registers.Model,
                    registers.Serial
                FROM 
                    addresses,
                    cities,
                    registers,
                    catalogs
                WHERE CONCAT(City, ', ', Street, ' ' , Home, Part) = @address
                AND
                    catalogs.Catalog_id = registers.Catalog_Id
                AND
                    addresses.Address_Id = catalogs.Catalog_Id
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
                        InfoTable documentTableList = new InfoTable
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
