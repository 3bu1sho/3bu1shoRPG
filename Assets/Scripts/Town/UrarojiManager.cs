using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UrarojiManager : MonoBehaviour
{
    public TownManager town;

    int random100;


    public GameObject UrarojiButton;

    public GameObject NoButton;
    public GameObject NoButton2;



    public GameObject MonoasariButton;
    public GameObject MonoasariYesButton;
    public Transform playerDamagePanel;

    public GameObject SuriButton;
    public GameObject SuriChottoButton;
     public GameObject SuriChottoYesButton;
    public GameObject SuriMaamaaButton;
     public GameObject SuriMaamaaYesButton;
    public GameObject SuriGatturiButton;
     public GameObject SuriGatturiYesButton;




    public void HideAllUrarojiButton()
    {
        UrarojiButton.SetActive(false);

        NoButton.SetActive(false);

        MonoasariButton.SetActive(false);
        MonoasariYesButton.SetActive(false);


        SuriButton.SetActive(false);
        NoButton.SetActive(false);
        NoButton2.SetActive(false);


        SuriChottoButton.SetActive(false);
        SuriMaamaaButton.SetActive(false);
        SuriGatturiButton.SetActive(false);
        SuriChottoYesButton.SetActive(false);
        SuriMaamaaYesButton.SetActive(false);
        SuriGatturiYesButton.SetActive(false);


    }

    public void OnUrarojiButton()
    {
        town.antenCheck++;
        town.OnToMarumaruButton();
        FadeIOManager.instance.FadeOutToIn2();
        StartCoroutine(ToUraroji());
        SoundManager.instance.PlaySE(0);

    }

    IEnumerator ToUraroji()
    {
        town.backToTownButton.SetActive(false);

        yield return new WaitForSeconds(0.75f);
        town.backToTownButton.SetActive(true);

        ShowUrarojiMenu();
        DialogTextManager.instance.SetScenarios(new string[] { "腐ったような匂いだ。\nすれ違う人の目は鋭く、\n今にも襲い掛かりそうだ。" });
    }

    public void OnNoButton()
    {
        HideAllUrarojiButton();
        SoundManager.instance.PlaySE(0);
        ShowUrarojiMenu();
        DialogTextManager.instance.SetScenarios(new string[] { "何をしようかな。" });
    }

    void ShowUrarojiMenu()
    {
        HideAllUrarojiButton();
        //SuriChottoButton.SetActive(true);
        //SuriMaamaaButton.SetActive(true);
        //SuriGatturiButton.SetActive(true);
        MonoasariButton.SetActive(true);
        SuriButton.SetActive(true);


    }



    public void OnMonoasariButton()
    {
        HideAllUrarojiButton();
        SoundManager.instance.PlaySE(0);

        NoButton.SetActive(true);
        MonoasariYesButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "ものを漁ろう。\n*まがチケ1枚、\nhp5を消費します。" });

    }
    public void OnMonoasariYesButton()
    {
        HideAllUrarojiButton();
        StartCoroutine(Monoasari());
        SoundManager.instance.PlaySE(0);

    }

    IEnumerator Monoasari()
    {

        if (PlayerManager.instance.hp <= 5)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "もう疲れた。\n今日はここまでに...。" });
        }

        else
        {
            FadeIOManager.instance.FadeOutToIn2();
            yield return new WaitForSeconds(0.8f);
            PlayerManager.instance.magaChike -= 1;

            random100 = Random.Range(0, 100);
            Debug.Log(random100);
            if(random100==99)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "これは...プリンセスだろうか。\n薄汚れてよくわからない。\nただ、何か悲しさを感じさせる。\n一体ここでなにがあったのだろう...\n自分は薄汚れたプリンセスを拾った。" });
                SaveInt.instance.dirtyPrincess = 1;

            }
            else if (random100 > 60 + PlayerManager.instance.luck / 2 + PlayerManager.instance.dexterity)
            {
                PlayerManager.instance.hp -= 5;
                if (PlayerManager.instance.hp < 1)
                {
                    PlayerManager.instance.hp = 1;
                }
                SoundManager.instance.PlaySE(6);
                playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);

                DialogTextManager.instance.SetScenarios(new string[] { "痛っ！\nとげが指に刺さった...。" });
                PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
                PlayerManager.instance.strength += 1;

            }

            else
            {
                random100 = Random.Range(0, 100);
                Debug.Log(random100);

                if (random100 < 0 + PlayerManager.instance.luck / 2 + PlayerManager.instance.dexterity/2)
                {
                    ItemManager.instance.erikusa++;
                    PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
                    ItemManager.instance.ActiveErikusa();
                    //ToMapOKButton.SetActive(true);
                    DialogTextManager.instance.SetScenarios(new string[] { "エリクサーを見つけた！\nやったね！" });
                    SoundManager.instance.PlaySE(2);


                }


                else if (random100 < 20)
                {
                    if (PlayerManager.instance.weaponType >= 1)
                    {
                        DialogTextManager.instance.SetScenarios(new string[] { "粗悪な武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });
                        //ToMapOKButton.SetActive(true);

                    }

                    else
                    {
                        PlayerManager.instance.weaponType = 1;
                        ItemManager.instance.EquipWeapon();
                        DialogTextManager.instance.SetScenarios(new string[] { "粗悪な武器を見つけた。\n多分無いよりはマシ！" });
                        //ToMapOKButton.SetActive(true);
                        SoundManager.instance.PlaySE(2);


                    }

                }
                else if (random100 < 20 + PlayerManager.instance.luck / 2 + PlayerManager.instance.dexterity/2)
                {
                    if (PlayerManager.instance.weaponType >= 2)
                    {
                        DialogTextManager.instance.SetScenarios(new string[] { "いい感じな武器を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });

                    }

                    else
                    {
                        PlayerManager.instance.weaponType = 2;
                        ItemManager.instance.EquipWeapon();
                        DialogTextManager.instance.SetScenarios(new string[] { "いい感じな武器を見つけた。\n素晴らしい切れ味！" });
                        SoundManager.instance.PlaySE(2);

                    }
                }



                else if (random100 < 40)
                {
                    if (PlayerManager.instance.armorType >= 1)
                    {
                        DialogTextManager.instance.SetScenarios(new string[] { "粗悪な防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });

                    }

                    else
                    {
                        PlayerManager.instance.armorType = 1;
                        ItemManager.instance.EquipArmor();
                        DialogTextManager.instance.SetScenarios(new string[] { "粗悪な防具を見つけた。\n多分無いよりはマシ！" });
                        SoundManager.instance.PlaySE(2);

                    }
                }
                else if (random100 < 40 + PlayerManager.instance.luck / 2 + PlayerManager.instance.dexterity/2)
                {
                    if (PlayerManager.instance.armorType >= 2)
                    {
                        DialogTextManager.instance.SetScenarios(new string[] { "いい感じの防具を見つけた。\n多分今の装備のほうが強いので\n放っておこう。" });

                    }

                    else
                    {
                        PlayerManager.instance.armorType = 2;
                        ItemManager.instance.EquipArmor();
                        DialogTextManager.instance.SetScenarios(new string[] { "いい感じな防具を見つけた。\n市販の物より品質が\nよさそうだ。" });
                        SoundManager.instance.PlaySE(2);

                    }

                }

                else if (random100 < 60)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { "カラスがこちらを見ている。" });
                }
                else if (random100 < 80)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { "何かいいもの、ないかな。" });
                }
                else
                {
                    DialogTextManager.instance.SetScenarios(new string[] { "何もない。\n何か見つかるといいが..." });
                }
            }
            PlayerManager.instance.hp -= 5;
            if (PlayerManager.instance.hp < 1)
            {
                PlayerManager.instance.hp = 1;
            }

            ShowUrarojiMenu();
            PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

        }

    }

    public void OnSuriButton()
    {
        HideAllUrarojiButton();
        DialogTextManager.instance.SetScenarios(new string[] { "自分は盗賊であることを思い出す。\nさて、誰から盗もうか。" });
        SuriChottoButton.SetActive(true);
        SuriMaamaaButton.SetActive(true);
        SuriGatturiButton.SetActive(true);
        NoButton2.SetActive(true);
        SoundManager.instance.PlaySE(0);

    }


    public void OnSuriChottoButton()
    {
        HideAllUrarojiButton();
        NoButton.SetActive(true);
        SuriChottoYesButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "あの農夫から金を盗もう。\n*まがチケを10枚消費します。" });
        SoundManager.instance.PlaySE(0);

    }

    public void OnSuriChottoYesButton()
    {
        FadeIOManager.instance.FadeOutToIn2();
        StartCoroutine(ChottoSuri());
        SoundManager.instance.PlaySE(0);

    }

    IEnumerator ChottoSuri()
    {
        yield return new WaitForSeconds(0.8f);

        PlayerManager.instance.magaChike -= 10;
        PlayerManager.instance.gold += 75 + PlayerManager.instance.dexterity;


        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        HideAllUrarojiButton();
        town.AfterAction();
        town.antenCheck--;
        SaveInt.instance.choker += 1;
        DialogTextManager.instance.SetScenarios(new string[] { "少しゴールドを盗めた。\nさて、今日は何をしようか。" });


    }

    public void OnSuriMaamaaButton()
    {
        HideAllUrarojiButton();
        NoButton.SetActive(true);
        SuriMaamaaYesButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "あの露天商から金を盗もう。\n*まがチケを18枚消費します。" });
        SoundManager.instance.PlaySE(0);

    }

    public void OnSuriMaamaaYesButton()
    {
        FadeIOManager.instance.FadeOutToIn2();
        StartCoroutine(MaamaaSuri());
        SoundManager.instance.PlaySE(0);

    }

    IEnumerator MaamaaSuri()
    {
        yield return new WaitForSeconds(0.8f);

        PlayerManager.instance.magaChike -= 18;
        PlayerManager.instance.gold += 150 + PlayerManager.instance.dexterity;


        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        HideAllUrarojiButton();
        town.AfterAction();
        town.antenCheck--;
        SaveInt.instance.choker += 2;
        DialogTextManager.instance.SetScenarios(new string[] { "そこそこゴールドを盗めた。\nさて、今日は何をしようか。" });


    }

    public void OnSuriGatturiButton()
    {
        HideAllUrarojiButton();
        NoButton.SetActive(true);
        SuriGatturiYesButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "華美な服の男から金を盗もう。\n*まがチケを25枚消費します。" });
        SoundManager.instance.PlaySE(0);

    }

    public void OnSuriGatturiYesButton()
    {
        StartCoroutine(GatturiSuri());
        FadeIOManager.instance.FadeOutToIn2();
        SoundManager.instance.PlaySE(0);

    }

    IEnumerator GatturiSuri()
    {
        yield return new WaitForSeconds(0.8f);

        DialogTextManager.instance.SetScenarios(new string[] { "結構ゴールドを盗めた。\nさて、今日は何をしようか。" });
        PlayerManager.instance.magaChike -= 25;
        PlayerManager.instance.gold += 225 + PlayerManager.instance.dexterity;

        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        HideAllUrarojiButton();
        town.AfterAction();
        town.antenCheck--;
        SaveInt.instance.choker += 3;

    }


}
