using System;
using Arkanoid.MVC;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.GUI
{
    public class EndGamePopupView : MonoBehaviour, IObservable
    {
        [SerializeField] private EndGamePopupController EndGamePopupController;
        [SerializeField] private Image Vignette;
        [SerializeField] private float Duration = 0.35f;
    
        private GameModel _gameModel;

        private void Awake()
        {
            _gameModel = GameModel.Instance();
            _gameModel.AddObserver(this);
        }

        private void OnDestroy()
        {
            _gameModel.RemoveObserver(this);
        }

        public void OnObjectChanged(IObserver observer)
        {
            if (_gameModel.GameEnd != GameModel.GameEndResult.NotEnded)
            {
                //After ShowVignette
                ShowVignette(() =>
                {
                    var isWinner = _gameModel.GameEnd == GameModel.GameEndResult.Winner;
                    EndGamePopupController.Show(isWinner);
                });
            }
        }

        private void ShowVignette(Action onComplete)
        {
            var color = Color.black;
            color.a *= 0f;
            Vignette.color = color;
            Vignette.gameObject.SetActive(true);
        
            DOTween.ToAlpha(() => Vignette.color, x => Vignette.color = x, 0.5f, Duration)
                .OnComplete(() => onComplete?.Invoke());
        }
    }
}
