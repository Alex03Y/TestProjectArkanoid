using System.Collections.Generic;
using Arkanoid.Controllers;
using Arkanoid.MVC;
using UnityEngine;
using Random = System.Random;


namespace Arkanoid
{
    public class LevelBuilder : MonoBehaviour, IObservable
    {
        [SerializeField] private BrickController BrickPrefab;
        [SerializeField] private int Width, Height;
        [SerializeField] private float SpacingWight, SpacingHeight;
        [SerializeField] private Sprite[] _sprites = new Sprite[5]; 
        
        private GameModel _gameModel;
        private float _sizeX, _sizeY;
        
        private void Awake()
        {
            _gameModel = GameModel.Instance();
            _gameModel.AddObserver(this);
            _gameModel.SetBricksCount(Width * Height);
        }

        private void Start()
        {
            var brickContainerParent = transform;
            var rnd = new Random();
            
            //Sizing
            var scalePrefab = BrickPrefab.transform.lossyScale;
            var sizePrefab = BrickPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size;
            
            _sizeX = sizePrefab.x * scalePrefab.x + SpacingWight;
            _sizeY = sizePrefab.y * scalePrefab.y + SpacingHeight;

            
            var bricksTransformList = new List<Transform>();
            var bricksBound = new Bounds();
            
            //Double cycle and encapsulate all bricks in bound
            for (int y = 0; y < Height; y++)
            {
                BrickPrefab.GetComponent<SpriteRenderer>().sprite = _sprites[rnd.Next(0, _sprites.Length-1)];
                for (int x = 0; x < Width; x++)
                {
                    var brick = Instantiate(BrickPrefab);
                    var brickTransform = brick.transform;
                    bricksTransformList.Add(brickTransform);
                    brickTransform.position = new Vector3(_sizeX * x, _sizeY * y, 0f);
                    brickTransform.parent = brickContainerParent;
                    bricksBound.Encapsulate(brickTransform.position);
                }
            }

            // Correction bricks position 
            foreach (var brick in bricksTransformList)
            {
                brick.transform.position -= (bricksBound.center - new Vector3(0f, bricksBound.size.y / 2f, 0f));
            }
        }


        public void OnObjectChanged(IObserver observer)
        {
            if (_gameModel.Score == _gameModel.BricksCount)
            {
                _gameModel.SetBricksCount(_gameModel.Score + 1);
                _gameModel.EndGame(true);
                _gameModel.SetChanged();
            }
        }
    }
}
