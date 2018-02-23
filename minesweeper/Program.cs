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
            Console.WriteLine("CLI Minesweeper");
            Console.Write("Choose the amount of tiles: 1 (10x10), 2 (20x20) ");
            string sizeAnswer = Console.ReadLine();

            int boardSize;
            while (!int.TryParse(sizeAnswer, out boardSize) || boardSize < 1 || boardSize > 2)
            {
                Console.WriteLine("Pick a number between 1-2");
            }

            Console.Clear();

            if (boardSize == 1)
                boardSize = 10;
            else
                boardSize = 20;

            // TODO: Do I need?
            // Board board = new Board(boardSize);

            List<Tile> tileList = new List<Tile>();

            int xSize = boardSize;
            int ySize = boardSize;
            int br = 0;
            while (xSize-- > 0)
            {
                while (ySize-- > 0)
                {
                    br++;
                    bool outer = xSize == boardSize || ySize == boardSize;
                    Tile tile = new Tile(br, outer);
                    tileList.Add(tile);

                    //string brTxt;
                    //if (br < 10)
                    //    brTxt = "00" + br;
                    //else if (br < 100)
                    //    brTxt = "0" + br;
                    //else
                    //    brTxt = br.ToString();

                    Console.Write(" [ ] ");   
                }

                ySize = boardSize;
                Console.WriteLine();
                Console.WriteLine();
            }

            int yPosition = 0;
            int xPosition = 2;

            Console.SetCursorPosition(xPosition, yPosition);



            Console.ReadLine();
        }
    }
}
