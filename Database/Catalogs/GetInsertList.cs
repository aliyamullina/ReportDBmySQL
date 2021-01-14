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
                INSERT INTO catalogs(Open, Catalog, Registry) 
                VALUES (@open, @catalog, @registry);
                SELECT LAST_INSERT_ID();
                ", connection))
            {
                connection.Open();
                foreach (var item in сatalogsList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@open", item.Open);
                    command.Parameters.AddWithValue("@catalog", item.Catalog);
                    command.Parameters.AddWithValue("@registry", item.Registry);

                    int catalog_id = Convert.ToInt32(command.ExecuteScalar());

                    Catalogs.GetSelect(in catalog_id, connection, out List<InfoCatalog> oneCatalogPath);

                    Adresses.GetFillList(in oneCatalogPath, out List<InfoAddress> addressesList);
                    Adresses.GetInsertList(in addressesList, connection);

                    Registers.GetFillList(in catalog_id, in oneCatalogPath, out List<InfoRegistry> registersList, out List<DateTime> dateList);
                    Registers.GetInsertList(in registersList, connection);

                    Dates.GetInsertList(in dateList, connection);
                }
                connection.Close();
            }
        }
    }
}
