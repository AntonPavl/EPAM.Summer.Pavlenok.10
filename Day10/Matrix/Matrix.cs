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
        public event EventHandler<MatrixData> Events = delegate { };
        private T[][] elements;
        private int? trigerA = null;
        private int? trigerB = null;
        public int Size { get;private set; }
        public Matrix(int size)
        {
            if (size<1) throw new ArgumentException();
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
        /// <param name="b">column index</param>
        /// <returns></returns>
        public T GetElement(int a, int b)
        {
            if (a > elements.Length || b > elements.Length) throw new ArgumentException();
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
            if (a > elements.Length || b > elements.Length) throw new ArgumentException();
            elements[a][b] = value;
            if (a == trigerA && b == trigerB) Sender();
        }
        protected virtual void Sender()
        {
            EventHandler<MatrixData> temp = Events;
            if (temp != null)
            {
                temp(this, new MatrixData((int)trigerA,(int)trigerB));
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
        public void Transposition()
        {

        }

        private void SetArray(int index,T[] array)
        {
            elements[index] = array;
        }

        public void Accept(IOperationVisitor<T> visitor, IMatrix<T> matr)
        {
            visitor.Visit(this,(dynamic)matr);
        }
    }
}
