using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Заполнение таблицы Registers в БД
        /// </summary>
        public void GetInsertRegisters(List<InfoRegistry> registersList)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand(@"
                INSERT INTO Registers(Catalog_id, Apartment, Model, Serial) 
                VALUES (@catalog_id, @apartment, @model, @serial)",
                connection))
                {
                    connection.Open();
                    foreach (var item in registersList)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@catalog_id", item.Catalog_id);
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
    }
}
