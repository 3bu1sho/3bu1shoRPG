using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JobManager : MonoBehaviour
{


    public GameObject omoidasitaButton;
    public GameObject chigaujibunjanaiButton;
    public GameObject tokuseiWindow;
    public CanvasGroup ojamaPanel;
    public CanvasGroup jobOjamaPanel;

    public GameObject migiYajirushi;
    public GameObject hidariYajirushi;

    public GameObject motazarumonoImage;
    public GameObject SenshiImage;
    public GameObject ArcherImage;
    public GameObject GamblerImage;
    public GameObject RogueImage;

    public UnlockManager unlock;

    void Start()
    {
        SaveInt.instance.activateNoJob = 1;

        Dialog.instance.ShowDialogWindow();
        PlayerUIManager.instance.HidePlayerUI();

        AddEventListenerOnTap(JobKettei);
    }

    Action tapAction;

    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        tapAction();
        SoundManager.instance.PlaySE(0);

    }

    public int jobSelect;
    void JobKettei()
    {
        ojamaPanel.blocksRaycasts = true;
        omoidasitaButton.SetActive(true);
        chigaujibunjanaiButton.SetActive(true);

        if (jobSelect == 1)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "思い出した。自分は戦士だ。\n立ちふさがるもの全て\n引き裂いてやる。" });

            PlayerManager.instance.jobCheck = 1;

        }
        else if (jobSelect == 2)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "思い出した。自分は弓術士だ。\n弓と矢、それさえあれば\n生活には困らない。" });

            PlayerManager.instance.jobCheck = 2;

        }
        else if (jobSelect == 3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "思い出した。自分はギャンブラーだ。\n賭け事とトランプ。\nそれがあるところに\n自分はいる！" });

            PlayerManager.instance.jobCheck = 3;

        }
        else if (jobSelect == 4)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "思い出した。自分は盗賊だ。\n自分の舌は肥えている。\n...知っている。\n土の味も、鉄の味も、\n人の不幸の蜜の味さえも。" });

            PlayerManager.instance.jobCheck = 4;

        }



        else
        {
            DialogTextManager.instance.SetScenarios(new string[] { "思い出した。自分には何も\n能力が無かった。" });

            PlayerManager.instance.jobCheck = 0;
        }
        

    }

    public void OmoidasitaButton()
    {
        SoundManager.instance.PlaySE(0);
        omoidasitaButton.SetActive(false);
        chigaujibunjanaiButton.SetActive(false);
        tokuseiWindow.SetActive(true);

        DialogTextManager.instance.SetScenarios(new string[] { "ふと今までの自分を振り返る。\n自分の個性は..." });
    }

    public void OnChigaujibunjanaiButton()
    {
        SoundManager.instance.PlaySE(0);

        omoidasitaButton.SetActive(false);
        chigaujibunjanaiButton.SetActive(false);
        DialogTextManager.instance.SetScenarios(new string[] { "次こそ職業を思い出してね。" });
        ojamaPanel.blocksRaycasts = false;


    }



    public int jobType;

    public void JobCheck()
    {
        if(PlayerManager.instance.jobCheck == 0)
        {
            PlayerManager.instance.maxHp = 50;
            PlayerManager.instance.hp = 50;
            PlayerManager.instance.maxHp = 50;
            PlayerManager.instance.strength = 5;
            PlayerManager.instance.maxHp = 50;
            PlayerManager.instance.luck = 5;
            PlayerManager.instance.accutracy = 5;
            PlayerManager.instance.agility = 5;
            PlayerManager.instance.dexterity = 5;
            PlayerManager.instance.gold = 100;
            PlayerManager.instance.magaChike = 150;
            PlayerManager.instance.jobSkillPoint = 0;
            PlayerManager.instance.maxJobSkillPoint = 0;

        }

        if (PlayerManager.instance.jobCheck == 1)
        {
            PlayerManager.instance.maxHp = 100;
            PlayerManager.instance.hp = 100;
            PlayerManager.instance.strength = 15;
            PlayerManager.instance.luck = 1;
            PlayerManager.instance.accutracy = 8;
            PlayerManager.instance.agility = 4;
            PlayerManager.instance.dexterity = 3;
            PlayerManager.instance.gold = 50;
            PlayerManager.instance.magaChike = 150;
            PlayerManager.instance.jobSkillPoint = 3;
            PlayerManager.instance.maxJobSkillPoint = 3;


            EquipmentManager.instance.EquipSoaku();
        }

        if (PlayerManager.instance.jobCheck == 2)
        {
            PlayerManager.instance.maxHp = 60;
            PlayerManager.instance.hp = 60;
            PlayerManager.instance.strength = 9;
            PlayerManager.instance.luck = 6;
            PlayerManager.instance.accutracy = 15;
            PlayerManager.instance.agility = 7;
            PlayerManager.instance.dexterity = 8;
            PlayerManager.instance.gold = 10;
            PlayerManager.instance.magaChike = 150;
            PlayerManager.instance.jobSkillPoint = 2;
            PlayerManager.instance.maxJobSkillPoint = 2;


            EquipmentManager.instance.EquipSoakuWeapon();
        }

        if (PlayerManager.instance.jobCheck == 2)
        {
            PlayerManager.instance.maxHp = 50;
            PlayerManager.instance.hp = 50;
            PlayerManager.instance.maxHp = 50;
            PlayerManager.instance.strength = 4;
            PlayerManager.instance.maxHp = 50;
            PlayerManager.instance.luck = 18;
            PlayerManager.instance.accutracy = 5;
            PlayerManager.instance.agility = 6;
            PlayerManager.instance.dexterity = 9;
            PlayerManager.instance.gold = 500;
            PlayerManager.instance.magaChike = 150;
            PlayerManager.instance.jobSkillPoint = 0;
            PlayerManager.instance.maxJobSkillPoint = 0;

        }

        else
        {
            PlayerManager.instance.maxHp = 50;
            PlayerManager.instance.hp = 50;
            PlayerManager.instance.maxHp = 50;
            PlayerManager.instance.strength = 5;
            PlayerManager.instance.maxHp = 50;
            PlayerManager.instance.luck = 5;
            PlayerManager.instance.accutracy = 5;
            PlayerManager.instance.agility = 5;
            PlayerManager.instance.dexterity = 5;
            PlayerManager.instance.gold = 100;
            PlayerManager.instance.magaChike = 150;
            PlayerManager.instance.jobSkillPoint = 0;
            PlayerManager.instance.maxJobSkillPoint = 0;

        }

    }

    void HideAllJobImage()
    {
        motazarumonoImage.SetActive(false);
        SenshiImage.SetActive(false);
        ArcherImage.SetActive(false);
        GamblerImage.SetActive(false);
        RogueImage.SetActive(false);

    }

    public void OnMigiButton()
    {

        SoundManager.instance.PlaySE(0);

        if (jobSelect==0)
        {
            jobOjamaPanel.blocksRaycasts = false;

            unlock.HideUnlockMenu();

            HideAllJobImage();
            jobSelect += 1;
            SenshiImage.SetActive(true);
            if(SaveInt.instance.activateSenshi==0)
            {
                jobOjamaPanel.blocksRaycasts = true;

                unlock.ShowUnlockMenu();
            }
        }

        else if (jobSelect == 1)
        {
            jobOjamaPanel.blocksRaycasts = false;

            unlock.HideUnlockMenu();

            HideAllJobImage();
            jobSelect += 1;
            ArcherImage.SetActive(true);
            if (SaveInt.instance.activateArcher == 0)
            {
                jobOjamaPanel.blocksRaycasts = true;

                unlock.ShowUnlockMenu();
            }
        }

        else if (jobSelect == 2)
        {
            jobOjamaPanel.blocksRaycasts = false;

            unlock.HideUnlockMenu();

            HideAllJobImage();
            jobSelect += 1;
            GamblerImage.SetActive(true);
            if (SaveInt.instance.activateGambler == 0)
            {
                jobOjamaPanel.blocksRaycasts = true;

                unlock.ShowUnlockMenu();
            }
        }

        else if (jobSelect == 3)
        {
            jobOjamaPanel.blocksRaycasts = false;

            unlock.HideUnlockMenu();

            HideAllJobImage();
            jobSelect += 1;
            RogueImage.SetActive(true);
            if (SaveInt.instance.activateRogue == 0)
            {
                jobOjamaPanel.blocksRaycasts = true;

                unlock.ShowUnlockMenu();
            }
        }

    }

    public void OnHidariButton()
    {
        unlock.HideUnlockMenu();

        SoundManager.instance.PlaySE(0);
        if (jobSelect == 4)
        {
            jobOjamaPanel.blocksRaycasts = false;

            unlock.HideUnlockMenu();

            HideAllJobImage();
            jobSelect -= 1;
            GamblerImage.SetActive(true);
            if (SaveInt.instance.activateGambler == 0)
            {
                jobOjamaPanel.blocksRaycasts = true;

                unlock.ShowUnlockMenu();
            }
        }
        else if (jobSelect == 3)
        {
            jobOjamaPanel.blocksRaycasts = false;

            unlock.HideUnlockMenu();

            HideAllJobImage();
            jobSelect -= 1;
            ArcherImage.SetActive(true);
            if (SaveInt.instance.activateArcher == 0)
            {
                jobOjamaPanel.blocksRaycasts = true;

                unlock.ShowUnlockMenu();
            }
        }
        else if (jobSelect == 2)
        {
            jobOjamaPanel.blocksRaycasts = false;

            unlock.HideUnlockMenu();

            HideAllJobImage();
            jobSelect -= 1;
            SenshiImage.SetActive(true);
            if (SaveInt.instance.activateSenshi == 0)
            {
                jobOjamaPanel.blocksRaycasts = true;

                unlock.ShowUnlockMenu();
            }
        }
        else if (jobSelect == 1)
        {
            jobOjamaPanel.blocksRaycasts = false;

            unlock.HideUnlockMenu();

            HideAllJobImage();
            jobSelect -= 1;
            motazarumonoImage.SetActive(true);
            if (SaveInt.instance.activateNoJob == 0)
            {
                jobOjamaPanel.blocksRaycasts = true;

                unlock.ShowUnlockMenu();
            }
        }

    }



}
