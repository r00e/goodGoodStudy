using System.Text.RegularExpressions;

namespace kata.DataMungling
{
    public class OriginalData
    {
        public readonly string Dy;
        public readonly string MxT;
        public readonly string MnT;

        public OriginalData(string day, string maxT, string minT)
        {
            Dy = day;
            MxT = Regex.Replace(maxT, "[^.0-9]", "");
            MnT = Regex.Replace(minT, "[^.0-9]", "");
        }
    }
}