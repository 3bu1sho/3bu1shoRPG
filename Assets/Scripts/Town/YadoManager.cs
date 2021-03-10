using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class YadoManager : MonoBehaviour
{

    public GameObject backToTownButton;

    public GameObject toPartButton;

    public GameObject toYadoButton;
    public GameObject chottoButton;
    public GameObject maamaaButton;
    public GameObject gatturiButton;
    public GameObject tansakuButton;
    public GameObject chottoYesButton;
    public GameObject maamaaYesButton;
    public GameObject gatturiYesButton;
    public GameObject yadoNoButton;
    public GameObject toBlacksmithButton;

    public CanvasGroup canvasGroup;
    public TownManager town;

    public void FadeOut()
    {
        SoundManager.instance.PlaySE(0);
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 0.8f)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0, 0.8f)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }


    public void OnBackToTownButton()
    {
        BackToTownYado();
    }

    public void BackToTownYado()
    {
        chottoButton.SetActive(false);
        maamaaButton.SetActive(false);
        gatturiButton.SetActive(false);
        chottoYesButton.SetActive(false);
        maamaaYesButton.SetActive(false);
        gatturiYesButton.SetActive(false);
        yadoNoButton.SetActive(false);
        backToTownButton.SetActive(false);
    }

    public void OnToYadoButton()
    {
        backToTownButton.SetActive(true);
        ShowOtomariButton();
        town.OnToMarumaruButton();
        tansakuButton.SetActive(false);
        SoundManager.instance.PlaySE(0);
    }

    void ShowOtomariButton()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "さて、どれくらい休もうかな。" });
        chottoButton.SetActive(true);
        maamaaButton.SetActive(true);
        gatturiButton.SetActive(true);
    }

    public void OnChottoButton()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "ちょっと休もう。\n*まがチケを10枚消費します。" });
        chottoYesButton.SetActive(true);
        yadoNoButton.SetActive(true);
        chottoButton.SetActive(false);
        maamaaButton.SetActive(false);
        gatturiButton.SetActive(false);
        maamaaYesButton.SetActive(false);
        gatturiYesButton.SetActive(false);
        backToTownButton.SetActive(false);
        SoundManager.instance.PlaySE(0);
    }

    public void OnMaamaaButton()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "そこそこ休もう。\n*まがチケを18枚消費します。" });

        maamaaYesButton.SetActive(true);
        yadoNoButton.SetActive(true);
        chottoButton.SetActive(false);
        maamaaButton.SetActive(false);
        gatturiButton.SetActive(false);
        chottoYesButton.SetActive(false);
        gatturiYesButton.SetActive(false);
        backToTownButton.SetActive(false);
        SoundManager.instance.PlaySE(0);

    }

    public void OnGatturiButton()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "めっちゃ休もう。\n*まがチケを25枚消費します。" });
        gatturiYesButton.SetActive(true);
        yadoNoButton.SetActive(true);
        chottoButton.SetActive(false);
        maamaaButton.SetActive(false);
        gatturiButton.SetActive(false);
        chottoYesButton.SetActive(false);
        maamaaYesButton.SetActive(false);
        backToTownButton.SetActive(false);
        SoundManager.instance.PlaySE(0);
    }

    int healHp;



    public void OnChottoYesButton()
    {
        BackToTownYado();
        healHp = PlayerManager.instance.maxHp*25/100+ PlayerManager.instance.luck;
        PlayerManager.instance.hp +=healHp;
        PlayerManager.instance.magaChike -= 10;
        if (PlayerManager.instance.hp>PlayerManager.instance.maxHp)
        {
            PlayerManager.instance.hp = PlayerManager.instance.maxHp;
        }
        FadeIOManager.instance.FadeOutToIn2();
        StartCoroutine(FadeInMan());
    }

    public void OnMaamaaYesButton()
    {
        BackToTownYado();
        healHp = PlayerManager.instance.maxHp * 50 / 100 + PlayerManager.instance.luck;
        PlayerManager.instance.hp +=healHp;
        PlayerManager.instance.magaChike -= 18;

        if (PlayerManager.instance.hp > PlayerManager.instance.maxHp)
        {
            PlayerManager.instance.hp = PlayerManager.instance.maxHp;
        }
        FadeIOManager.instance.FadeOutToIn2();
        StartCoroutine(FadeInMan());
    }

    public void OnGatturiYesButton()
    {
        BackToTownYado();

        healHp = PlayerManager.instance.maxHp * 80 / 100 + PlayerManager.instance.luck;
        PlayerManager.instance.hp +=healHp;
        PlayerManager.instance.magaChike -= 25;

        if (PlayerManager.instance.hp > PlayerManager.instance.maxHp)
        {
            PlayerManager.instance.hp = PlayerManager.instance.maxHp;
        }
        FadeIOManager.instance.FadeOutToIn2();
        StartCoroutine(FadeInMan());
    }

    IEnumerator FadeInMan()
    {
        yield return new WaitForSeconds(0.8f);
        DialogTextManager.instance.SetScenarios(new string[] { "休息が取れたのを感じる。\n今日も一日がんばろう。" });
        town.AfterAction();
        SoundManager.instance.PlaySE(7);


    }

    public void OnYadoNoButton()
    {
        chottoButton.SetActive(true);
        maamaaButton.SetActive(true);
        gatturiButton.SetActive(true);
        backToTownButton.SetActive(true);
        chottoYesButton.SetActive(false);
        maamaaYesButton.SetActive(false);
        gatturiYesButton.SetActive(false);
        yadoNoButton.SetActive(false);
        SoundManager.instance.PlaySE(0);
        DialogTextManager.instance.SetScenarios(new string[] { "さて、どれくらい休もうかな。" });
    }
}