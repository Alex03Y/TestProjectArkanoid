using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arkanoid.GUI
{
    public class EndGamePopupController : MonoBehaviour
    {
        [SerializeField] private Button RestartGameBtn;
        [SerializeField] private Button QuitBtn;
        [SerializeField] private TextMeshProUGUI EndGameText;
        [SerializeField] private AnimationCurve ShowAnimationCurve;

        [Multiline] public string WinnerMsg;
        [Multiline] public string LooserMsg;

        private void Awake()
        {
            RestartGameBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                GameModel.ClearInstance();
            });
            QuitBtn.onClick.AddListener(Application.Quit);
            transform.localScale = Vector3.zero;
        }

        public void Show(bool isWinner)
        {
            transform.DOScale(Vector3.one, 0.35f).SetEase(ShowAnimationCurve);
            EndGameText.text = isWinner ? WinnerMsg : LooserMsg;
            EndGameText.text += "\n<color=green>You result: " + GameModel.Instance().Score + "</color>";
        }
    }
}
