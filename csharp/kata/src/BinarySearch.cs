using System;
using System.Collections.Generic;
using System.Linq;

namespace kata
{
    public class BinarySearch
    {
        public int ChopRecursion(int target, int[] array)
        {
            try
            {
                return ChopWithException(target, array);
            }
            catch(Exception)
            {
                return -1;
            }

        }

        private static int ChopWithException(int target, int[] array)
        {
            var mid = array.Length/2;

            if (array.Length == 0)
            {
                throw new Exception();
            }
            if (target > array[mid])
            {
                return mid + ChopWithException(target, GetRightHalf(mid, array)) + 1;
            }
            if (target < array[mid])
            {
                return ChopWithException(target, GetLeftHalf(mid, array));
            }
            return mid;
        }

        private static int[] GetLeftHalf(int mid, int[] array)
        {
            return array.Take(mid).ToArray();
        }

        private static int[] GetRightHalf(int mid, int[] array)
        {
            return array.Skip(mid + 1).ToArray();
        }

        public int ChopIteration(int target, int[] array)
        {
            int left = 0;
            int mid = array.Length/2;
            int right = array.Length;

            while(left < right){
                if(target < array[mid])
                {
                    right = mid;
                }
                else if(target > array[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
                mid = (left + right)/2;
            }
            return -1;
        }
    }
}
