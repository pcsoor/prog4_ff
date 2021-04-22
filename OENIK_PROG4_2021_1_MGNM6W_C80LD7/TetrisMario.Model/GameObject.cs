// <copyright file="GameObject.cs" company="MGNM6W_C80LD7">
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
    /// One game object.
    /// </summary>
    public class GameObject : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class.
        /// </summary>
        /// <param name="type">Game item type.</param>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        public GameObject(Types type, int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Type = type;
            Random rnd = new Random();
            int num = rnd.Next(1, 6);
            switch (this.Type)
            {
                case Types.Block:
                    this.Color = num;
                    this.UiElement = UiElements.BasicBlock;
                    break;
                case Types.Wall:
                    this.UiElement = UiElements.Wall;
                    this.Pushable = false;
                    break;
                case Types.Undecided:
                    this.UiElement = UiElements.Undecided;
                    break;
                case Types.Empty:
                    this.UiElement = UiElements.Undecided;
                    break;
                case Types.Metal:
                    this.Color = num;
                    this.UiElement = UiElements.Metal;
                    this.Pushable = false;
                    break;
                case Types.PowerUp:
                    this.UiElement = UiElements.PowerUp;
                    break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class.
        /// </summary>
        /// <param name="type">Type of the game item.</param>
        public GameObject(Types type)
        {
            this.Type = type;
        }
    }
}
