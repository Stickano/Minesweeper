using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    class Tile
    {
        private Random rand;
        public bool value { get; private set; }
        public int position { get; private set; }
        public bool turned { get; set; }
        public int  around { get; set; }
        public bool outer { get; set; }

        public Tile(int position, bool outer = false)
        {
            rand = new Random();
            turned = false;
            this.position = position;

            if (outer == false)
                SetValue();
            else
                this.value = false;
        }

        private void SetValue()
        {
            int thisVal = rand.Next(1, 11);
            this.value = false;
            if (thisVal == 1)
                this.value = true;
        }

    }
}
