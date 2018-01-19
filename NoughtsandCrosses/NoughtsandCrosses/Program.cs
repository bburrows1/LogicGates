using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsandCrosses
{
    class Program
    {
        static void WriteBoard(char[,] Board)
        {
            Console.WriteLine("  | 1 | 2 | 3 ");
            for (int x = 0; x < 3; x++)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("{0} | {1} | {2} | {3}", x+1, Board[x, 0], Board[x, 1], Board[x, 2]);
            }
        }
        static bool CheckWin(char[,] Board)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2] && Board[i, 0] != ' ') || 
                    (Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i] && Board[0, i] != ' ') ||
                    (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[0, 0] != ' ') ||
                    (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[1, 1] != ' '))
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            char[,] Board = new char[3, 3] {{' ', ' ', ' '},
                                            {' ', ' ', ' '},
                                            {' ', ' ', ' '} };
            bool player = true;
            for (int i = 1 ; i < 10; i++)
            {
                bool complete = false;
                WriteBoard(Board);
                int positionx = IOUtils.IOUtils.readInt("X: ", 1, 3) - 1;
                int positiony = IOUtils.IOUtils.readInt("Y: ", 1, 3) - 1;
                while (!complete)
                {
                    if (Board[positiony, positionx] == ' ')
                    {
                        if (player)
                        {
                            Board[positiony, positionx] = 'O';
                            complete = true;
                        }
                        else
                        {
                            Board[positiony, positionx] = 'X';
                            complete = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("That place is already taken");
                        positionx = IOUtils.IOUtils.readInt("X: ", 1, 3) - 1;
                        positiony = IOUtils.IOUtils.readInt("Y: ", 1, 3) - 1;
                    }
                }
                if (CheckWin(Board))
                {
                    WriteBoard(Board);
                    if (player)
                    {
                        Console.WriteLine("O's Win!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("X's Win");
                        Console.ReadKey();
                    }
                    
                }
                else if (i == 9)
                {
                    Console.WriteLine("It's a draw!");
                    Console.ReadKey();
                } 
                player = !player;
            }
        }
    }
}
