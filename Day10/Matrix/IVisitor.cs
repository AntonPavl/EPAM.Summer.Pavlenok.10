using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    public interface IOperationVisitor<T>
    {
        void Visit(Matrix<T> mat,Matrix<T> mat2);
        void Visit(Matrix<T> mat, SimmetrMatrix<T> mat2);
        void Visit(Matrix<T> mat, DiagonalMatrix<T> mat2);
        void Visit(SimmetrMatrix<T> mat, SimmetrMatrix<T> mat2);
        void Visit(SimmetrMatrix<T> mat, Matrix<T> mat2);
        void Visit(SimmetrMatrix<T> mat, DiagonalMatrix<T> mat2);
        void Visit(DiagonalMatrix<T> mat,DiagonalMatrix<T> mat2);
        void Visit(DiagonalMatrix<T> mat, SimmetrMatrix<T> mat2);
        void Visit(DiagonalMatrix<T> mat, Matrix<T> mat2);
    }
}
