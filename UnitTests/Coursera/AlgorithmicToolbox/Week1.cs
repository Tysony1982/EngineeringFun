using CourseraAlgorithmicToolbox.Week1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static CourseraAlgorithmicToolbox.Week1.AddTwoNumbers;

namespace UnitTests.Coursera.AlgorithmicToolbox
{
    [TestFixture]
    public class Week1
    {

        private static List<string?> listOfStrings { get; set; } = new List<string?>();
        private int addToNumbersCounter { get; set; } = 0;

        [SetUp]
        public void SetUp()
        {
            // Ensure global AddToNumbers counter is reset each run
            addToNumbersCounter = 0;
        }

        [TestCase("1","f","2",null, 2.0)]
        [TestCase("4.2",null,"2",null, 8.4)]
        public void AddTwoNumbersTest(string? str1, string? str2, string? str3, string? str4, decimal expected)
        {
            // Set up global list of strings to be passed in to mock the standard input for AddTwoNumbersFunc
            listOfStrings = possibleDecimals(str1,str2,str3,str4);
            var sut = AddTwoNumbers.AddTwoNumbersFunc(tryForStringAsDecimal());
            Assert.AreEqual(expected, sut);

        }


        public AddTwoNumbersDelegate tryForStringAsDecimal()
        {
            var str = listOfStrings.Count > addToNumbersCounter ? listOfStrings[addToNumbersCounter] : "2";
            addToNumbersCounter++;  
            return str == null ? "".ToString : str.ToString;
        }
        public List<string?> possibleDecimals(string? str1, string? str2, string? str3 = null, string? str4 = null)
        {
            var list = new List<string?>()
            {
                str1,
                str2,
                str3,
                str4
            };

            return list;

        }
    }
}
