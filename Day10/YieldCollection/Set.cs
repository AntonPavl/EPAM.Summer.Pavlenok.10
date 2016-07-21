using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldCollection
{
    public class Set<T>: IEnumerable<T> where T : class
    {
        private List<T> elements;  //Do Array!!!
        /// <summary>
        /// create the Set
        /// </summary>
        public Set()
        {
            elements = new List<T>();
        }
        /// <summary>
        /// create the Set from another collection
        /// </summary>
        /// <param name="other"></param>
        public Set(IEnumerable<T> other)
        {
            elements = new List<T>();
            elements = other.Distinct().ToList();
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
            bool ret = elements.Contains(item);
            if (!ret)
                elements.Add(item);
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
            return elements.Contains(item);
        }
        /// <summary>
        /// copies the entire set to an array, startinr at the specified index of target array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            elements = elements.Except(other).ToList();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            elements = elements.Intersect(other).ToList();
        }
        /// <summary>
        /// Remove item from set
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            return elements.Remove(item);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            elements = elements.Except(other).Union(other.Except(elements)).ToList();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            elements = elements.Union(other).ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                yield return elements[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
