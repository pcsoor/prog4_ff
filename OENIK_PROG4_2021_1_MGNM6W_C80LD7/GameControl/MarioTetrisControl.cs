using GameModel;
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

namespace GameControl
{
    public class MarioTetrisControl : FrameworkElement
    {

        MarioTetrisModel model;
        MarioTetrisLogic logic;
        MarioTetrisRenderer renderer;
        Stopwatch stw;
        DispatcherTimer mainTimer;

        public MarioTetrisControl()
        {
            Loaded += MarioTetrisControl_Loaded;
        }

        private void MarioTetrisControl_Loaded(object sender, RoutedEventArgs e)
        {
            stw = new Stopwatch();
            model = new MarioTetrisModel(ActualWidth, ActualHeight);
            logic = new MarioTetrisLogic(model);
            renderer = new MarioTetrisRenderer(model);

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
                case Key.W: logic.Inputs.Enqueue(Enums.Directions.Up); break;
                case Key.S: logic.Inputs.Enqueue(Enums.Directions.Dowm); break;
                case Key.A: logic.Inputs.Enqueue(Enums.Directions.Left); break;
                case Key.D: logic.Inputs.Enqueue(Enums.Directions.Right); break;
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