using System;
using NUnit.Framework;
using FibonachiDLL;
using System.Diagnostics;

namespace FibonachiNTest
{
    [TestFixture]
    public class FibonachiTest
    {
        [Test]
        public void Evaluate()
        {

            Debug.WriteLine(Fibonachi.Evaluate(5));
            Debug.Write(Fibonachi.GetFibonachiNumber(8));
        }
    }
}