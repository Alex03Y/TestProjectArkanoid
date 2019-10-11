using Arkanoid.MVC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.GUI
{
    public class ScoreView : MonoBehaviour, IObservable
    {
        [SerializeField] private TextMeshProUGUI ScoreText;
        [SerializeField] private Button MenuBtn;
        [SerializeField] private MenuPopapView _menuPopapView;
        
        private GameModel _gameModel;
        
        //Button subscription
        private void Awake()
        {
            MenuBtn.gameObject.SetActive(true);
            Time.timeScale = 1f;
            _gameModel = GameModel.Instance();
            _gameModel.AddObserver(this);
            OnObjectChanged(_gameModel);
            MenuBtn.onClick.AddListener(() =>
            {
                _menuPopapView.ShowVignette();
                Time.timeScale = 0f;
            });
        }

        private void OnDestroy()
        {
            _gameModel.RemoveObserver(this);
        }
    
        //Shows the result
        public void OnObjectChanged(IObserver observer)
        {
            ScoreText.text = "Score: " + _gameModel.Score;
        }
    }
}
