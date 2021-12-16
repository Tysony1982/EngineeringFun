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
    public class LinkedListTests
    {
        [Test]
        public void CheckAddFrontWhenFirstElementEqualsLastElement()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddFront(1);
            Assert.IsTrue(list?.Head?.Value.Equals(1));
            Assert.IsTrue(list?.Tail?.Value == null);
            
        }
        [Test]
        public void CheckAddBackWhenFirstElementEqualsLastElement()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddBack(1);
            Assert.IsTrue(list?.Head?.Value.Equals(1));
            Assert.AreEqual(list?.Tail, null);
        }

        [Test]
        public void CheckListOrderRemainsAfterAddingToFront()
        {
            MyLinkedList<int> list = GetSequentialIntsByAddFront();

            var arr = list.ToArray();
            Assert.AreEqual(list.Count(), arr.Length);
            
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i].Equals(i));
            }
        }

        [Test]
        public void CheckListOrderRemainsAfterAddingToFrontAndThenBack()
        {
            MyLinkedList<int> list = GetSequentialIntsByAddFront();
            list.AddBack(5);
            list.AddBack(6);
            var arr = list.ToArray();
            Assert.AreEqual(7, arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i].Equals(i));
            }
        }

        [Test]
        public void CheckListOrderRemainsAfterAddingToBackThenFront()
        {
            MyLinkedList<int> list = GetSequentialIntsByAddBackAndAddFront();
            var arr = list.ToArray();
            Assert.AreEqual(7, arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i].Equals(i));
            }
        }

        [Test]
        public void CheckIndexGetTest()
        {
            var list = GetSequentialIntsByAddBackAndAddFront();
            var fifthElement = list[5];
            Assert.AreEqual(5, fifthElement);
        }


        [Test]
        public void SetIndexElementTest()
        {
            var list = GetSequentialIntsByAddBackAndAddFront();
            var previousCount = list.Count();
            var newValue = 2000;
            list[5] = newValue;
            var fifthElement = list[5];
            Assert.AreEqual(newValue, fifthElement);
            Assert.IsTrue(list.Count() == previousCount + 1);
        }
        [Test]
        public void AssertExceptionForIndexOutOfRangeTest()
        {
            var list = GetSequentialIntsByAddBackAndAddFront();
            bool hasArgumentOutOfRangeException = false; 

            try
            {
                var what = list[5000];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                hasArgumentOutOfRangeException = true;
            }
            finally
            {
                Assert.IsTrue(hasArgumentOutOfRangeException);
            }
        }

        


        private MyLinkedList<int> GetSequentialIntsByAddBackAndAddFront()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddBack(5);
            list.AddBack(6);
            list.AddFront(4);
            list.AddFront(3);
            list.AddFront(2);
            list.AddFront(1);
            list.AddFront(0);
            return list;
        }

        private MyLinkedList<int> GetSequentialIntsByAddFront()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddFront(4);
            list.AddFront(3);
            list.AddFront(2);
            list.AddFront(1);
            list.AddFront(0);
            return list;
        }
    }
}
