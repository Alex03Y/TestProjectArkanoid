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

        public int Score { get; private set; }
        public GameEndResult GameEnd { get; private set; }

        public void AddScore()
        {
            Score++;
            _bricksCount--;
            if (_bricksCount == 0)
            {
                EndGame(true);
                SetChanged();
            }
        }

        public void EndGame(bool winner)
        {
            GameEnd = winner ? GameEndResult.Winner : GameEndResult.Looser;
        }

        private static int _bricksCount;

        public void SetBricksCount(int count)
        {
            _bricksCount = count;
        }
    }
}
