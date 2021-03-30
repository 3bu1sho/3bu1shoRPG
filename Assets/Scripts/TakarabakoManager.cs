using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TakarabakoManager : MonoBehaviour
{

    int r;

    public GameObject hiButton;
    public GameObject NoButton;
    [SerializeField] GameObject ToMapOKButton;

    [SerializeField] Transform playerDamagePanel;




    GameObject map;

    public QuestManager quest;
    public QuestManager2 quest2;
    public QuestManager3 quest3;
    public QuestManager4 quest4;




    void Update()
    {
        r = Random.Range(0, 100);
    }

    public void FindTakarabako()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "たからばこがある。\nどうする？" +
            "\n　　　...開けちゃう？" });

        //map.GetComponent<StageUIManager>().HideButtons();
        StartCoroutine(ShowYesNoButton());
    }



    IEnumerator ShowYesNoButton()
    {
        yield return new WaitForSeconds(1f);

        hiButton.SetActive(true);
        NoButton.SetActive(true);
    }

    public void OnYesButton()
    {
        ToOpenTakarabako();
        SoundManager.instance.PlaySE(0);
        hiButton.SetActive(false);
        NoButton.SetActive(false);
    }

    public void OnNoButton()
    {
        SoundManager.instance.PlaySE(0);
        if(PlayerManager.instance.playerMapCheck==1)
        {
            map = GameObject.Find("マップ管理マン");
            map.GetComponent<MapManager>().ShowFieldButton();

        }

        else if(PlayerManager.instance.playerMapCheck == 2)
        {
            quest2.OnToMapOKButton();
        }

        else if (PlayerManager.instance.playerMapCheck == 3)
        {
            map = GameObject.Find("マップ管理マン");
            map.GetComponent<MapManager3>().ShowFieldButton();
            quest3.OnToMapOKButton();


        }

        else if (PlayerManager.instance.playerMapCheck == 4)
        {
            quest4.OnToMapOKButton();
        }

        hiButton.SetActive(false);
        NoButton.SetActive(false);
        ToMapOKButton.SetActive(false);

    }

    void ToOpenTakarabako()
    {
        StartCoroutine(OpenTakarabako());
    }

    IEnumerator OpenTakarabako()
    {
        int random;
        random = r;

        r =-PlayerManager.instance.luck;
        yield return new WaitForSeconds(0.75f);
        Debug.Log(r);


        if(PlayerManager.instance.playerMapCheck==2)
        {
            if (r < 25)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "エリクサーを手に入れた！\nやったね！" });
                GetErikusa();
                SoundManager.instance.PlaySE(2);
            }

            else if (r < 35)
            {
                GetSoakuBuki();
            }

            else if (r < 45)
            {
                GetSoakuBougu();
            }

            else if (r < 58)
            {
                GetFutuuBuki();
            }

            else if (r < 70)
            {
                GetFutuuBougu();
            }

            else if (r < 90)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "痛っ！\n中から氷魔法がとびだした！\nよよよ..." });
                PlayerManager.instance.hp -= 10;

                SoundManager.instance.PlaySE(1);
                playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);


                if (PlayerManager.instance.hp <= 0)
                {
                    PlayerManager.instance.hp = 1;
                }

                PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
                ToMapOKButton.SetActive(true);

            }



            else
            {
                DialogTextManager.instance.SetScenarios(new string[] { "...　　何もはいってないやんけ！" });
                ToMapOKButton.SetActive(true);
            }

        }

        else if (PlayerManager.instance.playerMapCheck == 3)
        {
            if (r < 36)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "エリクサーを手に入れた！\nやったね！" });
                GetErikusa();
                SoundManager.instance.PlaySE(2);
            }
            else if (r < 53)
            {
                GetFutuuBuki();
            }

            else if (r < 70)
            {
                GetFutuuBougu();
            }

            else if (r < 80)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "魔法トラップだ！　鈍い感覚が襲う。\n身体の中の何か大切な部分が\n壊された感覚がある。" });
                PlayerManager.instance.hp -= 20;

                SoundManager.instance.PlaySE(5);
                playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);


                if (PlayerManager.instance.hp <= 0)
                {
                    PlayerManager.instance.hp = 1;
                }

                PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
                ToMapOKButton.SetActive(true);

            }

            else if (r < 90)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "瞬間、鋭い刃が中から飛び出し、\n顔をかすめる。\n少しずれていれば致命傷だった。" });
                PlayerManager.instance.hp -= 10;

                SoundManager.instance.PlaySE(1);
                playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);


                if (PlayerManager.instance.hp <= 0)
                {
                    PlayerManager.instance.hp = 1;
                }

                PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
                ToMapOKButton.SetActive(true);

            }



            else
            {
                DialogTextManager.instance.SetScenarios(new string[] { "...　　何もはいってないやんけ！" });
                ToMapOKButton.SetActive(true);
            }

        }

        else
        {
            if (r < 20)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "エリクサーを手に入れた！\nやったね！" });
                GetErikusa();
                SoundManager.instance.PlaySE(2);
            }

            else if (r < 40)
            {
                GetSoakuBuki();
            }

            else if (r < 60)
            {
                GetSoakuBougu();
            }

            else if (r < 65)
            {
                GetFutuuBuki();
            }

            else if (r < 70)
            {
                GetFutuuBougu();
            }

            else
            {
                DialogTextManager.instance.SetScenarios(new string[] { "...　　何もはいってないやんけ！" });
                ToMapOKButton.SetActive(true);
            }

        }

    }

    void GetErikusa()
    {
        ItemManager.instance.erikusa++;
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        ToMapOKButton.SetActive(true);

        ItemManager.instance.ActiveErikusa();
    }

    void GetSoakuBuki()
    {
        if(PlayerManager.instance.weaponType>=1)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "粗悪な武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.weaponType = 1;
            EquipWeapon();
            DialogTextManager.instance.SetScenarios(new string[] { "粗悪な武器を見つけた。\n多分無いよりはマシ！" });
            ToMapOKButton.SetActive(true);
            SoundManager.instance.PlaySE(2);


        }
    }

    void GetFutuuBuki()
    {
        if (PlayerManager.instance.weaponType >= 2)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "いい感じな武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.weaponType = 2;
            EquipWeapon();
            DialogTextManager.instance.SetScenarios(new string[] { "いい感じな武器を見つけた。\n素晴らしい切れ味！" });
            ToMapOKButton.SetActive(true);
            SoundManager.instance.PlaySE(2);

        }
    }

    void GetSoakuBougu()
    {
        if (PlayerManager.instance.armorType >= 1)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "粗悪な防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.armorType = 1;
            EquipArmor();
            DialogTextManager.instance.SetScenarios(new string[] { "粗悪な防具を見つけた。\n多分無いよりはマシ！" });
            ToMapOKButton.SetActive(true);
            SoundManager.instance.PlaySE(2);

        }
    }

    void GetFutuuBougu()
    {
        if (PlayerManager.instance.armorType >= 2)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "いい感じの防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.armorType = 2;
            EquipArmor();
            DialogTextManager.instance.SetScenarios(new string[] { "いい感じな防具を見つけた。\n市販の物より品質が\nよさそうだ。" });
            ToMapOKButton.SetActive(true);
            SoundManager.instance.PlaySE(2);

        }
    }

    void EquipWeapon()
    {
        if(PlayerManager.instance.weaponType==1)
        {
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 10;
        }

        else if (PlayerManager.instance.weaponType == 2)
        {
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 20;
        }

        else if (PlayerManager.instance.weaponType == 3)
        {
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 100;
        }
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

    }

    void EquipArmor()
    {
        if (PlayerManager.instance.armorType == 1)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 10;
        }

        else if (PlayerManager.instance.armorType == 2)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 20;
        }
        else if (PlayerManager.instance.armorType == 3)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 100;
        }
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);


    }
}
