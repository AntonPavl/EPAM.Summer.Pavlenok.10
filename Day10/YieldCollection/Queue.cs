using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldCollection
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] stringsArray;
        private int memorySize = 4;
        private int head = 0;
        private int tail = -1;
        private int elemCount = 0;
        /// <summary>
        /// create the queue
        /// </summary>
        public Queue()
        {
            stringsArray = new T[memorySize];
        }
        /// <summary>
        /// create the queue from collection
        /// </summary>
        /// <param name="collection"></param>
        public Queue(IEnumerable<T> collection)
        {
            stringsArray = new T[memorySize];
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }
        private void AllocateMemory()
        {
            var oldMemory = memorySize;
            var newArray = new T[memorySize * 2];
            memorySize *= 2;
            var i = 0;
            if (elemCount > 0)
            {
                do
                {
                    newArray[i] = stringsArray[head];
                    i++;
                    head++;
                    if (head == oldMemory)
                    {
                        head = 0;
                    }
                } while (head != tail);
            }
            stringsArray = newArray;
            tail = oldMemory;
            head = 0;
        }
        /// <summary>
        /// Pop first element in queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (elemCount == 0)
            {
                throw new InvalidOperationException("The Queue is empty.");
            }
            var ret = stringsArray[head];
            stringsArray[head++] = default(T);
            elemCount--;
            if (head == memorySize)
            {
                head = 0;
            }
            return ret;
        }
        /// <summary>
        /// Push element to last position
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            tail++;
            if (tail == memorySize)
            {
                tail = 0;
            }
            if (elemCount == memorySize)
            {
                AllocateMemory();
            }
            stringsArray[tail] = item;
            elemCount++;
        }
        /// <summary>
        /// Get first element
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (elemCount == 0) throw new InvalidOperationException();
            return stringsArray[head];
        }

        public Iterator GetEnumerator() =>
            new Iterator(stringsArray,head,tail,elemCount);

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() =>
            this.GetEnumerator();

        public struct Iterator  : IEnumerator<T>
        {
            private readonly T[] collection;
            private readonly int head;
            private readonly int tail;
            private int elemcount;
            private int currentIndex;

            public Iterator(T[] collection,int head,int tail,int elemcount)
            {
                this.currentIndex = head-1;
                this.head = head;
                this.tail = tail;
                this.elemcount = elemcount;
                this.collection = collection;
            }

            public T Current
            {
                get
                {
                    return collection[currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public void Reset()
            {
                currentIndex = head;
            }

            public bool MoveNext()
            {
                currentIndex++;
                if (currentIndex == collection.Length)
                {
                    currentIndex = 0;
                }
                return --elemcount >= 0;
            }

            public void Dispose()
            {

            }
        }
    }
}
