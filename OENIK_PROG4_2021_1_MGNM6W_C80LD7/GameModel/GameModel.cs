using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{

    public class MarioTetrisModel : IGameModel
    {
        public int[,] Map { get; set; }
        public string Block { get; set; }
        public Point Mario { get; set; }

        public MarioTetrisModel()
        {
            this.Map = new int[26, 16];
        }
    }
}
