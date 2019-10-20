using System;
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

        private void Awake()
        {
            _gameModel = GameModel.Instance();
            _gameModel.AddObserver(this);
        }
        
        // I set static speed with help kick, because I'm used physics material, where bounciness = 1
        private void Start()
        {
//            var scaleBall = transform.localScale;
//            scaleBall *= _gameModel.ScaleFactor;
//            transform.localScale = scaleBall;
            var rndDirection = new Vector2(Random.Range(-1f, 1f), 1).normalized;
            Rigidbody2D.AddForce(rndDirection * Speed);
        }
        
        //Stop movement ball if the game to over; 
        public void OnObjectChanged(IObserver observer)
        {
            if (_gameModel.GameEnd == GameModel.GameEndResult.Winner)
                Rigidbody2D.velocity = Vector2.zero;
        }

        //Unsubscribing from game model
        private void OnDestroy()
        {
            _gameModel.RemoveObserver(this);
        }
    }
}
