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
        public static void GetInsert(List<InfoCatalog> catalogsInsert, MySqlConnection connection)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"
                INSERT INTO catalogs(Open, Catalog, Registry) 
                VALUES (@open, @catalog, @registry);
                SELECT LAST_INSERT_ID();
                ", connection))
            {
                connection.Open();
                foreach (var item in catalogsInsert)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@open", item.Open);
                    command.Parameters.AddWithValue("@catalog", item.Catalog);
                    command.Parameters.AddWithValue("@registry", item.Registry);
                    int catalog_id = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }
        }
    }
}
