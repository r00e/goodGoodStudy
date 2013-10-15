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
            var orderList = Data.OrderBy(d => d.Difference);
            var smallestTempSpreadDay = Data.FindAll(d => d.Difference == orderList.First().Difference);
            var result = smallestTempSpreadDay.Select(day => day.MainKey).ToList();
            return result;
        }
    }
}