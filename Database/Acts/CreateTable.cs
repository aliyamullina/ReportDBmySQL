using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class Acts
    {
        /// <summary>
        /// Создается таблица Acts в БД
        /// </summary>
        public static void CreateTable(MySqlConnection connection)
        {
            using (MySqlCommand command = new MySqlCommand(@"
            CREATE TABLE IF NOT EXISTS Acts (
                Aсt_Id      INT AUTO_INCREMENT PRIMARY KEY, 
                Device      VARCHAR(20), 
                Floor       INT(5) NOT NULL, 
                Entrance    INT(5) NOT NULL,
                Side        VARCHAR(10),
                Catalog_id      INT REFERENCES Catalogs(Catalog_id)
            )", connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
