using System;

class TicTacToe
{
    static char[,] board = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
    static char currentPlayer = 'X';

    static void Main()
    {
        int turns = 0;
        bool gameWon = false;
        while (turns < 9 && !gameWon)
        {
            Console.Clear();
            DisplayBoard();
            Console.WriteLine("Player " + currentPlayer + ", enter your move (1-9): ");
            int move = int.Parse(Console.ReadLine()) - 1;

            int row = move / 3;
            int col = move % 3;

            if (board[row, col] != 'X' && board[row, col] != 'O')
            {
                board[row, col] = currentPlayer;
                turns++;
                gameWon = CheckWin(row, col);

                if (!gameWon && turns < 9)
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
            else
            {
                Console.WriteLine("Invalid move! Try again.");
            }
        }

        Console.Clear();
        DisplayBoard();
        if (gameWon)
        {
            Console.WriteLine("Player " + currentPlayer + " wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }
    }

    static void DisplayBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("---------");
        }
    }

    static bool CheckWin(int row, int col)
    {

        if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
            return true;
        if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
            return true;

        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            return true;

        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            return true;

        return false;
    }
}
