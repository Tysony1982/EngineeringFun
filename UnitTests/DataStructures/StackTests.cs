using CSharpDataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DataStructures
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void IsEmptyTest()
        {
            var stack = new MyStack<int>(1);
            var sut = stack.IsEmpty();
            Assert.IsTrue(sut);
            stack.Push(1);
            var sut2 = stack.IsEmpty();
            Assert.IsFalse(sut2);
        }

        [Test]
        public void PopTest()
        {
            var stack = new MyStack<int>(2);
            var expected = 4;
            stack.Push(expected);
            var sut = stack.Pop();
            Assert.AreEqual(expected, sut); 
        }
        [Test]
        public void PeekTest()
        {
            var stack = new MyStack<int>(3);
            var expected = 4;
            stack.Push(expected);
            var sut = stack.Peek();
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void PopExceptionTest()
        {
            var stack = new MyStack<int>(3);
            var didThrow = false;
            try
            {
                stack.Pop();
            }
            catch(ArgumentOutOfRangeException ex)
            {
                didThrow = true;    
            }
            finally
            {
                Assert.IsTrue(didThrow);
            }
            
        }

        [Test]
        public void PushExceptionTest()
        {
            var stack = new MyStack<int>(2);
            var didThrow = false;
            stack.Push(1);
            stack.Push(2);
            try
            {
                stack.Push(3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                didThrow= true;
            }
            finally
            {
                Assert.IsTrue(didThrow);
            }

        }

        [Test]
        public void MultiplePopsWithIsEmptyCheckAtEndTest()
        {
            var stack = new MyStack<int>(3);
            var ex1 = 1;
            var ex2 = 2;
            var ex3 = 3;
            var ex4 = true;
            stack.Push(ex1);
            stack.Push(ex2);
            stack.Push(ex3);
            var sut3 = stack.Pop();
            var sut2 = stack.Pop();
            var sut1 = stack.Pop();
            var sut4 = stack.IsEmpty();
            Assert.AreEqual(ex1, sut1);
            Assert.AreEqual(ex2, sut2);
            Assert.AreEqual(ex3, sut3);
            Assert.AreEqual(ex4, sut4);
        }
    }
}
