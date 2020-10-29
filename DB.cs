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
CREATE DATABASE productsdb;
USE productsdb;
CREATE TABLE Cities
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    City VARCHAR(30) NOT NULL,
);

INSERT Cities(Id, City) 
VALUES ('Казань'),
VALUES ('Нурлат'),
VALUES ('Чистополь'),
VALUES ('Высокая гора');

1 таблица
IdГород 1, 1
Улица Большая, Подлужная
Дом 50, 40
IdУлица 1, 2
IsДом 1, 2

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
