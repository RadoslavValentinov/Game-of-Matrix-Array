using System;
using System.Threading;

namespace ProjectGameOfMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[3, 3];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int row = 0;
            int col = 0;

            char player1 = 'X';
            char player2 = 'O';
            int countPlayer = 1;

            while (true)
            {
                string[] comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                row = int.Parse(comand[0]);
                col = int.Parse(comand[1]);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Clear();
                if (countPlayer % 2 == 0)
                {
                    Console.WriteLine("Player 2 to move:");
                }

                if (countPlayer % 2 == 1)
                {
                    Console.WriteLine("Player 1 to move:");
                }
                if (GetValidationIndexes(row, col, matrix))
                {
                    if (countPlayer % 2 == 1)
                    {
                        matrix[row, col] = player1;
                        countPlayer++;
                        if (PlayerOfWIN(matrix, row, col))
                        {
                            Console.WriteLine("Player1 WIN");
                            break;
                        }
                    }
                    else if (countPlayer % 2 == 0)
                    {
                        matrix[row, col] = player2;
                        countPlayer++;
                        if (PlayerOfWIN(matrix, row, col))
                        {
                            Console.WriteLine("Player2 WIN");
                            break;
                        }
                    }

                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(string.Join(" ", matrix[i, j]));
                    }

                    Console.WriteLine();
                }
            }
        }

        private static bool PlayerOfWIN(char[,] matrix, int row, int col)
        {
            bool isWin = false;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row,col+i]=='X')
                {
                    isWin = true;
                }
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, col + i] == 'O')
                {
                    isWin = true;
                }
            }


            return isWin;// this method check how player win
        }

        private static bool GetValidationIndexes(int row, int col, char[,] matrix)
        {
            bool isVlid = false;

            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                isVlid = true;
            }

            if (matrix[row, col] == 'X')
            {
                Console.WriteLine($"Wrong Position");
                isVlid = false;
            }
            if (matrix[row, col] == 'O')
            {
                Console.WriteLine($"Wrong Position");
                isVlid = false;
            }


            return isVlid;
        }
    }
}
