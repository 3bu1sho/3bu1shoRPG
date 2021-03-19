using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUIManager3 : MonoBehaviour
{
    public Text stageText;
    public GameObject TansakuButton;
    public GameObject MachimodoButton;
    public GameObject MachimodoButton2;

    //    public GameObject stageClearText;
    public GameObject owariButton;
    public GameObject BossBattleButton;
//   public GameObject QuestClearButton;

    public GameObject IriguchiButton;
    public GameObject TanimaButton;
    public GameObject ShurakuButton;
    public GameObject KojoButton;
    public GameObject YosuiroButton;
    public GameObject HirobaButton;
    public GameObject RoyaButton;
    public GameObject HEYA101Button;
    public GameObject HEYA102Button;
    public GameObject HEYA103Button;
    public GameObject KakushiButton;
    public GameObject KantokukanButton;

    public GameObject ReturnToIriguchiButton;
    public GameObject ReturnToTanimaButton;
    public GameObject ReturnToShurakuButton;
    public GameObject ReturnToKojoButton;
    public GameObject ReturnToYosuiroButton;
    public GameObject ReturnToHirobaButton;
    public GameObject ReturnToRoyaButton;
    public GameObject ReturnToHEYA102Button;
    public GameObject ReturnToKakushiButton;
    public GameObject ReturnToKantokukanButton;




    public MapManager3 map;


    private void Start()
    {
        owariButton.SetActive(false);
    }

    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("今は{0}だよ！", currentStage + 1);

    }


    public void HideButtons()
    {
        IriguchiButton.SetActive(false);
        TanimaButton.SetActive(false);
        ShurakuButton.SetActive(false);
        KojoButton.SetActive(false);
        YosuiroButton.SetActive(false);
        HirobaButton.SetActive(false);
        RoyaButton.SetActive(false);
        HEYA101Button.SetActive(false);
        HEYA102Button.SetActive(false);
        HEYA103Button.SetActive(false);
        KakushiButton.SetActive(false);
        KantokukanButton.SetActive(false);
        ReturnToIriguchiButton.SetActive(false);
        ReturnToTanimaButton.SetActive(false);
        ReturnToShurakuButton.SetActive(false);
        ReturnToKojoButton.SetActive(false);
        ReturnToYosuiroButton.SetActive(false);
        ReturnToHirobaButton.SetActive(false);
        ReturnToRoyaButton.SetActive(false);
        ReturnToHEYA102Button.SetActive(false);
        ReturnToKakushiButton.SetActive(false);
        ReturnToKantokukanButton.SetActive(false);

        MachimodoButton.SetActive(false);
        MachimodoButton2.SetActive(false);

        BossBattleButton.SetActive(false);
//        QuestClearButton.SetActive(false);
    }

    public void ShowButtons()
    {
        //TansakuButton.SetActive(true);
        //MachimodoButton.SetActive(true);
        map.ShowFieldButton();
    }

    public void ShowClearText()
    {
//        stageClearText.SetActive(true);
        IriguchiButton.SetActive(false);
        TanimaButton.SetActive(false);
        ShurakuButton.SetActive(false);
        KojoButton.SetActive(false);
        YosuiroButton.SetActive(false);
        HirobaButton.SetActive(false);
        RoyaButton.SetActive(false);
        HEYA101Button.SetActive(false);
        HEYA102Button.SetActive(false);
        HEYA103Button.SetActive(false);
        KakushiButton.SetActive(false);
        KantokukanButton.SetActive(false);
        ReturnToIriguchiButton.SetActive(false);
        ReturnToTanimaButton.SetActive(false);
        ReturnToShurakuButton.SetActive(false);
        ReturnToKojoButton.SetActive(false);
        ReturnToYosuiroButton.SetActive(false);
        ReturnToHirobaButton.SetActive(false);
        ReturnToRoyaButton.SetActive(false);
        ReturnToHEYA102Button.SetActive(false);
        ReturnToKakushiButton.SetActive(false);
        ReturnToKantokukanButton.SetActive(false);


        BossBattleButton.SetActive(false);
//        QuestClearButton.SetActive(false);
    }

    public void HideMachimodo()
    {
        MachimodoButton.SetActive(false);
    }

}
