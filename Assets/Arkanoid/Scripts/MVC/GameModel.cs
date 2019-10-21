using System;
using Arkanoid.MVC;

namespace Arkanoid
{
    public class GameModel : Observer
    {
        private static GameModel _instance;
        public static GameModel Instance()
        {
            if (_instance == null)
            {
                _instance = new GameModel();
            }
        
            return _instance;
        }

        public static void ClearInstance()
        {
            _instance = null;
        }

        public enum GameEndResult
        {
            NotEnded,
            Winner,
            Looser
        }
        
        public GameEndResult GameEnd { get; private set; }

        public int Score { get; private set; }
        
        public void AddScore()
        {
            Score++;
        }

        public void EndGame(bool winner)
        {
            GameEnd = winner ? GameEndResult.Winner : GameEndResult.Looser;
        }

        public int BricksCount { get; private set; }

        public void SetBricksCount(int count)
        {
            if (count == 0) throw new NotImplementedException("Number of bricks in the scene can not be zero"); 
            BricksCount = count;
        }

        public int WidthScreenDefault { get; private set;} 
        public int HeightScreenDefault { get; private set;}
        
        public void SetScreenSizeDefault(int width, int height)
        {
            if (width == 0 || height == 0) throw new Exception("Default screen width or height can not be zero");
            WidthScreenDefault = width;
            HeightScreenDefault = height;
        }
    }
}
