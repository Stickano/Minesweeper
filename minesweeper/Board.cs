using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    class Board
    {
        private int boardSize;
        public int turnedTiles;
        public int bombAmount;
        private List<Tile> tiles;
        private List<int> bombPositions;
        private Random rand;

        /*
         * Constructor
         *     Sets the size of the Board
         */
        public Board(int size)
        {
            rand = new Random();
            tiles = new List<Tile>();
            bombPositions = new List<int>();
            boardSize = size;
            turnedTiles = 0;
            GenerateBoard();
        }

        
        /*
         * Generate all the tiles required for the board
         * and save them in a list.
         */
        private void GenerateBoard()
        {
            int br = 0;
            int line = 0;
            int position = 0;

            int xSize = boardSize;
            int ySize = boardSize;
            
            while (xSize-- > 0)
            {
                while (ySize-- > 0)
                {
                    br++;
                    /*      Spaghetti!
                     *          1
                     *      ---------
                     *      |       |  
                     *    4 |   0   | 2
                     *      |       |
                     *      ---------
                     *          3
                     */
                    int outer = 0;
                    if (line == 0)
                        outer = 1;
                    else if (br == boardSize)
                        outer = 2;
                    else if (line + 1 == boardSize)
                        outer = 3;
                    else if (br == 1)
                        outer = 4;
                    
                    if (br == boardSize)
                    {
                        line++;
                        br = 0;
                    }
                    
                    Tile tile = new Tile(position, outer);
                    tiles.Add(tile);
                    position++;
                }
                
                ySize = boardSize;
            }

            PlaceBombs();
        }

        
        /*
         * Will place bombs at random positions
         * in our list of tiles. 
         */
        private void PlaceBombs()
        {
            int amount = boardSize == 10 ? 10 : 80;
            bombAmount = amount;

            while (amount > 0)
            {
                int pos = rand.Next(1, (boardSize * boardSize));
                Tile result = tiles.Find(t => t.position.Equals(pos));
                
                if (result.outer != 0 || result.value)
                    continue;

                tiles[pos].value = true;
                bombPositions.Add(pos);
                amount--;
            }
            
            PlaceMarkers();
        }

        
        /*
         * Will count and set the amount of bombs around
         * relevant tiles.
         */
        private void PlaceMarkers()
        {
            foreach (int bomb in bombPositions)
            {
                tiles[bomb].around++; // TODO: Might be able to remove
                foreach (int tilePosition in SurroundingPositions(bomb))
                {
                    tiles[tilePosition].around++;
                }
            }
        }


        /*
         * Helps find all the surrounding tile-
         * positions from a given position.
         * TODO: SPaghetti in house!
         */
        private List<int> SurroundingPositions(int position)
        {
            List<int> tilePositions = new List<int>();
            int totalTiles = (boardSize * boardSize) -1;
            
            if (position+1 <= totalTiles && tiles[position].outer != 2) 
                tilePositions.Add(position+1);
            if (position + boardSize <= totalTiles)
                tilePositions.Add(position+boardSize);
            if (position + boardSize+1 <= totalTiles && tiles[position].outer != 2) 
                tilePositions.Add(position+boardSize+1);
            if (position + boardSize-1 < totalTiles && tiles[position].outer != 4 && position != 0) 
                tilePositions.Add(position+boardSize-1);
            
            if (position - 1 >= 0 && tiles[position].outer != 4 && position != 90 && position != 380)
                tilePositions.Add(position-1);
            if (position - boardSize >= 0)
                tilePositions.Add(position-boardSize);
            if (position - boardSize +1 >= 0 && tiles[position].outer != 2)
                tilePositions.Add(position-boardSize+1);
            if (position - boardSize -1 >= 0 && tiles[position].outer != 4 && position != 90 && position != 380)
                tilePositions.Add(position-boardSize-1);

            return tilePositions;
        }
        
        
        


        /*
         * Turns over, and show surrounding bombs, for tiles
         * played by the view. This will also call the RecursiveTurn,
         * which will turn surrounding tiles.
         */
        public int  TurnTile(int tilePosition)
        {
            int GameOver = -1;
            if (tiles[tilePosition].value)
                GameOver = 1;
            else if (!tiles[tilePosition].turned )
            {
                tiles[tilePosition].turned = true;
                turnedTiles++;
                                
                List<int> turnThese = new List<int>();
                turnThese = RecursiveTurn(turnThese, tilePosition);

                foreach (int i in turnThese)
                {
                    tiles[i].turned = true;
                    turnedTiles++;
                }

                if (turnedTiles + bombAmount == boardSize * boardSize)
                    GameOver = 2;
            }

            return GameOver;
        }


        /*  
         * Will recursively turn the surround tiles, 
         * if the conditions match. 
         */
        private List<int> RecursiveTurn(List<int> turnThese, int position)
        {
            List<int> turn = turnThese;
            if(!turn.Contains(position))
                turn.Add(position);

            foreach (int i in SurroundingPositions(position))
            {
                if (!tiles[i].marked && !tiles[i].value && !turn.Contains(i))
                {
                    turn.Add(i);
                    if (tiles[i].around == 0)
                        RecursiveTurn(turn, i);
                }
            }

            return turn;
        }


        /*
         * Makes the user able to mark tiles,
         * that is suspected to have a bomb.
         */
        public void MarkTile(int tilePosition)
        {
            if (!tiles[tilePosition].turned)
                tiles[tilePosition].marked = !tiles[tilePosition].marked;
        }

        
        /*
         * Return the Tile list with all
         * their new values - For the view.
         */
        public List<Tile> GetTiles()
        {
            return tiles;
        }
    }
}
