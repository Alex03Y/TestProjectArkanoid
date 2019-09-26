using Arkanoid.MVC;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Controllers
{
    public class BallController : MonoBehaviour, IObservable
    {
        [SerializeField] private float Speed;
        [SerializeField] private Rigidbody2D Rigidbody2D;

        private GameModel _gameModel;
    
        private void Start()
        {
            var rndDirection = new Vector2(Random.Range(-1f, 1f), 1).normalized;
            Rigidbody2D.AddForce(rndDirection * Speed);
            _gameModel = GameModel.Instance();
            _gameModel.AddObserver(this);
        }

        public void OnObjectChanged(IObserver observer)
        {
            if (_gameModel.GameEnd == GameModel.GameEndResult.Winner)
                Rigidbody2D.velocity = Vector2.zero;
        }

        private void OnDestroy()
        {
            _gameModel.RemoveObserver(this);
        }
    }
}
