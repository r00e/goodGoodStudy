using System.Collections.Generic;
using System.IO;

namespace ck4
{
    public class DataMunging
    {
        public IList<Weather> ProcessWeather(Stream stream)
        {
            var streamReader = new StreamReader(stream);
            
            string readLine = streamReader.ReadLine();
            var weathers = new List<Weather>();

            while (readLine != null)
            {
                var weather = Weather.Create(readLine);
                weathers.Add(weather);
                readLine = streamReader.ReadLine();
            }
            return weathers;
        }

        public IList<Score> ProcessScore(Stream stream)
        {
            var streamReader = new StreamReader(stream);

            var readLine = streamReader.ReadLine();
            var scores = new List<Score>();

            while(readLine != null)
            {
                var score = Score.Create(readLine);
                scores.Add(score);
                readLine = streamReader.ReadLine();
            }
            return scores;
        }
    }
}