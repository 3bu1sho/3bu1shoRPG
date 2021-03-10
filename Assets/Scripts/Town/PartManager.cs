using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour
{

    public TownManager town;
    //public GameObject partImage;
    public GameObject toYadoButton;
    public GameObject toKajiyaButton;
    public GameObject tankiPartButton;
    public GameObject chukiPartButton;
    public GameObject chokiPartButton;





    public GameObject toPartButton;
    public void OnPartButton()
    {
        town.antenCheck++;
        SoundManager.instance.PlaySE(0);
        FadeIOManager.instance.FadeOutToIn2();
        StartCoroutine(ShowPartPicture());    }

    IEnumerator ShowPartPicture()
    {
        yield return new WaitForSeconds(0.75f);
        //partImage.SetActive(true);
        town.OnToMarumaruButton();
        ShowPartButton();
        town.backToTownButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "デバッグおにいさん\n「お、何か働く気になったか。\n仕事なら山ほどあるぞ！」" });
    }

    void ShowPartButton()
    {
        tankiPartButton.SetActive(true);
        chukiPartButton.SetActive(true);
        chokiPartButton.SetActive(true);
    }

    void HidePartButton()
    {
        tankiPartButton.SetActive(false);
        chukiPartButton.SetActive(false);
        chokiPartButton.SetActive(false);
        SoundManager.instance.PlaySE(0);
    }

    public void HideAllPartButton()
    {
        tankiPartButton.SetActive(false);
        chukiPartButton.SetActive(false);
        chokiPartButton.SetActive(false);
        tankiYesButton.SetActive(false);
        chukiYesButton.SetActive(false);
        chokiYesButton.SetActive(false);
        noButton.SetActive(false);


    }


    //以下、ボタン押したときの処理。
    public GameObject tankiYesButton;

    public void OnTankiPartButton()
    {
        HidePartButton();
        tankiYesButton.SetActive(true);
        noButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "ちょっと働こう。\n*まがチケを10枚消費します。" });


    }

    public GameObject chukiYesButton;

    public void OnChukiPartButton()
    {
        HidePartButton();
        chukiYesButton.SetActive(true);
        noButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "ちょっと働こう。\n*まがチケを18枚消費します。" });

    }

    public GameObject chokiYesButton;


    public void OnChokiPartButton()
    {
        HidePartButton();
        chokiYesButton.SetActive(true);
        noButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "ちょっと働こう。\n*まがチケを25枚消費します。" });

    }

    public GameObject noButton;
    public void OnNoButton()
    {
        tankiYesButton.SetActive(false);
        chukiYesButton.SetActive(false);
        chokiYesButton.SetActive(false);
        noButton.SetActive(false);
        SoundManager.instance.PlaySE(0);
        ShowPartButton();
        DialogTextManager.instance.SetScenarios(new string[] { "デバッグおにいさん\n「なら、こっちの仕事はどうだろう」" });

    }

    public void OnTankiYesButton()
    {
        FadeIOManager.instance.FadeOutToIn2();
        PlayerManager.instance.magaChike -= 10;
        StartCoroutine(TankiPart());
        SoundManager.instance.PlaySE(0);

    }

    IEnumerator TankiPart()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerManager.instance.gold += 50+ PlayerManager.instance.luck;
        DialogTextManager.instance.SetScenarios(new string[] { "ちょっと働いた。\n今日も一日がんばろう。" });
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        HideAllPartButton();
        town.AfterAction();
        town.antenCheck--;
        SaveInt.instance.choker += 1;


    }

    public void OnChukiYesButton()
    {
        FadeIOManager.instance.FadeOutToIn2();
        PlayerManager.instance.magaChike -= 18;
        StartCoroutine(ChukiPart());
        SoundManager.instance.PlaySE(0);

    }

    IEnumerator ChukiPart()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerManager.instance.gold += 100 + PlayerManager.instance.luck;
        DialogTextManager.instance.SetScenarios(new string[] { "まあまあ働いた。\n今日も一日がんばろう。" });
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        HideAllPartButton();
        town.AfterAction();
        town.antenCheck--;
        SaveInt.instance.choker += 2;

    }

    public void OnChokiYesButton()
    {
        FadeIOManager.instance.FadeOutToIn2();
        PlayerManager.instance.magaChike -= 25;
        StartCoroutine(ChokiPart());
        SoundManager.instance.PlaySE(0);

    }

    IEnumerator ChokiPart()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerManager.instance.gold += 150 + PlayerManager.instance.luck;
        DialogTextManager.instance.SetScenarios(new string[] { "結構働いた。\n今日も一日がんばろう。" });
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        HideAllPartButton();
        town.AfterAction();
        town.antenCheck--;
        SaveInt.instance.choker += 3;

    }
}
