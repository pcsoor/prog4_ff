// <copyright file="GameItem.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static TetrisMario.Model.Enumerators;

    /// <summary>
    /// Game item class.
    /// </summary>
    public class GameItem : IGameItem
    {
        private Types type = Types.Undecided;
        private UiElements ui = UiElements.Undecided;
        private int waitTime;
        private int x = -1;
        private int y = -1;

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public Types Type
        {
            get { return this.type; } set { this.type = value; }
        }

        /// <summary>
        /// Gets or sets UiElements.
        /// </summary>
        public UiElements UiElement
        {
            get { return this.ui; } set { this.ui = value; }
        }

        /// <summary>
        /// Gets or sets wait time.
        /// </summary>
        public int WaitTime
        {
            get { return this.waitTime; } set { this.waitTime = value; }
        }

        /// <summary>
        /// Gets or sets x coordinate.
        /// </summary>
        public int X
        {
            get { return this.x; } set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets y coordinate.
        /// </summary>
        public int Y
        {
            get { return this.y; } set { this.y = value; }
        }

        /// <summary>
        /// Push item to one direction.
        /// </summary>
        /// <param name="direction">direction.</param>
        /// <returns>Types.</returns>
        public virtual Types Push(Directions direction)
        {
            int newX = this.X;
            int newY = this.Y;

            switch (direction)
            {
                case Directions.Left:
                    newX = this.X - 1;
                    newY = this.Y;
                    break;
                case Directions.Right:
                    newX = this.X + 1;
                    newY = this.Y;
                    break;
                case Directions.Up:
                    newX = this.X;
                    newY = this.Y - 1;
                    break;
                case Directions.Down:
                    newX = this.X;
                    newY = this.Y + 1;
                    break;
            }

            if (GameModel.Map[newX, newY] == null)
            {
                GameModel.Map[this.X, this.Y] = null;
                this.X = newX;
                this.Y = newY;
                GameModel.Map[this.X, this.Y] = this;
                return Types.Empty;
            }
            else
            {
                return GameModel.Map[newX, newY].Type;
            }
        }

        /// <summary>
        /// Game item's moving.
        /// </summary>
        /// <param name="newX">x coordinates.</param>
        /// <param name="newY">y coordinates.</param>
        /// <returns>Type.</returns>
        public Types Move(int newX, int newY)
        {
            if (GameModel.Map[newX, newY] == null)
            {
                GameModel.Map[this.X, this.Y] = null;
                this.X = newX;
                this.Y = newY;
                GameModel.Map[this.X, this.Y] = this;
                return Types.Empty;
            }
            else
            {
                return GameModel.Map[this.X, this.Y].Type;
            }
        }

        /// <summary>
        /// Checks surrounded items.
        /// </summary>
        /// <param name="direction">direction.</param>
        /// <returns>GameItem.</returns>
        public GameItem CheckSurrounding(Directions direction)
        {
            GameItem item = null;
            switch (direction)
            {
                case Directions.Left:
                    if (GameModel.Map[this.x - 1, this.y] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = GameModel.Map[this.x - 1, this.y];
                    }

                    break;
                case Directions.Right:
                    if (GameModel.Map[this.x + 1, this.y] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = GameModel.Map[this.x + 1, this.y];
                    }

                    break;
                case Directions.Up:
                    if (GameModel.Map[this.x, this.y - 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = GameModel.Map[this.x, this.y - 1];
                    }

                    break;
                case Directions.Down:
                    if (GameModel.Map[this.x, this.y + 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = GameModel.Map[this.x, this.y + 1];
                    }

                    break;
                case Directions.LowerLeft:
                    if (GameModel.Map[this.x - 1, this.y + 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = GameModel.Map[this.x - 1, this.y + 1];
                    }

                    break;
                case Directions.LowerRight:
                    if (GameModel.Map[this.x + 1, this.y + 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = GameModel.Map[this.x + 1, this.y + 1];
                    }

                    break;
                case Directions.UpperLeft:
                    if (GameModel.Map[this.x - 1, this.y - 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = GameModel.Map[this.x - 1, this.y - 1];
                    }

                    break;
                case Directions.UpperRight:
                    if (GameModel.Map[this.x + 1, this.y - 1] == null)
                    {
                        item = new GameObject(Types.Empty);
                    }
                    else
                    {
                        item = GameModel.Map[this.x + 1, this.y - 1];
                    }

                    break;
            }

            return item;
        }
    }
}
