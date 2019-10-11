using Arkanoid.GUI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopapView : MonoBehaviour
{
    [SerializeField] private Image Vignette;
    [SerializeField] private MenuPopupController MenuPopupController;

    public void ShowVignette()
    {
        var color = Color.black;
        color.a *= 0f;
        Vignette.color = color;
        Vignette.gameObject.SetActive(true);
        
        //Showing the vignette and calling the function to show menu
        DOTween.ToAlpha(() => Vignette.color, x => Vignette.color = x, 0.5f, 0.2f)
            .OnComplete(() => MenuPopupController.ShowPopupMenu());
    }

}
