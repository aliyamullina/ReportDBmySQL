using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public class AddressInfo
    {
        public AddressInfo(string street, string home, string city_id, string catalog_id)
        {
            this.Street = street;
            this.Home = home;
            this.City_id = city_id;
            this.Catalog_id = catalog_id;
        }

        public string Street { get; private set; }
        public string Home { get; private set; }
        public string City_id { get; private set; }
        public string Catalog_id { get; private set; }
    }
    public partial class DB
    {
        /// <summary>
        /// Создается таблица Adresses в БД
        /// </summary>
        public void CreateTableAdresses()
        {
            MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Addresses
                (Id INT AUTO_INCREMENT PRIMARY KEY, 
                Street VARCHAR(30) NOT NULL, 
                Home VARCHAR(10), 
                City_Id INT REFERENCES Cities(City_Id),
                Catalog_Id INT REFERENCES Catalogs(Catalog_Id))",
                connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Заполнение таблицы Adresses в БД
        /// </summary>
        public void InsertTableAdresses(List<AddressInfo> addressesList)
        {
            // Добавляет повторно, нет проверки на существование записи
            using (MySqlCommand command = new MySqlCommand(@"INSERT INTO addresses(Street, Home, City_Id) VALUES (@street, @home, @city_id)", connection))
            {
                connection.Open();
                foreach (var item in addressesList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@street", item.Street);
                    command.Parameters.AddWithValue("@home", item.Home);
                    command.Parameters.AddWithValue("@city_id", item.City_id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
