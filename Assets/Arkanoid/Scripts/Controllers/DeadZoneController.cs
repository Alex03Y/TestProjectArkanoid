using UnityEngine;

namespace Arkanoid.Controllers
{
    public class DeadZoneController : MonoBehaviour
    {
        [SerializeField] private EdgeCollider2D ZoneCollider2D;
        [SerializeField] private Camera Camera;
    

        private void Awake()
        {
            //Paint a Collider for dead zone;
            GetPointsScreen(out var screenPoints);
            ConversionPointsToWorld(ref screenPoints);
            ZoneCollider2D.points = screenPoints;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var ball = other.gameObject;
            ball.SetActive(false);
            Destroy(ball);
            
            GameModel.Instance().EndGame(false);
            GameModel.Instance().SetChanged();
        }
    
        #region PaintColider
        private void GetPointsScreen(out Vector2[] points)
        {
            points = new Vector2[2];
            points[0] = new Vector2(0, 0); 
            points[1] = new Vector2(Screen.width, 0);
        }

        private void ConversionPointsToWorld(ref Vector2[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = Camera.ScreenToWorldPoint(new Vector3(points[i].x, points[i].y, 0));
            }
        }
        #endregion
    }
}
