using System;
using NUnit.Framework;
using Matrixs;
namespace MatrixNTests
{
    [TestFixture]
    public class DiagonalMatrixTests
    {
        [Test]
        public void TestMethod1()
        {
            DiagonalMatrix<int> dm = new DiagonalMatrix<int>(4);
            dm.SetElement(10, 2, 2);
            Matrix<int> m = new Matrix<int>(4);
            m.SetElement(10, 2, 2);
        }
    }
}