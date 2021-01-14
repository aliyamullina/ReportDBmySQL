using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class Opens
    {
        /// <summary>
        /// Создается таблица Opens в БД
        /// </summary>
        public static void CreateTable(MySqlConnection connection)
        {
            using (MySqlCommand command = new MySqlCommand(@"
            CREATE TABLE IF NOT EXISTS Catalogs (
                Open_Id      INT AUTO_INCREMENT PRIMARY KEY, 
                Open         VARCHAR(300) NOT NULL,
            );", connection)) 
            { 
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
