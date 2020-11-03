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
        public List<CatalogInfo> Select()
        {
            List<CatalogInfo> catalogsSelect = new List<CatalogInfo>();

            using (MySqlCommand command = new MySqlCommand(@"SELECT 'Catalog' FROM catalogs", connection))
            {
                connection.Open();

                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    CatalogInfo catalog = new CatalogInfo();

                    catalog.Catalog = dataReader["Catalog"];
                    catalog.Save = dataReader["Save"];

                    catalogsSelect.Add(catalog);
                }

                dataReader.Close();
                connection.Close();
            }
            return catalogsSelect;
        }
    }
}

/*
    public class YourClass
    {
        public List<string>[] Select()
        {
            string query = "SELECT * FROM users";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];


            ///
            /// you original implementation here 
            ///
        }
    }


 public class UsingClass
   {
    private YourClass _yourClass;
    public UsingClass()
    {
       _yourClass = new YourClass();
    }

    private void SomeUsingMethod()
    {
       List<string>[] list =  _yourClass.Select();
    }
  }

*/

/*
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