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

        /*
         * Constructor
         *     Inform how large the board is,
         *     such that it can set its limits accordingly.
         */
        public Controls(int boardSize)
        {
            this.boardSize = boardSize;
            tilePosition = 0;
            yPosition = 0;
            xPosition = 2;
        }


        /*
         * Here we handle the navigation from the user.
         * We accept arrow-keys and move the cursor accordingly,
         * and if the user is turning a tile, that tile-position
         * is returned for the board to manipulate.
         */
        public int CursorAction(ConsoleKey keyPush)
        {
            #region Navigations
                if (keyPush == ConsoleKey.UpArrow)
                {
                    if (tilePosition - boardSize >= 0)
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
            #endregion
            
            int tilePos = -1;
            if (keyPush == ConsoleKey.Spacebar)
                tilePos = tilePosition;
            
            return tilePos;
        }
    }
}