﻿using MySql.Data.MySqlClient;
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

        /// <summary>
        /// Заполнение таблицы Cities в БД
        /// </summary>
        public void InsertTableCities()
        {
            MySqlCommand command = new MySqlCommand(@"
            INSERT INTO Cities(City) VALUES ('@city')",
            connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Заполнение таблицы Adresses в БД
        /// </summary>
        public void InsertTableAdresses()
        {
            MySqlCommand command = new MySqlCommand(@"
            INSERT INTO Addresses(Address, Home, City_Id) 
            VALUES ('Подлужная', '40', 1),
            VALUES ('Большая', '80', 1)",
            connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

/*

INSERT Cities(City_Id, City) 
VALUES ('Казань'),
VALUES ('Нурлат'),
VALUES ('Чистополь'),
VALUES ('Высокая гора');

INSERT Addresses(Id, Address, Home, City_Id) VALUES ('Большая', '80', 1),
VALUES ('Подлужная', '40', 1);

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


