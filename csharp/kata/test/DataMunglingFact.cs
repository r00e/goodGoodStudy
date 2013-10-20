using System;
using System.Collections.Generic;
using Xunit;
using kata.DataMungling;

namespace kata.test
{
    public class DataMunglingFact
    {
        readonly List<OriginalData> _weatherData = new GenerateWeatherData().Generate();
        readonly List<OriginalData> _scoreData = new GenerateScoreData().Generate();

        [Fact]
        public void should_get_all_lines_with_Dy_MxT_MnT()
        {
            Assert.Equal(5, _weatherData.Count);
        }

        [Fact]
        public void should_get_Day_MxT_MnT()
        {
            Assert.Equal(1, Convert.ToInt32(_weatherData[0].PrimaryKey));
            Assert.Equal(88, Convert.ToInt32(_weatherData[0].Max));
            Assert.Equal(59, Convert.ToInt32(_weatherData[0].Min));            
        }

        [Fact]
        public void should_remove_asterisk_in_temperature()
        {
            Assert.Equal(32, Convert.ToInt32(_weatherData[1].Min));
            Assert.Equal(97, Convert.ToInt32(_weatherData[3].Max));
        }

        [Fact]
        public void should_get_all_smallest_temperature_spread_day_number()
        {
            Assert.Equal(2, GetSmallestDiff.GetSmallest(_weatherData).Count);
            Assert.Contains(25.ToString(), GetSmallestDiff.GetSmallest(_weatherData));
            Assert.Contains(28.ToString(), GetSmallestDiff.GetSmallest(_weatherData));
        }

        [Fact]
        public void should_get_all_lines_with_team_scoreF_scoreA()
        {
            Assert.Equal(4, _scoreData.Count);
        }

        [Fact]
        public void should_get_team_scoreF_scoreA()
        {
            Assert.Equal("Arsenal", _scoreData[0].PrimaryKey);
            Assert.Equal(79, Convert.ToInt32(_scoreData[0].Max));
            Assert.Equal(36, Convert.ToInt32(_scoreData[0].Min));
        }

        [Fact]
        public void should_get_all_smallest_difference_team()
        {
            Assert.Equal(2, GetSmallestDiff.GetSmallest(_scoreData).Count);
            Assert.Contains("Ipswich", GetSmallestDiff.GetSmallest(_scoreData));
            Assert.Contains("Derby", GetSmallestDiff.GetSmallest(_scoreData));
        }
    }
}