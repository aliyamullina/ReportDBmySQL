using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Создается таблица Cities в БД
        /// </summary>
        public void GetCreateCities()
        {
            using (MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Cities
                (City_Id INT AUTO_INCREMENT PRIMARY KEY, 
                City VARCHAR(30) NOT NULL);",
                connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
