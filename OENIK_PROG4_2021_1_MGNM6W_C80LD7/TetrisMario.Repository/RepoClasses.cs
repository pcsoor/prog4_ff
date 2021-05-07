using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TetrisMario.Model;

namespace TetrisMario.Repository
{
    public class Repo
    {
        public static string[] LoadHighscores()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TetrisMario.Repository.Highscores.txt");
            StreamReader sr = new StreamReader(stream);
            string[] lines = sr.ReadToEnd().Replace("\r", "").Split('\n');
            return lines;
        }

        public void SaveHighScores()
        {
            StreamWriter sw = new StreamWriter("TetrisMario.Repository.Highscores.txt");
            sw.WriteLine(GameModel.HighScore.ToString() + " - " + GameModel.PlayerName);
            sw.Flush();
            sw.Close();
        }

        public void Save()
        {
            StreamWriter sw = new StreamWriter("TetrisMario.Repository.Save.txt");
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
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TetrisMario.Repository.Save.txt");
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
    }
}
