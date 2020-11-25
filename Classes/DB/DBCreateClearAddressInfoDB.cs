using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Создается общая БД addressinfodb
        /// </summary>
        public void CreateAddressInfoDB()
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("CREATE DATABASE addressinfodb;", connection))
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

        /// <summary>
        /// Очистка общей таблицы
        /// </summary>
        public void ClearAddressInfoDB()
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("DROP TABLE cities, addresses, catalogs, registers;", connection))
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


//2 таблица Реестр
//IdУлица
//IdДом
//Данные по счетчикам

//3 таблица 2гис данные
//IdУлица
//IdДом
//Данные по домам

//4 таблица аскуэ
//IdУлица
//IdДом
//Данные по подъездам
//Этаж
//Количество квартир
//Подъезды


