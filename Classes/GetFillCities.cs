using System.Collections.Generic;

namespace ReportDBmySQL
{
    class GetFillCities
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static List<InfoCity> Get()
        {
            List<InfoCity> citiesList = new List<InfoCity>();
            string[] citiesArray = { "Казань", "Нурлат", "Чистополь", "Высокая гора", "Зеленодольск" };
            foreach (var city in citiesArray)
            {
                citiesList.Add(new InfoCity(city));
            }
            return citiesList;
        }
    }
}
