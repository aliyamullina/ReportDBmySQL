using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public class DateInfo
    {
        public DateInfo(string date)
        {
            this.Date = date;
        }
        public string Date { get; set; }
    }

    public class RegistryInfo
    {
        public RegistryInfo(string apartment, string model, string serial)
        {
            this.Apartment = apartment;
            this.Model = model;
            this.Serial = serial;
        }
        public string Apartment { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
    }

    public partial class DB
    {
        /// <summary>
        /// Создается таблица Registers в БД
        /// </summary>
        public void CreateTableRegisters()
        {
            MySqlCommand command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Registers
                (Registry_Id INT AUTO_INCREMENT PRIMARY KEY, 
                Apartment VARCHAR(5) NOT NULL,
                Model VARCHAR(20) NOT NULL,
                Serial VARCHAR(20) NOT NULL);",
                connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Заполнение таблицы Registers в БД
        /// </summary>
        /// <param name="registersList"></param>
        public void InsertTableRegisters(List<RegistryInfo> registersList)
        {
        }

        public List<RegistryInfo> GetRegistryList()
        {
            List<RegistryInfo> registrySelect = new List<RegistryInfo>();
            //
            return registrySelect;
        }
    }
}