// <copyright file="GameRenderer.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Renderer
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using TetrisMario.Model;

    /// <summary>
    /// Game renderer class.
    /// </summary>
    public class GameRenderer
    {
        private IGameModel model;
        private Dictionary<string, Brush> myBrushes = new Dictionary<string, Brush>();
        private int oldLifeValue = -1;
        private FormattedText lifeText;
        private FormattedText stormActiveText;
        private FormattedText metalActiveText;
        private FormattedText doubleJumpActiveText;
        private FormattedText doublePushActiveText;
        private FormattedText highscore;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRenderer"/> class.
        /// </summary>
        /// <param name="model">model reference.</param>
        public GameRenderer(IGameModel model)
        {
            this.model = model;
        }

        public Brush BulletBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Bullet.bmp", false);
            }
        }

        /// <summary>
        /// Gets player's brush.
        /// </summary>
        public Brush PlayerBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Karakter.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush BlueBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Blue Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush BrownBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Brown Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GreenBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Green Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GreyBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Grey Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GoldBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Gold Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush BlueMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Blue Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GreenMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Green Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush BrownMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Brown Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GoldMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Gold Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GreyMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Grey Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush PowerUpBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Power Up.bmp", false);
            }
        }

        /// <summary>
        /// Gets wall's brush.
        /// </summary>
        public Brush WallBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Border.bmp", true);
            }
        }

        /// <summary>
        /// Returns a brush for a specific item.
        /// </summary>
        /// <param name="fname">file name.</param>
        /// <param name="isTiled">check if tiled.</param>
        /// <returns>brush.</returns>
        public Brush GetBrush(string fname, bool isTiled)
        {
            if (!this.myBrushes.ContainsKey(fname))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
                bmp.EndInit();
                ImageBrush ib = new ImageBrush(bmp);
                if (isTiled)
                {
                    ib.TileMode = TileMode.Tile;
                    ib.Viewport = new Rect(0, 0, this.model.TileSize, this.model.TileSize);
                    ib.ViewportUnits = BrushMappingMode.Absolute;
                }

                this.myBrushes[fname] = ib;
            }

            return this.myBrushes[fname];
        }

        private void DrawLifeText(DrawingContext ctx)
        {
            if (this.oldLifeValue != this.model.playerLife)
            {
                this.lifeText = new FormattedText(
                    "Life: "+ this.model.playerLife.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);
            }

            ctx.DrawText(this.lifeText, new Point(1.5 * this.model.TileSize, 1.5 * this.model.TileSize));
        }

        private void DrawBlockStormActive(DrawingContext ctx)
        {
            if (this.model.BlockStormActive >= 0)
            {
                this.stormActiveText = new FormattedText(
                    "BLOCKSTORM: - ",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);
            }
            else
            {
                this.stormActiveText = new FormattedText(
                    "BLOCKSTORM: ACTIVE",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);
            }

            ctx.DrawText(this.stormActiveText, new Point(3.5 * this.model.TileSize, 1.5 * this.model.TileSize));
        }

        private void DrawMetalActive(DrawingContext ctx)
        {
            if (this.model.MetalBlocksOnly >= 0)
            {
                this.metalActiveText = new FormattedText(
                    "Metal Blocks Only: - ",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);
            }
            else
            {
                this.metalActiveText = new FormattedText(
                    "Metal Blocks Only: ACTIVE",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);
            }

            ctx.DrawText(this.metalActiveText, new Point(8 * this.model.TileSize, 1.5 * this.model.TileSize));
        }

        private void DrawDoubleJumpActive(DrawingContext ctx)
        {
            if (this.model.timeLeftForDoubleJump < 0)
            {
                this.doubleJumpActiveText = new FormattedText(
                    "Double Jump: " + model.timeLeftForDoubleJump/1000,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);
            }
            else
            {
                this.doubleJumpActiveText = new FormattedText(
                    "Double Jump: 0",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);
            }

            ctx.DrawText(this.doubleJumpActiveText, new Point(15 * this.model.TileSize, 1.5 * this.model.TileSize));
        }

        private void DrawDoublePushActive(DrawingContext ctx)
        {
            if (this.model.timeLeftForDoublePush < 0)
            {
                this.doublePushActiveText = new FormattedText(
                    "Double Push: " + model.timeLeftForDoublePush / 1000,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);
            }
            else
            {
                this.doublePushActiveText = new FormattedText(
                    "Double Push: 0",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);
            }

            ctx.DrawText(this.doublePushActiveText, new Point(20 * this.model.TileSize, 1.5 * this.model.TileSize));
        }

        private void Highscore(DrawingContext ctx)
        {
            this.highscore = new FormattedText(
                    "Score: " + GameModel.HighScore,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    26,
                    Brushes.Black,
                    2);

            ctx.DrawText(this.highscore, new Point(13 * this.model.TileSize, 1 * this.model.TileSize));
        }

        /// <summary>
        /// Builder method.
        /// </summary>
        /// <param name="ctx">drawing context.</param>
        public void BuildDisplay(DrawingContext ctx)
        {
            if (ctx != null)
            {
                for (int x = 0; x < GameModel.Map.GetLength(0); x++)
                {
                    for (int y = 0; y < GameModel.Map.GetLength(1); y++)
                    {
                        if (GameModel.Map[x, y] != null)
                        {
                            Geometry box = new RectangleGeometry(new Rect(x * this.model.TileSize, y * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                            if (GameModel.Map[x, y].Type == Enumerators.Types.Block)
                            {
                                if (GameModel.Map[x, y].Color == 1)
                                {
                                    ctx.DrawGeometry(this.BlueBlockBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 2)
                                {
                                    ctx.DrawGeometry(this.GreenBlockBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 3)
                                {
                                    ctx.DrawGeometry(this.GoldBlockBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 4)
                                {
                                    ctx.DrawGeometry(this.GreyBlockBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 5)
                                {
                                    ctx.DrawGeometry(this.BrownBlockBrush, null, box);
                                }
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.Metal)
                            {
                                if (GameModel.Map[x, y].Color == 1)
                                {
                                    ctx.DrawGeometry(this.BlueMetalBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 2)
                                {
                                    ctx.DrawGeometry(this.GreenMetalBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 3)
                                {
                                    ctx.DrawGeometry(this.GoldMetalBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 4)
                                {
                                    ctx.DrawGeometry(this.GreyMetalBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 5)
                                {
                                    ctx.DrawGeometry(this.BrownMetalBrush, null, box);
                                }
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.PowerUp)
                            {
                                ctx.DrawGeometry(this.PowerUpBrush, null, box);
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.Wall)
                            {
                                ctx.DrawGeometry(this.WallBrush, null, box);
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.Player)
                            {
                                ctx.DrawGeometry(this.PlayerBrush, null, box);
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.Bullet)
                            {
                                ctx.DrawGeometry(this.BulletBrush, null, box);
                            }
                        }
                    }
                }

                this.DrawLifeText(ctx);
                this.DrawBlockStormActive(ctx);
                this.DrawMetalActive(ctx);
                this.DrawDoubleJumpActive(ctx);
                this.DrawDoublePushActive(ctx);
                this.Highscore(ctx);
            }
        }
    }
}
