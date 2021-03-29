using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageUIManager4 : MonoBehaviour
{

    public Text stageText;
    public GameObject TansakuButton;
    public GameObject MachimodoButton;
    public GameObject MachimodoButton2;

    //    public GameObject stageClearText;
    public GameObject owariButton;
    public GameObject BossBattleButton;


    int stageCurrent;
    public Text tier;
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


        MachimodoButton.SetActive(false);
        MachimodoButton2.SetActive(false);
        TansakuButton.SetActive(false);

        BossBattleButton.SetActive(false);
    }
    public void ShowButtons()
    {
        if (stageCurrent == 20)
        {
            BossBattleButton.SetActive(true);
            tier.text = string.Format("帰還");
        }
        else
        {
            TansakuButton.SetActive(true);
            stageCurrent++;
            tier.text = string.Format("階層:{0}", tier);
        }
    }

    public void HideMachimodo()
    {
        MachimodoButton.SetActive(false);
    }
}
