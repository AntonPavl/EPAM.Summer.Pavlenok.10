using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public class SymmetricMatrix<T>: SquareMatrix<T>
    {
        public SymmetricMatrix(int size = 2)
        {
            array = new T[size*size];
            Size = size;
        }
        protected override void SetValue(int i, int j, T value)
        {
            array[i * Size + j] = value;
            array[j * Size + i] = value;
        }
    }
}
