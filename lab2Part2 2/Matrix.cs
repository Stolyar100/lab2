using System;
using System.Security.Cryptography.X509Certificates;

namespace lab2.Part2
{
    public class Matrix
    {
        private int rows;
        private int columns;
        private double[,] matrix;
        

        public int Rows => rows;
        public int Columns => columns;

        public double[,] MatrixValue
        {
            get => matrix;
            set => matrix = value;
            
        }

        public int[] getSaddlePoint()
        {
            int[] saddlePoint = new int[2];
            saddlePoint[0] = -1;
            saddlePoint[1] = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, j + 1] && matrix[i, j] > matrix[i, j - 1] &&
                        matrix[i, j] < matrix[i - 1, j] && matrix[i, j] < matrix[i + 1, j])
                    {
                        saddlePoint[0] = i;
                        saddlePoint[1] = j;
                        return saddlePoint;
                    }
                }
            }
            return saddlePoint;
        }

        public Matrix(int rowsAmount, int columnsAmount, double value = 0)
        {
            matrix = new double[rowsAmount, columnsAmount];
            rows = rowsAmount;
            columns = columnsAmount;
            Random r = new Random();
            int range = 99;

            if (value == 0)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = r.NextDouble()* range;
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = value;
                    }
                }   
            }
        }
        
        public Matrix(int rowsAmount, int columnsAmount, Matrix clonedMatrix)
        {
            matrix = new double[rowsAmount, columnsAmount];
            rows = rowsAmount;
            columns = columnsAmount;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i > clonedMatrix.MatrixValue.GetLength(0) - 1) && (j > clonedMatrix.MatrixValue.GetLength(1) - 1))
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = clonedMatrix.MatrixValue[i, j];
                    }
                }
            }
        }
        
        public Matrix(int rowsAmount, int columnsAmount, int startRow, int startColumn, int endRow, int endColumn)
        {    
            Random r = new Random();
            int range = 99;
            
            matrix = new double[rowsAmount, columnsAmount];
            rows = rowsAmount;
            columns = columnsAmount;

            for (int i = 0; i < rowsAmount; i++)
            {
                for (int j = 0; j < columnsAmount; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            
            for (int i = startRow; i < endRow + 1; i++)
            {
                
                for (int j = startColumn; j < endColumn + 1; j++)
                {
                    matrix[i, j] = r.NextDouble()* range;
                }
            }
        }
    }
}