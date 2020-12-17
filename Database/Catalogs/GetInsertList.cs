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
        public static void GetInsertList(in List<InfoCatalog> сatalogsList, MySqlConnection connection)
        {
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

                    int catalog_id = Convert.ToInt32(command.ExecuteScalar());

                    GetSelect(out List<InfoCatalog> oneCatalogPath, connection, catalog_id);
                    Adresses.GetID(connection, catalog_id, ref oneCatalogPath);
                    Registers.GetID(connection, catalog_id, oneCatalogPath);
                }
                connection.Close();
            }
        }
    }
}
