using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace kata.DataMungling
{
    public class GenerateScoreData
    {
        private const string InputFile = @".\src\DataMungling\football_copy.dat";
        private readonly List<OriginalData> _score = new List<OriginalData>();

        public List<OriginalData> Generate(string inputFile = InputFile)
        {
            if (!File.Exists(inputFile)) throw FileNotFoundException;
            ReadDataFromFileToScore(inputFile, _score);
            return _score;
        }

        protected Exception FileNotFoundException
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        private void ReadDataFromFileToScore(string inputFile, List<OriginalData> score)
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
                        var originalData = new OriginalData(data[1], data[6], data[8]);
                        score.Add(originalData);
                    }
                }
            }
        }
    }
}