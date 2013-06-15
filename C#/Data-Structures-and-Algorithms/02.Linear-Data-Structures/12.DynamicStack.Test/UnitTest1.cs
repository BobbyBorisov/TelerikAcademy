using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _12.DynamicStack.Test
{
    [TestClass]
    public class DynamicStackTest
    {
        [TestMethod]
        public void TestPush()
        {
            var dynamicStack = new DynamicStack<int>();
            var list = new List<object>();

            for (int i = 0; i < 1000; i++)
            {
                dynamicStack.Push(i);
                list.Add(i);
            }

            list.Reverse();
            var expected = list.ToArray();
            var actual = dynamicStack.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestPushNullValue()
        //{
        //    var dynamicStack = new DynamicStack<int>();
        //    dynamicStack.Push(null);
        //}

        [TestMethod]
        public void TestPop()
        {
            var dynamicStack = new DynamicStack<int>();
            var list = new List<object>();
            for (int i = 0; i < 1000; i++)
            {
                dynamicStack.Push(i);
                list.Add(i);
            }

            for (int i = 0; i < 50; i++)
            {
                dynamicStack.Pop();

            }
            list.RemoveRange(950, 50);
            list.Reverse();
            var expected = list.ToArray();
            var actual = dynamicStack.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestClear()
        {
            var dynamicStack = new DynamicStack<int>();

            for (int i = 0; i < 1000; i++)
            {
                dynamicStack.Push(i);

            }

            dynamicStack.Clear();
            Assert.AreEqual(0, dynamicStack.Count);
        }

        [TestMethod]
        public void TestContainsExistingValue()
        {
            var dynamicStack = new DynamicStack<int>();

            for (int i = 0; i < 1000; i++)
            {
                dynamicStack.Push(i);

            }

            var actual = dynamicStack.Contains(400);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestContainsNonExistingValue()
        {
            var dynamicStack = new DynamicStack<int>();

            for (int i = 0; i < 1000; i++)
            {
                dynamicStack.Push(i);

            }

            var actual = dynamicStack.Contains(1002);
            Assert.IsFalse(actual);
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestContainsNullValue()
        //{
        //    var dynamicStack = new DynamicStack<int>();

        //    dynamicStack.Contains(null);   
        //}

    }
}
