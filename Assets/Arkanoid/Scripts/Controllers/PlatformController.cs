using System;
using Arkanoid.MVC;
using UnityEngine;

namespace Arkanoid.Controllers
{
    public class PlatformController : MonoBehaviour, IObservable
    {
        [SerializeField] private float Speed = 2f;
        [SerializeField] private EdgeCollider2D Border;

        private float _sizePlatform;
        private Transform _transform;
        private float _minPosX, _maxPosX;

        private GameModel _gameModel;

        private void Start()
        {
            _gameModel = GameModel.Instance();
            _gameModel.AddObserver(this);

            var scalePrefab = GetComponent<Transform>().lossyScale.x; 
            _sizePlatform = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x * scalePrefab;
            _sizePlatform /= 2f;

            var points = Border.points;
            _minPosX = points[0].x;
            _maxPosX = points[3].x;
        }

        private void Update()
        {
            var position = transform.position;
            
            position.x += Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            position.x = Mathf.Clamp(position.x, _minPosX + _sizePlatform, _maxPosX - _sizePlatform);
            
            transform.position = position;
        }

        private void OnDestroy()
        {
            _gameModel.RemoveObserver(this);
        }

        public void OnObjectChanged(IObserver observer)
        {
            if(_gameModel.GameEnd == GameModel.GameEndResult.NotEnded) return;
            enabled = false;
        }
    }
}
