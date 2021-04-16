using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public class Enums
    {
        public enum UI
        {
            Wall = 1,
            Player = 7,
            BasicBlock = 2,
            Undecided = 0
        }

        public enum Types
        {
            Player,
            Block,
            Wall,
            Undecided,
            Empty
        }

        public enum Directions
        {
            Left,
            Right,
            Up,
            Dowm,
            LowerLeft,
            LowerRight,
            UpperLeft,
            UpperRight,
            Null
        }

        public enum eWaitTime
        {
            Player = 0,
            PlayerJump = -150,
            PlayerRecover = -50,
            Box = -100
        }
    }
}
