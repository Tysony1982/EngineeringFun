using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpAlgos.Sorting.Sorting;

namespace UnitTests.SortingAlgos
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void PracTest()
        {
            var array = new int[] { 1, 14, 22, 45, 6, 55, 43, 22, 7, 0 };
            var test = MergeSort(array);

            Assert.IsTrue(test.Last() == 55);
        }
    }
}
