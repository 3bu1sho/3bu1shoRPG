using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject TansakuButton;
    public GameObject MachimodoButton;
    public GameObject stageClearText;
    public GameObject owariButton;
    public GameObject BossBattleButton;
    public GameObject QuestClearButton;

    public GameObject HeigenButton;
    public GameObject HayashiButton;
    public GameObject KemenomichiButton;
    public GameObject FakeButton;
    public GameObject MoriButton;
    public GameObject KuraiMoriButton;
    public GameObject NumaButton;
    public GameObject ReturnHeigenButton;
    public GameObject ReturnHayashiButton;
    public GameObject ReturnMoriButton;
    public GameObject ReturnKuraiMoriButton;




    public MapManager map;


    private void Start()
    {
        owariButton.SetActive(false);
    }

    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("今は{0}だよ！", currentStage+1);

    }


    public void HideButtons()
    {
        if(PlayerManager.instance.playerMapCheck==1)
        {
            //TansakuButton.SetActive(false);
            HeigenButton.SetActive(false);
            HayashiButton.SetActive(false);
            KemenomichiButton.SetActive(false);
            MoriButton.SetActive(false);
            KuraiMoriButton.SetActive(false);
            NumaButton.SetActive(false);
            ReturnHeigenButton.SetActive(false);
            ReturnHayashiButton.SetActive(false);
            ReturnMoriButton.SetActive(false);
            ReturnKuraiMoriButton.SetActive(false);
            MachimodoButton.SetActive(false);
            BossBattleButton.SetActive(false);
            QuestClearButton.SetActive(false);
            FakeButton.SetActive(false);

        }
    }

    public void ShowButtons()
    {
        //TansakuButton.SetActive(true);
        //MachimodoButton.SetActive(true);
        map.ShowFieldButton();
    }

    public void ShowClearText()
    {
        stageClearText.SetActive(true);
        HeigenButton.SetActive(false);
        HayashiButton.SetActive(false);
        KemenomichiButton.SetActive(false);
        MoriButton.SetActive(false);
        KuraiMoriButton.SetActive(false);
        NumaButton.SetActive(false);
        MachimodoButton.SetActive(true);
        ReturnHeigenButton.SetActive(false);
        ReturnHayashiButton.SetActive(false);
        ReturnMoriButton.SetActive(false);
        ReturnKuraiMoriButton.SetActive(false);
        BossBattleButton.SetActive(false);
        QuestClearButton.SetActive(false);
        FakeButton.SetActive(false);
    }

    public void HideMachimodo()
    {
        MachimodoButton.SetActive(false);
    }

}
