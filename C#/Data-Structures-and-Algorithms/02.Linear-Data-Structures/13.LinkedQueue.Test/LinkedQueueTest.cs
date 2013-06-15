using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _13.LinkedQueue.Test
{
    [TestClass]
    public class LinkedQueueTest
    {
        [TestMethod]
        public void Enqueue_AddSingleElement()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(1);

            Assert.IsTrue(queue.Count == 1);
        }

        [TestMethod]
        public void Enqueue_AddFiveElements()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.Enqueue(13);
            queue.Enqueue(14);

            Assert.IsTrue(queue.Count == 5);
        }

        [TestMethod]
        public void Denqueue_RemoveOfListWithSingleElement()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(123);
            int actual = queue.Dequeue();

            Assert.IsTrue(actual == 123);

            Assert.IsTrue(queue.Count == 0);
        }

        [TestMethod]
        public void Denqueue_RemoveFirstOfFiveElements()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.Enqueue(13);
            queue.Enqueue(14);

            int actual = queue.Dequeue();
            Assert.IsTrue(queue.Count == 4);
            Assert.IsTrue(actual == 10);
        }

        [TestMethod]
        public void Denqueue_PeekFirstOfFiveElements()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.Enqueue(13);
            queue.Enqueue(14);

            int actual = queue.Peek();
            Assert.IsTrue(queue.Count == 5);
            Assert.IsTrue(actual == 10);
        }
    }
}
