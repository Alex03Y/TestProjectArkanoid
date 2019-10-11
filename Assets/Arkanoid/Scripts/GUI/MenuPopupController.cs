using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arkanoid.GUI
{
    public class MenuPopupController : MonoBehaviour
    {
        [SerializeField] private Button ContinueBtn, RestartBtn, QuitBtn, MenuBtn;
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private Image Vignette;

        private Vector3 _tempPosition;

        //Button subscription
        private void Awake()
        {
            transform.localScale = Vector3.zero;
            RestartBtn.onClick.AddListener(() => 
            { 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                GameModel.ClearInstance();
            });
            
            QuitBtn.onClick.AddListener((() => Application.Quit()));
            ContinueBtn.onClick.AddListener(HidePopupMenu);
        }

        public void ShowPopupMenu()
        {
            _tempPosition = transform.localPosition;
            transform.DOScale(Vector3.one, 0.5f).SetEase(_animationCurve);
            transform.DOLocalMove(Vector3.one, 0.5f, false).SetEase(_animationCurve);
        }

        public void HidePopupMenu()
        {
            transform.DOScale(Vector3.zero, 0.5f).SetEase(_animationCurve);
            transform.DOLocalMove(_tempPosition, 0.5f, false).SetEase(_animationCurve).OnComplete(() =>
            {
                Vignette.gameObject.SetActive(false);
                Time.timeScale = 1;
            });
            
        }
    }
}