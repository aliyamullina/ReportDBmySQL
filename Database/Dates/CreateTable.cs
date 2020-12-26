using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class Dates
    {
        /// <summary>
        /// Создается таблица Cities в БД
        /// </summary>
        public static void CreateTable(MySqlConnection connection)
        {
            
            using (MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Dates
                (Date_Id INT AUTO_INCREMENT PRIMARY KEY, 
                Date DATE NOT NULL);",
                connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
