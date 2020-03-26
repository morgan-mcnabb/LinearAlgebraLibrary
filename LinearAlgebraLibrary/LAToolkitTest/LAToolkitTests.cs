using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebraLibrary;
namespace LAToolkitTest
{
    [TestClass]
    public class LAToolkitTests
    {
        [TestMethod]
        public void AddTest()
        {
            var matrix1 = new Matrix(2, 3);
            var matrix2 = new Matrix(3, 3);

            matrix1.Add(matrix2);
            Assert.IsFalse(matrix1.SameMatrixDimensions(matrix2));
        }

        [TestMethod]
        public void SubTest()
        {
            var matrix1 = new Matrix(3, 3);
            var matrix2 = new Matrix(3, 3);
            matrix1.Values[2, 1] = 6;
            matrix2.Values[2, 1] = 19;

            matrix1.Subtract(matrix2);
            Assert.AreEqual(-13, matrix1.Values[2, 1]);
        }
    }
}
