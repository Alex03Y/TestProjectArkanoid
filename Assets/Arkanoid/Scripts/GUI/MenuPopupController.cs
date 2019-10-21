using Arkanoid.MVC;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arkanoid.GUI
{
    public class MenuPopupController : MonoBehaviour, IObservable
    {
        [SerializeField] private Button ContinueBtn, RestartBtn, QuitBtn;
        [SerializeField] private AnimationCurve AnimationCurveShow, AnimationCurveHide;
        [SerializeField] private MenuPopupView MenuPopupView;
        [SerializeField] private RectTransform PopupSize, MenuBtn;
        [SerializeField] private float Duration = 0.5f;
        [SerializeField] private SubstrateController Substrate;
        [SerializeField] private ScoreController ScoreText;

        [Space] [Header("Debug")] [SerializeField]
        private float WidthPopup, HeightPopup, WidthMenuBtn, HeightMenuBtn;

        private CanvasGroup _canvasGroupPopup;
        private Vector3 _tempPosition, _tempScale;
        private GameModel _gameModel;

        //Button subscription
        private void Awake()
        {
            transform.localScale = Vector3.zero;

            transform.position = MenuBtn.position;

            var rectMenu = MenuBtn.rect;
            WidthMenuBtn = rectMenu.width;
            HeightMenuBtn = rectMenu.height;

            var rectPopup = PopupSize.rect;
            WidthPopup = rectPopup.width;
            HeightPopup = rectPopup.height;

            PopupSize.gameObject.SetActive(false);
            gameObject.SetActive(true);

            _canvasGroupPopup = GetComponent<CanvasGroup>();
            _canvasGroupPopup.alpha = 0f;

            RestartBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                GameModel.ClearInstance();
            });

            QuitBtn.onClick.AddListener((() => Application.Quit()));
            ContinueBtn.onClick.AddListener(HidePopupMenu);
        }

        private void Start()
        {
            _gameModel = GameModel.Instance();
            _gameModel.AddObserver(this);
        }

        public void ShowPopupMenu()
        {
            Substrate.SizeSubstrare(WidthPopup, HeightPopup, Duration, AnimationCurveShow);
            Substrate.MoveSubstrate(Vector3.one, Duration, AnimationCurveShow);
            ScoreText.HideScoreText(Duration, AnimationCurveShow);

            
            _tempPosition = transform.localPosition;
            _tempScale = transform.lossyScale;
            DOTween.To(() => _canvasGroupPopup.alpha, x => _canvasGroupPopup.alpha = x, 1f, Duration)
                .SetEase(AnimationCurveShow);
            transform.DOScale(Vector3.one, Duration).SetEase(AnimationCurveShow);
            transform.DOLocalMove(Vector3.one, Duration, false).SetEase(AnimationCurveShow);

        }

        public void HidePopupMenu()
        {
            Substrate.SizeSubstrare(WidthMenuBtn, HeightMenuBtn, Duration, AnimationCurveHide);
            Substrate.MoveSubstrate(_tempPosition, Duration, AnimationCurveHide);
            ScoreText.ShowScoreText(Duration,AnimationCurveHide);

            DOTween.To(() => _canvasGroupPopup.alpha, x => _canvasGroupPopup.alpha = x, 0f, Duration)
                .SetEase(AnimationCurveHide);
            transform.DOScale(_tempScale, Duration).SetEase(AnimationCurveHide);
            transform.DOLocalMove(_tempPosition, Duration, false).SetEase(AnimationCurveHide).OnComplete(() =>
            {
                MenuPopupView.HideVignette();
                Time.timeScale = 1;
            });
        }

        public void OnObjectChanged(IObserver observer)
        {
            if (_gameModel.GameEnd != GameModel.GameEndResult.NotEnded)
            {
                Substrate.gameObject.SetActive(false);
                MenuBtn.gameObject.SetActive(false);
                gameObject.SetActive(false);
                ScoreText.gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            _gameModel.RemoveObserver(this);
        }
    }
}