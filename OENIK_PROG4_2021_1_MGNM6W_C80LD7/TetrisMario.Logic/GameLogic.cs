﻿// <copyright file="GameLogic.cs" company="MGNM6W_C80LD7">
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

        public void Save(string fname)
        {
            StreamWriter sw = new StreamWriter(fname);
            for (int y = 0; y < GameModel.Map.GetLength(1); y++)
            {
                for (int x = 0; x < GameModel.Map.GetLength(0); x++)
                {
                    if (GameModel.Map[x, y] != null)
                    {
                        string line = ((int)GameModel.Map[x, y].UiElement).ToString();
                        sw.Write(line);
                    }
                    else
                    {
                        string line = " ";
                        sw.Write(line);
                    }
                }

                sw.WriteLine();
            }

            sw.Flush();
            sw.Close();

        }

        public void Load()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Save.txt");
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
                        case '3':
                            GameModel.Map[x, y] = new GameObject(Enumerators.Types.Metal, x, y);
                            break;
                        case '4':
                            GameModel.Map[x, y] = new GameObject(Enumerators.Types.PowerUp, x, y);
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
                if (model.MetalBlocksOnly < 0)
                {
                    GameModel.Map[randomNumber, 4] = new GameObject(Types.Metal, randomNumber, 4);
                }
                else
                {
                    int randomBlockType = rnd.Next(1, 101);
                    if (randomBlockType <= 80)
                    {
                        GameModel.Map[randomNumber, 4] = new GameObject(Types.Block, randomNumber, 4);
                    }
                    else if (randomBlockType < 95 && randomBlockType > 80)
                    {
                        GameModel.Map[randomNumber, 4] = new GameObject(Types.Metal, randomNumber, 4);
                    }
                    else if (randomBlockType >= 95)
                    {
                        GameModel.Map[randomNumber, 4] = new GameObject(Types.PowerUp, randomNumber, 4);
                    }

                }

                if (model.BlockStormActive < 0)
                {
                    nextBoxCounter = (int)WaitTime.NextBlockBlockStorm;
                }
                else
                {
                    nextBoxCounter = (int)WaitTime.NextBlockBasic;
                }
            }
            else
            {
                nextBoxCounter += 5;
                model.MetalBlocksOnly += 5;
                model.BlockStormActive += 5;
            }
        }

        /// <summary>
        /// Check last layer of game area.
        /// </summary>
        public bool CheckIfBottomIsFull()
        {
            bool result = true;
            for (int i = 1; i < GameModel.Map.GetLength(0) - 1; i++)
            {
                if (GameModel.Map[i, GameModel.Map.GetLength(1) - 2] == null || GameModel.Map[i, GameModel.Map.GetLength(1) - 2].Type == Types.Player)
                {
                    result = false;
                    return result;
                }
            }

            if (result)
            {
                for (int i = 1; i < GameModel.Map.GetLength(0) - 1; i++)
                {
                    GameModel.Map[i, GameModel.Map.GetLength(1) - 2] = null;
                }

                GameModel.HighScore += (int)ScorePoints.BottomFull;
            }

            return result;
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

        public bool Shoot(Player player)
        {
            if (GameModel.Map[player.X, player.Y - 1] == null)
            {
                GameModel.Map[player.X, player.Y - 1] = new GameObject(Types.Bullet, player.X, player.Y - 1);
                return true;
            }

            return false;
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
                    if (item.Type == Types.Bullet)
                    {
                        if (item.WaitTime == 0)
                        {
                            Types result = item.Push(Directions.Up);
                            if (result == Types.Block)
                            {
                                GameModel.Map[item.X, item.Y] = null;
                                GameModel.Map[item.X, item.Y - 1] = null;
                            }
                            else if (result == Types.PowerUp)
                            {
                                GameModel.Map[item.X, item.Y] = null;
                                GameModel.Map[item.X, item.Y - 1] = null;
                                Random rnd = new Random();
                                int powerUpChance = rnd.Next(1, 4);
                                if (powerUpChance == 1)
                                {
                                    model.timeLeftForDoubleJump += (int)WaitTime.DoubleJump;
                                }
                                else if (powerUpChance == 2)
                                {
                                    model.playerLife += 1;
                                }
                                else
                                {
                                    model.timeLeftForDoublePush += (int)WaitTime.DoublePush;
                                }
                            }
                            else if (result == Types.Metal || result == Types.Wall)
                            {
                                GameModel.Map[item.X, item.Y] = null;
                            }

                            item.WaitTime = (int)WaitTime.BulletWaitTime;
                        }
                        else
                        {
                            item.WaitTime += 5;
                        }
                    }
                    else if (item.Type == Types.Player)
                    {
                        if (model.timeLeftForDoubleJump < 0)
                        {
                            model.timeLeftForDoubleJump += 5;
                        }

                        if (model.timeLeftForDoublePush < 0)
                        {
                            model.timeLeftForDoublePush += 5;
                        }

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
                                    else
                                    {
                                        Types result = item.Push(input);
                                        if (result == Types.Empty)
                                        {
                                            (item as Player).LastMove = input;
                                            input = Directions.Null;
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
                                            else if (model.timeLeftForDoublePush < 0 && (block.CheckSurrounding(Directions.Up).Type == Types.Empty) && (block.CheckSurrounding(input).Type == Types.Block || block.CheckSurrounding(input).Type == Types.PowerUp))
                                            {
                                                GameObject block2 = (GameObject)block.CheckSurrounding(input);
                                                if ((block2.CheckSurrounding(Directions.Up).Type == Types.Empty) && (block2.CheckSurrounding(input).Type == Types.Empty))
                                                {
                                                    if (block2.CheckSurrounding(Directions.Down).Type != Types.Empty)
                                                    {
                                                        if (block2.Push(input) == Types.Empty)
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
                                            else if (model.timeLeftForDoublePush < 0 && (block.CheckSurrounding(Directions.Up).Type == Types.Empty) && (block.CheckSurrounding(input).Type == Types.Block || block.CheckSurrounding(input).Type == Types.PowerUp))
                                            {
                                                GameObject block2 = (GameObject)block.CheckSurrounding(input);
                                                if ((block2.CheckSurrounding(Directions.Up).Type == Types.Empty) && (block2.CheckSurrounding(input).Type == Types.Empty))
                                                {
                                                    if (block2.CheckSurrounding(Directions.Down).Type != Types.Empty)
                                                    {
                                                        if (block2.Push(input) == Types.Empty)
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
                                else if (model.timeLeftForDoubleJump < 0 && (item as Player).LastMove == Directions.Up)
                                {
                                    if (item.Y + 2 < GameModel.Map.GetLength(1))
                                    {
                                        if (GameModel.Map[item.X, item.Y + 2] != null || GameModel.Map[item.X, item.Y + 1] != null)
                                        {
                                            Types result = item.Push(input);
                                            if (result == Types.Empty)
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
                    else if (item.Type == Types.Block || item.Type == Types.Metal || item.Type == Types.PowerUp)
                    {
                        if (item.WaitTime >= 0)
                        {
                            if (item.CheckSurrounding(Directions.Down).Type == Types.Empty)
                            {
                                item.WaitTime = (int)WaitTime.Box;
                            }
                            else if (item.CheckSurrounding(Directions.Down).Type == Types.Player)
                            {
                                GameModel.Map[item.X, item.Y] = null;
                                if (this.model.playerLife > 1)
                                {
                                    this.model.playerLife -= 1;
                                }
                                else
                                {
                                    this.model.GameOver = true;
                                }
                            }
                        }
                        else if (item.WaitTime != 0)
                        {
                            item.WaitTime += 5;
                            if (item.WaitTime == 0)
                            {
                                Types result = item.Push(Directions.Down);
                                if (result == Types.Player)
                                {
                                    GameModel.Map[item.X, item.Y] = null;
                                    if (this.model.playerLife > 1)
                                    {
                                        this.model.playerLife -= 1;
                                    }
                                    else
                                    {
                                        this.model.GameOver = true;
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
