using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class TestGenericList
    {
        [TestMethod]
        public void AutoGrowTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            int actual = intlist.Capacity;
            int expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            string actual = intlist.ToStringForTesting();
            string expected = "1 2 3 4 ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveOneTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            intlist.Remove(2);
            string actual = intlist.ToStringForTesting();
            string expected = "1 2 4 ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTwoTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            intlist.Remove(2);
            intlist.Remove(2);
            string actual = intlist.ToStringForTesting();
            string expected = "1 2 ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_DownbTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            intlist.Remove(0);
            string actual = intlist.ToStringForTesting();
            string expected = "2 3 4 ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_UpbTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            intlist.Remove(3);
            string actual = intlist.ToStringForTesting();
            string expected = "1 2 3 ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            intlist.Insert(5, 1);
            string actual = intlist.ToStringForTesting();
            string expected = "1 5 2 3 4 ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_DownbTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            intlist.Insert(5, 0);
            string actual = intlist.ToStringForTesting();
            string expected = "5 1 2 3 4 ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_UpbTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            intlist.Insert(5, 3);
            string actual = intlist.ToStringForTesting();
            string expected = "1 2 3 5 4 ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MaxTest()
        {
            GenericList<int> intlist = new GenericList<int>(2);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            int index_max=intlist.Max<int>();
            int actual = intlist[index_max];
            int expected = 4;
            Assert.AreEqual(expected, actual);
        }

        




    }
}
