// <copyright file="Repo.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Repository
{
    using System.IO;
    using System.Reflection;
    using TetrisMario.Model;

    /// <summary>
    /// Class containing methods for saving and loading.
    /// </summary>
    public static class Repo
    {
        /// <summary>
        /// Method for loading the highscores.
        /// </summary>
        /// <returns>Returns the highscores.</returns>
        public static string[] LoadHighscores()
        {
            StreamReader sr = new StreamReader("Highscores.txt");
            string[] lines = sr.ReadToEnd().Replace("\r", string.Empty).Split('\n');
            sr.Close();
            return lines;
        }

        /// <summary>
        /// Saves the high scores into a file.
        /// </summary>
        public static void SaveHighScores()
        {
            if (!File.Exists("Highscores.txt"))
            {
                StreamWriter sw2 = new StreamWriter("Highscores.txt");
                sw2.Close();
            }

            StreamReader sr = new StreamReader("Highscores.txt");
            string[] lines = sr.ReadToEnd().Replace("\r", string.Empty).Split('\n');
            sr.Close();
            StreamWriter sw = new StreamWriter("Highscores.txt");
            sw.WriteLine(GameModel.HighScore.ToString());
            for (int i = 0; i < lines.Length; i++)
            {
                sw.WriteLine(lines[i]);
            }

            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// Saves the current state of the game into a file.
        /// </summary>
        public static void Save()
        {
            StreamWriter sw = new StreamWriter("Save.txt");
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

            sw.WriteLine(GameModel.PlayerLife);
            sw.WriteLine(GameModel.BlockStormActive);
            sw.WriteLine(GameModel.MetalBlocksOnly);
            sw.WriteLine(GameModel.TimeLeftForDoubleJump);
            sw.WriteLine(GameModel.TimeLeftForDoublePush);
            sw.WriteLine(GameModel.HighScore);
            sw.WriteLine(GameModel.PlayerName);

            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// Load the game model with the saved data.
        /// </summary>
        /// <param name="name">Name of the txt.</param>
        public static void Load(string name)
        {
            if (File.Exists(name))
            {
                StreamReader sr = new StreamReader(name);
                string[] lines = sr.ReadToEnd().Replace("\r", string.Empty).Split('\n');
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

                for (int i = GameModel.Map.GetLength(1); i < lines.Length; i++)
                {
                    if (lines[i] != null)
                    {
                        switch (i)
                        {
                            case 16:
                                GameModel.PlayerLife = int.Parse(lines[i]);
                                break;
                            case 17:
                                GameModel.BlockStormActive = int.Parse(lines[i]);
                                break;
                            case 18:
                                GameModel.MetalBlocksOnly = int.Parse(lines[i]);
                                break;
                            case 19:
                                GameModel.TimeLeftForDoubleJump = int.Parse(lines[i]);
                                break;
                            case 20:
                                GameModel.TimeLeftForDoublePush = int.Parse(lines[i]);
                                break;
                            case 21:
                                GameModel.HighScore = int.Parse(lines[i]);
                                break;
                            case 22:
                                GameModel.PlayerName = lines[i];
                                break;
                        }
                    }
                }
            }
        }
    }
}
