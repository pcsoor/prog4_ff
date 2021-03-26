using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    interface IGameLogic
    {
        void MoveLeft();
        void MoveRight();
        void Shoot();
        void Jump();
        void Damage();
    }
}
