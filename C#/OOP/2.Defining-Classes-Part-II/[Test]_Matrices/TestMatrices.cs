using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_II_from_8_to_10_;

namespace Testing_matrices
{
    [TestClass]
    public class TestMatrices
    {
        [TestMethod]
        public void AddingTest()
        {
            var matrix = MatrixTest.CreateMatrix<int>(2, 2, 2);
            var matrix_1 = MatrixTest.CreateMatrix<int>(2, 2, 2);
            var result_matrix = matrix + matrix_1;
            string actual = result_matrix.ToStringForTesting();
            string expected = "4 4 4 4 ";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractingTest()
        {
            var matrix = MatrixTest.CreateMatrix<int>(2, 2, 2);
            var matrix_1 = MatrixTest.CreateMatrix<int>(2, 2, 2);
            var result_matrix = matrix - matrix_1;
            string actual = result_matrix.ToStringForTesting();
            string expected = "0 0 0 0 ";
        
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyingTest() {
            var matrix_1 = MatrixTest.CreateParamMatrix<int>(2,3,1,2,3,4,5,6);
            var matrix_2 = MatrixTest.CreateParamMatrix<int>(3,2,7,8,9,10,11,12);
           
            Matrix<int> multi_result = matrix_1 * matrix_2;
            string actual = multi_result.ToStringForTesting();
            string expected = "58 64 139 154 ";

            Assert.AreEqual(expected, actual);
        }
    }
}
