using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection(
            "Server = localhost; " +
            "Port = 3306; " +
            "Username = root; " +
            "Password = root; " +
            "database = reportdbmysqlhomes"
            );

/*******************/

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

/*******************/

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

/*******************/
Заполнить таблицы:
 Из названия папки в город
 Из названия файлов в Адрес и дома

Массив Адреса (Город, Адрес, Дом)
Массив Города(Казань, Нурлат, Чистополь)

Из mysql в массив
Mассив передать в макет word с адресом в имени


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


// Почитать, про классы
https://coderoad.ru/21142288/%D0%9A%D0%B0%D0%BA-%D0%B2%D1%81%D1%82%D0%B0%D0%B2%D0%B8%D1%82%D1%8C-%D1%8D%D0%BB%D0%B5%D0%BC%D0%B5%D0%BD%D1%82%D1%8B-%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%D0%B0-%D0%B2-%D0%B1%D0%B0%D0%B7%D1%83-%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85-%D1%81%D0%B5%D1%80%D0%B2%D0%B5%D1%80%D0%B0-SQL-%D1%81-%D0%BF%D0%BE%D0%BC%D0%BE%D1%89%D1%8C%D1%8E-C

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
    }
}
