using System;
using System.Text.RegularExpressions;

namespace kata.DataMungling
{
    public class OriginalData
    {
        public readonly string PrimaryKey;
        public readonly string Max;
        public readonly string Min;
        public readonly int Difference;

        public OriginalData(string primaryKey, string max, string min)
        {
            PrimaryKey = primaryKey;
            Max = Regex.Replace(max, "[^.0-9]", "");
            Min = Regex.Replace(min, "[^.0-9]", "");
            Difference = Math.Abs(int.Parse(Max) - int.Parse(Min));
        }
    }
}