using System;
using System.Linq;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int currentPlayer = 1; // 1 for player X, 2 for player O
    static bool isGameActive = true;

    static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            DrawBoard();
            HandleMove();
            CheckForWinner();
            SwitchPlayer();
        } while (isGameActive);

        Console.ReadLine(); // Keep console window open after the game ends
    }

    static void DrawBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    static void HandleMove()
    {
        bool isValidMove = false;
        int move;

        do
        {
            Console.Write($"{GetPlayerSymbol()}\'s move > ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out move) && move >= 1 && move <= 9 && board[move - 1] != 'X' && board[move - 1] != 'O')
            {
                isValidMove = true;
            }
            else
            {
                Console.WriteLine("Illegal move! Try again.");
            }

        } while (!isValidMove);

        board[move - 1] = GetPlayerSymbol();
    }

    static char GetPlayerSymbol()
    {
        return currentPlayer == 1 ? 'X' : 'O';
    }

    static void SwitchPlayer()
    {
        currentPlayer = currentPlayer == 1 ? 2 : 1;
    }

    static void CheckForWinner()
    {
        if (CheckForWin('X'))
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine("Player X wins!");
            isGameActive = false;
        }
        else if (CheckForWin('O'))
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine("Player O wins!");
            isGameActive = false;
        }
        else if (board.All(cell => cell == 'X' || cell == 'O'))
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine("It's a draw!");
            isGameActive = false;
        }
    }

    static bool CheckForWin(char symbol)
    {
        return (board[0] == symbol && board[1] == symbol && board[2] == symbol) ||
               (board[3] == symbol && board[4] == symbol && board[5] == symbol) ||
               (board[6] == symbol && board[7] == symbol && board[8] == symbol) ||
               (board[0] == symbol && board[3] == symbol && board[6] == symbol) ||
               (board[1] == symbol && board[4] == symbol && board[7] == symbol) ||
               (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||
               (board[0] == symbol && board[4] == symbol && board[8] == symbol) ||
               (board[2] == symbol && board[4] == symbol && board[6] == symbol);
    }
}