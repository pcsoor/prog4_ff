namespace GameModel
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Game Model Interface.
    /// </summary>
    interface IGameModel
    {
        int[,] Walls { get; set; }
        string Block { get; set; }
        Point Mario { get; set; }
    }
}
