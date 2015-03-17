using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    public class Matrix<T>:IEnumerable<T>//, IComparable<T>
    {
        private T[,] items;
        private int rows;
        private int cols;
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    yield return this.items[Rows, Cols];
                }            
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.items = new T[this.Rows, this.Cols];
        }
        public int Rows
        {
            get { return this.rows; }
            private set { this.rows = value; }
        }
        public int Cols
        {
            get { return this.cols; }
            private set { this.cols = value; }
        }
        public T this [int row, int col]
        {
            get 
            {
                if ((row >= 0 && row <= this.Rows - 1) &&(col >= 0 && col <= this.Cols - 1)) 
                {
                    return this.items[row, col];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if ((row >= 0 && row <= this.Rows - 1) &&(col >= 0 && col <= this.Cols - 1)) 
                {
                    this.items[row, col] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public static Matrix<T> operator + (Matrix<T> M1, Matrix<T> M2)
        {
            if (M1.Rows == M2.Rows && M1.Cols == M2.cols)
            {
                Matrix<T> M3 = new Matrix<T>(M1.Rows, M2.cols);
                for (int i = 0; i < M1.Rows; i++)
                {
                    for (int j = 0; j < M1.Cols; j++)
                    {
                        M3[i, j] = (dynamic)M1[i, j] + (dynamic)M2[i, j];
                    }
                }
                return M3;
            }
            else
            {
                throw new IndexOutOfRangeException("rows and cols of the both matrices have to be equal");
            }
        }
        public static Matrix<T> operator - (Matrix<T> M1, Matrix<T> M2)
        {
            if (M1.Rows == M2.Rows && M1.Cols == M2.cols)
            {
                Matrix<T> M3 = new Matrix<T>(M1.Rows, M2.cols);
                for (int i = 0; i < M1.Rows; i++)
                {
                    for (int j = 0; j < M1.Cols; j++)
                    {
                        M3[i, j] = (dynamic)M1[i, j] - (dynamic)M2[i, j];
                    }
                }
                return M3;
            }
            else
            {
                throw new IndexOutOfRangeException("rows and cols of the both matrices have to be equal");
            }
        }
        public static Matrix<T> operator * (Matrix<T> M1, Matrix<T> M2)
        {
            if (M1.Rows == M2.Cols && M1.Rows == M2.cols)
            {
                Matrix<T> M3 = new Matrix<T>(M1.Rows, M2.cols);
                for (int i = 0; i < M3.Rows; i++)
                {
                    for (int j = 0; j < M3.Cols; j++)
                    {
                        for (int k = 0; k < M1.Rows; k++)
                        {
                            M3[i, j] += (dynamic)M1[i, k] * M2[k, j];
                        }
                    }
                }
                return M3;
            }
            else
            {
                throw new IndexOutOfRangeException("rows of the one matrix has to be equal to the cols of the other");
            }
        }
        public static bool operator true(Matrix<T> M)
        {
            return BooleanOperator(M, true);
        }
        public static bool operator false(Matrix<T> M)
        {
            return BooleanOperator(M, false);
        }
        private static bool BooleanOperator(Matrix<T> M, bool trueFalse)
        {
            foreach (var element in M.items)
            {
                if (!element.Equals(default(T)))
                {
                    return trueFalse;
                }
            }
            return !trueFalse;
        }
    }
}
