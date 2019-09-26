using System.Collections.Generic;
using Arkanoid.Controllers;
using UnityEngine;

namespace Arkanoid
{
    public class LevelBuilder : MonoBehaviour
    {
        [SerializeField] private BrickController BrickPrefab;
        [SerializeField] private int Width, Height;
        [SerializeField] private float Spacing;

        private float _sizeX, _sizeY;
        private int _brickCounter;

        private void Start()
        {
            var brickContainerParent = transform;
        
            var scalePrefab = BrickPrefab.transform.lossyScale;
            var sizePrefab = BrickPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size;
        
            _sizeX = sizePrefab.x * scalePrefab.x + Spacing;
            _sizeY = sizePrefab.y * scalePrefab.y + Spacing;

            int counterX = 0;

            var bricks = new List<Transform>();
            var bricksBounds = new Bounds();

            #region Double cycle && score logics
            
            for (int x = 0; x < Width; x++)
            {
                int counterY = 0;
            
                for (int y = 0; y < Height; y++)
                {
                    var brickController = Instantiate(BrickPrefab);
                    var brickTransform = brickController.transform;
                    bricks.Add(brickTransform);
                    brickTransform.position = new Vector3(x + (counterX * _sizeX), y + (counterY * _sizeY), 0);
                    brickTransform.parent = brickContainerParent;
                    counterY++;
                
                    bricksBounds.Encapsulate(brickTransform.position);

                    _brickCounter++;
                    brickController.OnDestroyed += () =>
                    {
                        _brickCounter--;
                        if (_brickCounter == 0)
                        {
                            GameModel.Instance().EndGame(true);
                            GameModel.Instance().SetChanged();
                        }
                    };

                }
                counterX++;
            }
            #endregion 
            
            // bricks position correction
            foreach (var brick in bricks)
            {
                brick.transform.position -= (bricksBounds.center - new Vector3(0f, bricksBounds.size.y * 1.2f, 0f));
            }
        }
    }
}
