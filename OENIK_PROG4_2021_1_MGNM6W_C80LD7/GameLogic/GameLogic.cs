using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameModel;

namespace GameLogic
{
    class MarioTetrisLogic
    {
        MarioTetrisModel model;

        public MarioTetrisLogic(MarioTetrisModel model)
        {
            this.model = model;
            this.InitModel();
        }

        private void InitModel()
        {
            for (int x = 0; x < 26; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x == 0 || y == 0)
                    {
                        this.model.Map[x, y] = 1;
                    }
                }
            }

            this.model.Map[15, 8] = 7;

        }

        //public bool Move(int dx, int dy)
        //{
        //    int newx = (int)(model.Mario.X + dx);
        //    int newy = (int)(model.Mario.Y + dy);
        //    if ()
        //    {

        //    }
        //}

    }
}
