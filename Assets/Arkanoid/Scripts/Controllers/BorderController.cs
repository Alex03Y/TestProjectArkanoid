using UnityEngine;

namespace Arkanoid.Controllers
{
    public class BorderController : MonoBehaviour
    {
        [SerializeField] private Camera MainCamera;
        [SerializeField] private EdgeCollider2D EdgeCollider;
        [SerializeField] private float Scatter;
        
        /*
         Resize a border depending on the aspect ratio.
         And paint a collider for interaction with ball. 
        */
        private void Awake()
        {
            var sizeOnScreenSide = 1920f / Scatter;
            var sizeOnScreenTop = 1080f / Scatter;

            var scatterWidth = Screen.width / sizeOnScreenSide;
            var scatterHeight = Screen.height / sizeOnScreenTop;

            GetScreenPointsForBorder(out var screenPoints, scatterWidth, scatterHeight);
            ConvertScreenPointsToWorldPoints(ref screenPoints, MainCamera);
            EdgeCollider.points = screenPoints;
        }
        
        private void GetScreenPointsForBorder(out Vector2[] points, float width, float height)
        {
            points = new Vector2[4];
            points[0] = new Vector2(width, 0);
            points[1] = new Vector2(width, Screen.height - height);
            points[2] = new Vector2(Screen.width - width, Screen.height - height);
            points[3] = new Vector2(Screen.width - width, 0);
        }

        private void ConvertScreenPointsToWorldPoints(ref Vector2[] screenPoints, Camera mainCamera)
        {
            for (int i = 0; i < screenPoints.Length; i++)
            {
                screenPoints[i] = mainCamera.ScreenToWorldPoint(screenPoints[i]);
            }
        }
    }
}