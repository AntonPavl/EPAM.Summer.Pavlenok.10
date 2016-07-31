using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public class MatrixData<T> : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public T OldValue { get; set; }
        public T NewValue { get; set; }
    }

    public abstract class AbstractMatrix<T> : IEnumerable
    {
        protected T[] array;

        public event EventHandler<MatrixData<T>> ElementChangeEvent = delegate { };

        public int Size { get; protected set; }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                    throw new IndexOutOfRangeException();
                return GetValue(i, j);
            }
            set
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                    throw new IndexOutOfRangeException();

                var oldValue = GetValue(i, j);
                SetValue(i, j, value);
                OnElementChanged(new MatrixData<T>()
                {
                    Column = i,
                    Row = j,
                    OldValue = oldValue,
                    NewValue = value
                });
            }
        }

        protected virtual void OnElementChanged(MatrixData<T> arg)
        {
            ElementChangeEvent(this, arg);
        }

        protected abstract T GetValue(int i, int j);

        protected abstract void SetValue(int i, int j, T value);

        public void Accept(IOperationVisitor<T> visitor,AbstractMatrix<T> matrix)
        {
            if (this.Size != matrix.Size) throw new ArgumentException();
            visitor.Visit((dynamic)this, (dynamic)matrix);
        }

        public IEnumerator GetEnumerator() //Change 
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
}
