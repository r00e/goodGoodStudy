using System.Globalization;
using Xunit;
using kata.DataMungling;

namespace kata.test
{
    public class DataMunglingFact
    {
        readonly WeatherData _weatherData = new GenerateWeatherData().Generate();
        readonly ScoreData _scoreData = new GenerateScoreData().Generate();

        [Fact]
        public void should_get_all_lines_with_Dy_MxT_MnT()
        {
            Assert.Equal(5, _weatherData.Data.Count);
        }

        [Fact]
        public void should_get_Day_MxT_MnT()
        {
            Assert.Equal(expected: 1.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[0].MainKey);
            Assert.Equal(expected: 88.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[0].Max);
            Assert.Equal(expected: 59.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[0].Min);            
        }

        [Fact]
        public void should_remove_asterisk_in_temperature()
        {
            Assert.Equal(expected: 32.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[1].Min);
            Assert.Equal(expected: 97.ToString(CultureInfo.InvariantCulture), actual: _weatherData.Data[3].Max);
        }

        [Fact]
        public void should_get_all_smallest_temperature_spread_day_number()
        {
            Assert.Equal(2, _weatherData.DaySmallestTemperatureSpread().Count);
            Assert.Contains(expected: 25.ToString(CultureInfo.InvariantCulture), collection: _weatherData.DaySmallestTemperatureSpread());
            Assert.Contains(expected: 28.ToString(CultureInfo.InvariantCulture), collection: _weatherData.DaySmallestTemperatureSpread());
        }

        [Fact]
        public void should_get_all_lines_with_team_scoreF_scoreA()
        {
            Assert.Equal(4, _scoreData.Data.Count);
        }

        [Fact]
        public void should_get_team_scoreF_scoreA()
        {
            Assert.Equal("Arsenal", _scoreData.Data[0].MainKey);
            Assert.Equal(expected: 79.ToString(CultureInfo.InvariantCulture), actual: _scoreData.Data[0].Max);
            Assert.Equal(expected: 36.ToString(CultureInfo.InvariantCulture), actual: _scoreData.Data[0].Min);
        }

        [Fact]
        public void should_get_all_smallest_difference_team()
        {
            Assert.Equal(2, _weatherData.DaySmallestTemperatureSpread().Count);
            Assert.Contains("Ipswich", _scoreData.ScoreSmallestDifference());
            Assert.Contains("Derby", _scoreData.ScoreSmallestDifference());
        }
    }
}