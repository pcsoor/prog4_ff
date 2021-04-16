// <copyright file="MarioTetrisControl.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace GameControl
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using GameLogic;
    using GameModel;
    using GameRenderer;

    /// <summary>
    /// Game control class.
    /// </summary>
    public class MarioTetrisControl : FrameworkElement
    {
        private MarioTetrisModel model;
        private MarioTetrisLogic logic;
        private MarioTetrisRenderer renderer;
        private Stopwatch stw;
        private DispatcherTimer mainTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarioTetrisControl"/> class.
        /// </summary>
        public MarioTetrisControl()
        {
            this.Loaded += this.MarioTetrisControl_Loaded;
        }

        /// <summary>
        /// Calls renderer.
        /// </summary>
        /// <param name="drawingContext">drawing context.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                this.renderer.BuildDisplay(drawingContext);
            }
        }

        private void MarioTetrisControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.stw = new Stopwatch();
            this.model = new MarioTetrisModel(this.ActualWidth, this.ActualHeight);
            this.logic = new MarioTetrisLogic(this.model);
            this.renderer = new MarioTetrisRenderer(this.model);

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += this.Win_KeyDown;
                this.mainTimer = new DispatcherTimer();
                this.mainTimer.Interval = TimeSpan.FromMilliseconds(1);
                this.mainTimer.Tick += this.TimerTick;
                this.mainTimer.Start();
            }

            this.InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W: this.logic.inputs.Enqueue(Enums.Directions.Up); break;
                case Key.S: this.logic.inputs.Enqueue(Enums.Directions.Dowm); break;
                case Key.A: this.logic.inputs.Enqueue(Enums.Directions.Left); break;
                case Key.D: this.logic.inputs.Enqueue(Enums.Directions.Right); break;
            }

            this.InvalidateVisual();
        }

        /// <summary>
        /// one tick in game.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">event.</param>
        private void TimerTick(object sender, EventArgs e)
        {
            this.logic.SpawnBlock();
            this.logic.Update();
            this.logic.CheckIfBottomIsFull();
            this.InvalidateVisual();
        }
    }
}