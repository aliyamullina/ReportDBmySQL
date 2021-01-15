using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Dates
    {
        /// <summary>
        /// Возвращает реестр для текущего адреса в БД
        /// </summary>
        public static void GetSelectList(out List<DateTime> documentDate, in string fN, MySqlConnection connection)
        {
            documentDate = new List<DateTime>();

            //"Казань, Ямашева 88"

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
                    dates.Date
                FROM addresses, cities, dates 
                WHERE CONCAT(City, ', ', Street, ' ' , Home, ' ' , Part) = @address
                AND
                 addresses.Address_Id = dates.Date_id
                AND
                 addresses.City_id = cities.City_Id
                GROUP BY Address_id
                ", connection))
            {
                connection.Open();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@address", fN);
                command.ExecuteNonQuery();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        documentDate.Add((DateTime)dataReader["Date"]);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
        }
    }
}