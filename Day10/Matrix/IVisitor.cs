using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public interface IOperationVisitor<T>
    {
        void Visit(SquareMatrix<T> mat,AbstractMatrix<T> mat2);
        void Visit(SymmetricMatrix<T> mat, DiagonalMatrix<T> mat2);
        void Visit(DiagonalMatrix<T> mat, DiagonalMatrix<T> mat2);
    }
}
