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
        private List<Tile> tiles;
        private List<int> bombPositions;
            
        /*
         * Constructor
         *     Sets the size of the Board
         */
        public Board(int size)
        {
            tiles = new List<Tile>();
            bombPositions = new List<int>();
            boardSize = size;
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
                    bool outer = false;
                    if (line == 0)
                        outer = true;
                    else if (br == 1 || br == boardSize)
                        outer = true;
                    else if (line + 1 == boardSize)
                        outer = true;
                    
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
            Random rand = new Random();
            int amount = boardSize == 10 ? 10 : 80;

            while (amount > 0)
            {
                int pos = rand.Next(1, (boardSize * boardSize));
                Tile result = tiles.Find(t => t.position.Equals(pos));
                
                if (result.outer || result.value)
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
                tiles[bomb].around++;
                tiles[bomb + 1].around++;
                tiles[bomb + boardSize].around++;
                tiles[bomb + boardSize + 1].around++;
                tiles[bomb + boardSize - 1].around++;
                
                if (bomb - 1 >= 0)
                    tiles[bomb - 1].around++;
                if (bomb - boardSize >= 0)
                    tiles[bomb - boardSize].around++;
                if (bomb - boardSize + 1 >= 0)
                    tiles[bomb - boardSize + 1].around++;
                if (bomb - boardSize - 1 >= 0)
                    tiles[bomb - boardSize - 1].around++;
            }
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
