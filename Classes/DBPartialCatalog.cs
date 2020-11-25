using MySql.Data.MySqlClient;
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
                VALUES (@open, @catalog, @registry)
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

                    // Вернуть Catalog_Id
                    //command.ExecuteScalar();
                    //return (int)command.Parameters["@newId"].Value;
                    //return (int)(decimal)cmd.ExecuteScalar();
                    //return int modified = (int)cmd.ExecuteScalar();

                    //int newID;
                    //var cmd = "INSERT INTO foo (column_name)VALUES (@Value);SELECT CAST(scope_identity() AS int)";
                    //using (var insertCommand = new SqlCommand(cmd, con))
                    //{
                    //    insertCommand.Parameters.AddWithValue("@Value", "bar");
                    //    con.Open();
                    //    newID = (int)insertCommand.ExecuteScalar();
                    //}

                    // mysql OUTPUT id AUTO_INCREMENT

                    //insert into record (firstname,middlename,lastname,birthday,age,department) 
                    //OUTPUT INSERTED.ID values ....connection.Close();

                    //SELECT SCOPE_IDENTITY() - для одного

                    //OUTPUT  несколько значений идентификаторов

                    //Select t.userid_pk From Crm_User_Info T
                    //Where T.Rowid = (select max(t.rowid) from crm_user_info t) 

                    //INSERT INTO table(name)
                    //OUTPUT Inserted.ID
                    //VALUES('что-нибудь');
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
    }
}
