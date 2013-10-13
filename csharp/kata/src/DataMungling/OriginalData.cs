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
            MxT = maxT;
            MnT = minT;
        }
    }
}