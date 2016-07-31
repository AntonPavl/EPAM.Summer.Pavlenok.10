using System;
using NUnit.Framework;
using Matrixs;
using System.Diagnostics;

namespace MatrixNTests
{
    [TestFixture]
    public class DiagonalMatrixTests
    {
        [Test]
        public void TestMethod1()
        {
            SymmetricMatrix<int> SM1 = new SymmetricMatrix<int>(3);
            Debug.WriteLine(SM1.Size);
        }
    }
}