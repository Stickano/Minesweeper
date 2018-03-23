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
        public int outer { get; }
        public bool marked { get; set; }

        public Tile(int position, int outer = 0)
        {
            turned = false;
            marked = false;
            around = 0;
            this.position = position;
            this.outer = outer;
        }
    }
}
