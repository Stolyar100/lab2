using System;
using System.Collections.Generic;


namespace lab2.Part2
{
    internal class Program
    {
        public static int enterIndex()
        {
            Console.WriteLine("Enter the choosen matrix index");
            return Int32.Parse(Console.ReadLine());
        }
        
        public static void seeMatrixlistCase(List<Matrix> matrixList)
        {
            foreach (Matrix tempMatrix in matrixList)
            {
                Console.WriteLine($"Index of object: {matrixList.IndexOf(tempMatrix)}");
            }
        }
        
        public static void addNewMatrixCase(List<Matrix> matrixList)
        {
            Console.WriteLine("Enter:{0}" +
                              "0 - to create matrix with manual size and random values;{0}" +
                              "1 - to create matrix with manual size and manual value;{0}" +
                              "3 - to create matrix with cloning values from another matrix;{0}" +
                              "4 - to create matrix with manual size and filing manual size;{0}" +
                              "6 - to cancel", Environment.NewLine);
            int newClockMenu = Int32.Parse(Console.ReadLine());
            
            switch (newClockMenu)
            {
                case 0:
                    Console.WriteLine("Enter the number of rows");
                    int rowsCase0 = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter the number of columns");
                    int columnsCase0 = Int32.Parse(Console.ReadLine());
                    matrixList.Add(new Matrix(rowsCase0,columnsCase0));
                    break;
                case 1:
                    Console.WriteLine("Enter the number of rows");
                    int rowsCase1 = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter the number of columns");
                    int columnsCase1 = Int32.Parse(Console.ReadLine());
                    int clonedIndex = enterIndex();
                    matrixList.Add(new Matrix(rowsCase1, columnsCase1, matrixList[clonedIndex]));
                    break;
                case 2:
                    Console.WriteLine("Enter the number of rows");
                    int rowsCase2 = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter the number of columns");
                    int columnsCase2 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the start row's index of submatrix");
                    int startRow = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter the end row's index of submatrix");
                    int endRow = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the start column's index of submatrix");
                    int startColumn = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter the end columns's index of submatrix");
                    int endColumn = Int32.Parse(Console.ReadLine());
                    matrixList.Add(new Matrix(rowsCase2, columnsCase2, startRow, startColumn, endRow, endColumn));
                    break;
                case 3:
                    break;
                default: 
                    Console.WriteLine("You`ve entered wrong number");
                    break;
            }
        }
        
        public static void deleteMatrixCase(List<Matrix> matrixList)
        {
            int deleteIndex = enterIndex();
            matrixList.RemoveAt(deleteIndex);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void chooseMatrixCase(List<Matrix> matrixList)
        {
            int choosenIndex = enterIndex();
            bool condition = true;
            
            while (condition)
            {
                Console.WriteLine("A congratulations! It`s sub menu, enter: {0}" +
                                  "0 - to get value by coordinates;{0}" +
                                  "1 - to set value by coordinates;{0}" +
                                  "2 - to print matrix;{0}" +
                                  "3 - to cancel;{0}", Environment.NewLine);
                int item_id = Int32.Parse(Console.ReadLine());

                switch (item_id)
                {
                    case 0:
                        Console.WriteLine("Enter the row's index of element");
                        int _rowGet = Int32.Parse(Console.ReadLine()); 
                        Console.WriteLine("Enter the column's index of element");
                        int _columnGet = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"Matrix[{_rowGet},{_columnGet}] = {matrixList[choosenIndex].MatrixValue[_rowGet, _columnGet]}");
                        break;
                    case 1:
                        Console.WriteLine("Enter the row's index of element");
                        int _rowSet = Int32.Parse(Console.ReadLine()); 
                        Console.WriteLine("Enter the column's index of element");
                        int _columnSet = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new value of element");
                        int _value = Int32.Parse(Console.ReadLine());
                        matrixList[choosenIndex].MatrixValue[_rowSet, _columnSet] = _value;
                        break;
                    case 2:
                        Console.Write(Environment.NewLine);
                        for (int i = 0; i < matrixList[choosenIndex].Rows; i++)
                        {
                            Console.Write(Environment.NewLine);
                            for (int j = 0; j < matrixList[choosenIndex].Columns; j++)
                            {
                                Console.Write($"{matrixList[choosenIndex].MatrixValue[i,j]} ");
                            }
                        }
                        break;
                    case 3:
                        condition = false;
                        break;
                    default:
                        Console.WriteLine("You`ve entered wrong number");
                        break;
                }
            }
        }
        
        public static void Main(string[] args)
        {
           bool condition = true;
            while (condition)
            {
                Console.WriteLine("A congratulations! It`s main menu, enter: {0}" +
                                  "0 - to see matrix object list {0}" +
                                  "1 - to create new matrix {0}" +
                                  "2 - to delete matrix {0}" +
                                  "3 - to choose matrix {0}" +
                                  "4 - cancel{0}", Environment.NewLine);
                int item_id = Int32.Parse(Console.ReadLine());

                switch (item_id)
                {
                    case 0:
                        seeMatrixlistCase(MatrixList.Matricies);
                        break;
                    case 1:
                        addNewMatrixCase(MatrixList.Matricies);
                        break;
                    case 2:
                        deleteMatrixCase(MatrixList.Matricies);
                        break;
                    case 3:
                        chooseMatrixCase(MatrixList.Matricies);
                        break;
                    case 4:
                        condition = false;
                        break;
                    default:
                        Console.WriteLine("You`ve entered wrong number");
                        break;
                }
                Console.WriteLine("{0} -------------------------------------------------- {0}",
                    Environment.NewLine);
            }  
        }
    }
}