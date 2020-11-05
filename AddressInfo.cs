using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
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
        public List<AddressInfo> GetAddressList()
        {
            List<AddressInfo> addressSelect = new List<AddressInfo>();


            // LEFT \ INNER JOIN
            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
	                cities.City,
                    addresses.street, 
                    addresses.home,
                    catalogs.Save
                FROM 
	                cities,
                    addresses,
                    catalogs
                WHERE
	                cities.City_Id = addresses.City_id,
                    catalogs.Catalog_Id = addresses.Catalog_id
                ", connection))
            {
                connection.Open();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        AddressInfo addressList = new AddressInfo();

                        addressList.Street = dataReader["Street"].ToString();
                        addressList.Home = dataReader["Home"].ToString();
                        addressList.City_id = (int)dataReader["City_id"];
                        addressList.Catalog_id = (int)dataReader["Catalog_id"];

                        addressSelect.Add(addressList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return addressSelect;
        }
    }
}
