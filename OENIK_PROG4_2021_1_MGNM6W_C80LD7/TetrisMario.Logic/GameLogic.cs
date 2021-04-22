// <copyright file="GameLogic.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using TetrisMario.Model;
    using static TetrisMario.Model.Enumerators;

    /// <summary>
    /// Game logic.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// Inputs.
        /// </summary>
        private static int nextBoxCounter;
        private Queue<Directions> inputs;
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
            this.inputs = new Queue<Directions>();
        }

        /// <summary>
        /// Gets key input.
        /// </summary>
        public Queue<Directions> Inputs
        {
            get
            {
                return this.inputs;
            }
        }

        public void Save()
        {
            string lines = string.Empty;
            for (int x = 0; x < GameModel.Map.GetLength(0); x++)
            {
                for (int y = 0; y < GameModel.Map.GetLength(1); y++)
                {
                    if (GameModel.Map[x, y] != null)
                    {
                        switch (GameModel.Map[x, y].Type)
                        {
                            case Enumerators.Types.Wall:
                                lines += '1';
                                break;
                            case Enumerators.Types.Player:
                                lines += '7';
                                break;
                            case Enumerators.Types.Block:
                                lines += '2';
                                break;
                            default:
                                lines += ' ';
                                break;
                        }
                    }
                }
            }

            File.WriteAllText(@"OENIK_PROG4_2021_1_MGNM6W_C80LD7.GameLogic", lines);
        }

        public void Load()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("OENIK_PROG4_2021_1_MGNM6W_C80LD7.GameLogic.Save.txt");
            StreamReader sr = new StreamReader(stream);
            string[] lines = sr.ReadToEnd().Replace("\r", "").Split('\n');
            for (int x = 0; x < GameModel.Map.GetLength(0); x++)
            {
                for (int y = 0; y < GameModel.Map.GetLength(1); y++)
                {
                    char current = lines[y][x];
                    switch (current)
                    {
                        case '1':
                            GameModel.Map[x, y] = new GameObject(Enumerators.Types.Wall, x, y);
                            break;
                        case '7':
                            GameModel.Map[x, y] = new Player(x, y);
                            break;
                        case '2':
                            GameModel.Map[x, y] = new GameObject(Enumerators.Types.Block, x, y);
                            break;
                        default:
                            GameModel.Map[x, y] = null;
                            break;
                    }
                }
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
                int randomBlockType = rnd.Next(1, 100);
                if (randomBlockType <= 70)
                {
                    GameModel.Map[randomNumber, 4] = new GameObject(Types.Block, randomNumber, 4);
                }
                else if ( randomBlockType < 95 && randomBlockType > 70)
                {
                    GameModel.Map[randomNumber, 4] = new GameObject(Types.Metal, randomNumber, 4);
                }
                else if (randomBlockType >= 95)
                {
                    GameModel.Map[randomNumber, 4] = new GameObject(Types.PowerUp, randomNumber, 4);
                }

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
                if (GameModel.Map[i, GameModel.Map.GetLength(1) - 2] == null || GameModel.Map[i, GameModel.Map.GetLength(1) - 2].Type == Types.Player)
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

                GameModel.HighScore += 1000;
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
                        GameModel.Map[i, j] = new GameObject(Types.Wall, i, j);
                    }
                }
            }

            GameModel.Map[13, 14] = new Player(13, 14);
        }

        public void Shoot(Player player)
        {
            if (player.canShoot)
            {
                for (int i = player.Y + 1; i > 4; i--)
                {
                    if (GameModel.Map[player.X, i] != null)
                    {
                        if (GameModel.Map[player.X, i].Type == Enumerators.Types.Block)
                        {
                            GameModel.Map[player.X, i] = null;
                        }
                        else if (GameModel.Map[player.X, i].Type == Enumerators.Types.PowerUp)
                        {

                        }
                    }
                }
            }
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
                    if (item.Type == Types.Player)
                    {
                        if (item.WaitTime >= 0)
                        {
                            if (item.CheckSurrounding(Directions.Down).Type == Types.Empty)
                            {
                                item.WaitTime = (int)WaitTime.PlayerJump;
                            }
                            else if (this.inputs.Count != 0)
                            {
                                if ((item as Player).LastMove == Directions.Up)
                                {
                                    item.WaitTime = (int)WaitTime.PlayerRecover;
                                    (item as Player).LastMove = Directions.Null;
                                }
                                else
                                {
                                    Directions input = this.inputs.Dequeue();
                                    if (input == Directions.Shoot)
                                    {
                                        this.Shoot((Player)item);
                                    }
                                    else if (true)
                                    {
                                        Types result = item.Push(input);
                                        if (result == Types.Empty)
                                        {
                                            (item as Player).LastMove = input;
                                            input = Directions.Null;
                                        }
                                        else if (result == Types.Block)
                                        {
                                            GameObject block = (GameObject)item.CheckSurrounding(input);
                                            if ((block.CheckSurrounding(Directions.Up).Type == Types.Empty) && (block.CheckSurrounding(input).Type == Types.Empty))
                                            {
                                                if (block.CheckSurrounding(Directions.Down).Type != Types.Empty)
                                                {
                                                    if (block.Push(input) == Types.Empty)
                                                    {
                                                        if (item.Push(input) == Types.Empty)
                                                        {
                                                            (item as Player).LastMove = input;
                                                            input = Directions.Null;
                                                        }
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
                                item.Push(Directions.Down);
                            }
                            else if (this.inputs.Count != 0)
                            {
                                Directions input = this.inputs.Dequeue();

                                if ((item as Player).LastMove == Directions.Up && (input == Directions.Right || input == Directions.Left))
                                {
                                    bool checkSurroundings_clear = false;
                                    if (input == Directions.Right && item.CheckSurrounding(Directions.LowerRight).Type != Types.Empty)
                                    {
                                        checkSurroundings_clear = true;
                                    }
                                    else if (input == Directions.Left && item.CheckSurrounding(Directions.LowerLeft).Type != Types.Empty)
                                    {
                                        checkSurroundings_clear = true;
                                    }

                                    if (checkSurroundings_clear)
                                    {
                                        Types result = item.Push(input);
                                        if (result == Types.Empty)
                                        {
                                            item.WaitTime = 0;
                                            (item as Player).LastMove = input;
                                        }
                                        else if (result == Types.Block || result == Types.PowerUp)
                                        {
                                            GameObject block = (GameObject)item.CheckSurrounding(input);
                                            if ((block.CheckSurrounding(Directions.Up).Type == Types.Empty) && (block.CheckSurrounding(input).Type == Types.Empty))
                                            {
                                                if (block.CheckSurrounding(Directions.Down).Type != Types.Empty)
                                                {
                                                    if (block.Push(input) == Types.Empty)
                                                    {
                                                        if (item.Push(input) == Types.Empty)
                                                        {
                                                            (item as Player).LastMove = input;
                                                            input = Directions.Null;
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
                    else if (item.Type == Types.Block || item.Type == Types.Metal || item.Type == Types.PowerUp)
                    {
                        if (item.WaitTime >= 0)
                        {
                            if (item.CheckSurrounding(Directions.Down).Type == Types.Empty)
                            {
                                item.WaitTime = (int)WaitTime.Box;
                            }
                        }
                        else if (item.WaitTime != 0)
                        {
                            item.WaitTime += 5;
                            if (item.WaitTime == 0)
                            {
                                item.Push(Directions.Down);
                            }
                        }
                    }
                }
            }
        }
    }
}
