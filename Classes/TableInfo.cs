using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDBmySQL.Classes
{
    class DateInfo
    {
        public DateInfo(string date)
        {
            this.Date = date;
        }
        public string Date { get; set; }
    }

    class TableInfo
    {
        public TableInfo(string apartment, string model, string serial)
        {
            this.Apartment = apartment;
            this.Model = model;
            this.Serial = serial;
        }
        public string Apartment { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
    }
}
