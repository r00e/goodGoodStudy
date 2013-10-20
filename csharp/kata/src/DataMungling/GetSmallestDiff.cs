using System;
using System.Collections.Generic;
using System.Linq;

namespace kata.DataMungling
{
    public class GetSmallestDiff
    {
        public static List<string> GetSmallest(List<OriginalData> data)
        {
            var orderList = data.OrderBy(d => d.Difference);
            var smallestDiff = data.FindAll(d => d.Difference == orderList.First().Difference);
            var result = smallestDiff.Select(day => day.PrimaryKey).ToList();
            return result;
        }         
    }
}