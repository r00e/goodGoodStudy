using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace kata.DataMungling
{
    public class WeatherData
    {
        public List<OriginalData> Data = new List<OriginalData>();

        public string DaySmallestTemperatureSpread()
        {
            var newList = Data.OrderBy(d => d.TemperaturSpread);
            return newList.First().Dy;
        }
    }
}