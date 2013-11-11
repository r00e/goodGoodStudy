using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace ck4.test
{
    public class DataMungingFacts
    {
        [Fact]
        public void should_return_empty_data_when_weather_stream_is_empty()
        {
            string str = "";                        
            byte[] array = Encoding.ASCII.GetBytes(str);            
            Stream stream = new MemoryStream(array);
            IList<Weather> weathers = new DataMunging().ProcessWeather(stream);
            Assert.Equal(0, weathers.Count);
        }

        [Fact]
        public void should_return_empty_data_when_score_stream_is_empty()
        {
            string str = "";
            byte[] array = Encoding.ASCII.GetBytes(str);
            Stream stream = new MemoryStream(array);
            IList<Score> scores = new DataMunging().ProcessScore(stream);
            Assert.Equal(0, scores.Count);
        }

        [Fact]
        public void should_return_weather_when_stream_includes_valid_data()
        {
            var testData = new object[][] { 
                new object[] {"1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5", 1, 29f},
                new object[] {"26  97*   64    81          70.4       0.00 H       050  5.1 200  12  4.0 107 45 1014.9", 26, 33f}
            };

            foreach (object[] t in testData)
            {
                var array = Encoding.ASCII.GetBytes((string) t[0]);
                var stream = new MemoryStream(array);
                var weathers = new DataMunging().ProcessWeather(stream);
                
                Assert.Equal(1, weathers.Count);
                Assert.Equal(t[1], weathers[0].Day);
                Assert.Equal(t[2], weathers[0].Diff);
            }
        }

        [Fact]
        public void should_return_score_when_stream_includes_valid_data()
        {
            var testData = new object[] { "    1. Arsenal         38    26   9   3    79  -  36    87", "Arsenal", 43f };

            var array = Encoding.ASCII.GetBytes((string) testData[0]);
            var stream = new MemoryStream(array);
            var score = new DataMunging().ProcessScore(stream);

            Assert.Equal(1, score.Count);
            Assert.Equal(testData[1], score[0].Team);
            Assert.Equal(testData[2],score[0].Diff);
        }

        [Fact]
        public void should_return_weathers_when_stream_includes_multiple_valid_data()
        {
            var array = Encoding.ASCII.GetBytes("1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5\n26  97*   64    81          70.4       0.00 H       050  5.1 200  12  4.0 107 45 1014.9");
            var stream = new MemoryStream(array);
            var weathers = new DataMunging().ProcessWeather(stream);
                
            Assert.Equal(2, weathers.Count);
        }

        [Fact]
        public void should_return_scores_when_stream_includes_multiple_valid_data()
        {
            var array = Encoding.ASCII.GetBytes("    1. Arsenal         38    26   9   3    79  -  36    87\n    2. Liverpool       38    24   8   6    67  -  30    80");
            var stream = new MemoryStream(array);
            var scores = new DataMunging().ProcessScore(stream);

            Assert.Equal(2, scores.Count);         
        }

        [Fact]
        public void should_return_empty_when_there_is_no_weather_data()
        {
            var selected = new Selector().SelectWeather(new List<Weather>());
            Assert.Equal(0, selected.Count);
        }

        [Fact]
        public void should_return_the_weather_data_with_max_diff()
        {
            var weathers = new List<Weather> { new Weather(1, 5f), new Weather(2, 15f), new Weather(3, 10f) };
            var maxDiffDay = new Selector().SelectWeather(weathers);

            Assert.Equal(2, maxDiffDay[0].Day);
            Assert.Equal(15f, maxDiffDay[0].Diff);
        }

        [Fact]
        public void should_return_all_the_weather_with_max_diff()
        {
            var weathers = new List<Weather> { new Weather(1, 5f), new Weather(2, 15f), new Weather(3, 15f) };
            var maxDiffDays = new Selector().SelectWeather(weathers);

            Assert.Equal(2, maxDiffDays.Count);
        }
    }
}
