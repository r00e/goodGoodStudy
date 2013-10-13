using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace kata.DataMungling
{
    public class WeatherData
    {
        public List<OriginalData> Data = new List<OriginalData>();

        public List<string> DaySmallestTemperatureSpread()
        {
            var orderList = Data.OrderBy(d => d.TemperaturSpread);
            var smallestTempSpreadDay = Data.FindAll(d => d.TemperaturSpread == orderList.First().TemperaturSpread);
            var result = smallestTempSpreadDay.Select(day => day.Dy).ToList();
            return result;
        }
    }
}