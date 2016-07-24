using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public class DiagonalMatrix<T> : IMatrix<T>, IEquatable<DiagonalMatrix<T>>, IEnumerable<T>
    {
        public event EventHandler Events = delegate { };
        private T[][] elements;
        private int? trigerA = null;
        private int? trigerB = null;
        public int Size { get;private set; }
        public DiagonalMatrix(int size)
        {
            if (size < 1) throw new ArgumentException();
            this.Size = size;
            elements = new T[size][];
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = new T[size];
            }
        }

        /// <summary>
        /// Get value from a,b index
        /// </summary>
        /// <param name="a">string index</param>
        /// <returns></returns>
        public T GetElement(int a,int b)
        {
            if (a > elements.Length || b> elements.Length) throw new ArgumentException();
            if (a != b) throw new ArgumentException();
            return elements[a][b];
        }
        /// <summary>
        /// Set value to a,b index
        /// </summary>
        /// <param name="value"></param>
        /// <param name="a">a index</param>
        public void SetElement(T value, int a,int b)
        {
            if (a > elements.Length || b>elements.Length) throw new ArgumentException();
            if (a!=b) throw new ArgumentException();
            elements[a][b] = value;
            if (a == trigerA && b == trigerB) Sender();
        }

        protected virtual void Sender()
        {
            EventHandler temp = Events;
            if (temp != null)
            {
                temp(this, null);
            }
        }
        /// <summary>
        /// Do event when element has been changed
        /// </summary>
        /// <param name="a">oneDimesion index</param>
        public void SetElementChangedTrigger(int a,int b)
        {
            trigerA = a;
            trigerB = b;
        }
        /// <summary>
        /// Remove eventchange trigger
        /// </summary>
        public void RemoveElementChangedTrigger()
        {
            trigerA = null;
            trigerB = null;
        }

        public bool Equals(DiagonalMatrix<T> other)
        {
            return ReferenceEquals(this, other);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                yield return elements[i][i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Transposition()
        {

        }
    }
}
