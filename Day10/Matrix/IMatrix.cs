using Matrixs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public interface IMatrix<T>
    {
        void SetElement(T value, int a, int b);
        T GetElement(int a, int b);
        void Transposition();
        void Accept(IOperationVisitor<T> visitor, IMatrix<T> matr);
    }
}
