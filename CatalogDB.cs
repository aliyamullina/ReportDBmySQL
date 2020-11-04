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
                        CatalogInfo catalog = new CatalogInfo();

                        catalog.Catalog = dataReader["Catalog"].ToString();
                        catalog.Save = dataReader["Save"].ToString();

                        catalogsSelect.Add(catalog);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return catalogsSelect;
        }
    }
}

/*
https://coderoad.ru/34828151/C-%D1%81%D0%BF%D0%B8%D1%81%D0%BE%D0%BA-%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%B0-%D0%BF%D0%BE%D1%81%D0%BB%D0%B5-%D0%B2%D0%BE%D0%B7%D0%B2%D1%80%D0%B0%D1%89%D0%B5%D0%BD%D0%B8%D1%8F
Затем измените rest метода для создания и возврата списка пользователей.

public List<User> Select()
{
    List<User> list = new List<User>();
    if (this.OpenConnection() == true)
    {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        MySqlDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            User user = new User();
            user.Id = dataReader["id"].toString();
            user.Test = dataReader["test"].toString();
            user.Balance = dataReader["balance"].toString();
            list.Add(user);
        }
        dataReader.Close();
        this.CloseConnection();
    }
    return list;
}
Тогда вы можете использовать свой список примерно так:

ClassThatContainsSelectMethod yourDBObject = new ClassThatContainsSelectMethod();

List<User> users = yourDBObject.Select();

foreach (User user in users)
{
    Console.WriteLine(user.Id, user.Test, user.Balance);
}
*/