using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace kata.DataMungling
{
    public class GenerateWeatherData
    {
        private const string InputFile = @".\src\DataMungling\weather_copy.dat";
        private static readonly WeatherData Weather = new WeatherData();

        public static WeatherData Generate(string inputFile = InputFile)
        {
            if (!File.Exists(inputFile)) throw FileNotFoundException;
            ReadDataFromFileToWeather(inputFile, Weather);
            return Weather;
        }

        protected static Exception FileNotFoundException
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        private static void ReadDataFromFileToWeather(string inputFile, WeatherData weather)
        {
            using (var reader = new StreamReader(inputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line.Trim(), @"^\d+"))
                    {
                        var data = new List<string>(line.Split());
                        data.RemoveAll(String.IsNullOrEmpty);
                        var originalData = new OriginalData(data[0], data[1], data[2]);
                        weather.Data.Add(originalData);
                    }
                }
            }
        }
    }
}