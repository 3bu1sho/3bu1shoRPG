using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SakeManager : MonoBehaviour
{

    public TownManager town;
    public KajinoManager kajino;

    public GameObject johoButton;

    public Transform playerDamagePanel;


    public GameObject ensouMenuButton;
    public GameObject ensouHaiButton;


    public GameObject kakegotoMenuButton;
    public GameObject HiLowButton;
    public GameObject HiLowYesButton; 
    public GameObject HiLowHiButton;
    public GameObject HiLowLowButton;
    public GameObject HiLowNoButton;
    public GameObject HiLowHiBetButton;


    public GameObject BlackjackButton;
    public GameObject BlackjackYesButton;
    public GameObject BlackjackHitButton;
    public GameObject BlackjackStandButton;
    public GameObject BlackjackDoubleButton;
    public GameObject BlackjackWindow;
    public GameObject BlackjackHiBetButton;


    public GameObject tradePrincessButton;


    public int random100;



    public GameObject noButton;

    public void HideAllSakeButton()
    {
        ensouMenuButton.SetActive(false);
        ensouHaiButton.SetActive(false);
        noButton.SetActive(false);
        kakegotoMenuButton.SetActive(false);
        HiLowButton.SetActive(false);
        HiLowYesButton.SetActive(false);
        HiLowNoButton.SetActive(false);
        HiLowHiButton.SetActive(false);
        HiLowLowButton.SetActive(false);
        HiLowHiBetButton.SetActive(false);

        BlackjackButton.SetActive(false);
        BlackjackYesButton.SetActive(false);
        BlackjackHitButton.SetActive(false);
        BlackjackStandButton.SetActive(false);
        BlackjackDoubleButton.SetActive(false);
        BlackjackHiBetButton.SetActive(false);



        johoButton.SetActive(false);

        tradePrincessButton.SetActive(false);

    }

    public void OnSakeButton()
    {
        HideAllSakeButton();

        town.OnToMarumaruButton();
        SoundManager.instance.PlaySE(0);
        ShowSakeMenu();
        DialogTextManager.instance.SetScenarios(new string[] { "酒場についた。\nそれぞれが卓を囲み、\nそれぞれの会話を披露する。" });

    }

    void ShowSakeMenu()
    {
        HideAllSakeButton();
        ensouMenuButton.SetActive(true);
        kakegotoMenuButton.SetActive(true);
        johoButton.SetActive(true);
        tradePrincessButton.SetActive(true);


    }

    public void OnNoButton()
    {
        ShowSakeMenu();
        BlackjackWindow.SetActive(false);
        SoundManager.instance.PlaySE(0);
        ResetBlackjack();
        DialogTextManager.instance.SetScenarios(new string[] { "何をしようかな。" });


    }

    public void OnEnsouMenuButton()
    {
        HideAllSakeButton();
        ensouHaiButton.SetActive(true);
        noButton.SetActive(true);
        SoundManager.instance.PlaySE(0);
        DialogTextManager.instance.SetScenarios(new string[] { "見知らぬ誰かのピアノが止み、\n拍手喝采が起こる。\n自分も何か演奏しよう。" });


    }

    public void OnEnsouHaiButton()
    {
        HideAllSakeButton();

        DialogTextManager.instance.SetScenarios(new string[] { "..." });
        FadeIOManager.instance.FadeOutToIn2();
        StartCoroutine(Ensouchu());
        SoundManager.instance.PlaySE(0);

    }

    IEnumerator Ensouchu()
    {
        yield return new WaitForSeconds(0.8f);
        Debug.Log(DiceRoll.instance.roll2D6);

        PlayerManager.instance.magaChike -= 10;
        if (DiceRoll.instance.roll2D6 == 12)
        {
            PlayerManager.instance.gold += 100+PlayerManager.instance.dexterity + PlayerManager.instance.luck * 1 / 2+DiceRoll.instance.dice1;
            PlayerManager.instance.dexterity += 2;
            DialogTextManager.instance.SetScenarios(new string[] { "会心の演奏だ！" });
            SoundManager.instance.PlaySE(9);

        }


        else if (DiceRoll.instance.roll2D6 + PlayerManager.instance.dexterity < 11)
        {
            PlayerManager.instance.hp -= 50;
            if(PlayerManager.instance.hp<1)
            {
                PlayerManager.instance.hp = 1;
            }
            SoundManager.instance.PlaySE(6);
            playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);

            DialogTextManager.instance.SetScenarios(new string[] { "紅の英雄-ザナン-\n「へたっぴ！」\n   ...何者かに投石を受けた。" });
        }


        else if (DiceRoll.instance.roll2D6+PlayerManager.instance.dexterity < 16)
        {
            PlayerManager.instance.dexterity ++;
            PlayerManager.instance.gold += 25 + PlayerManager.instance.dexterity + PlayerManager.instance.luck * 1 / 2 + DiceRoll.instance.dice1;

            DialogTextManager.instance.SetScenarios(new string[] { "まずまずの演奏だ。" });
            SoundManager.instance.PlaySE(8);

        }

        else if (DiceRoll.instance.roll2D6 + PlayerManager.instance.dexterity < 19)
        {
            PlayerManager.instance.dexterity++;
            PlayerManager.instance.gold += 50 + PlayerManager.instance.dexterity + PlayerManager.instance.luck * 1 / 2 + DiceRoll.instance.dice1;
            DialogTextManager.instance.SetScenarios(new string[] { "いい感じの演奏だ。" });
            SoundManager.instance.PlaySE(8);

        }

        else if (DiceRoll.instance.roll2D6 + PlayerManager.instance.dexterity < 23)
        {
            PlayerManager.instance.dexterity += 2;
            PlayerManager.instance.gold += 100+PlayerManager.instance.dexterity + PlayerManager.instance.luck * 1 / 2 + DiceRoll.instance.dice1;

            DialogTextManager.instance.SetScenarios(new string[] { "会心の演奏だ!" });
            SoundManager.instance.PlaySE(9);

        }

        else
        {
            PlayerManager.instance.dexterity += 2;
            PlayerManager.instance.gold += 100+PlayerManager.instance.dexterity + PlayerManager.instance.luck * 1 / 2 + DiceRoll.instance.dice1;

            DialogTextManager.instance.SetScenarios(new string[] { "会心の演奏だ!" });
            SoundManager.instance.PlaySE(9);

        }
        EndEnsou();

    }

    void EndEnsou()
    {
        HideAllSakeButton();
        ShowSakeMenu();
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
    }


    //以下賭け

    public void OnKakegotoMenuButton()
    {
        HideAllSakeButton();
        HiLowButton.SetActive(true);
        BlackjackButton.SetActive(true);

        SoundManager.instance.PlaySE(0);
        playCount = 0;
        getGoldHiLow = 0;
        HiBet = 0;


    }

    void ShowKakegotoMenu()
    {
        HideAllSakeButton();
        HiLowButton.SetActive(true);
        BlackjackButton.SetActive(true);

        playCount = 0;
        getGoldHiLow = 0;
        HiBet = 0;
    }

    public void OnHiLowButton()
    {
        HideAllSakeButton();
        HiLowYesButton.SetActive(true);
        HiLowNoButton.SetActive(true);
        if(PlayerManager.instance.jobCheck==3)
        {
            HiLowHiBetButton.SetActive(true);
        }
        DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「掛け金は10ゴールドだ。\nさ、どうする？」\nまがチケ1、10ゴールド、\n5HPを消費します。" });
        SoundManager.instance.PlaySE(0);

    }

    int winCount;
    int playCount;

    int HiBet;

    public void OnHiLowHiBetButton()
    {
        if (PlayerManager.instance.gold < 50)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「掛け金も無いとはな。\nお前さんにここは\n早すぎたって事だ。」" });
            SoundManager.instance.PlaySE(0);

        }

        else if (PlayerManager.instance.hp < 6)

        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「おいおい、疲れが顔に出てるぜ。\n今日はもう休みな。」" });
            SoundManager.instance.PlaySE(0);
        }
        else
        {
            HiBet = 1;
            PlayerManager.instance.gold -= 40;
            OnHiLowYesButton();
        }
    }
    public void OnHiLowYesButton()
    {

        if (PlayerManager.instance.gold<10)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「掛け金も無いとはな。\nお前さんにここは\n早すぎたって事だ。」"});
            SoundManager.instance.PlaySE(0);

        }

        else if(PlayerManager.instance.hp<6)

        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「おいおい、疲れが顔に出てるぜ。\n今日はもう休みな。」" });
            SoundManager.instance.PlaySE(0);
        }
        else
        {

            if (playCount == 0)
            {
                kajino.card14 = Random.Range(2, 15);
                PlayerManager.instance.gold -= 10;
                PlayerManager.instance.magaChike -= 1;
                PlayerManager.instance.hp -= 5;
                if(PlayerManager.instance.hp<=0)
                {
                    PlayerManager.instance.hp = 1;
                }
                PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
                SoundManager.instance.PlaySE(10);

                if(PlayerManager.instance.jobCheck==3)
                {
                    kajino.card14 = 14;
                }
            }

            else if(winCount==14)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「悪いな、今回は俺の完敗だ。\nもう勘弁してくれ。」"});

                HideAllSakeButton();
                HiLowNoButton.SetActive(true);

            }
            else
            {
                SoundManager.instance.PlaySE(0);

            }
            kajino.CheckTrampCard();

            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp + "だな。\nさ、どっちに賭けるか？」\n現在の金額:" + getGoldHiLow });
            HideAllSakeButton();

            HiLowHiButton.SetActive(true);
            HiLowLowButton.SetActive(true);

            playCount++;
        }
    }

    public void OnHiLowNoButton()
    {

        GetGoldForHiLow();
        OnKakegotoMenuButton();
    }

    int getGoldHiLow;

    void WinCountCheck()
    {
        if (winCount == 0)
        {
            getGoldHiLow = 0;
        }

        else if (winCount == 1)
        {
            getGoldHiLow = 16;

        }

        else if (winCount == 2)
        {
            getGoldHiLow = 24;
        }
        else if (winCount == 3)
        {
            getGoldHiLow = 34;
            PlayerManager.instance.luck++;
        }
        else if (winCount == 4)
        {
            getGoldHiLow = 50;
            PlayerManager.instance.luck++;

        }
        else if (winCount == 5)
        {
            PlayerManager.instance.luck++;

            getGoldHiLow = 80;
        }
        else if (winCount == 6)
        {
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;

            getGoldHiLow = 110;
        }
        else if (winCount == 7)
        {
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;

            getGoldHiLow = 154;
        }
        else if (winCount == 8)
        {
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;

            getGoldHiLow = 200;
        }
        else if (winCount == 9)
        {
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;

            getGoldHiLow = 260;
        }
        else if (winCount == 10)
        {
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;

            getGoldHiLow = 340;
        }
        else if (winCount == 11)
        {
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;

            getGoldHiLow = 500;
        }
        else if (winCount == 12)
        {
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;

            getGoldHiLow = 760;
        }
        else if (winCount == 13)
        {
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;

            getGoldHiLow = 1110;
        }
        else
        {
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;
            PlayerManager.instance.luck++;

            getGoldHiLow = 1554;
        }
        getGoldHiLow /= 2;
        if (HiBet == 1)
        {
            getGoldHiLow *= 5;
        }
    }

    void GetGoldForHiLow()
    {

        PlayerManager.instance.gold += getGoldHiLow;
        SaveInt.instance.choker += winCount * 3;

        HiBet = 0;

        winCount = 0;
        WinCountCheck();

        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
    }



    public void OnHiLowHiButton()
    {
        SoundManager.instance.PlaySE(0);

        StartCoroutine(OnHi());
    }

    IEnumerator OnHi()
    {
        OjamaPanel.instance.Ojama1f();

        DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「...」" });
        yield return new WaitForSeconds(0.3f);
        SoundManager.instance.PlaySE(10);

        yield return new WaitForSeconds(0.7f);
        HideAllSakeButton();
        kajino.CheckTrampCard2();
        if (kajino.card14 < kajino.card14No2)
        {
            winCount++;
            WinCountCheck();
            SoundManager.instance.PlaySE(2);

            kajino.card14 = kajino.card14No2;
            HiLowYesButton.SetActive(true);
            HiLowNoButton.SetActive(true);
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp2 + "!\nあんたの勝ちだ、やるな。\nどうする、続けるか？」\n現在の金額:" + getGoldHiLow });

        }

        else if (kajino.card14 == kajino.card14No2)
        {
            WinCountCheck();

            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp2 + "。\nドローだな。\nどうする、続けるか？」\n現在の金額:" + getGoldHiLow });
            kajino.card14 = kajino.card14No2;
            HiLowYesButton.SetActive(true);
            HiLowNoButton.SetActive(true);
        }

        else
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp2 + "。\nへ、俺の勝ちだ。\n掛け金はもらうぜ。」" });
            HideAllSakeButton();
            ShowKakegotoMenu();
            WinCountCheck();
            SoundManager.instance.PlaySE(11);
            playCount = 0;
            HiBet = 0;


        }

    }
    public void OnHiLowLowButton()
    {
        SoundManager.instance.PlaySE(0);

        StartCoroutine(OnLow());
    }

    IEnumerator OnLow()
    {
        OjamaPanel.instance.Ojama1f();
        DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「...」" });
        yield return new WaitForSeconds(0.3f);
        SoundManager.instance.PlaySE(10);

        yield return new WaitForSeconds(0.7f);
        HideAllSakeButton();
        kajino.CheckTrampCard2();
        if (kajino.card14 > kajino.card14No2)
        {
            SoundManager.instance.PlaySE(2);

            winCount++;
            WinCountCheck();
            kajino.card14 = kajino.card14No2;
            HiLowYesButton.SetActive(true);
            HiLowNoButton.SetActive(true);
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp2 + "!\nあんたの勝ちだ、やるな。\nどうする、続けるか？」\n現在の金額:" + getGoldHiLow });
        }

        else if (kajino.card14 == kajino.card14No2)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp2 + "。\nドローだな。\nどうする、続けるか？」\n現在の金額:" + getGoldHiLow });
            kajino.card14 = kajino.card14No2;
            HiLowYesButton.SetActive(true);
            HiLowNoButton.SetActive(true);
        }

        else
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp2 + "。\nへ、俺の勝ちだ。\n掛け金はもらうぜ」" });
            HideAllSakeButton();
            BlackjackButton.SetActive(true);
            HiLowButton.SetActive(true);
            winCount = 0;
            SoundManager.instance.PlaySE(11);
            playCount = 0;
        }
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

    }


    //以下、ブラックジャック

    public void OnBlackjackButton()
    {
        SoundManager.instance.PlaySE(0);
        HideAllSakeButton();
        BlackjackYesButton.SetActive(true);
        noButton.SetActive(true);
        if (PlayerManager.instance.jobCheck == 3)
        {
            BlackjackHiBetButton.SetActive(true);
        }
        DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「掛け金は30ゴールドだ。\nさ、どうする？」\nまがチケ1、30ゴールド、\n5HPを消費します。" });

        //BlackjackYesButton.SetActive(true);
        //BlackjackHitButton.SetActive(true);
        //BlackjackStandButton.SetActive(true);
        //BlackjackDoubleButton.SetActive(true);
        //BlackjackSplitButton.SetActive(true);
    }


    public int drawCount;

    public void OnBlackJackHiBetButon()
    {
        if (PlayerManager.instance.gold < 150)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「掛け金も無いとはな。\n帰った帰った。」" });

        }

        else if (PlayerManager.instance.hp < 5)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「おいおい、\n疲れが顔に出てるぜ。\n今日はもう休みな。」" });

        }
        else
        {
            PlayerManager.instance.gold -= 120;
            HiBet = 1;
            OnBlackjackYesButton();
        }
    }

    public void OnBlackjackYesButton()
    {
        SoundManager.instance.PlaySE(0);


        if (PlayerManager.instance.gold < 30)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「掛け金も無いとはな。\n帰った帰った。」" });

        }

        else if(PlayerManager.instance.hp<5)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「おいおい、\n疲れが顔に出てるぜ。\n今日はもう休みな。」" });

        }

        else
        {
            ResetBlackjack();
            kajino.NowLoadingText();
            kajino.kakekin = 30;
            kajino.kakekin *= 2;
            PlayerManager.instance.gold -= 30;
            PlayerManager.instance.hp -= 5;
            PlayerManager.instance.magaChike -= 1;

            if (PlayerManager.instance.hp <= 0)
            {
                PlayerManager.instance.hp = 1;
            }

            HideAllSakeButton();
            ShowBlackjackWindow();
            ResetBlackjack();
            StartCoroutine(DrawCard());
            PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        }




    }

    IEnumerator DrawCard()
    {
        OjamaPanel.instance.Ojama1f();
        BlackjackHitButton.SetActive(false);
        BlackjackStandButton.SetActive(false);
        BlackjackDoubleButton.SetActive(false);
        DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「...」" });
        yield return new WaitForSeconds(0.3f);
        SoundManager.instance.PlaySE(10);

        yield return new WaitForSeconds(0.7f);
        BlackjackHitButton.SetActive(true);
        BlackjackStandButton.SetActive(true);


        drawCount++;

        kajino.Tramp52();
        if (drawCount == 1)
        {
            if (PlayerManager.instance.jobCheck == 3)
            {
                kajino.card14 = 14;
            }
        }
        if (kajino.card14 == 14)
        {
            kajino.playerACheck =1;
        }



        kajino.CheckTrampCard();

        if(kajino.card14>10)
        {
            kajino.card14 = 10;
            if (kajino.playerACheck == 1)
            {
                kajino.card14 = 11;
            }
        }

        kajino.playerBlackjackPoint += kajino.card14;
        if (kajino.playerBlackjackPoint > 21)
        {
            if (kajino.playerACheck == 1)
            {
                kajino.playerBlackjackPoint -= 10;
                kajino.playerACheck = 0;
            }
            else
            {
                //バストの処理
                PlayerBust();
                StartCoroutine(BlackjackDealerturn());

            }
        }


        if(dealersDrawCount==0)
        {
            dealersDrawCount = 1;
            StartCoroutine(DealersFirstDraw());

        }
        kajino.UpdateBlackjackUI();

        DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp + "。\nどうするか？」" });
        if(doubleDownCheck==1)
        {
            BlackjackHitButton.SetActive(false);
            BlackjackStandButton.SetActive(false);
            BlackjackDoubleButton.SetActive(false);
            StartCoroutine(BlackjackDealerturn());
            doubleDownCheck = 0;
        }


    }

    public void OnBlackjackHitButton()
    {
        SoundManager.instance.PlaySE(0);

        StartCoroutine(DrawCard());
    }

    public void OnBlackjackStandButton()
    {
        SoundManager.instance.PlaySE(0);

        StartCoroutine(BlackjackDealerturn());
    }

    int doubleDownCheck;
    public void OnBlackjackDoubleDownButton()
    {
        SoundManager.instance.PlaySE(0);
        PlayerManager.instance.luck += 1;

        if (PlayerManager.instance.gold >= kajino.kakekin)
        {
            kajino.kakekin *= 2;
            PlayerManager.instance.gold -= kajino.kakekin;
            StartCoroutine(DrawCard());
            doubleDownCheck++;
            doubleDounCount = 1;
        }

        else
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「掛け金が足りないぜ」" });

        }
    }

    int dealersDrawCount;
    IEnumerator DealersFirstDraw()
    {
        OjamaPanel.instance.Ojama1f();
        BlackjackHitButton.SetActive(false);
        BlackjackStandButton.SetActive(false);
        BlackjackDoubleButton.SetActive(false);
        DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「...」" });
        yield return new WaitForSeconds(0.3f);
        SoundManager.instance.PlaySE(10);

        yield return new WaitForSeconds(0.7f);
            dealersDrawCount = 1;

        kajino.Tramp52d();
        kajino.CheckTrampCard();

        if (kajino.card14 == 14)
        {
            kajino.dealerACheck = 1;
        }

        if (kajino.card14 > 10)
        {
            kajino.card14 = 10;
            if (kajino.dealerACheck == 1)
            {
                kajino.card14 = 11;
            }
        }

        kajino.dealerBlackjackPoint += kajino.card14;
        if (kajino.dealerBlackjackPoint > 21)
        {
            if (kajino.dealerACheck == 1)
            {
                kajino.dealerBlackjackPoint -= 10;
                kajino.dealerACheck = 0;
            }

            else
            {
                DealerBust();
            }
        }

        kajino.UpdateBlackjackUI();


        BlackjackHitButton.SetActive(true);
        BlackjackStandButton.SetActive(true);
        BlackjackDoubleButton.SetActive(true);

        DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp + "」" });

    }

    IEnumerator BlackjackDealerturn()
    {
        OjamaPanel.instance.Ojama1f();
        BlackjackHitButton.SetActive(false);
        BlackjackStandButton.SetActive(false);
        BlackjackDoubleButton.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        SoundManager.instance.PlaySE(10);

        yield return new WaitForSeconds(0.7f);
        if (kajino.dealerBlackjackPoint ==17)
        {
            if(kajino.dealerACheck>=1)
            {
                DealersDraw();
            }
            else
            {
                BlackjackBattle();
            }
        }

        else if (kajino.dealerBlackjackPoint > 21)
        {
            DealerBust();
            BlackjackBattle();
        }

        else if (kajino.dealerBlackjackPoint >= 17)
        {
            BlackjackBattle();
        }
        else
        {
            DealersDraw();       
        }

    }

    void DealersRepeatTurn()
    {
        StartCoroutine(BlackjackDealerturn());
    }

    void DealersDraw()
    {
        kajino.Tramp52d();
        kajino.CheckTrampCard();
        DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp + "」" });

        if (kajino.card14 == 14)
        {
            kajino.dealerACheck = 1;
        }
        if (kajino.card14 > 10)
        {
            kajino.card14 = 10;
            if (kajino.dealerACheck == 1)
            {
                kajino.card14 = 11;
            }
        }
        kajino.dealerBlackjackPoint += kajino.card14;

        if (kajino.dealerBlackjackPoint > 21)
        {
            if (kajino.dealerACheck == 1)
            {
                kajino.dealerACheck = 0;
                kajino.dealerBlackjackPoint -= 10;

            }
        }
        kajino.UpdateBlackjackUI();


        if (kajino.dealerBlackjackPoint > 21)
        {
            DealerBust();
            BlackjackBattle();

        }

        else if (kajino.dealerBlackjackPoint >= 17)
        {
            BlackjackBattle();
        }
        else
        {
            DealersRepeatTurn();
        }
    }

    void ResetBlackjack()
    {
        drawCount = 0;
        dealersDrawCount = 0;

        kajino.playerACheck = 0;
        kajino.dealerACheck = 0;

        kajino.playerBlackjackPoint = 0;
        kajino.dealerBlackjackPoint = 0;

        kajino.ResetBlackjackCard();
    }

    void PlayerBust()
    {
        kajino.playerBlackjackPoint = -1;
        kajino.UpdateBlackjackUI();

    }

    void DealerBust()
    {
        kajino.dealerBlackjackPoint = -1;
        kajino.UpdateBlackjackUI();

    }

    int doubleDounCount;

    void BlackjackBattle()
    {
        if(kajino.dealerBlackjackPoint>kajino.playerBlackjackPoint)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp + "。\n俺の勝ちだな。\n続けるか？」" });
            kajino.kakekin = 0;
            SoundManager.instance.PlaySE(11);
            PlayerManager.instance.luck += -1;


        }
        else if (kajino.playerBlackjackPoint>kajino.dealerBlackjackPoint)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp + "。\n俺の負けだな。\n続けるか？」" });
            kajino.kakekin += PlayerManager.instance.luck;
            if (HiBet == 1)
            {
                kajino.kakekin *= 5;
            }
            HiBet = 0;
            PlayerManager.instance.gold += kajino.kakekin;
            if(doubleDounCount==1)
            {
                SaveInt.instance.doubleDown = 1;
            }
            kajino.kakekin = 0;
            doubleDounCount = 0;
            PlayerManager.instance.luck += 2;
            SaveInt.instance.choker += 10;
            SoundManager.instance.PlaySE(2);

        }

        else if (kajino.playerBlackjackPoint == kajino.dealerBlackjackPoint)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ディーラー\n「引いたカードは" + kajino.tramp + "。\n引き分けだな。\n続けるか？」" });
            if (HiBet == 1)
            {
                kajino.kakekin *= 5;
            }
            HiBet = 0;
            kajino.kakekin/=2;

            PlayerManager.instance.gold += kajino.kakekin;
            PlayerManager.instance.luck += 1;
            kajino.kakekin = 0;

        }
        doubleDounCount = 0;
        HiBet = 0;

        kajino.UpdateBlackjackUI();
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        BlackjackYesButton.SetActive(true);
        noButton.SetActive(true);
        if (PlayerManager.instance.jobCheck == 3)
        {
            BlackjackHiBetButton.SetActive(true);
        }
    }
    void ShowBlackjackWindow()
    {
        BlackjackWindow.SetActive(true);
    }

    public void OnJohoButton()
    {
        SoundManager.instance.PlaySE(0);

        random100 = Random.Range(1, 10);
        if(random100==1)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「左上のステータスバーを\nタップすると、ステータスの\n詳細を確認できるぞ」" });
        }
        if (random100 == 2)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「Luckはほぼ全ての判定に\n影響するらしいぞ。\n運のいいやつはこの世界を\n制するってな」" });
        }
        if (random100 == 3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「攻撃力はStrengthに依存する。\nパワーイズパワーだぜ」" });
        }
        if (random100 == 4)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「Agilityは行動順と回避力に\n影響する。\n当たらなければどうということはない、\nってことだな」" });
        }
        if (random100 == 5)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「Dexterityは演奏と汚い仕事に\n影響するらしいぜ。\nま、お前さんはそんな人では\nなさそうだが...」" });
        }
        if (random100 == 6)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「ゴールドは武具を買ったり、\n宿に泊まるのに使う。\n日銭程度は残しておくのが、\n生き残るコツだな」" });
        }
        if (random100 == 7)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「Accuracyは命中率だ。\nこれがないと苦労する敵も\nいるだろうさ」" });
        }
        if (random100 == 8)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「まがチケか...これまた妙なものを。\nこれが切れると魔王戦になるそうだな。\n...生きて帰って来いよ」" });
        }
        if (random100 == 9)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「チョーカーはあらゆることで\n気づかないうちに貰えてる\n事がほとんどだぜ。\nこまめにチェックしとくといいな」" });
        }
    }



    public void OnTradePrincess()
    {
        if(SaveInt.instance.choker<100)
        {
            SoundManager.instance.PlaySE(0);

            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「チョーカーを100集めたら\n1プリンセスと交換してやるさ」" });
        }
        else
        {
            SoundManager.instance.PlaySE(9);

            DialogTextManager.instance.SetScenarios(new string[] { "店の主人\n「はいよ、これがお望みかい？」\n＊プリンセスを手に入れた！" });
            SaveInt.instance.choker -= 100;
            SaveInt.instance.princess++;

        }
    }

}