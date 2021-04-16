// <copyright file="MarioTetrisLogic.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using GameModel;

    /// <summary>
    /// Game logic.
    /// </summary>
    public class MarioTetrisLogic
    {
        /// <summary>
        /// Inputs.
        /// </summary>
        private static int nextBoxCounter;
        public Queue<Enums.Directions> inputs;
        private MarioTetrisModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarioTetrisLogic"/> class.
        /// </summary>
        /// <param name="model">Game model referece.</param>
        public MarioTetrisLogic(MarioTetrisModel model)
        {
            this.model = model;
            this.InitModel();
            nextBoxCounter = 0;
            this.inputs = new Queue<Enums.Directions>();
        }

        /// <summary>
        /// Spawn one block in random place.
        /// </summary>
        public void SpawnBlock()
        {
            if (nextBoxCounter == 0)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, MarioTetrisModel.Map.GetLength(0) - 1);
                MarioTetrisModel.Map[randomNumber, 4] = new GameObject(Enums.Types.Block, randomNumber, 4);
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
            for (int i = 1; i < MarioTetrisModel.Map.GetLength(0) - 1; i++)
            {
                if (MarioTetrisModel.Map[i, MarioTetrisModel.Map.GetLength(1) - 2] == null || MarioTetrisModel.Map[i, MarioTetrisModel.Map.GetLength(1) - 2].Type == Enums.Types.Player)
                {
                    result = false;
                }
            }

            if (result)
            {
                for (int i = 1; i < MarioTetrisModel.Map.GetLength(0) - 1; i++)
                {
                    MarioTetrisModel.Map[i, MarioTetrisModel.Map.GetLength(1) - 2] = null;
                }
            }
        }

        /// <summary>
        /// Initializing method.
        /// </summary>
        public void InitModel()
        {
            this.model.TileSize = Math.Min(this.model.GameWidth / 26, this.model.GameHeight / 16);
            for (int i = 0; i < MarioTetrisModel.Map.GetLength(0); i++)
            {
                for (int j = 0; j < MarioTetrisModel.Map.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || j == 3 || i == 25 || j == 15)
                    {
                        MarioTetrisModel.Map[i, j] = new GameObject(GameModel.Enums.Types.Wall, i, j);
                    }
                }
            }

            MarioTetrisModel.Map[13, 14] = new Player(13, 14);
        }

        /// <summary>
        /// Updates all game item.
        /// </summary>
        public void Update()
        {
            foreach (GameItem item in MarioTetrisModel.Map)
            {
                if (item != null)
                {
                    if (item.Type == Enums.Types.Player)
                    {
                        if (item.WaitTime >= 0)
                        {
                            if (item.CheckSurrounding(Enums.Directions.Dowm).Type == Enums.Types.Empty)
                            {
                                item.WaitTime = (int)Enums.WaitTime.PlayerJump;
                            }
                            else if (this.inputs.Count != 0)
                            {
                                if ((item as Player).lastMove == Enums.Directions.Up)
                                {
                                    item.WaitTime = (int)Enums.WaitTime.PlayerRecover;
                                    (item as Player).lastMove = Enums.Directions.Null;
                                }
                                else
                                {
                                    Enums.Directions input = this.inputs.Dequeue();
                                    Enums.Types result = item.Push(input);
                                    if (result == Enums.Types.Empty)
                                    {
                                        (item as Player).lastMove = input;
                                        input = Enums.Directions.Null;
                                    }
                                    else if (result == Enums.Types.Block)
                                    {
                                        GameObject block = (GameObject)item.CheckSurrounding(input);
                                        if ((block.CheckSurrounding(Enums.Directions.Up).Type == Enums.Types.Empty) && (block.CheckSurrounding(input).Type == Enums.Types.Empty))
                                        {
                                            if (block.CheckSurrounding(Enums.Directions.Dowm).Type != Enums.Types.Empty)
                                            {
                                                if (block.Push(input) == Enums.Types.Empty)
                                                {
                                                    if (item.Push(input) == Enums.Types.Empty)
                                                    {
                                                        (item as Player).lastMove = input;
                                                        input = Enums.Directions.Null;
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
                                item.Push(Enums.Directions.Dowm);
                            }
                            else if (this.inputs.Count != 0)
                            {
                                Enums.Directions input = this.inputs.Dequeue();

                                if ((item as Player).lastMove == Enums.Directions.Up && (input == Enums.Directions.Right || input == Enums.Directions.Left))
                                {
                                    bool checkSurroundings_clear = false;
                                    if (input == Enums.Directions.Right && item.CheckSurrounding(Enums.Directions.LowerRight).Type == Enums.Types.Block)
                                    {
                                        checkSurroundings_clear = true;
                                    }
                                    else if (input == Enums.Directions.Left && item.CheckSurrounding(Enums.Directions.LowerLeft).Type == Enums.Types.Block)
                                    {
                                        checkSurroundings_clear = true;
                                    }

                                    if (checkSurroundings_clear)
                                    {
                                        Enums.Types result = item.Push(input);
                                        if (result == Enums.Types.Empty)
                                        {
                                            item.WaitTime = 0;
                                            (item as Player).lastMove = input;
                                        }
                                        else if (result == Enums.Types.Block)
                                        {
                                            GameObject block = (GameObject)item.CheckSurrounding(input);
                                            if ((block.CheckSurrounding(Enums.Directions.Up).Type == Enums.Types.Empty) && (block.CheckSurrounding(input).Type == Enums.Types.Empty))
                                            {
                                                if (block.CheckSurrounding(Enums.Directions.Dowm).Type != Enums.Types.Empty)
                                                {
                                                    if (block.Push(input) == Enums.Types.Empty)
                                                    {
                                                        if (item.Push(input) == Enums.Types.Empty)
                                                        {
                                                            (item as Player).lastMove = input;
                                                            input = Enums.Directions.Null;
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
                    else if (item.Type == Enums.Types.Block)
                    {
                        if (item.WaitTime >= 0)
                        {
                            if (item.CheckSurrounding(Enums.Directions.Dowm).Type == Enums.Types.Empty)
                            {
                                item.WaitTime = (int)Enums.WaitTime.Box;
                            }
                        }
                        else if (item.WaitTime != 0)
                        {
                            item.WaitTime += 5;
                            if (item.WaitTime == 0)
                            {
                                item.Push(Enums.Directions.Dowm);
                            }
                        }
                    }
                }
            }
        }
    }
}
