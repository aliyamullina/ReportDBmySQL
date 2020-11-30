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
        public static List<InfoCatalog> GetSelect(MySqlConnection connection, int catalog_id)
        {
            List<InfoCatalog> catalogsSelect = new List<InfoCatalog>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT * FROM catalogs 
                WHERE Catalog_Id 
                LIKE @catalog_id
                ", connection))
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@catalog_id", "%" + catalog_id + "%");
                command.ExecuteNonQuery();

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
            }
            return catalogsSelect;
        }
    }
}
