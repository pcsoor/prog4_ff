using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameModel.Enums;

namespace GameModel
{
    public class MarioTetrisModel
    {
        public static GameItem[,] Map = new GameItem[26, 16];

        public int MapLenght0 = 26;

        public int MapLenght1 = 16;

        public GameObject Block { get; set; }

        public GameObject Wall { get; set; }

        public Player Mario { get; set; }

        public double GameWidth { get; private set; }

        public double GameHeight { get; private set; }

        public double TileSize { get; set; }

        public MarioTetrisModel(double w, double h)
        {
            GameWidth = w;
            GameHeight = h;
        }
    }

    public abstract class GameItem
    {
        public int x = -1;
        public int y = -1;

        public Types Type = Types.Undecided;
        public UI Ui = UI.Undecided;
        public int WaitTime = 0;

        public Types Push(Directions direction)
        {
            int newX = x;
            int newY = y;

            switch (direction)
            {
                case Directions.Left:
                    newX = x - 1;
                    newY = y;
                    break;
                case Directions.Right:
                    newX = x + 1;
                    newY = y;
                    break;
                case Directions.Up:
                    newX = x;
                    newY = y - 1;
                    break;
                case Directions.Dowm:
                    newX = x;
                    newY = y + 1;
                    break;
            }

            if (MarioTetrisModel.Map[newX, newY] == null)
            {
                MarioTetrisModel.Map[x, y] = null;
                x = newX;
                y = newY;
                MarioTetrisModel.Map[x, y] = this;
                return Types.Empty;
            }
            else
            {
                return MarioTetrisModel.Map[newX, newY].Type;
            }
        }

        public Types Move(int newX, int newY)
        {
            if (MarioTetrisModel.Map[newX, newY] == null)
            {
                MarioTetrisModel.Map[x, y] = null;
                x = newX;
                y = newY;
                MarioTetrisModel.Map[x, y] = this;
                return Types.Empty;
            }
            else
            {
                return MarioTetrisModel.Map[x, y].Type;
            }
        }

        public Types Create(int newX, int newY)
        {
            if (MarioTetrisModel.Map != null)
            {
                if (MarioTetrisModel.Map[newX, newY] == null)
                {
                    x = newX;
                    y = newY;
                    MarioTetrisModel.Map[x, y] = this;
                    return Types.Empty;
                }
                else
                {
                    return MarioTetrisModel.Map[x, y].Type;
                }
            }
            else
            {
                return Types.Empty;
            }
        }

        public GameItem CheckSurrounding(Directions direction)
        {
            GameItem item = null;
            switch (direction)
            {
                case Enums.Directions.Left:
                    if (MarioTetrisModel.Map[x-1,y] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = MarioTetrisModel.Map[x - 1, y];
                    }
                    break;
                case Enums.Directions.Right:
                    if (MarioTetrisModel.Map[x + 1, y] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = MarioTetrisModel.Map[x + 1, y];
                    }
                    break;
                case Enums.Directions.Up:
                    if (MarioTetrisModel.Map[x, y - 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = MarioTetrisModel.Map[x, y - 1];
                    }
                    break;
                case Enums.Directions.Dowm:
                    if (MarioTetrisModel.Map[x, y + 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = MarioTetrisModel.Map[x, y + 1];
                    }
                    break;
                case Enums.Directions.LowerLeft:
                    if (MarioTetrisModel.Map[x - 1, y + 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = MarioTetrisModel.Map[x - 1, y + 1];
                    }
                    break;
                case Enums.Directions.LowerRight:
                    if (MarioTetrisModel.Map[x + 1, y + 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = MarioTetrisModel.Map[x + 1, y + 1];
                    }
                    break;
                case Enums.Directions.UpperLeft:
                    if (MarioTetrisModel.Map[x - 1, y - 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = MarioTetrisModel.Map[x - 1, y - 1];
                    }
                    break;
                case Enums.Directions.UpperRight:
                    if (MarioTetrisModel.Map[x + 1, y - 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = MarioTetrisModel.Map[x + 1, y - 1];
                    }
                    break;
            }

            return item;
        }
    }

    public class Player : GameItem
    {
        private static Player instance = null;

        public Directions lastMove = Directions.Null;

        public Player(int x, int y)
        {
            Type = Types.Player;
            Ui = UI.Player;
            instance = this;
            this.x = x;
            this.y = y;
        }
    }

    public class GameObject : GameItem
    {
        public GameObject(Types type, int x, int y)
        {
            this.x = x;
            this.y = y;
            Type = type;
            switch (Type)
            {
                case Types.Block:
                    Ui = UI.BasicBlock;
                    break;
                case Types.Wall:
                    Ui = UI.Wall;
                    break;
                case Types.Undecided:
                    Ui = UI.Undecided;
                    break;
                case Types.Empty:
                    Ui = UI.Undecided;
                    break;

            }
        }

        public GameObject(Types type)
        {
            Type = type;
        }
    }
}
