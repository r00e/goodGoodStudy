using System;
using System.Collections.Generic;

namespace ck4
{
    public class Selector
    {
        public IList<Weather> SelectWeather(List<Weather> weathers)
        {
            return weathers.Count == 0 ? new List<Weather>() : FindWeathersWithMaxDiff(weathers);
        }

        private static IList<Weather> FindWeathersWithMaxDiff(IList<Weather> weathers)
        {
            var max = weathers[0];
            var weathersMaxDiff = new List<Weather> {max};

            for (int i = 1; i < weathers.Count; i++)
            {
                if (max.Diff < weathers[i].Diff)
                {
                    max = weathers[i];
                    weathersMaxDiff.Clear();
                    weathersMaxDiff.Add(max);
                }
                else if (Equal(max.Diff, weathers[i].Diff))
                {
                    weathersMaxDiff.Add(weathers[i]);
                }
            }

            return weathersMaxDiff;
        }

        private static bool Equal(float left, float right)
        {
            return Math.Abs(left - right) < Single.Epsilon;
        }
    }
}