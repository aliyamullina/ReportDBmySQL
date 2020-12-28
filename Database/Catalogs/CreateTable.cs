using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class Catalogs
    {
        /// <summary>
        /// Создается таблица Catalogs в БД
        /// </summary>
        public static void CreateTable(MySqlConnection connection)
        {
            using (MySqlCommand command = new MySqlCommand(@"
            CREATE TABLE IF NOT EXISTS Catalogs (
                Catalog_Id      INT AUTO_INCREMENT PRIMARY KEY, 
                Catalog         VARCHAR(300) NOT NULL,
                Registry        VARCHAR(300) NOT NULL
            );", connection)) 
            { 
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
