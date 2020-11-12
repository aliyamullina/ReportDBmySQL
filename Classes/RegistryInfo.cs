using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDBmySQL.Classes
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