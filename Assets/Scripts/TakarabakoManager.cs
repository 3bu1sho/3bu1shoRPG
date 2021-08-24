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
    public QuestManager5 quest5;





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

        else if (PlayerManager.instance.playerMapCheck == 5)
        {
            quest5.OnToMapOKButton();
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

        else if (PlayerManager.instance.playerMapCheck == 4)
        {
            if (r < 29)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "エリクサーを手に入れた！\nやったね！" });
                GetErikusa();
                SoundManager.instance.PlaySE(2);
            }
            else if (r < 44)
            {
                GetJoshitsuBuki();
            }

            else if (r < 59)
            {
                GetJoshitsuBougu();
            }

            else if (r < 67)
            {
                GetShinseiBuki();
            }

            else if (r < 75)
            {
                GetShinseiBougu();
            }


            else if (r < 89)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "へどろの槍が手首を貫く。\n手の感覚がない。\n自分は這い上がれるだろうか。" });
                PlayerManager.instance.hp -= 30 ;

                SoundManager.instance.PlaySE(5);
                playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);


                if (PlayerManager.instance.hp <= 0)
                {
                    PlayerManager.instance.hp = 1;
                }

                PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
                ToMapOKButton.SetActive(true);

            }

            else if (r < 99)
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

        else if (PlayerManager.instance.playerMapCheck == 5)
        {
            if (r < 29)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "エリクサーを手に入れた！\nやったね！" });
                GetErikusa();
                SoundManager.instance.PlaySE(2);
            }
            else if (r < 33)
            {
                GetSouseiBuki();
            }

            else if (r < 37)
            {
                GetSouseiBougu();
            }

            else if (r < 47)
            {
                GetShinseiBuki();
            }

            else if (r < 57)
            {
                GetShinseiBougu();
            }


            else if (r < 78)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "死のらせんが自分を貫く。\nこの罠は死ぬこともあり得る。" });
                PlayerManager.instance.hp -= 40;

                SoundManager.instance.PlaySE(5);
                playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);


                if (PlayerManager.instance.hp <= 0)
                {
                    PlayerManager.instance.hp = 1;
                }

                PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
                ToMapOKButton.SetActive(true);

            }

            else if (r < 99)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "瞬間、らせんが中から飛び出し、\n顔をかすめる。\n少しずれていれば致命傷だった。" });
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

    void GetJoshitsuBuki()
    {
        if(PlayerManager.instance.weaponType == 3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "上質な武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);
        }

        else if (PlayerManager.instance.weaponType >= 4)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "上質な武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.weaponType = 4;
            EquipWeapon();
            DialogTextManager.instance.SetScenarios(new string[] { "上質な武器を見つけた。\n武器としてこれほど\n頼もしいものはないだろう。" });
            ToMapOKButton.SetActive(true);
            SoundManager.instance.PlaySE(2);

        }
    }

    void GetShinseiBuki()
    {
        if (PlayerManager.instance.weaponType == 3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "神聖な武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);
        }

        else if (PlayerManager.instance.weaponType >= 5)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "神聖な武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.weaponType = 5;
            EquipWeapon();
            DialogTextManager.instance.SetScenarios(new string[] { "神聖な武器を見つけた。\n武器としてこれほど\n頼もしいものはないだろう。" });
            ToMapOKButton.SetActive(true);
            SoundManager.instance.PlaySE(2);

        }
    }

    void GetSouseiBuki()
    {
        if (PlayerManager.instance.weaponType == 3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "創世の武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);
        }

        else if (PlayerManager.instance.weaponType >= 6)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "創世の武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.weaponType = 6;
            EquipWeapon();
            DialogTextManager.instance.SetScenarios(new string[] { "創世の武器を見つけた。\nこれで世界が切り拓かれた\nのだろう。" });
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

    void GetJoshitsuBougu()
    {
        if (PlayerManager.instance.armorType == 3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "上質な防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else if (PlayerManager.instance.armorType >= 4)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "上質な防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.armorType = 4;
            EquipArmor();
            DialogTextManager.instance.SetScenarios(new string[] { "上質な防具を見つけた。\nこれほどの品質を\n市場で見たことはない。" });
            ToMapOKButton.SetActive(true);
            SoundManager.instance.PlaySE(2);

        }
    }

    void GetShinseiBougu()
    {
        if (PlayerManager.instance.armorType == 3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "神聖な防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else if (PlayerManager.instance.armorType >= 5)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "神聖な防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.armorType = 5;
            EquipArmor();
            DialogTextManager.instance.SetScenarios(new string[] { "神聖な防具を見つけた。\n防具としてこれほど\n頼もしいものはないだろう。" });
            ToMapOKButton.SetActive(true);
            SoundManager.instance.PlaySE(2);

        }
    }

    void GetSouseiBougu()
    {
        if (PlayerManager.instance.armorType == 3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "神聖な防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else if (PlayerManager.instance.armorType >= 6)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "神聖な防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
            ToMapOKButton.SetActive(true);

        }

        else
        {
            PlayerManager.instance.armorType = 6;
            EquipArmor();
            DialogTextManager.instance.SetScenarios(new string[] { "創世の武器を見つけた。\nこれで世界が切り拓かれた\nのだろう。" });
            ToMapOKButton.SetActive(true);
            SoundManager.instance.PlaySE(2);

        }
    }


    public void EquipWeapon()
    {
        if (PlayerManager.instance.weaponType == 1)
        {
            //粗悪
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 10;
        }

        else if (PlayerManager.instance.weaponType == 2)
        {
            //普通
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 20;
        }

        else if (PlayerManager.instance.weaponType == 3)
        {
            //オリハルコン
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 100;
        }

        else if (PlayerManager.instance.weaponType == 4)
        {
            //最高
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 30;
        }

        else if (PlayerManager.instance.weaponType == 5)
        {
            //神話
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 40;
        }

        else if (PlayerManager.instance.weaponType == 6)
        {
            //創世
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 50;
        }
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

    }

    public void EquipArmor()
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
        else if (PlayerManager.instance.armorType == 4)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 30;
        }
        else if (PlayerManager.instance.armorType == 5)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 40;
        }
        else if (PlayerManager.instance.armorType == 6)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 50;
        }


        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);


    }
}
