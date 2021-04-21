<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameLogic/MarioTetrisLogic.cs
﻿namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using GameModel;

    public class MarioTetrisLogic
    {
        private MarioTetrisModel model;
        static int nextBoxCounter;
        public Queue<Enums.Directions> Inputs;

        public MarioTetrisLogic(MarioTetrisModel model)
=======
﻿// <copyright file="GameLogic.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Logic
{
    using System;
    using System.Collections.Generic;
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
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Logic/GameLogic.cs
        {
            this.model = model;
            this.InitModel();
            nextBoxCounter = 0;
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameLogic/MarioTetrisLogic.cs
            Inputs = new Queue<Enums.Directions>();
        }

        public void InitModel()
        {
            model.TileSize = Math.Min(model.GameWidth / MarioTetrisModel.Map.GetLength(0), model.GameHeight / MarioTetrisModel.Map.GetLength(1));
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
=======
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
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Logic/GameLogic.cs
        }

        //public void Save()
        //{
        //    string lines = string.Empty;
        //    for (int x = 0; x < MarioTetrisModel.Map.GetLength(0); x++)
        //    {
        //        for (int y = 0; y < MarioTetrisModel.Map.GetLength(1); y++)
        //        {
        //            switch (MarioTetrisModel.Map[x, y].Type)
        //            {
        //                case Enums.Types.Wall:
        //                    lines += '1';
        //                    break;
        //                case Enums.Types.Player:
        //                    lines += '7';
        //                    break;
        //                case Enums.Types.Block:
        //                    lines += '2';
        //                    break;
        //                default:
        //                    lines += ' ';
        //                    break;
        //            }
        //        }
        //    }
        //    string docPath = "OENIK_PROG4_2021_1_MGNM6W_C80LD7.GameLogic";
        //    File.WriteAllText(docPath, lines);
        //}

        //public void Load()
        //{
        //    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("OENIK_PROG4_2021_1_MGNM6W_C80LD7.GameLogic.Save.txt");
        //    StreamReader sr = new StreamReader(stream);
        //    string[] lines = sr.ReadToEnd().Replace("\r", "").Split('\n');
        //    for (int x = 0; x < MarioTetrisModel.Map.GetLength(0); x++)
        //    {
        //        for (int y = 0; y < MarioTetrisModel.Map.GetLength(1); y++)
        //        {
        //            char current = lines[y][x];
        //            switch (current)
        //            {
        //                case '1':
        //                    MarioTetrisModel.Map[x, y] = new GameObject(Enums.Types.Wall, x, y);
        //                    break;
        //                case '7':
        //                    MarioTetrisModel.Map[x, y] = new Player(x, y);
        //                    break;
        //                case '2':
        //                    MarioTetrisModel.Map[x, y] = new GameObject(Enums.Types.Block, x, y);
        //                    break;
        //                default:
        //                    MarioTetrisModel.Map[x, y] = null;
        //                    break;
        //            }
        //        }
        //    }
        //}

        public void SpawnBlock()
        {
            if (nextBoxCounter == 0)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, GameModel.Map.GetLength(0) - 1);
                GameModel.Map[randomNumber, 4] = new GameObject(Types.Block, randomNumber, 4);
                nextBoxCounter = -500;
            }
            else
            {
                nextBoxCounter += 5;
            }
        }

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
            }
        }

<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameLogic/MarioTetrisLogic.cs
=======
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

        /// <summary>
        /// Updates all game item.
        /// </summary>
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Logic/GameLogic.cs
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
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameLogic/MarioTetrisLogic.cs
                                item.WaitTime = (int)Enums.eWaitTime.PlayerJump;
=======
                                item.WaitTime = (int)WaitTime.PlayerJump;
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Logic/GameLogic.cs
                            }
                            else if (Inputs.Count != 0)
                            {
                                if ((item as Player).LastMove == Directions.Up)
                                {
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameLogic/MarioTetrisLogic.cs
                                    item.WaitTime = (int)Enums.eWaitTime.PlayerRecover;
                                    (item as Player).lastMove = Enums.Directions.Null;
                                }
                                else
                                {
                                    Enums.Directions input = Inputs.Dequeue();
                                    Enums.Types result = item.Push(input);
                                    if (result == Enums.Types.Empty)
=======
                                    item.WaitTime = (int)WaitTime.PlayerRecover;
                                    (item as Player).LastMove = Directions.Null;
                                }
                                else
                                {
                                    Directions input = this.inputs.Dequeue();
                                    Types result = item.Push(input);
                                    if (result == Types.Empty)
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Logic/GameLogic.cs
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
                        else if (item.WaitTime != 0)
                        {
                            item.WaitTime += 5;
                            if (item.WaitTime == 0)
                            {
                                item.Push(Directions.Down);
                            }
                            else if (Inputs.Count != 0)
                            {
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameLogic/MarioTetrisLogic.cs
                                Enums.Directions input = Inputs.Dequeue();
=======
                                Directions input = this.inputs.Dequeue();
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Logic/GameLogic.cs

                                if ((item as Player).LastMove == Directions.Up && (input == Directions.Right || input == Directions.Left))
                                {
                                    bool checkSurroundings_clear = false;
                                    if (input == Directions.Right && item.CheckSurrounding(Directions.LowerRight).Type == Types.Block)
                                    {
                                        checkSurroundings_clear = true;
                                    }
                                    else if (input == Directions.Left && item.CheckSurrounding(Directions.LowerLeft).Type == Types.Block)
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
                    }
                    else if (item.Type == Types.Block)
                    {
                        if (item.WaitTime >= 0)
                        {
                            if (item.CheckSurrounding(Directions.Down).Type == Types.Empty)
                            {
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameLogic/MarioTetrisLogic.cs
                                item.WaitTime = (int)Enums.eWaitTime.Box;
=======
                                item.WaitTime = (int)WaitTime.Box;
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Logic/GameLogic.cs
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
