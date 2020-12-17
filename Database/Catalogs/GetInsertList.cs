using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Catalogs
    {
        /// <summary>
        /// Заполнение таблицы Catalogs в БД
        /// </summary>
        public static void GetInsertList(in List<InfoCatalog> сatalogsList, out int catalog_id, MySqlConnection connection)
        {
            catalog_id = 0;

            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"
                INSERT INTO catalogs(Catalog, Registry) 
                VALUES (@catalog, @registry);
                SELECT LAST_INSERT_ID();
                ", connection))
            {
                connection.Open();
                foreach (var item in сatalogsList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@catalog", item.Catalog);
                    command.Parameters.AddWithValue("@registry", item.Registry);

                    catalog_id = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }
        }
    }
}
