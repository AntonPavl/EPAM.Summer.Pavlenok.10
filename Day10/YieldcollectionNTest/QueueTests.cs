using System;
using NUnit.Framework;
using YieldCollection;
using System.Diagnostics;

namespace YieldcollectionNTest
{
    [TestFixture]
    public class QueueTests
    {

        [Test]
        public void QueueTest_foreach_test()
        {
            var queue = new Queue<int>();
            var array = new int[30];
            Random rand = new Random();
            for (int i = 0; i < 30; i++)
            {
                int temp = rand.Next(100);
                queue.Enqueue(temp);
                array[i] = temp; 
            }
            int index = -1;
            foreach ( var e in queue)
            {
                Assert.AreEqual(array[++index], e);
            }
        }

        [Test]
        public void QueueTest_Dequeue_Enqueue_Test()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Enqueue(3);
            Assert.AreEqual(queue.Dequeue(), 2);
            Assert.AreEqual(queue.Dequeue(), 3);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void QueueTest_Dequeue_exception()
        {
            Queue<int> q = new Queue<int>();
            q.Dequeue();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void QueueTest_Peek_exception()
        {
            Queue<int> q = new Queue<int>();
            q.Peek();
        }

        [Test]
        public void QueueTest_EnqueueStringFromAnotherStringcllection()
        {
            string[] temp = { "1", "2", "3", "4" };
            Queue<string> q = new Queue<string>(temp);
            int index = -1;
            foreach (var item in q)
            {
                Assert.AreEqual(item, temp[++index]);
            }
        }

    }
}