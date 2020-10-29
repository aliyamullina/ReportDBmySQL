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
 Из названия файлов в Адрес и номер дома



2 таблица Реестр
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
Подъезды
    }
}
