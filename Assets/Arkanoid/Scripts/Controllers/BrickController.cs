using System;
using UnityEngine;

namespace Arkanoid.Controllers
{
    public class BrickController : MonoBehaviour
    {
        private GameModel _gameModel;
        
        [HideInInspector] public SpriteRenderer SpriteRenderer;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            _gameModel = GameModel.Instance();
            _gameModel.AddScore();
            _gameModel.SetChanged();
            Destroy(gameObject);
        }
    }
}
