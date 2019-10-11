using UnityEngine;

namespace Arkanoid.Controllers
{
    public class DeadZoneController : MonoBehaviour
    {
        [SerializeField] private EdgeCollider2D ZoneCollider2D;
        [SerializeField] private Camera Camera;
    

        //Paint a collider for dead zone;
        private void Awake()
        {
            GetPointsScreen(out var screenPoints);
            ConversionPointsToWorld(ref screenPoints);
            ZoneCollider2D.points = screenPoints;
        }
        
        // If player lose
        private void OnTriggerEnter2D(Collider2D other)
        {
            var ball = other.gameObject;
            ball.SetActive(false);
            Destroy(ball);
            
            GameModel.Instance().EndGame(false);
            GameModel.Instance().SetChanged();
        }
        
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
    }
}
