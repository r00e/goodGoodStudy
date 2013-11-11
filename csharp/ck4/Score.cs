using System;

namespace ck4
{
    public class Score
    {
        public string Team;
        public float Diff;

        public Score(string teamName, float diff)
        {
            Team = teamName;
            Diff = diff;
        }

        public static Score Create(string readLine)
        {
            string[] element = readLine.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            float columnF = Single.Parse(element[6]);
            float columnA = Single.Parse(element[8]);
            
            var score = new Score(element[1], Math.Abs(columnF - columnA));
            return score;            
        }
    }
}