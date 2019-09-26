using System;
using UnityEngine;

namespace Arkanoid.Controllers
{
    public class BrickController : MonoBehaviour
    {
        public event Action OnDestroyed;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            GameModel.Instance().AddScore();
            GameModel.Instance().SetChanged();
            
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
