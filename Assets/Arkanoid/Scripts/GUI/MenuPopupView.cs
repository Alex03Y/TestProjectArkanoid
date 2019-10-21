using Arkanoid;
using Arkanoid.GUI;
using Arkanoid.MVC;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopupView : MonoBehaviour, IObservable
{
    [SerializeField] private Image Vignette;
    [SerializeField] private MenuPopupController MenuPopupController;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Button MenuBtn;
    
    private GameModel _gameModel;
    private Vector3 _tempPosition;
    
    //Button subscription
    private void Awake()
    {
        var color = Color.white;
        color.a *= 0f;
        MenuBtn.GetComponent<Image>().color = color;
        Time.timeScale = 1f;
        _gameModel = GameModel.Instance();
        _gameModel.AddObserver(this);
        OnObjectChanged(_gameModel);
        MenuBtn.onClick.AddListener(() =>
        {
            ShowVignette();
            Time.timeScale = 0f;
        });
       
    }
    
    public void ShowVignette()
    {
        MenuBtn.interactable = false;
        var color = Color.black;
        color.a *= 0f;
        Vignette.color = color;
        Vignette.gameObject.SetActive(true);
        
        //Showing the vignette and calling the function to show menu
        DOTween.ToAlpha(() => Vignette.color, x => Vignette.color = x, 0.5f, 0.2f)
            .OnComplete(() => MenuPopupController.ShowPopupMenu());

    }

    public void HideVignette()
    {
        DOTween.ToAlpha(() => Vignette.color, x => Vignette.color = x, 0f, 0.2f)
            .OnComplete(()=>
            {
                Vignette.gameObject.SetActive(false);
                MenuBtn.interactable = true;
            });
    }

    private void OnDestroy()
    {
        _gameModel.RemoveObserver(this);
    }
    
    //Shows the result
    public void OnObjectChanged(IObserver observer)
    {
        ScoreText.text = "Score: " + _gameModel.Score;
    }

}
