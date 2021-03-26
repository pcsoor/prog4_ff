using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    interface IGameModel
    {
        int[,] Board { get; set; }
        string Block { get; set; }
    }
}
