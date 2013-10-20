using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace kata.DataMungling
{
    public class GenerateWeatherData
    {
        private const string InputFile = @".\src\DataMungling\weather_copy.dat";
        private readonly List<OriginalData> _weather = new List<OriginalData>();

        public List<OriginalData> Generate(string inputFile = InputFile)
        {
            if (!File.Exists(inputFile)) throw FileNotFoundException;
            ReadDataFromFileToWeather(inputFile, _weather);
            return _weather;
        }

        protected Exception FileNotFoundException
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        private void ReadDataFromFileToWeather(string inputFile, List<OriginalData> weather)
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
                        weather.Add(originalData);
                    }
                }
            }
        }
    }
}