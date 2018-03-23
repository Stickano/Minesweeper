using System;
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
            bool GameWon = false;
            
            
            /*
             * Run the game in a loop until GameOver is set.
             * Here we print out the Tiles (Board) in the console.
             * And print print/move the cursor position accordingly
             * to the users key-presses.
             */
            while (!GameOver && !GameWon)
            {
                Console.Clear();
                
                int br = 0;
                foreach (Tile tile in board.GetTiles())
                {
                    Console.ResetColor();
                    if (tile.turned)
                    {
                        if (tile.around < 2)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else if (tile.around < 4)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        
                        Console.Write(" [" + tile.around + "] ");
                    }
                    else if (tile.marked)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" [M] ");
                    }
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
                Console.ResetColor();
                Console.WriteLine(board.turnedTiles + board.bombAmount);
                Console.WriteLine("Press M to mark tiles. Press Q to quit.");
                Console.WriteLine("Move with the Arrow-keys and turn tiles with Space.");
                
                Console.SetCursorPosition(cursor.xPosition, cursor.yPosition);
                ConsoleKey keyPush = Console.ReadKey().Key;
                int keyAction = cursor.CursorAction(keyPush);

                //while (keyAction == -1) // TODO: This some none-working BS.
                //{
                //    //if (board.GetTiles()[cursor.tilePosition].turned)
                //    //    Console.Write(board.GetTiles()[cursor.tilePosition].around);

                //    Console.SetCursorPosition(cursor.xPosition, cursor.yPosition);
                //    keyPush = Console.ReadKey().Key;
                //    keyAction = cursor.CursorAction(keyPush);
                    
                //    if (keyPush == ConsoleKey.M)
                //        board.MarkTile(cursor.tilePosition);

                //    if (keyPush == ConsoleKey.Q)
                //        GameOver = true;
                //}

                if (keyAction >= 0)
                {
                    int response = board.TurnTile(keyAction);
                    if (response == 1)
                        GameOver = true;
                    else if (response == 2)
                        GameWon = true;
                }

                if (keyPush == ConsoleKey.M)
                    board.MarkTile(cursor.tilePosition);

                if (keyPush == ConsoleKey.Q)
                    GameOver = true;
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
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" [B] ");
                }
                else
                {
                    if (tile.around < 2)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (tile.around < 4)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    
                    Console.Write(" [" + tile.around + "] ");
                }


                endBr++;
                if (endBr == boardSize)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    endBr = 0;
                }
            }
            
            Console.WriteLine();
            if (GameOver)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Game Over! Press any key to exit..");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulation. Game Won! Press any key to exit..");
            }

            Console.SetCursorPosition(cursor.xPosition, cursor.yPosition);
            Console.ReadKey();
        }
    }
}
