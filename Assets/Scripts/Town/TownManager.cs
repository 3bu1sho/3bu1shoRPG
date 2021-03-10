using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    PlayerManager player;
    PlayerUIManager playerUI;
    public YadoManager yado;
    public BlacksmithManager blacksmith;
    public GameObject tansakuButton;
    public GameObject backToTownButton;
    public GameObject toYadoButton;        
    public GameObject toPartButton;
    public GameObject toBlacksmithButton;
    public GameObject toSakeButton;
    public GameObject urarojiButton;
    public PartManager part;
    public SakeManager sake;
    public UrarojiManager uraroji;
    public QuestMapManager questMap;


    public int antenCheck;


    void Start()
    {
        playerUI = PlayerUIManager.instance;
        player = PlayerManager.instance;
        playerUI.ShowPlayerUI();
        playerUI.UpdateUI(player);

        //DialogTextManager.instance.SetScenarios(new string[] { "街についた。\nシャバの空気はうまいぜ。" });
    }

    /*public void OnToQuestButton()
    {

        SoundManager.instance.PlaySE(0);
        SceneTransitionManager.instance.LoadTo("Quest");
        PlayerManager.instance.playerMapCheck=1;
    }*/



    public void OnBackToTownButton()
    {
        SoundManager.instance.PlaySE(0);
        if (antenCheck >= 1)
        {
            antenCheck=0;
            StartCoroutine(OnBackToTownButtonDeley());
        }

        else
        {
            Machimodo();
        }
    }

    IEnumerator OnBackToTownButtonDeley()
    {
        FadeIOManager.instance.FadeOutToIn2();
        yield return new WaitForSeconds(0.75f);
        Machimodo();    }

    void Machimodo()
    {
        blacksmith.BackToTownBlacksmith();
        yado.BackToTownYado();
        part.HideAllPartButton();
        sake.HideAllSakeButton();
        questMap.HideAllQuestButton();
        uraroji.HideAllUrarojiButton();

        backToTownButton.SetActive(false);
        blacksmith.kajiyaImage.SetActive(false);
        tansakuButton.SetActive(true);
        toYadoButton.SetActive(true);
        toPartButton.SetActive(true);
        toBlacksmithButton.SetActive(true);
        toSakeButton.SetActive(true);
        urarojiButton.SetActive(true);


        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        DialogTextManager.instance.SetScenarios(new string[] { "自分はその場を後にし、\n街の中央へと引き返した。" });

    }

    public void OnToMarumaruButton()
    {
        backToTownButton.SetActive(true);
        tansakuButton.SetActive(false);
        toPartButton.SetActive(false);
        toYadoButton.SetActive(false);
        toBlacksmithButton.SetActive(false);
        toSakeButton.SetActive(false);
        urarojiButton.SetActive(false);

    }

    int testnum;
    public void TestScript()
    {
        testnum++;
        Debug.Log(testnum);
    }

    public void AfterAction()
    {
        backToTownButton.SetActive(false);
        tansakuButton.SetActive(true);
        toYadoButton.SetActive(true);
        toBlacksmithButton.SetActive(true);
        toPartButton.SetActive(true);
        toSakeButton.SetActive(true);
        urarojiButton.SetActive(true);


        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
    }

}