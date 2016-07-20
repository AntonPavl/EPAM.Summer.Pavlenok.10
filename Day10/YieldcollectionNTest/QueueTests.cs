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
        public void QueueTest()
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

            bool res = true;
            int index = 0;
            foreach ( var e in queue)
            {
                if (array[index] != e) res = false;
                index++;
            }
            Assert.AreEqual(res, true);
        }
    }
}