using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SubstrateController : MonoBehaviour
{
    [SerializeField] private RectTransform MenuBtn;
    [SerializeField] private AnimationCurve DefaultAnimationCurve;

    private RectTransform _transform;
    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _transform.position = MenuBtn.position;
        
        var rectMenuBtn = MenuBtn.rect;
        _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectMenuBtn.width);
        _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectMenuBtn.height);
        gameObject.SetActive(true);
        MenuBtn.gameObject.SetActive(true);
    }

    public void SizeSubstrare(float width, float height, float duration, AnimationCurve animationCurve)
    { 
        if (animationCurve == null) animationCurve = DefaultAnimationCurve;
        DOTween.To(() => _transform.rect.width, x => _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x),
            width, duration).SetEase(animationCurve);
        DOTween.To(() => _transform.rect.height, x => _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, x),
            height, duration).SetEase(animationCurve);
    }

    public void MoveSubstrate(Vector3 point, float duration, AnimationCurve animationCurve)
    {
        _transform.DOLocalMove(point, duration, false).SetEase(animationCurve);
    }

}
