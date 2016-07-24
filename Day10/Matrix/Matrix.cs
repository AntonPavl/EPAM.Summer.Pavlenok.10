using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public class Matrix<T> : IMatrix<T>,IEquatable<Matrix<T>>,IEnumerable<T>
    {
        public event EventHandler Events = delegate { };
        private T[][] elements;
        private int size;
        private int? trigerA = null;
        private int? trigerB = null;

        public Matrix(int size)
        {
            this.size = size;
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
        /// <param name="b">column index</param>
        /// <returns></returns>
        public T GetElement(int a, int b)
        {
            return elements[a][b];
        }
        /// <summary>
        /// Set value to a,b index
        /// </summary>
        /// <param name="value"></param>
        /// <param name="a">string index</param>
        /// <param name="b">column index</param>
        public void SetElement(T value, int a, int b)
        {
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
        /// <param name="b">twoDimsension index</param>
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

        public bool Equals(Matrix<T> other)
        {
            return ReferenceEquals(this, other);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var oneDim in elements)
            {
                foreach (var twoDim in oneDim)
                {
                    yield return twoDim;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        /// <summary>
        /// Matrix transposition
        /// </summary>
        /// <returns></returns>
        public Matrix<T> Transposition()
        {
            var ret = new Matrix<T>(size);
            int i = 0;
            foreach (var item in GetOneDimEnumerator())
            {
                ret.SetArray(i++, item);
            }
            return ret;
        }

        private void SetArray(int index,T[] array)
        {
            elements[index] = array;
        }

        private IEnumerable<T[]> GetOneDimEnumerator()
        {
            foreach (var oneDim in elements)
            {
                yield return oneDim;
            }
        }

    }
}
