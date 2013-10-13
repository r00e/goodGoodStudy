using System.Collections.Generic;
using System.Globalization;
using Xunit;
using kata.DataMungling;

namespace kata.test
{
    public class DataMunglingFact
    {
        readonly WeatherData _weatherData = GenerateWeatherData.Generate();

        [Fact]
        public void should_get_all_lines_with_Dy_MxT_MnT()
        {
            Assert.Equal(4, _weatherData.Data.Count);
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
    }
}