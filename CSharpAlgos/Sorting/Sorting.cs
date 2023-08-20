using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAlgos.Sorting
{
    public static class Sorting
    {
        public static IEnumerable<T>? MergeSort<T>(IEnumerable<T>? arrayToSort) where T : IComparable<T>
        {
            // First check for 1 or less elements
            if (arrayToSort?.Count() < 2 || arrayToSort is null) return arrayToSort;

            return InternalMergeSort(arrayToSort);
        }

        //public static T[] QuickSort<T>(T[] arrayToSort) where T : IComparable<T>
        //{
            
        //}

        //private static void InternalQuickSort<T>(T[] arrayToSort) where T : IComparable<T>
        //{

        //}

        private static T[] InternalMergeSort<T>(IEnumerable<T> arrayToSort) where T : IComparable<T>
        {
            // First check for 1 or less elements
            if (arrayToSort?.Count() < 2 || arrayToSort is null) return arrayToSort?.ToArray() ?? Array.Empty<T>();

            // Split the array into 2
            var halfWayPoint = arrayToSort.Count() / 2;
            (T[] firstHalf, T[] secondHalf) = (arrayToSort.Take(halfWayPoint).ToArray(), arrayToSort.Skip(halfWayPoint).ToArray());

            // Must ensure you reset these halves of the array to the sorted version coming out of 
            firstHalf = InternalMergeSort(firstHalf);
            secondHalf = InternalMergeSort(secondHalf);

            return Merge(arrayToSort.ToArray(),firstHalf,secondHalf);
        }


        private static T[] Merge<T>(T[] arrayToSort, T[] firstHalf, T[] secondHalf) where T : IComparable<T>
        {
            // Set index trackers
            var firstHalfIndex = 0;
            var secondHalfIndex = 0;
            // Get lengths of each sub array and the total so we can determine the looping
            var firstHalfLength = firstHalf.Length;
            var secondHalfLength = secondHalf.Length;
            var totalLength = arrayToSort.Length;

            if (totalLength != (firstHalfLength + secondHalfLength)) 
                throw new ArgumentException("Sub arrays should add up to the total length of array in question");

            for (var targetIndex = 0; targetIndex < totalLength; targetIndex++) 
            {
                if (firstHalfIndex >= firstHalfLength)
                {
                    arrayToSort[targetIndex] = secondHalf[secondHalfIndex];
                    secondHalfIndex++;
                }
                else if (secondHalfIndex >= secondHalfLength)
                {
                    arrayToSort[targetIndex] = firstHalf[firstHalfIndex];
                    firstHalfIndex++;
                }
                else if (firstHalf[firstHalfIndex].CompareTo(secondHalf[secondHalfIndex]) < 0)
                {
                    arrayToSort[targetIndex] = firstHalf[firstHalfIndex];
                    firstHalfIndex++;
                }
                else //if (secondHalf[secondHalfIndex].CompareTo(firstHalf[firstHalfIndex]) < 0)
                {
                    arrayToSort[targetIndex] = secondHalf[secondHalfIndex];
                    secondHalfIndex++;
                }

            }
            return arrayToSort;

        }


    }
}
