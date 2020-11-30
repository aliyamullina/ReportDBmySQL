using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Создается список данных карты для адресов
        /// </summary>
        public static List<InfoMap> GetFill()
        {
            List<InfoMap> mapsList = new List<InfoMap>();
            mapsList.Add(new InfoMap("​5 этажей", "60", "В доме 4 подъезда"));  // Высокая гора, Большая Красная, 214 
            mapsList.Add(new InfoMap("5 этажей", "60", "В доме 4 подъезда"));  // Высокая гора, Большая Красная, 216 
            mapsList.Add(new InfoMap("​2 этажа", "16", "В доме 2 подъезда"));   // Высокая гора, Большая Красная, 218 
            mapsList.Add(new InfoMap( "​2 этажа", "16", "В доме 2 подъезда"));  // Высокая гора, Большая Красная, 220
            mapsList.Add(new InfoMap("​2 этажа", "16", "В доме 2 подъезда"));   // Высокая гора, Большая Красная, 222 
            mapsList.Add(new InfoMap("​5 этажей", "50", "В доме 4 подъезда"));  // Высокая гора, Большая Красная, 224 
            mapsList.Add(new InfoMap("​3 этажа", "36", "В доме 3 подъезда"));   // Высокая гора, Большая Красная, 226 
            mapsList.Add(new InfoMap("5 этажей", "49", "В доме 4 подъезда"));  // Высокая гора, Большая Красная, 228 
            mapsList.Add(new InfoMap("3 этажа", "27", "В доме 3 подъезда"));   // Высокая гора, Заречная, 7 
            mapsList.Add(new InfoMap("4 этажа", "27", "В доме 3 подъезда"));   // Высокая гора, Заречная, 8 

            return mapsList;
        }
    }
}
