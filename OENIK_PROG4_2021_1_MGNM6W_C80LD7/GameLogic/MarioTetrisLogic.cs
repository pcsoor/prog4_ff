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

    public class MarioTetrisLogic
    {
        private MarioTetrisModel model;
        static int nextBoxCounter;
        public Queue<Enums.Directions> Inputs;

        public MarioTetrisLogic(MarioTetrisModel model)
        {
            this.model = model;
            this.InitModel();
            nextBoxCounter = 0;
            Inputs = new Queue<Enums.Directions>();
        }

        public void InitModel()
        {
            model.TileSize = Math.Min(model.GameWidth / 26, model.GameHeight / 16);
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
                                item.WaitTime = (int)Enums.eWaitTime.PlayerJump;
                            }
                            else if (Inputs.Count != 0)
                            {
                                if ((item as Player).lastMove == Enums.Directions.Up)
                                {
                                    item.WaitTime = (int)Enums.eWaitTime.PlayerRecover;
                                    (item as Player).lastMove = Enums.Directions.Null;
                                }
                                else
                                {
                                    Enums.Directions input = Inputs.Dequeue();
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
                            else if (Inputs.Count != 0)
                            {
                                Enums.Directions input = Inputs.Dequeue();

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
                                item.WaitTime = (int)Enums.eWaitTime.Box;
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
