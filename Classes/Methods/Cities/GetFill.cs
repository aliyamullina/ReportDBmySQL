using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Cities
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static List<InfoCity> GetFill()
        {
            List<InfoCity> citiesList = new List<InfoCity>();
            string[] citiesArray = { "Казань", "Нурлат", "Чистополь", "Высокая гора", "Зеленодольск", "Васильево" };
            foreach (var city in citiesArray)
            {
                citiesList.Add(new InfoCity(city));
            }
            return citiesList;
        }
    }
}
