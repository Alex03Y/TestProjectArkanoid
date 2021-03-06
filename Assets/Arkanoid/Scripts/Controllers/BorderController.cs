﻿using System;
using UnityEngine;

namespace Arkanoid.Controllers
{
    public class BorderController : MonoBehaviour
    {
        [SerializeField] private Camera MainCamera;
        [SerializeField] private EdgeCollider2D EdgeCollider;
        [Header("Size in pixel. Needs left or right border image")]
        [SerializeField] private RectTransform BorderImage;
        [Header("Debug")]
        [SerializeField]private float Scatter;

        private GameModel _gameModel;
        private int _widthScreenDefault, _heightScreenDefault;
        
        /*
         Resize a border depending on the aspect ratio.
         And paint a collider for interaction with ball. 
        */

        private void Awake()
        {
            _gameModel = GameModel.Instance();
        }

        private void Start()
        {
            _widthScreenDefault = _gameModel.WidthScreenDefault;
            _heightScreenDefault = _gameModel.HeightScreenDefault;
            var rectBorder = BorderImage.rect;
            Scatter = rectBorder.width >= rectBorder.height
                ? rectBorder.height
                : rectBorder.width;
            Scatter = Screen.width <= _widthScreenDefault ? Screen.width * (Scatter / _widthScreenDefault) : Screen.height * (Scatter / _heightScreenDefault); 

            GetScreenPointsForBorder(out var screenPoints, Scatter);
            ConvertScreenPointsToWorldPoints(ref screenPoints, MainCamera);
            EdgeCollider.points = screenPoints;
        }
        
        private void GetScreenPointsForBorder(out Vector2[] points, float scatter)
        {
            points = new Vector2[4];
            points[0] = new Vector2(scatter, 0);
            points[1] = new Vector2(scatter, Screen.height - scatter);
            points[2] = new Vector2(Screen.width - scatter, Screen.height - scatter);
            points[3] = new Vector2(Screen.width - scatter, 0);
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