using MySql.Data.MySqlClient;
using Renci.SshNet.Security.Cryptography;

namespace ReportDBmySQL
{
    class DB
    {
        readonly MySqlConnection connection = new MySqlConnection(
            "Server = localhost; " +
            "Port = 3306; " +
            "Username = root; " +
            "Password = root; " +
            "database = addressinfodb"
            );

        /// <summary>
        /// Подключение к БД
        /// </summary>
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        /// <summary>
        /// Отключение от БД
        /// </summary>
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        
        /// <summary>
        /// Возвращает подключение к БД
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        /// <summary>
        /// Создается БД addressinfodb
        /// </summary>
        public void CreateAddressInfoDB()
        {
            MySqlCommand command = new MySqlCommand("CREATE DATABASE addressinfodb;", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Создается таблица Cities в БД
        /// </summary>
        public void CreateTableCities()
        {
            MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Cities
                (City_Id INT AUTO_INCREMENT PRIMARY KEY, 
                City VARCHAR(30) NOT NULL);",
                connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Создается таблица Adresses в БД
        /// </summary>
        public void CreateTableAdresses()
        {
            MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Adresses
                (Id INT AUTO_INCREMENT PRIMARY KEY, 
                Address VARCHAR(30) NOT NULL, 
                Home VARCHAR(10), 
                City_Id INT REFERENCES Cities(City_Id))",
                connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

/*

CREATE DATABASE productsdb;
USE productsdb;
CREATE TABLE Cities
(
    City_Id INT AUTO_INCREMENT PRIMARY KEY,
    City VARCHAR(30) NOT NULL,
);

INSERT Cities(City_Id, City) 
VALUES ('Казань'),
VALUES ('Нурлат'),
VALUES ('Чистополь'),
VALUES ('Высокая гора');



CREATE DATABASE productsdb;
USE productsdb;
CREATE TABLE Addresses
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Address VARCHAR(30) NOT NULL,
    Home VARCHAR(10),
    City_Id INT REFERENCES Cities(City_Id),
);

INSERT Cities(Id, Address, Home, City_Id) 
VALUES ('Большая', '80', 1),
VALUES ('Подлужная', '40', 1);


Заполнить таблицы:
 Из названия папки в город
 Из названия файлов в Адрес и дома

Массив Адреса (Город, Адрес, Дом)
Массив Города(Казань, Нурлат, Чистополь)




// Вариант2
var mycommand = new SqlCommand("INSERT INTO RSS2 VALUES(@Date, @Templow, @Temphigh)", 
                               myConnection);

mycommand.Parameters.AddWithValue("@Date", DateTime.MinValue);
mycommand.Parameters.AddWithValue("@Templow", Double.MinValue);
mycommand.Parameters.AddWithValue("@Temphigh", Double.MinValue);
for (i = 0; i < 5; i++)
{
    mycommand.Parameters["@Date"].Value = Convert.ToDateTime(myArray[i,0]);   
    mycommand.Parameters["@Templow"].Value = Convert.ToDouble(myArray[i,1]);   
    mycommand.Parameters["@Temphigh"].Value = Convert.ToDouble(myArray[i,2]);    
    mycommand.ExecuteNonQuery();
}

// Вариант1
var p = Basket.arrayList;

itemsQueryCommand.CommandText = "INSERT INTO tOrderItems (orderId, name, quantity) VALUES (@OrderId, @name, @quantity )";
itemsQueryCommand.Parameters.Add("@OrderId");
itemsQueryCommand.Parameters.Add("@name");
itemsQueryCommand.Parameters.Add("@quantity");


for (int i = 0; i < p.Count; i++)
    // Loop through List 
{
    itemsQueryCommand.Parameters["@OrderId"] = id;
    itemsQueryCommand.Parameters["@name"] =  p[i][0]; // ProductId;
    itemsQueryCommand.Parameters["@quantity"] = p[i][1]; //Quantity;

    itemsQueryCommand.ExecuteNonQuery();
}


    /*2 таблица Реестр
    IdУлица
    IdДом
    Данные по счетчикам

    3 таблица 2гис данные
    IdУлица
    IdДом
    Данные по домам

    4 таблица аскуэ
    IdУлица
    IdДом
    Данные по подъездам
    Этаж
    Количество квартир
    Подъезды*/
    

