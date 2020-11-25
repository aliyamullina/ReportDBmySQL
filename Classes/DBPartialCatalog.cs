using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Создается таблица Catalogs в БД
        /// </summary>
        public void CreateCatalogs()
        {
            MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Catalogs
                (Catalog_Id INT AUTO_INCREMENT PRIMARY KEY, 
                Open VARCHAR(150) NOT NULL,
                Catalog VARCHAR(150) NOT NULL,
                Registry VARCHAR(150) NOT NULL);",
                connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Заполнение таблицы Catalogs в БД
        /// </summary>
        public void InsertCatalogs(List<InfoCatalog> catalogsInsert)
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
                    command.ExecuteNonQuery();

                    //using (MySqlDataReader dataReader = command.ExecuteReader())
                    //{
                    //    while (dataReader.Read())
                    //    {
                    //        int catalog_id = dataReader["Open"].ToString();
                    //    }
                    //    dataReader.Close();
                    //}

                    int catalog_id = (int)command.ExecuteScalar();
                    Console.WriteLine(catalog_id);
                }
                connection.Close();
            }
        }

        /// <summary>
        /// Извлечение из таблицы Catalogs в List
        /// </summary>
        public List<InfoCatalog> GetCatalogList()
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
