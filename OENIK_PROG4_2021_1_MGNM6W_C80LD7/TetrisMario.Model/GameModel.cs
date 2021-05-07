// <copyright file="GameModel.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Model
{
    /// <summary>
    /// Model class.
    /// </summary>
    public class GameModel : IGameModel
    {
        private static GameItem[,] map = new GameItem[26, 16];
        private readonly bool gameOver;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// </summary>
        /// <param name="w">width of the game.</param>
        /// <param name="h">height of the game.</param>
        public GameModel(double w, double h)
        {
            this.GameWidth = w;
            this.GameHeight = h;
            GameModel.BlockStormActive = 0;
            GameModel.MetalBlocksOnly = 0;
            HighScore = 0;
            GameModel.PlayerLife = 1;
            GameModel.TimeLeftForDoubleJump = 0;
            GameModel.TimeLeftForDoublePush = 0;
            this.gameOver = false;
        }

        /// <summary>
        /// Gets or sets the highscore for the current game.
        /// </summary>
        public static int HighScore { get; set; }

        /// <summary>
        /// Gets or sets the time of the blocstorm.
        /// </summary>
        public static int BlockStormActive { get; set; }

        /// <summary>
        /// Gets or sets the time of the metal strorm event.
        /// </summary>
        public static int MetalBlocksOnly { get; set; }

        /// <summary>
        /// Gets or sets the players life.
        /// </summary>
        public static int PlayerLife { get; set; }

        /// <summary>
        /// Gets or sets the time left for the double jump power up.
        /// </summary>
        public static int TimeLeftForDoubleJump { get; set; }

        /// <summary>
        /// Gets or sets the time left for the double push power up.
        /// </summary>
        public static int TimeLeftForDoublePush { get; set; }

        /// <summary>
        /// Gets or sets the players name.
        /// </summary>
        public static string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        public static GameItem[,] Map
        {
            get { return map; }
            set { map = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the game is over or not.
        /// </summary>
        public static bool GameOver { get; set; }

        /// <summary>
        /// Gets game width.
        /// </summary>
        public double GameWidth { get; private set; }

        /// <summary>
        /// Gets game height.
        /// </summary>
        public double GameHeight { get; private set; }

        /// <summary>
        /// Gets or sets tile size.
        /// </summary>
        public double TileSize { get; set; }
    }
}
