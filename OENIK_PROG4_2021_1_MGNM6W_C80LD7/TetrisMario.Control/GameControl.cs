<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameControl/MarioTetrisControl.cs
﻿using GameModel;
using GameLogic;
using GameRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Input;
using System.Threading;
using System.Windows.Threading;
=======
﻿// <copyright file="GameControl.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Control/GameControl.cs

namespace TetrisMario.Control
{
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameControl/MarioTetrisControl.cs
    public class MarioTetrisControl : FrameworkElement
    {

        MarioTetrisModel model;
        MarioTetrisLogic logic;
        MarioTetrisRenderer renderer;
        Stopwatch stw;
        DispatcherTimer mainTimer;
=======
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using TetrisMario.Model;
    using TetrisMario.Renderer;

    /// <summary>
    /// Game control class.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        private IGameModel model;
        private IGameItem gameItem;
        private Logic.GameLogic logic;
        private GameRenderer renderer;
        private Stopwatch stw;
        private DispatcherTimer mainTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.MarioTetrisControl_Loaded;
        }
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Control/GameControl.cs

        public MarioTetrisControl()
        {
            Loaded += MarioTetrisControl_Loaded;
        }

        private void MarioTetrisControl_Loaded(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameControl/MarioTetrisControl.cs
            stw = new Stopwatch();
            model = new MarioTetrisModel(ActualWidth, ActualHeight);
            logic = new MarioTetrisLogic(model);
            renderer = new MarioTetrisRenderer(model);
=======
            this.stw = new Stopwatch();
            this.model = new GameModel(this.ActualWidth, this.ActualHeight);
            this.gameItem = new GameItem();
            this.logic = new Logic.GameLogic(this.model);
            this.renderer = new GameRenderer(this.model);
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Control/GameControl.cs

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += Win_KeyDown;
                mainTimer = new DispatcherTimer();
                mainTimer.Interval = TimeSpan.FromMilliseconds(1);
                mainTimer.Tick += timer_Tick;
                mainTimer.Start();
            }

            InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameControl/MarioTetrisControl.cs
                case Key.W: logic.Inputs.Enqueue(Enums.Directions.Up); break;
                case Key.S: logic.Inputs.Enqueue(Enums.Directions.Dowm); break;
                case Key.A: logic.Inputs.Enqueue(Enums.Directions.Left); break;
                case Key.D: logic.Inputs.Enqueue(Enums.Directions.Right); break;
=======
                case Key.W: this.logic.Inputs.Enqueue(Enumerators.Directions.Up); break;
                case Key.S: this.logic.Inputs.Enqueue(Enumerators.Directions.Down); break;
                case Key.A: this.logic.Inputs.Enqueue(Enumerators.Directions.Left); break;
                case Key.D: this.logic.Inputs.Enqueue(Enumerators.Directions.Right); break;
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Control/GameControl.cs
            }

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (renderer != null) renderer.BuildDisplay(drawingContext);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            logic.SpawnBlock();
            logic.Update();
            logic.CheckIfBottomIsFull();
            InvalidateVisual();
        }
    }
}