using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageUIManager5 : MonoBehaviour
{

    public Text stageText;
    public GameObject TansakuButton;
    public GameObject BackButton;
    public GameObject MachimodoButton;
    public GameObject MachimodoButton2;

    //    public GameObject stageClearText;
    public GameObject owariButton;
    public GameObject BossBattleButton;


    public Text tierText;
    public int tier;
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
        BackButton.SetActive(false);


        BossBattleButton.SetActive(false);
    }
    public void ShowButtons()
    {
        if (tier == 5)
        {
            BossBattleButton.SetActive(true);
            BackButton.SetActive(true);
            tierText.text = string.Format("ラストバトル");
            DialogTextManager.instance.SetScenarios(new string[] { "これが最後なのだと知覚する。\n\n* かつてないほどの強敵です。\n準備はよろしいですか？" });
        }
        else if(tier==1)
        {
            TansakuButton.SetActive(true);
            MachimodoButton.SetActive(true);
            tierText.text = string.Format("階層:{0}", this.tier);
        }
        else
        {
            TansakuButton.SetActive(true);
            BackButton.SetActive(true);
            tierText.text = string.Format("階層:{0}", this.tier);
        }
    }

    public void HideMachimodo()
    {
        MachimodoButton.SetActive(false);
    }
}
