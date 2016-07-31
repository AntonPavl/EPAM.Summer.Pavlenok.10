using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        public DiagonalMatrix(int size = 2)
        {
            array = new T[size];
        }
        public DiagonalMatrix(IEnumerable<T> collection)
        {
            double temp = Math.Sqrt(collection.Count());
            temp = temp - Math.Truncate(temp);
            if (temp > 0) throw new ArgumentException();
            Size = (int)temp * (int)temp;
            array = new T[Size];
            int index = 0;
            foreach (var item in collection)
            {
                array[index++] = item;
            }
        }
        protected override T GetValue(int i, int j)
        {
            return i == j ? array[i] : default(T);
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i != j) throw new ArgumentException();
            array[i] = value;
        }
    }
}
