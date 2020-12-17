using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Cities
    {
        public static void GetFillList(in string openFolder, out List<InfoCity> citiesList)
        {
            citiesList = new List<InfoCity>();
            var city = openFolder.Substring(openFolder.LastIndexOf("\\")).Replace("\\", string.Empty);
            citiesList.Add(new InfoCity(city));
        }
    }
}
