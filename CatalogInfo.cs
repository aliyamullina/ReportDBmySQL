using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public class CatalogInfo
    {
        public CatalogInfo()
        {
        }

        public CatalogInfo(string catalog, string save)
        {
            this.Catalog = catalog;
            this.Save = save;
        }
        public string Catalog { get; set; }
        public string Save { get; set; }
    }

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
                Catalog VARCHAR(150) NOT NULL,
                Save VARCHAR(150) NOT NULL);",
                connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Заполнение таблицы Catalogs в БД
        /// </summary>
        public void InsertTableCatalogs(List<CatalogInfo> catalogsInsert)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"INSERT INTO catalogs(Catalog, Save) VALUES (@catalog, @save)", connection))
            //using (MySqlCommand command = new MySqlCommand(@"INSERT INTO catalogs(Catalog) VALUES (@catalog)", connection))
            {
                connection.Open();
                foreach (var item in catalogsInsert)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@catalog", item.Catalog);
                    command.Parameters.AddWithValue("@save", item.Save);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        /// <summary>
        /// Извлечение из таблицы Catalogs в List
        /// </summary>
        public List<CatalogInfo> GetCatalogList()
        {
            List<CatalogInfo> catalogsSelect = new List<CatalogInfo>();

            using (MySqlCommand command = new MySqlCommand(@"SELECT * FROM catalogs", connection))
            {
                connection.Open();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        CatalogInfo catalogList = new CatalogInfo();

                        catalogList.Catalog = dataReader["Catalog"].ToString();
                        catalogList.Save = dataReader["Save"].ToString();

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
