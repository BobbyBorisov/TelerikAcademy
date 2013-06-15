using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace _14.Labyrinth.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[,] inputField = new string[6, 6]
            {
                { "0", "0", "0", "x", "0", "x"},
                { "0", "x", "0", "x", "0", "x"},
                { "0", "*", "x", "0", "x", "0"},
                { "0", "x", "0", "0", "0", "0"},
                { "0", "0", "0", "x", "x", "0"},
                { "0", "0", "0", "x", "0", "x"},
            };

            string[,] expectedResult = 
            {
                { "3", "4", "5", "x", "u", "x"},
                { "2", "x", "6", "x", "u", "x"},
                { "1", "*", "x", "8", "x", "10"},
                { "2", "x", "6", "7", "8", "9"},
                { "3", "4", "5", "x", "x", "10"},
                { "4", "5", "6", "x", "u", "x"},
            };

            var expected = GetMatrixProfile(expectedResult);
            var matrix = LabyrinthWalk.Walk(inputField);
            var actual = GetMatrixProfile(matrix);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string[,] inputField = new string[6, 6]
            {
                 { "0", "0", "0", "0", "0", "0"},
                  { "0", "0", "0", "0", "0", "0"},
                  { "0", "0", "*", "0", "0", "0"},
                  { "0", "0", "0", "0", "0", "0"},
                  { "0", "0", "0", "0", "0", "0"},
                 { "0", "0", "0", "0", "0", "0"},
            };

            string[,] expectedResult = 
            {
                 { "4", "3", "2", "3", "4", "5"},
                 { "3", "2", "1", "2", "3", "4"},
                 { "2", "1", "*", "1", "2", "3"},
                 { "3", "2", "1", "2", "3", "4"}, 
                 { "4", "3", "2", "3", "4", "5"},
                 { "5", "4", "3", "4", "5", "6"},
            };


            string[,] actualResult = LabyrinthWalk.Walk(inputField);

            string expected = GetMatrixProfile(expectedResult);
            string actual = GetMatrixProfile(actualResult);

            Assert.AreEqual(expected, actual);
        }

        private string GetMatrixProfile(string[,] matrix)
        {
            var sb = new StringBuilder();
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sb.Append(matrix[row, col]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
