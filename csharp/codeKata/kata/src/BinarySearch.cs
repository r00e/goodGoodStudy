using System;
using System.Globalization;
using System.Linq;

namespace kata
{
    public class BinarySearch
    {
        public int ChopRecursion(int target, int[] array)
        {
            int mid = array.Length/2;

            if (array.Length == 0 || array.Length == 1 && target != array[mid])
            {
                return -1;
            }
            else if (target > array[mid])
            {
                return getResult(mid, ChopRecursion(target, GetRightHalf(array)));
            }
            else if (target < array[mid])
            {
                return getResult(0, ChopRecursion(target, GetLeftHalf(array)));
            }
            else
            {
                return mid;
            }
        }

        private static int[] GetLeftHalf(int[] array)
        {
            var newArray = new int[array.Length/2];
            for (int i = 0; i < array.Length / 2; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }

        private static int[] GetRightHalf(int[] array)
        {
            var newArray = new int[array.Length-array.Length/2];
            for (int i = array.Length/2, j=0; i < array.Length; i++, j++)
            {
                newArray[j] = array[i];
            }
            return newArray;
        }

        private int getResult(int mid, int position)
        {
            return position == -1 ? -1 : mid + position;
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
