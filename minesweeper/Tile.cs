using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    class Tile
    {
        public bool value { get; set; }
        public int position { get; }
        public bool turned { get; set; }
        public int  around { get; set; }
        public bool outer { get; }

        public Tile(int position, bool outer = false)
        {
            turned = false;
            around = 0;
            this.position = position;
            this.outer = outer;
        }
    }
}
