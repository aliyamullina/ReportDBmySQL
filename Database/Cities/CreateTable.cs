using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class Cities
    {
        /// <summary>
        /// Создается таблица Cities в БД
        /// </summary>
        public static void CreateTable(MySqlConnection connection)
        {
            using (MySqlCommand command = new MySqlCommand(@"
            CREATE TABLE IF NOT EXISTS Cities(
                City_Id     INT AUTO_INCREMENT PRIMARY KEY, 
                City        VARCHAR(50) NOT NULL
            );", connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
