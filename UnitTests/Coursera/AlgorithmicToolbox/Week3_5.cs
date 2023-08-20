using CourseraAlgorithmicToolbox.Week1;
using CourseraAlgorithmicToolbox.Week3_5;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static CourseraAlgorithmicToolbox.Week3_5.GreedyAlgorithms;

namespace UnitTests.Coursera.AlgorithmicToolbox
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void LongestNumberTest() 
        { 
            var array = new int[] { 1, 2, 3, 8, 4, 9, 6 };
            var longestNumber = GreedyAlgorithms.LargestNumber(array);

            Assert.IsTrue(longestNumber == 9864321);
        }


        [Test]
        public void PatientQueueTest()
        {
            var array = new int[] { 34, 99, 120, 12 };
            var minimumTime = MinimumWaitingTimeForQueue(array);

            Assert.IsTrue(minimumTime == (12 * 3 + 34 * 2 + 99 * 1));
        }

        [Test]
        public void CelebrationPartyTest()
        {
            var array = new decimal[] { 1, 4, 2, 5, 8, 9, 11 };
            var returnArray = MinimumNumberSegments(array);

            Assert.IsTrue(returnArray.Count == 4);
        
        }

        [Test]
        public void GetMaximumLootTest()
        {
            var weights = new decimal[] { 5, 4, 3 };
            var values = new decimal[] { 30, 28, 24 };

            var sut = GetMaximumLoot(weights, values);

            Assert.IsTrue(sut.Select(x => x.weight).Sum() == 9);
            Assert.IsTrue(sut.Select(x => x.value).Sum() == 64);
        }


        [Test]
        public void AssignmentQuestion1_1()
        {
            var array = Enumerable.Range(1,60).ToArray();
            var result = GetDistinctBucketsWithinNumber(array);

            Assert.IsTrue(result.data.Last().Length == 24);
        }

        [Test]
        public void AssignmentQuestion1_2()
        {
            var array = Enumerable.Range(1, 45).ToArray();
            var result = GetDistinctBucketsWithinNumber(array);

            Assert.IsTrue(result.data.Last().Length == 9);
        }

        [Test]
        public void AssignmentQuestion1_3()
        {
            var array = Enumerable.Range(1, 30).ToArray();
            var result = GetDistinctBucketsWithinNumber(array);

            Assert.IsTrue(result.success == false);
            Assert.IsTrue(result.data.Count != 10);
        }



    }
}

	

