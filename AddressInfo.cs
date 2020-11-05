using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{

    public class AddressDoc
    {
        public AddressDoc()
        {
        }

        public AddressDoc(string city, string street, string home, string save)
        {
            this.City = city;
            this.Street = street;
            this.Home = home;
            this.Save = save;
        }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Save { get; set; }
    }

    public class AddressInfo
    {
        public AddressInfo()
        {
        }

        public AddressInfo(string street, string home, int city_id, int catalog_id)
        {
            this.Street = street;
            this.Home = home;
            this.City_id = city_id;
            this.Catalog_id = catalog_id;
        }
        public string Street { get;  set; }
        public string Home { get;  set; }
        public int City_id { get;  set; }
        public int Catalog_id { get;  set; }
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
                City_id INT REFERENCES Cities(City_id),
                Catalog_id INT REFERENCES Catalogs(Catalog_id))",
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
            using (MySqlCommand command = new MySqlCommand(@"
                INSERT INTO addresses(Street, Home, City_id, Catalog_id) 
                VALUES (@street, @home, @city_id, @сatalog_id)", 
                connection))
            {
                connection.Open();
                foreach (var item in addressesList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@street", item.Street);
                    command.Parameters.AddWithValue("@home", item.Home);
                    command.Parameters.AddWithValue("@city_id", item.City_id);
                    command.Parameters.AddWithValue("@сatalog_id", item.Catalog_id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// Извлечение из таблицы Catalogs в List
        /// </summary>
        public List<AddressDoc> GetAddressList()
        {
            List<AddressDoc> addressSelect = new List<AddressDoc>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.Street, 
                    addresses.Home,
                    catalogs.Save
                FROM 
                    addresses,
                    cities,
                    catalogs
                WHERE 
                    addresses.City_id = cities.City_Id 
                AND
                    addresses.Catalog_id = catalogs.Catalog_Id
                ", connection))
            {
                connection.Open();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        AddressDoc addressFullList = new AddressDoc();

                        addressFullList.City = dataReader["City"].ToString();
                        addressFullList.Street = dataReader["Street"].ToString();
                        addressFullList.Home = dataReader["Home"].ToString();
                        addressFullList.Save = dataReader["Save"].ToString();

                        addressSelect.Add(addressFullList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return addressSelect;
        }
    }
}
