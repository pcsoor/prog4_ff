using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public class MarioTetrisModel
    {
        public int[,] Map { get; private set; }

        public string Block { get; set; }

        public Point Mario { get; set; }

        public double GameWidth { get; private set; }

        public double GameHeight { get; private set; }

        public double TileSize { get; set; }

        public MarioTetrisModel()
        {
            this.Map = new int[26, 16];
        }
    }
}
