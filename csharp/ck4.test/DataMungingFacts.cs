﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace ck4.test
{
    public class DataMungingFacts
    {
        [Fact]
        public void should_return_empty_data_when_stream_is_empty()
        {
            string str = "";                        
            byte[] array = Encoding.ASCII.GetBytes(str);            
            Stream stream = new MemoryStream(array);
            IList<Weather> weathers = new DataMunging().Process(stream);
            Assert.Equal(0, weathers.Count);
        }

        [Fact]
        public void should_return_weather_when_stream_includes_valid_data()
        {
            var str = new object[][] { 
                new object[] {"1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5", 1, 29f},
                new object[] {"26  97*   64    81          70.4       0.00 H       050  5.1 200  12  4.0 107 45 1014.9", 26, 33f}
            };

            foreach (object[] t in str)
            {
                var array = Encoding.ASCII.GetBytes((string) t[0]);
                var stream = new MemoryStream(array);
                var weathers = new DataMunging().Process(stream);
                
                Assert.Equal(1, weathers.Count);
                Assert.Equal(t[1], weathers[0].Day);
                Assert.Equal(t[2], weathers[0].Diff);
            }
        }

        [Fact]
        public void should_return_weathers_when_stream_includes_multiple_valid_data()
        {
            var array = Encoding.ASCII.GetBytes("1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5\n26  97*   64    81          70.4       0.00 H       050  5.1 200  12  4.0 107 45 1014.9");
            var stream = new MemoryStream(array);
            var weathers = new DataMunging().Process(stream);
                
            Assert.Equal(2, weathers.Count);
        }

        [Fact]
        public void should_return_empty_when_there_is_no_weather_data()
        {
            var selected = new Selector().Select(new List<Weather>());
            Assert.Equal(0, selected.Count);
        }
    }

    public class Selector
    {
        public IList<Weather> Select(List<Weather> weathers)
        {
            return new List<Weather>();
        }
    }

    public class DataMunging
    {
        public IList<Weather> Process(Stream stream)
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
    }

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
