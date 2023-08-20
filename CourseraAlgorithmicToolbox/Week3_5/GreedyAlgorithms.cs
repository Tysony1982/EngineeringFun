using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseraAlgorithmicToolbox.Week3_5
{
    public static class GreedyAlgorithms
    {

        public static long LargestNumber(int[] array)
        {
            var sortedArray = array.OrderBy(x => x);
            var returnNumber = 0d;
            var index = 0;

            foreach (var num in sortedArray) 
            {
                returnNumber += (num * (Math.Pow(10, index)));
                index ++;
            }
            return (long)returnNumber;
        }


        public static long MinimumWaitingTimeForQueue(int[] array)
        {
            var totalClients = array.Count();
            // Sort the array so the minimum treatment time is at the start
            var sortedArray = array.OrderBy(x => x);
            var minimumTime = 0;
            var index = 0;
            // Cycle through array times and add them to the waiting time
            foreach (var item in sortedArray) 
            {
                if (index == totalClients - 1) break;

                minimumTime += (totalClients - (index + 1)) * item;

                index++;
            }

            return minimumTime;
        }


        public static List<decimal[]> MinimumNumberSegments(decimal[] array, decimal numberToCover = 2)
        {
            var sortedArray = array.OrderBy(x => x).ToArray();
            var segments = new List<decimal[]>();

            while (sortedArray.Any())
            {
                var rangeLower = sortedArray.First();
                var rangeUpper = rangeLower + numberToCover;
                var length = sortedArray.Length;
                var upperIndex = 0;
                // Get upper index of sorted array that 
                while (upperIndex < sortedArray.Length && sortedArray[upperIndex] <= rangeUpper)
                    upperIndex++;

                var lengthOfNewArray = upperIndex;
                var segmentArray = new decimal[lengthOfNewArray];
                Array.Copy(sortedArray, 0, segmentArray, 0, lengthOfNewArray);

                // Remove the used elements from the sortedArray
                sortedArray = sortedArray.Skip(lengthOfNewArray).ToArray();


                segments.Add(segmentArray);
            }
            return segments;
        }

        public static List<(decimal weight,decimal value)> GetMaximumLoot(decimal[] weights, decimal[] values, decimal maxWeight = 9)
        {
            if (weights.Length != values.Length) throw new ArgumentException("Array lengths must be equal");

            // First find the unit cost of each so we can better understand the most expensive per unit of measure
            var unitPrices = new decimal[weights.Length];
            for (var i = 0; i < weights.Length;  i++)
                unitPrices[i] = values[i] / weights[i];

            // Add together data so we can sort on unit pricing 
            (decimal unitPrice,decimal weight,decimal value)[] dataSet = unitPrices.Zip(weights, values).OrderByDescending(x => x.First).ToArray();

            // Now we have an ordered list of unitprices and weights lets greedily fill
            var weightLeftToFill = maxWeight;
            var currentIndex = 0;
            var composition = new List<(decimal weight, decimal value)>();
            while (weightLeftToFill > 0 && currentIndex < dataSet.Length) 
            {
                // Get the item for the current index and see if it fills the remaining capcity in the bag
                var fillsBag = dataSet[currentIndex].weight >= weightLeftToFill;

                if (fillsBag)
                {
                    var valueToUse = weightLeftToFill * dataSet[currentIndex].unitPrice;
                    composition.Add((weightLeftToFill, valueToUse));
                    weightLeftToFill = 0;
                }
                else
                {
                    composition.Add((dataSet[currentIndex].weight, dataSet[currentIndex].value));
                    weightLeftToFill -= dataSet[currentIndex].weight;
                }

                currentIndex++;
            }

            return composition;
        }


        /// <summary>
        /// Takes an array of ints (say numbered balls for example) and trys to split them into unequal sized buckets
        /// </summary>
        /// <returns>Returns the data associated with the bucketing (should all be different sizes) and a boolean idicating success or not</returns>
        public static (List<int[]> data, bool success) GetDistinctBucketsWithinNumber(int[] dataToSplit, int numberOfDistinctSizedBuckets = 10)
        {
            var returnList = new List<int[]>();
            
            int thisBucketSize = 0;
            var range = Enumerable.Range(0, numberOfDistinctSizedBuckets);
            foreach(var bucket in range) 
            {
                if (dataToSplit.Length == 0)
                    break; 
                
                if (thisBucketSize > dataToSplit.Length) // && bucket != numberOfDistinctSizedBuckets)
                {
                    return (returnList, false);
                }

                if (bucket == range.Last())
                {
                    returnList.Add(dataToSplit);
                    break;
                }

                var newArray = dataToSplit.Take(thisBucketSize).ToArray();
                dataToSplit = dataToSplit.Skip(thisBucketSize).ToArray();
                returnList.Add(newArray);
                thisBucketSize++;
            }

            return (returnList, true);
        }

    }
}
