using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Catalogs
    {
        /// <summary>
        /// Извлечение из таблицы Catalogs в List
        /// </summary>
        public static List<InfoCatalog> GetSelect(MySqlConnection connection)
        {
            List<InfoCatalog> catalogsSelect = new List<InfoCatalog>();

            using (MySqlCommand command = new MySqlCommand(@"SELECT * FROM catalogs", connection))
            {
                connection.Open();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        InfoCatalog catalogList = new InfoCatalog
                        {
                            Open = dataReader["Open"].ToString(),
                            Catalog = dataReader["Catalog"].ToString(),
                            Registry = dataReader["Registry"].ToString()
                        };
                        catalogsSelect.Add(catalogList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return catalogsSelect;
        }
    }
}
