using Arkanoid.MVC;
using TMPro;
using UnityEngine;

namespace Arkanoid.GUI
{
    public class ScoreView : MonoBehaviour, IObservable
    {
        [SerializeField] private TextMeshProUGUI ScoreText;
        
        private GameModel _gameModel;
    
        private void Awake()
        {
            _gameModel = GameModel.Instance();
            _gameModel.AddObserver(this);
            OnObjectChanged(_gameModel);
        }

        private void OnDestroy()
        {
            _gameModel.RemoveObserver(this);
        }

        public void OnObjectChanged(IObserver observer)
        {
            ScoreText.text = "Score: " + _gameModel.Score;
            if(_gameModel.GameEnd != GameModel.GameEndResult.NotEnded) ScoreText.text = "";
        }
    }
}
