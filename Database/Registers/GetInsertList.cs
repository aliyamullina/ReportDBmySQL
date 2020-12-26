using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        /// <summary>
        /// Заполнение таблицы Registers в БД
        /// </summary>
        public static void GetInsertList(in List<InfoRegistry> registersList, MySqlConnection connection)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand(@"
                INSERT INTO Registers(Catalog_id, Apartment, Model, Serial) 
                VALUES (@catalog_id, @apartment, @model, @serial)",
                connection))
                {
                    foreach (var item in registersList)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@catalog_id", item.Catalog_id);
                        command.Parameters.AddWithValue("@apartment", item.Apartment);
                        command.Parameters.AddWithValue("@model", item.Model);
                        command.Parameters.AddWithValue("@serial", item.Serial);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

        }
    }
}
