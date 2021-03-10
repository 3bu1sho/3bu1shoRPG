using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManager : MonoBehaviour
{
    public GameObject unlockMenu;
    public GameObject unlockButton;
    public GameObject unlockHiButton;
    public GameObject unlockNoButton;

    public JobManager job;
    public Text jobUnlockConditionText;
    public GameObject jobUnlockConditionTextObj;
    public Text princessCount;


    private void Start()
    {
        princessCount.text = "プリンセス:"+ SaveInt.instance.princess;

    }


    public void ShowUnlockMenu()
    {
        if(job.jobSelect==0)
        {
            jobUnlockConditionText.text = string.Format("・チュートリアルを終える");
        }
        else if (job.jobSelect == 1)
        {
            jobUnlockConditionText.text = string.Format("・プリンセスを2つささげる");
        }
        else if (job.jobSelect == 2)
        {
            jobUnlockConditionText.text = string.Format("・プリンセスを5つささげる");
        }
        else if (job.jobSelect == 3)
        {
            jobUnlockConditionText.text = string.Format("・プリンセスを10つささげる\n・ブラックジャックで\n  ダブルダウンをして勝つ");
        }
        else if (job.jobSelect == 4)
        {
            jobUnlockConditionText.text = string.Format("・プリンセスを15つささげる\n・薄汚れたプリンセスを拾う");
        }
        unlockMenu.SetActive(true);

    }

    public void HideUnlockMenu()
    {
        unlockMenu.SetActive(false);
    }

    public void OnUnlockButton()
    {
        SoundManager.instance.PlaySE(0);
        job.ojamaPanel.blocksRaycasts = true;


        if (job.jobSelect == 0)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "持たざる者をアンロックする？" });
        }
        else if (job.jobSelect == 1)
        {
                DialogTextManager.instance.SetScenarios(new string[] { "戦士をアンロックする？" });
        }
        else if (job.jobSelect == 2)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "弓術士をアンロックする？" });
        }
        else if (job.jobSelect == 3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ギャンブラーをアンロックする？" });
        }
        else if (job.jobSelect == 4)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "盗賊をアンロックする？" });
        }
        unlockHiButton.SetActive(true);
        unlockNoButton.SetActive(true);
    }

    public void OnUnlockHiButton()
    {
        SoundManager.instance.PlaySE(0);

        if (job.jobSelect == 0)
        {
            SaveInt.instance.activateNoJob = 1;  
        }
        else if (job.jobSelect == 1)
        {
            if(SaveInt.instance.princess<2)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "プリンセスが足りない。" });
            }
            else
            {
                SaveInt.instance.princess -= 2;
                SaveInt.instance.activateSenshi = 1;
                unlockMenu.SetActive(false);
                DialogTextManager.instance.SetScenarios(new string[] { "戦士をアンロックした！\n" });

            }
        }
        else if (job.jobSelect == 2)
        {
            if (SaveInt.instance.princess < 5)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "プリンセスが足りない。" });
            }
            else
            {
                SaveInt.instance.princess -= 5;
                SaveInt.instance.activateArcher = 1;
                unlockMenu.SetActive(false);
                DialogTextManager.instance.SetScenarios(new string[] { "弓術士をアンロックした！\n" });

            }
        }
        else if (job.jobSelect == 3)
        {
            if(SaveInt.instance.doubleDown==0)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "自分はまだダブルダウンの\n快感を知らない。\nこれはきっと、自分ではないのだ。\n＊酒場でブラックジャックに\n　挑戦しましょう。" });

            }
            else if (SaveInt.instance.princess < 10)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "プリンセスが足りない。" });
            }
            else
            {
                SaveInt.instance.princess -= 10;
                SaveInt.instance.activateGambler = 1;
                unlockMenu.SetActive(false);
                DialogTextManager.instance.SetScenarios(new string[] { "ギャンブラーをアンロックした！\n" });

            }
        }
        else if (job.jobSelect == 4)
        {
            if(SaveInt.instance.dirtyPrincess ==0)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "薄汚れたプリンセスが足りない。\n注意深く探索してみよう。" });
            }
            else if (SaveInt.instance.princess < 15)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "プリンセスが足りない。" });
            }
            else
            {
                SaveInt.instance.princess -= 15;
                SaveInt.instance.activateRogue = 1;
                unlockMenu.SetActive(false);
                DialogTextManager.instance.SetScenarios(new string[] { "盗賊をアンロックした！\n" });

            }
        }
        unlockHiButton.SetActive(false);
        unlockNoButton.SetActive(false);
        princessCount.text = "プリンセス:" + SaveInt.instance.princess;
        job.ojamaPanel.blocksRaycasts = false;
        job.jobOjamaPanel.blocksRaycasts = false;


    }

    public void OnUnlockNoButton()
    {
        SoundManager.instance.PlaySE(0);

        unlockHiButton.SetActive(false);
        unlockNoButton.SetActive(false);
        DialogTextManager.instance.SetScenarios(new string[] { "そうだ...自分の職業は..." });
        job.ojamaPanel.blocksRaycasts = false;

    }
}
