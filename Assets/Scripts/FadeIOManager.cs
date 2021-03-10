using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIOManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeTime = 0.8f;
    public float deleyFadeTime = 0.81f;
    public float fastFadeTime = 0.79f;
    public static FadeIOManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, fadeTime)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0, fadeTime)
            .OnComplete(() => canvasGroup.blocksRaycasts=false);
    }
    public void FadeOutToIn(TweenCallback action)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, fadeTime)
            .OnComplete(() => {
                action();
                FadeIn();
            });
    }
    public void FadeOutToIn2()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, fadeTime)
            .OnComplete(() => {
                FadeIn();
            });
    }
}