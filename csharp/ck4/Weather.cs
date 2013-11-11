using System;

namespace ck4
{
    public class Weather
    {
        public int Day;
        public float Diff;

        public Weather(int day, float diff)
        {
            Day = day;
            Diff = diff;
        }
        public static Weather Create(string readLine)
        {
            string[] element = readLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            float max = Single.Parse(element[1].Replace("*", ""));
            float min = Single.Parse(element[2].Replace("*", ""));
            var weather = new Weather(Int32.Parse(element[0]), max - min);
            return weather;
        }
    }
}