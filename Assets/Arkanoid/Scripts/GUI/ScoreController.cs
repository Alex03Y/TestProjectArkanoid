using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private RectTransform MenuBtn;
    [SerializeField] private AnimationCurve AnimationCurveHide, AnimationCurveShow;

    [SerializeField] private Vector3 SizeTextAnimtion = new Vector3(1.6f, 2.1f, 1f);

    private Vector3 _tempPosition;
    private TextMeshProUGUI _text;

    private void Start()
    {
        transform.position = MenuBtn.position;
        _text = GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(true);
    }

    public void HideScoreText(float duration, AnimationCurve animationCurve)
    {
        _tempPosition = transform.localPosition;
        transform.DOLocalMove(Vector3.one, duration, false).SetEase(animationCurve);
        transform.DOScale(SizeTextAnimtion, duration).SetEase(AnimationCurveHide)
            .OnComplete(() => transform.localScale = Vector3.one);
        DOTween.To(()=> _text.alpha, x => _text.alpha = x, 0f, duration).SetEase(AnimationCurveHide);
    }

    public void ShowScoreText(float duration, AnimationCurve animationCurve)
    {
        transform.DOLocalMove(_tempPosition, duration, false).SetEase(animationCurve);
        DOTween.To(()=> _text.alpha, x => _text.alpha = x, 1f, duration).SetEase(AnimationCurveShow);
    }
}
