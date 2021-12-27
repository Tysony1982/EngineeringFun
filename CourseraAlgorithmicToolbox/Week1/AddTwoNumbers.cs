using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseraAlgorithmicToolbox.Week1
{
    public static class AddTwoNumbers
    {
        public delegate string? AddTwoNumbersDelegate();
        //public static decimal AddTwoNumbersFunc(Func<string?> tryForStringAsDecimal)
        public static decimal AddTwoNumbersFunc(AddTwoNumbersDelegate tryForStringAsDecimal)
        {
            decimal firstNumber = 0;
            decimal secondNumber = 0;

            Console.WriteLine("Please enter a number: ");
            string? firstNumberInput = tryForStringAsDecimal();

            firstNumber = WaitUntilValidDecimal(firstNumberInput, tryForStringAsDecimal);

            Console.WriteLine("Please enter another number: ");
            string? secondNumberInput = tryForStringAsDecimal();
            secondNumber = WaitUntilValidDecimal(secondNumberInput, tryForStringAsDecimal);

            var add = firstNumber + secondNumber;
            Console.WriteLine($"Your total is {add}");

            return add;
            
        }

        private static decimal WaitUntilValidDecimal(string? inputValue, AddTwoNumbersDelegate possibleDecimal)
        {
            bool isSuccess = false;
            decimal firstNumber = 0;
 
            while (!isSuccess)
            {
                isSuccess = decimal.TryParse(inputValue, out firstNumber);
                if (isSuccess)
                    break;
                Console.WriteLine("Please enter a VALID number: ");
                inputValue = possibleDecimal();
            }
            return firstNumber;
        }
    }
}
