using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_II_from_8_to_10_
{
    public class Matrix<T>
    {
        T[,] matrix;
        public int Rows { get; private set; }
        public int Cols { get; private set; }


        public Matrix(int capacity) {
            matrix = new T[capacity,capacity];
            Cols = Rows = capacity;
        }

        public Matrix(int rows, int cols) {
            matrix = new T[rows, cols];
            Rows = rows;
            Cols = cols;
        }

        public T this[int row, int col] {
            get {
                if((row<0 || row>=Rows) || (col<0 || col>=Cols))
                    throw new ArgumentException(String.Format("Indexes for row={0} and col={1} does not exist", row,col));
                return this.matrix[row, col];
            }
            set {
                if ((row < 0 || row >= Rows) || (col < 0 || col >= Cols))
                    throw new ArgumentException(String.Format("Indexes for row={0} and col={1} does not exist", row, col));
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        
        {

            Matrix<T> NewMatrix = new Matrix<T>(m1.Cols);

            for (int row = 0; row <m1.Cols; row++)
            {               
                for (int col = 0; col < m1.Cols; col++)
                {
                    NewMatrix[row, col] = (dynamic)m1[row, col] + m2[row, col];
                }
               
            }
            return NewMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {

            Matrix<T> NewMatrix = new Matrix<T>(m1.Cols);

            for (int row = 0; row < m1.Cols; row++)
            {
                for (int col = 0; col < m1.Cols; col++)
                {
                    NewMatrix[row, col] = (dynamic)m1[row, col] - m2[row, col];
                }

            }
            return NewMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> NewMatrix = new Matrix<T>(m1.Rows,m2.Cols);
            T[] value = new T[m2.Cols+2];            
            int counter = 0;

            if ((m1.Rows != m2.Cols) || (m1.Cols != m2.Rows))
                throw new ArgumentException("row of first matrix should be equal to col of second, same for col of first and row of second");
            
            for (int row = 0; row < m1.Rows; row++)
            {
               
                for (int col = 0; col < m2.Cols; col++) {
                    
                    for (int k = 0; k < m2.Rows; k++) 
                    {
                         value[counter]+= (dynamic)m1[row, k] * m2[k, col];
                       }
                     NewMatrix[row,col] = value[counter];
                     counter++;
                 }
            }
            return NewMatrix;
        }

        public static bool operator true(Matrix<T> m1)
        {

            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Cols; col++)
                {
                    if (!(object.Equals(m1[row, col], default(T))))
                        return false;
                }
            }
            return true;
        }

        public static bool operator false(Matrix<T> m1)
        {

            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Cols; col++)
                {
                    if (!(object.Equals(m1[row, col], default(T))))
                        return false;
                }
            }
            return true;
        }
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++) {
                sb.Append("(");
                for (int col = 0; col < matrix.GetLength(1); col++) {
                    sb.Append(matrix[row,col]);
                }
                sb.Append(")");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public string ToStringForTesting() {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]+" ");
                }
            }
            return sb.ToString();
        }
    }

  public class MatrixTest {


        public static Matrix<T> CreateMatrix<T>(int rows, int cols,T number) {
           
            Matrix<T> matrix = new Matrix<T>(rows, cols);
           
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    matrix[row, col] = number;
                }
            }
          return matrix;
        }

        public static Matrix<T> CreateParamMatrix<T>(int rows, int cols,params T[] values)
        {

            Matrix<T> matrix = new Matrix<T>(rows, cols);
            int index=0;

            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    matrix[row, col] = values[index];
                    index++;
                }
            }

            return matrix;
        }
             
        static void Main() {

            var matrix_new = MatrixTest.CreateMatrix<int>(4, 4, 2);
            Console.WriteLine("create and auto initiliazied matrix \n{0}",matrix_new.ToString());


            var matrix_params = MatrixTest.CreateParamMatrix<int>(3,3,1,2,3,4,5,6,7,8,9);
            Console.WriteLine("create and auto param initiliazied matrix\n{0}",matrix_params.ToString());

            var matrix_1 = MatrixTest.CreateParamMatrix<int>(2, 4, 1, 2, 3, 8, 4, 5, 6, 8);
            Console.WriteLine(matrix_1.ToString());

            var matrix_2 = MatrixTest.CreateParamMatrix<int>(4, 2, 7, 8, 9, 10, 11, 12, 13, 14);          
            Console.WriteLine(matrix_2.ToString());

            Matrix<int> multi_result = matrix_1 * matrix_2;
            Console.WriteLine(multi_result.ToStringForTesting());

            Matrix<int> null_matrix = new Matrix<int>(3, 3);
            null_matrix[2, 2] = 2;
            if (null_matrix)
            {
                Console.WriteLine("only zeros");
            }
            else
            {
                Console.WriteLine("non-only zeros");
            }
            Console.WriteLine(null_matrix.ToString());           
        }
    }
}
