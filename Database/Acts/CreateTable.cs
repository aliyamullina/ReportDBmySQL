using MySql.Data.MySqlClient;
using System;

namespace ReportDBmySQL
{
    public partial class Acts
    {
        /// <summary>
        /// Создается таблица Acts в БД
        /// </summary>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Acts (
                    Aсt_Id      INT AUTO_INCREMENT PRIMARY KEY, 
                    Device      INT(5) NOT NULL, 
                    Floor       INT(5), 
                    Entrance    INT(5),
                    Side        VARCHAR(10)
                )", connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
