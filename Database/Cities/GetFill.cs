using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Cities
    {
        public static void GetFill(in string open, out List<InfoCity> citiesList)
        {
            citiesList = new List<InfoCity>();
            var city = open.Substring(open.LastIndexOf("\\")).Replace("\\", string.Empty);
            citiesList.Add(new InfoCity(city));
        }
    }
}
