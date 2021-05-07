using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisMario.Control
{
    public class Highscore : ObservableObject
    {
        string data;

        public string Data { get; set; }
    }
}
