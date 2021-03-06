﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Catalogs
    {
        /// <summary>
        /// Извлечение из таблицы Catalogs в List
        /// </summary>
        public static void GetSelect(in int catalog_id, MySqlConnection connection, out List<InfoCatalog> oneCatalogPath)
        {
            oneCatalogPath = new List<InfoCatalog>();

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
                        oneCatalogPath.Add(
                            new InfoCatalog(
                                dataReader["Open"].ToString(), 
                                dataReader["Catalog"].ToString(), 
                                dataReader["Registry"].ToString()
                            )
                        );
                    }
                    dataReader.Close();
                }
            }
        }
    }
}
