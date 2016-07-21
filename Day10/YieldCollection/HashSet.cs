using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldCollection
{
    public class HashSet<T> :IEnumerable<T>,IEquatable<T> where T : class
    {
        private Hashtable elements;  
        /// <summary>
        /// create the Set
        /// </summary>
        //public Hashtable Elements { get { return elements; }}

        public HashSet()
        {
            elements = new Hashtable();
        }
        public HashSet(IEnumerable<T> other)
        {
            elements = new Hashtable();
            if (!ReferenceEquals(other, null))
            {
                foreach (var item in other.Distinct())
                {
                    elements.Add(item.GetHashCode(), item);
                }
            }
        }
        /// <summary>
        /// Get amount of elements
        /// </summary>
        public int Count
        {
            get
            {
                return elements.Count;
            }
        }

        /// <summary>
        /// Add item in Set
        /// </summary>
        /// <param name="item">item</param>
        /// <returns></returns>
        public bool Add(T item)
        {
            if (ReferenceEquals(item, null)) throw new ArgumentNullException();
            bool ret = elements.Contains(item.GetHashCode());
            if (!ret) elements.Add(item.GetHashCode(), item);
            return ret;
        }

        /// <summary>
        /// clear all elements in set
        /// </summary>
        public void Clear()
        {
            elements.Clear();
        }
        /// <summary>
        /// check item occurrence in the set
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool Contains(T item)
        {
            return elements.Contains(item.GetHashCode());
        }
        /// <summary>
        /// copies the entire set to an array, startinr at the specified index of target array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException();
            elements.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(HashSet<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException();
            foreach (DictionaryEntry item in other.elements)
            {
                if (elements.ContainsKey(item.Key))
                    elements.Remove(item.Key);
            }
        }
        private Hashtable GetHashTable()
        {
            return new Hashtable(elements);
        }
        public void IntersectWith(HashSet<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException();
            Hashtable part1 = GetHashTable();
            foreach (DictionaryEntry item in elements)
            {
                if (!other.elements.Contains(item.Key)) part1.Remove(item.Key);
            }
            elements = part1;
        }
        public void SymmetricExceptWith(HashSet<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException();
            Hashtable part1 = GetHashTable();
            Hashtable part2 = other.GetHashTable();
            foreach (DictionaryEntry item in elements)
            {
                if (other.elements.Contains(item.Key)) part1.Remove(item.Key);
            }
            foreach (DictionaryEntry item in other.elements)
            {
                if (elements.Contains(item.Key)) part2.Remove(item.Key);
            }
            elements = part1;
            foreach (DictionaryEntry item in part2)
            {
                elements.Add(item.Key, item.Value);
            }
        }

        public void UnionWith(HashSet<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException();
            foreach (DictionaryEntry item in other.elements)
            {
                if (!elements.ContainsKey(item.Key))
                    elements.Add(item.Key,item.Value);
            }
        }


        /// <summary>
        /// Remove item from set
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Remove(T item)
        {
            if (ReferenceEquals(item, null)) throw new ArgumentNullException();
            elements.Remove(item.GetHashCode());
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var e in elements.Values)
            {
                yield return (dynamic)e;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Equals(T other)
        {
            return base.Equals(other);
        }
    }
}
