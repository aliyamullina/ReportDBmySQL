using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Создается таблица Catalogs в БД
        /// </summary>
        public void CreateTableCatalogs()
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
        public void InsertTableCatalogs(List<InfoCatalog> catalogsInsert)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"INSERT INTO catalogs(Open, Catalog, Registry) VALUES (@open, @catalog, @registry)", connection))
            {
                connection.Open();
                foreach (var item in catalogsInsert)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@open", item.Open);
                    command.Parameters.AddWithValue("@catalog", item.Catalog);
                    command.Parameters.AddWithValue("@registry", item.Registry);
                    command.ExecuteNonQuery();
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
                        InfoCatalog catalogList = new InfoCatalog();

                        catalogList.Open = dataReader["Open"].ToString();
                        catalogList.Catalog = dataReader["Catalog"].ToString();
                        catalogList.Registry = dataReader["Registry"].ToString();

                        catalogsSelect.Add(catalogList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return catalogsSelect;
        }

        /// <summary>
        /// Извлечение из таблицы Catalogs catalog_id
        /// </summary>
        public int GetCatalogId(string catalog)
        {
            

            using (MySqlCommand command = new MySqlCommand(@"SELECT catalog_id FROM catalogs WHERE Catalog LIKE @catalog", connection))
            {
                int catalog_id;
                connection.Open();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@catalog", "%" + catalog + "%");
                command.ExecuteNonQuery();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        catalog_id = (int)dataReader["Catalog"];
                    }
                    dataReader.Close();
                }
                connection.Close();

                return catalog_id;
            }

            
        }
    }
}
