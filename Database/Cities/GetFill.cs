using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Cities
    {
        public static void GetFill(string open, MySqlConnection connection)
        {
            var city = open.Substring(open.LastIndexOf("\\")).Replace("\\", string.Empty);

            List<InfoCity> citiesList = new List<InfoCity>
                {
                    new InfoCity(city)
                };
            GetInsert(citiesList, connection);
        }
    }
}
