using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMapManager : MonoBehaviour
{
    public TownManager town;

    public GameObject noButton;


    public GameObject moriButton;
    public GameObject moriYesButton;
    public GameObject yukiButton;
    public GameObject yukiYesButton;
    public GameObject haikyoButton;
    public GameObject haikyoYesButton;


    public GameObject tansakuButton;
    public void OnTansakuButton()
    {
        SoundManager.instance.PlaySE(0);
        town.OnToMarumaruButton();
        town.backToTownButton.SetActive(true);
        ShowQuestMap();
        DialogTextManager.instance.SetScenarios(new string[] { "門番\n「どこか探索に出るのか。\n気をつけろよ」" });

    }

    void ShowQuestMap()
    {
        moriButton.SetActive(true);
        yukiButton.SetActive(true);
        haikyoButton.SetActive(true);

    }

    public void HideAllQuestButton()
    {
        moriButton.SetActive(false);
        yukiButton.SetActive(false);
        tansakuButton.SetActive(false);
        moriYesButton.SetActive(false);
        yukiYesButton.SetActive(false);
        haikyoButton.SetActive(false);
        haikyoYesButton.SetActive(false);

        noButton.SetActive(false);


    }

    public void OnNoButton()
    {
        HideAllQuestButton();
        ShowQuestMap();
        SoundManager.instance.PlaySE(0);
        DialogTextManager.instance.SetScenarios(new string[] { "門番\n「賢明な判断だな」" });



    }


    public void OnMoriButton()
    {
        HideAllQuestButton();
        moriYesButton.SetActive(true);
        noButton.SetActive(true);
        SoundManager.instance.PlaySE(0);
        DialogTextManager.instance.SetScenarios(new string[] { "門番\n「駆け出し冒険者はまずここだな。\nだが、準備は念入りにな」\n難易度:★☆☆☆☆" });

    }

    public void OnYukiButton()
    {
        HideAllQuestButton();
        yukiYesButton.SetActive(true);
        noButton.SetActive(true);
        SoundManager.instance.PlaySE(0);
        DialogTextManager.instance.SetScenarios(new string[] { "門番\n「ここでは方向感覚が機能しない。\n万端で挑めよ」\n難易度:★★☆☆☆" });

    }

    public void OnHaikyoButton()
    {
        SoundManager.instance.PlaySE(0);

        if (SaveInt.instance.yukiClear==0)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "門番\n「ここには死神が出る。\nあんたの手には負えない。\nやめておけ」\n難易度:★★★☆☆\n＊実力を示す必要があるようだ..." });
        }
        else
        {
            haikyoYesButton.SetActive(true);
            noButton.SetActive(true);
            DialogTextManager.instance.SetScenarios(new string[] { "門番\n「ここでは方向感覚が機能しない。\n万端で挑めよ」\n難易度:★★☆☆☆" });
        }
    }

    public void OnMoriYesButton()
    {
        SoundManager.instance.PlaySE(0);
        SceneTransitionManager.instance.LoadTo("Quest");
        PlayerManager.instance.playerMapCheck = 1;

    }

    public void OnYukiYesButton()
    {
        SoundManager.instance.PlaySE(0);
        SceneTransitionManager.instance.LoadTo("Quest2");
        PlayerManager.instance.playerMapCheck = 2;

    }

    public void OnHaikyoYesButton()
    {
        SoundManager.instance.PlaySE(0);
        SceneTransitionManager.instance.LoadTo("Quest3");
        PlayerManager.instance.playerMapCheck = 3;

    }
}
