using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIDrawer : MonoBehaviour
{
    public Vector2 visiblePos, hiddenPos;
    public float durationSec = 0.5f;
    public Ease ease = Ease.InOutSine;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetVisible(bool visible)
    {
        var transition = rectTransform.DOAnchorPos(visible ? visiblePos : hiddenPos, durationSec).SetEase(ease);
    }
}
