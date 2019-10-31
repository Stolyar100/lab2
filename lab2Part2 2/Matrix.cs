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

        public double[,] Matrix1
        {
            get => matrix;
            set => matrix = value;
        }

        public int[] getSaddlePoint()
        {
            int[] saddlePoint = new int[2];

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
        }
        
    }
}