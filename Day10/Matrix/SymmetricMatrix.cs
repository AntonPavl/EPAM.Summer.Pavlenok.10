using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public class SymmetricMatrix<T>: SquareMatrix<T>
    {
        private int demiSize;
        public SymmetricMatrix(int size = 2)
        {
            Size = size;
            for (int i = 1; i <= size; i++)
            {
                demiSize += i;
            }
            array = new T[demiSize];
        }
        protected override void SetValue(int i, int j, T value)
        {
            //hmm
        }

        protected override T GetValue(int i, int j)
        {
            //hmm
            return array[0];
        }
    }
}
