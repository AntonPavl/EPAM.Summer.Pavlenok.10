using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public class MatrixData : EventArgs
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public MatrixData(int a, int b)
        {
            A = a;
            B = b;
        }
    }
}
