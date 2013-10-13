using System.Collections.Generic;
using System.Globalization;
using Xunit;
using kata.DataMungling;

namespace kata.test
{
    public class DataMunglingFact
    {
        readonly WeatherData _weatherData = new GenerateWeatherData().Generate();

        [Fact]
        public void should_get_all_lines_with_Dy_MxT_MnT()
        {
            Assert.Equal(5, _weatherData.Data.Count);
        }

        [Fact]
        public void should_get_Day_MxT_MnT()
        {
            Assert.Equal(expected: 1.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[0].Dy);
            Assert.Equal(expected: 88.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[0].MxT);
            Assert.Equal(expected: 59.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[0].MnT);            
        }

        [Fact]
        public void should_remove_asterisk_in_temperature()
        {
            Assert.Equal(expected: 32.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[1].MnT);
            Assert.Equal(expected: 97.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[3].MxT);
        }

        [Fact]
        public void should_get_all_smallest_temperature_spread_day_number()
        {
            Assert.Equal(2, _weatherData.DaySmallestTemperatureSpread().Count);
            Assert.Contains(expected: 25.ToString(CultureInfo.InvariantCulture), collection: _weatherData.DaySmallestTemperatureSpread());
            Assert.Contains(expected: 28.ToString(CultureInfo.InvariantCulture), collection: _weatherData.DaySmallestTemperatureSpread());
        }
    }
}