// See https://aka.ms/new-console-template for more information

using CourseraAlgorithmicToolbox.Week1;
using static CourseraAlgorithmicToolbox.Week1.AddTwoNumbers;

Console.WriteLine("Begin Program");



AddTwoNumbersDelegate tryForStringAsDecimal = () => Console.ReadLine();

AddTwoNumbers.AddTwoNumbersFunc(tryForStringAsDecimal);   
