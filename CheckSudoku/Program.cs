namespace CheckSudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] goodSudoku1 = {
                   new int[] {7, 8, 4, 1, 5, 9, 3, 2, 6},
                   new int[] {5, 3, 9, 6, 7, 2, 8, 4, 1},
                   new int[] {6, 1, 2, 4, 3, 8, 7, 5, 9},
                   new int[] {9, 2, 8, 7, 1, 5, 4, 6, 3},
                   new int[] {3, 5, 7, 8, 4, 6, 1, 9, 2},
                   new int[] {4, 6, 1, 9, 2, 3, 5, 8, 7},
                   new int[] {8, 7, 6, 3, 9, 4, 2, 1, 5},
                   new int[] {2, 4, 3, 5, 6, 1, 9, 7, 8},
                   new int[] {1, 9, 5, 2, 8, 7, 6, 3, 4}
             };
            Console.WriteLine(ValidateSudokuGame(goodSudoku1));
            Console.ReadLine();
        }

        public static bool ValidateSudokuGame(int[][] sudokuGame)
        {
            int N = sudokuGame.Length;
            int squareRootOfN = (int)Math.Sqrt(N);

            //Validate if length of the 2 dimensional array is valid which means if it is the size of a sudoku game
            // Example if N = 9 then square of root of 9 = 3  3*3= 9 this is a valid sudoku
            // if N = 10 then square of root for 10 will be again 3 taking it as integeer so 3*3 != 9 which means sudoku dimensions not valid
            if (N <= 0 && squareRootOfN * squareRootOfN != N)
                return false;

            // using Hashset because you can add only unique items here so if another element is added with the same value it will return false
            HashSet<int> checkList = new HashSet<int>();

            //iterate from i to N and check each column and row of each index until reaching to N
            for (int i = 0; i < N; i++)
            {
                checkList.Clear();

                // Check row
                for (int j = 0; j < N; j++)
                {
                    if (!IsValidNumberInsideSudokuGroupSet(sudokuGame[i][j], checkList, N))
                        return false;
                }

                checkList.Clear();

                // Check column
                for (int j = 0; j < N; j++)
                {
                    if (!IsValidNumberInsideSudokuGroupSet(sudokuGame[j][i], checkList, N))
                        return false;
                }
            }

            // Validate sub-grids
            for (int row = 0; row < N; row += squareRootOfN)
            {
                for (int col = 0; col < N; col += squareRootOfN)
                {
                    checkList.Clear();
                    for (int k = 0; k < squareRootOfN; k++)
                    {
                        for (int l = 0; l < squareRootOfN; l++)
                        {
                            if (!IsValidNumberInsideSudokuGroupSet(sudokuGame[row + k][col + l], checkList, N))
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        private static bool IsValidNumberInsideSudokuGroupSet(int currentNumber, HashSet<int> checkList, int N)
        {
            if (currentNumber < 1 || currentNumber > N)
                return false;

            return checkList.Add(currentNumber); // Attempt to add, returns false if it was already present
        }
    }
}
