﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Создается таблица Registers в БД
        /// </summary>
        public void CreateTableRegisters()
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Registers
                (Registry_Id INT AUTO_INCREMENT PRIMARY KEY, 
                Apartment VARCHAR(15) NOT NULL,
                Model VARCHAR(30) NOT NULL,
                Serial VARCHAR(30) NOT NULL);",
                connection))
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
        /// Заполнение таблицы Registers в БД
        /// </summary>
        public void InsertTableRegisters(List<RegistryInfo> registersList)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand(@"
                INSERT INTO Registers(Apartment, Model, Serial) 
                VALUES (@apartment, @model, @serial)",
                connection))
                {
                    connection.Open();
                    foreach (var item in registersList)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@apartment", item.Apartment);
                        command.Parameters.AddWithValue("@model", item.Model);
                        command.Parameters.AddWithValue("@serial", item.Serial);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

        }

        /// <summary>
        /// Извлечение из таблицы Registers в List
        /// </summary>
        public List<RegistryInfo> GetRegistryList()
        {
            List<RegistryInfo> registrySelect = new List<RegistryInfo>();
            //
            return registrySelect;
        }
    }
}