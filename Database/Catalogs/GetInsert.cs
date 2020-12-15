﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Catalogs
    {
        /// <summary>
        /// Заполнение таблицы Catalogs в БД
        /// </summary>
        public static void GetInsert(ref List<InfoCatalog> сatalogsPath, MySqlConnection connection)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"
                INSERT INTO catalogs(Catalog, Registry) 
                VALUES (@catalog, @registry);
                SELECT LAST_INSERT_ID();
                ", connection))
            {
                connection.Open();
                foreach (var item in сatalogsPath)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@catalog", item.Catalog);
                    command.Parameters.AddWithValue("@registry", item.Registry);
                    int catalog_id = Convert.ToInt32(command.ExecuteScalar());

                    List<InfoCatalog> oneCatalogPath = new List<InfoCatalog>();
                    GetSelect(ref oneCatalogPath, connection, catalog_id);

                    Adresses.GetID(connection, catalog_id, ref oneCatalogPath);
                    Registers.GetID(connection, catalog_id, oneCatalogPath);
                }
                connection.Close();
            }
        }
    }
}
