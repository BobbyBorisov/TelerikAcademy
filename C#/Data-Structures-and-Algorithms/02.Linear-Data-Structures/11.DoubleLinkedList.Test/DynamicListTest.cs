using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _11.DynamicDoubleLinkedList;

namespace _11.DoubleLinkedList.Test
{
    [TestClass]
    public class DynamicListTest
    {
        [TestMethod]
        public void Add_AddOneNumber()
        {
            var list = new DynamicDoubleLinkedList<int>();
            list.Add(6);

            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void Add_AddFiveNumbers()
        {
            var list = new DynamicDoubleLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(6);
            }

            Assert.IsTrue(list.Count == 5);
        }

        [TestMethod]
        public void RemoveByIndex_RemoveNumberInTheMiddle()
        {
            var list = new DynamicDoubleLinkedList<int>();

            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int actual = list.RemoveByIndex(3);
            Assert.AreEqual(3, actual);
            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod]
        public void RemoveByIndex_RemoveNumberInTheBegining()
        {
            var list = new DynamicDoubleLinkedList<int>();

            list.Add(10);
            list.Add(11);
            list.Add(12);
            list.Add(13);
            list.Add(14);

            int actual = list.RemoveByIndex(0);
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod]
        public void RemoveByIndex_RemoveHeadAndTail()
        {
            var list = new DynamicDoubleLinkedList<int>();

            list.Add(10);

            int actual = list.RemoveByIndex(0);
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void RemoveByIndex_RemoveHead()
        {
            var list = new DynamicDoubleLinkedList<int>();

            list.Add(10);
            list.Add(11);

            int actual = list.RemoveByIndex(0);
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void Remove_RemoveHead()
        {
            var list = new DynamicDoubleLinkedList<int>();

            list.Add(10);
            list.Add(11);

            int actual = list.RemoveByIndex(0);
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void Remove_RemoveHeadAndLeaveEmptyList()
        {
            var list = new DynamicDoubleLinkedList<int>();

            list.Add(10);


            int actual = list.RemoveByIndex(0);
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 0);
        }

        

        [TestMethod]
        public void Insert_InsertInTheMiddle()
        {
            var list = new DynamicDoubleLinkedList<int>();

            list.Add(10);
            list.Add(11);

            list.Insert(1, 1);

            Assert.IsTrue(list.Count == 3);
        }
    }
}
