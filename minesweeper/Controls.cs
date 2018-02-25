using System;
using System.Runtime.InteropServices;

namespace minesweeper
{
    public class Controls
    {
        private int boardSize;
        public int tilePosition { get; private set; }
        public int yPosition { get; private set; }
        public int xPosition { get; private set; }

        public Controls(int boardSize)
        {
            this.boardSize = boardSize;
            tilePosition = 0;
            yPosition = 0;
            xPosition = 2;
        }


        public void CursorAction(ConsoleKey keyPush)
        {
            if (keyPush == ConsoleKey.UpArrow)
            {
                if (tilePosition - boardSize > 0)
                {
                    tilePosition = tilePosition - boardSize;
                    yPosition = yPosition - 2;
                }
            }
                    
            if (keyPush == ConsoleKey.DownArrow)
            {
                if (tilePosition + boardSize < boardSize * boardSize){
                    tilePosition = tilePosition + boardSize;
                    yPosition = yPosition + 2;
                }
            }
                    
            if (keyPush == ConsoleKey.LeftArrow)
            {
                if (tilePosition != 0 && tilePosition % boardSize != 0)
                {
                    tilePosition--;
                    xPosition = xPosition - 5;
                }
            }
                    
            if (keyPush == ConsoleKey.RightArrow)
            {
                if ((tilePosition + 1) % boardSize != 0 && tilePosition + 1 < boardSize * boardSize)
                {
                    tilePosition++;
                    xPosition = xPosition + 5;
                }
            }
        }
    }
}