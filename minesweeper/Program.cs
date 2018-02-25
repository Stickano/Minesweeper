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

            if (boardSize == 1)
                boardSize = 10;
            else
                boardSize = 20;

            Console.Clear();

            int br = 0;
            Board board = new Board(boardSize);
            foreach (Tile tile in board.GetTiles())
            {
                if (tile.outer)
                    Console.Write(" [O] ");
                else if (tile.value)
                    Console.Write(" [B] ");
                else 
                    Console.Write(" ["+tile.around+"] ");

                br++;
                if (br == boardSize)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    br = 0;
                }
            }

            int yPosition = 0;
            int xPosition = 2;

            Console.SetCursorPosition(xPosition, yPosition);



            Console.ReadLine();
        }
    }
}
