﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /*
             * Introduction to CLI Minesweeper.
             * Here we'll set a small or large boardsize
             * and loop through the process untill we get an
             * answer that we accept. 
             */
            Console.WriteLine("CLI Minesweeper");
            Console.Write("Choose the amount of tiles: 1 (10x10), 2 (20x20) ");
            string sizeAnswer = Console.ReadLine();

            int boardSize;
            while (!int.TryParse(sizeAnswer, out boardSize) || boardSize < 1 || boardSize > 2)
            {
                Console.WriteLine("Pick a number between 1-2");
                sizeAnswer = Console.ReadLine();
            }

            
            /*
             * Create a Board object and clear the console.
             * We also create a Controls object, which handles
             * the users navigations/actions.
             */
            Console.Clear();
            
            boardSize = boardSize == 1 ? 10 : 20;
            Board board = new Board(boardSize);
            Controls cursor = new Controls(boardSize);

            bool GameOver = false;
            
            
            /*
             * Run the game in a loop until GameOver is set.
             * Here we print out the Tiles (Board) in the console.
             * And print print/move the cursor position accordingly
             * to the users key-presses.
             */
            while (!GameOver)
            {
                Console.Clear();
                
                int br = 0;
                foreach (Tile tile in board.GetTiles())
                {
                    
                    if (tile.turned)
                        Console.Write(" ["+tile.around+"] ");
                    else if (tile.marked)
                        Console.Write(" [M] ");
                    else
                        Console.Write(" [ ] ");

                    br++;
                    if (br == boardSize)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        br = 0;
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Press M to mark tiles. Press Q to quit.");
                
                Console.SetCursorPosition(cursor.xPosition, cursor.yPosition);
                ConsoleKey keyPush = Console.ReadKey().Key;
                
                int keyAction = cursor.CursorAction(keyPush);
                if (keyAction >= 0)
                    GameOver = board.TurnTile(keyAction);
                
                if (keyPush == ConsoleKey.M)
                    board.MarkTile(cursor.tilePosition);

                if (keyPush == ConsoleKey.Q)
                    break;
            }


            
            /*
             * When the game is over, print out a little finish
             * along with the complete turned tiles of the board
             */
            Console.Clear();
            
            int endBr = 0;
            foreach (Tile tile in board.GetTiles())
            {
                    
                if (tile.value)
                    Console.Write(" [B] ");
                else
                    Console.Write(" ["+tile.around+"] ");

                
                
                endBr++;
                if (endBr == boardSize)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    endBr = 0;
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Game Over! Press any key to exit..");
            Console.SetCursorPosition(cursor.xPosition, cursor.yPosition);
            Console.ReadKey();
        }
    }
}
