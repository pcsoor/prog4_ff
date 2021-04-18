// <copyright file="GameLogic.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using TetrisMario.Model;

    /// <summary>
    /// Game logic.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// Inputs.
        /// </summary>
        private static int nextBoxCounter;
        private Queue<Enumerators.Directions> inputs;
        private IGameModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <param name="model">Game model referece.</param>
        public GameLogic(IGameModel model)
        {
            this.model = model;
            this.InitModel();
            nextBoxCounter = 0;
            this.inputs = new Queue<Enumerators.Directions>();
        }

        /// <summary>
        /// Gets key input.
        /// </summary>
        public Queue<Enumerators.Directions> Inputs
        {
            get
            {
                return this.inputs;
            }
        }

        /// <summary>
        /// Spawn one block in random place.
        /// </summary>
        public void SpawnBlock()
        {
            if (nextBoxCounter == 0)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, GameModel.Map.GetLength(0) - 1);
                GameModel.Map[randomNumber, 4] = new GameObject(Enumerators.Types.Block, randomNumber, 4);
                nextBoxCounter = -500;
            }
            else
            {
                nextBoxCounter += 5;
            }
        }

        /// <summary>
        /// Check last layer of game area.
        /// </summary>
        public void CheckIfBottomIsFull()
        {
            bool result = true;
            for (int i = 1; i < GameModel.Map.GetLength(0) - 1; i++)
            {
                if (GameModel.Map[i, GameModel.Map.GetLength(1) - 2] == null || GameModel.Map[i, GameModel.Map.GetLength(1) - 2].Type == Enumerators.Types.Player)
                {
                    result = false;
                }
            }

            if (result)
            {
                for (int i = 1; i < GameModel.Map.GetLength(0) - 1; i++)
                {
                    GameModel.Map[i, GameModel.Map.GetLength(1) - 2] = null;
                }
            }
        }

        /// <summary>
        /// Initializing method.
        /// </summary>
        public void InitModel()
        {
            this.model.TileSize = Math.Min(this.model.GameWidth / 26, this.model.GameHeight / 16);
            for (int i = 0; i < GameModel.Map.GetLength(0); i++)
            {
                for (int j = 0; j < GameModel.Map.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || j == 3 || i == 25 || j == 15)
                    {
                        GameModel.Map[i, j] = new GameObject(TetrisMario.Model.Enumerators.Types.Wall, i, j);
                    }
                }
            }

            GameModel.Map[13, 14] = new Player(13, 14);
        }

        /// <summary>
        /// Updates all game item.
        /// </summary>
        public void Update()
        {
            foreach (GameItem item in GameModel.Map)
            {
                if (item != null)
                {
                    if (item.Type == Enumerators.Types.Player)
                    {
                        if (item.WaitTime >= 0)
                        {
                            if (item.CheckSurrounding(Enumerators.Directions.Down).Type == Enumerators.Types.Empty)
                            {
                                item.WaitTime = (int)Enumerators.WaitTime.PlayerJump;
                            }
                            else if (this.inputs.Count != 0)
                            {
                                if ((item as Player).LastMove == Enumerators.Directions.Up)
                                {
                                    item.WaitTime = (int)Enumerators.WaitTime.PlayerRecover;
                                    (item as Player).LastMove = Enumerators.Directions.Null;
                                }
                                else
                                {
                                    Enumerators.Directions input = this.inputs.Dequeue();
                                    Enumerators.Types result = item.Push(input);
                                    if (result == Enumerators.Types.Empty)
                                    {
                                        (item as Player).LastMove = input;
                                        input = Enumerators.Directions.Null;
                                    }
                                    else if (result == Enumerators.Types.Block)
                                    {
                                        GameObject block = (GameObject)item.CheckSurrounding(input);
                                        if ((block.CheckSurrounding(Enumerators.Directions.Up).Type == Enumerators.Types.Empty) && (block.CheckSurrounding(input).Type == Enumerators.Types.Empty))
                                        {
                                            if (block.CheckSurrounding(Enumerators.Directions.Down).Type != Enumerators.Types.Empty)
                                            {
                                                if (block.Push(input) == Enumerators.Types.Empty)
                                                {
                                                    if (item.Push(input) == Enumerators.Types.Empty)
                                                    {
                                                        (item as Player).LastMove = input;
                                                        input = Enumerators.Directions.Null;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (item.WaitTime != 0)
                        {
                            item.WaitTime += 5;
                            if (item.WaitTime == 0)
                            {
                                item.Push(Enumerators.Directions.Down);
                            }
                            else if (this.inputs.Count != 0)
                            {
                                Enumerators.Directions input = this.inputs.Dequeue();

                                if ((item as Player).LastMove == Enumerators.Directions.Up && (input == Enumerators.Directions.Right || input == Enumerators.Directions.Left))
                                {
                                    bool checkSurroundings_clear = false;
                                    if (input == Enumerators.Directions.Right && item.CheckSurrounding(Enumerators.Directions.LowerRight).Type == Enumerators.Types.Block)
                                    {
                                        checkSurroundings_clear = true;
                                    }
                                    else if (input == Enumerators.Directions.Left && item.CheckSurrounding(Enumerators.Directions.LowerLeft).Type == Enumerators.Types.Block)
                                    {
                                        checkSurroundings_clear = true;
                                    }

                                    if (checkSurroundings_clear)
                                    {
                                        Enumerators.Types result = item.Push(input);
                                        if (result == Enumerators.Types.Empty)
                                        {
                                            item.WaitTime = 0;
                                            (item as Player).LastMove = input;
                                        }
                                        else if (result == Enumerators.Types.Block)
                                        {
                                            GameObject block = (GameObject)item.CheckSurrounding(input);
                                            if ((block.CheckSurrounding(Enumerators.Directions.Up).Type == Enumerators.Types.Empty) && (block.CheckSurrounding(input).Type == Enumerators.Types.Empty))
                                            {
                                                if (block.CheckSurrounding(Enumerators.Directions.Down).Type != Enumerators.Types.Empty)
                                                {
                                                    if (block.Push(input) == Enumerators.Types.Empty)
                                                    {
                                                        if (item.Push(input) == Enumerators.Types.Empty)
                                                        {
                                                            (item as Player).LastMove = input;
                                                            input = Enumerators.Directions.Null;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (item.Type == Enumerators.Types.Block)
                    {
                        if (item.WaitTime >= 0)
                        {
                            if (item.CheckSurrounding(Enumerators.Directions.Down).Type == Enumerators.Types.Empty)
                            {
                                item.WaitTime = (int)Enumerators.WaitTime.Box;
                            }
                        }
                        else if (item.WaitTime != 0)
                        {
                            item.WaitTime += 5;
                            if (item.WaitTime == 0)
                            {
                                item.Push(Enumerators.Directions.Down);
                            }
                        }
                    }
                }
            }
        }
    }
}
