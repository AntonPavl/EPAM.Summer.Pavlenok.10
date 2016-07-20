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

        private List<T> elements;
        public Set()
        {
            elements = new List<T>();
        }
        public Set(IEnumerable<T> other)
        {
            elements = new List<T>();
            foreach (var item in other)
            {
                elements.Add(item);
            }
        }
        public int Count
        {
            get
            {
                return elements.Count;
            }
        }

        public bool Add(T item)
        {
            bool ret = elements.Contains(item);
            if (!ret)
                elements.Add(item);
            return ret;
        }

        public void Clear()
        {
            elements.Clear();
        }

        public bool Contains(T item)
        {
            return elements.Contains(item);
        }

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

        public bool Remove(T item)
        {
            return elements.Remove(item);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            var temp = elements;
            elements = elements.Except(other).Union(other.Except(temp)).ToList();
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
