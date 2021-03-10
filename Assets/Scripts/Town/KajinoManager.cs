using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KajinoManager : MonoBehaviour
{

    public int card14;
    public int card14No2;

    public string tramp;
    public string tramp2;

    public int kakekin;

    public void Pick1TrampCard()
    {
 
    }

    public void CheckTrampCard()
    {
        if (card14 == 13)
        {
            tramp = "キング";
        }

        else if (card14 == 12)
        {
            tramp = "クイーン";
        }

        else if (card14 == 11)
        {
            tramp = "ジャック";
        }

        else if (card14 == 14)
        {
            tramp = "A";
        }

        else
        {
            tramp = card14.ToString();
        }
    }

    public void CheckTrampCard2()
    {
        card14No2 = Random.Range(2, 15);

        if (card14No2 == 13)
        {
            tramp2 = "キング";
        }

        else if (card14No2 == 12)
        {
            tramp2 = "クイーン";
        }

        else if (card14No2 == 11)
        {
            tramp2 = "ジャック";
        }

        else if (card14No2 == 14)
        {
            tramp2 = "A";
        }

        else
        {
            tramp2 = card14No2.ToString();
        }
    }

    public int tramp52;
    int checkA;
    int check2;
    int check3;
    int check4;
    int check5;
    int check6;
    int check7;
    int check8;
    int check9;
    int check10;
    int checkJ;
    int checkQ;
    int checkK;

    int encountA;
    int encount2;
    int encount3;
    int encount4;
    int encount5;
    int encount6;
    int encount7;
    int encount8;
    int encount9;
    int encount10;
    int encountJ;
    int encountQ;
    int encountK;



    public void Tramp52()
    {
        tramp52 = Random.Range(0, 52);

        if(tramp52<=4)
        {
            if(tramp52+ encountA <= 4)
            {
                card14 = 14;
                encountA++;
                checkA++;
            }

            else
            {
                Tramp52();
            }
        }

        else if (tramp52 <= 8)
        {
            if (tramp52 + encount2 <= 8)
            {
                card14 = 2;
                encount2++;
                check2++;

            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 12)
        {
            if (tramp52 + encount3 <= 12)
            {
                card14 = 3;
                check3++;
                encount3++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 16)
        {
            if (tramp52 + encount4 <= 16)
            {
                card14 = 4;
                check4++;
                encount4++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 20)
        {
            if (tramp52 + encount5 <= 20)
            {
                card14 = 5;
                check5++;
                encount5++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 24)
        {
            if (tramp52 + encount6 <= 24)
            {
                card14 = 6;
                check6++;
                encount6++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 28)
        {
            if (tramp52 + encount7 <= 28)
            {
                card14 = 7;
                check7++;
                encount7++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 32)
        {
            if (tramp52 + encount8 <= 32)
            {
                card14 = 8;
                check8++;
                encount8++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 36)
        {
            if (tramp52 + encount9 <= 36)
            {
                card14 = 9;
                check9++;
                encount9++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 40)
        {
            if (tramp52 + encount10 <= 40)
            {
                card14 = 10;
                check10++;
                encount10++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 44)
        {
            if (tramp52 + encountJ <= 44)
            {
                card14 = 11;
                checkJ++;
                encountJ++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 48)
        {
            if (tramp52 + encountQ <= 48)
            {
                card14 = 12;
                checkQ++;
                encountQ++;
            }
            else
            {
                Tramp52();
            }

        }

        else if (tramp52 <= 52)
        {
            if (tramp52 + encountK <= 52)
            {
                card14 = 13;
                checkK++;
                encountK++;
            }
            else
            {
                Tramp52();
            }

        }

        else
        {
            card14 = 13;
            checkK++;
            encountK++;
        }

    }

    public Text playerBlackjackHand;




    public void UpdatePlayerHandCount()
    {
        playerBlackjackHand.text = string.Format("2:{0}   3:{1}   4:{2}   5:{3}   6:{4}   7:{5}\n\n\n8:{6}  9:{7}  10:{8}  J:{9}  Q:{10}  K:{11}  A:{12}"
        , check2
        , check3
        , check4
        , check5
        , check6
        , check7
        , check8
        , check9
        , check10
        , checkJ
        , checkQ
        , checkK
        , checkA);

    }

    public Text playerBlackjackPointText;
    public int playerBlackjackPoint;

    public int playerACheck;



    public void UpdatePlayerBlackjackPoint()
    {
        if (playerBlackjackPoint ==-1)
        {
            playerBlackjackPointText.text = string.Format("バスト！");

        }
        else
        {
            if (playerACheck == 1)
            {
                playerBlackjackPointText.text = string.Format("ハンド:ソフト" + playerBlackjackPoint);
            }

            else
            {
                playerBlackjackPointText.text = string.Format("ハンド:ハード" + playerBlackjackPoint);
            }

        }


    }



    public int tramp52d;
    int checkAd;
    int check2d;
    int check3d;
    int check4d;
    int check5d;
    int check6d;
    int check7d;
    int check8d;
    int check9d;
    int check10d;
    int checkJd;
    int checkQd;
    int checkKd;

    public void Tramp52d()
    {
        tramp52d = Random.Range(0, 52);

        if (tramp52d <= 4)
        {
            if (tramp52d + encountA <= 4)
            {
                card14 = 14;
                encountA++;
                checkAd++;
            }

            else
            {
                Tramp52d();
            }
        }

        else if (tramp52d <= 8)
        {
            if (tramp52d + encount2 <= 8)
            {
                card14 = 2;
                check2d++;
                encount2++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 12)
        {
            if (tramp52d + encount3 <= 12)
            {
                card14 = 3;
                check3d++;
                encount3++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 16)
        {
            if (tramp52d + encount4 <= 16)
            {
                card14 = 4;
                check4d++;
                encount4++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 20)
        {
            if (tramp52d + encount5 <= 20)
            {
                card14 = 5;
                check5d++;
                encount5++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 24)
        {
            if (tramp52d + encount6 <= 24)
            {
                card14 = 6;
                check6d++;
                encount6++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 28)
        {
            if (tramp52d + encount7 <= 28)
            {
                card14 = 7;
                check7d++;
                encount7++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 32)
        {
            if (tramp52d + encount8 <= 32)
            {
                card14 = 8;
                check8d++;
                encount8++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 36)
        {
            if (tramp52d + encount9 <= 36)
            {
                card14 = 9;
                check9d++;
                encount9++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 40)
        {
            if (tramp52d + encount10 <= 40)
            {
                card14 = 10;
                check10d++;
                encount10++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 44)
        {
            if (tramp52d + encountJ <= 44)
            {
                card14 = 11;
                checkJd++;
                encountJ++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 48)
        {
            if (tramp52d + encountQ <= 48)
            {
                card14 = 12;
                checkQd++;
                encountQ++;
            }
            else
            {
                Tramp52d();
            }

        }

        else if (tramp52d <= 52)
        {
            if (tramp52d + encountK <= 52)
            {
                card14 = 13;
                checkKd++;
                encountK++;
            }
            else
            {
                Tramp52d();
            }

        }

        else
        {
            Tramp52d();

        }

    }


    public Text dealerBlackjackHand;
    public Text dealerBlackjackPointText;
    public int dealerBlackjackPoint;
    public int dealerACheck;



    public void UpdateDealerBlackjackPoint()
    {if(dealerBlackjackPoint==-1)
        {

            dealerBlackjackPointText.text = string.Format("バスト！");


        }

        else
        {
            if (dealerACheck == 1)
            {
                dealerBlackjackPointText.text = string.Format("ハンド:ソフト" + dealerBlackjackPoint);
            }

            else
            {
                dealerBlackjackPointText.text = string.Format("ハンド:ハード" + dealerBlackjackPoint);
            }

        }

    }

    void UpdateDealerHandCount()
    {
        dealerBlackjackHand.text = string.Format("2:{0}   3:{1}   4:{2}   5:{3}   6:{4}   7:{5}\n\n\n8:{6}  9:{7}  10:{8}  J:{9}  Q:{10}  K:{11}  A:{12}"
, check2d
, check3d
, check4d
, check5d
, check6d
, check7d
, check8d
, check9d
, check10d
, checkJd
, checkQd
, checkKd
, checkAd);

    }

    public void UpdateBlackjackUI()
    {
        UpdateDealerBlackjackPoint();
        UpdatePlayerBlackjackPoint();
        UpdatePlayerHandCount();
        UpdateDealerHandCount();
    }

    public void ResetBlackjackCard()
    {
        check2d = 0;
        check3d = 0;
        check4d = 0;
        check5d = 0;
        check6d = 0;
        check7d = 0;
        check8d = 0;
        check9d = 0;
        check10d = 0;
        checkJd = 0;
        checkQd = 0;
        checkKd = 0;
        checkAd = 0;

        check2 = 0;
        check3 = 0;
        check4 = 0;
        check5 = 0;
        check6 = 0;
        check7 = 0;
        check8 = 0;
        check9 = 0;
        check10 = 0;
        checkJ = 0;
        checkQ = 0;
        checkK = 0;
        checkA = 0;

        encountA = 0;
        encount2 = 0;
        encount3 = 0;
        encount4 = 0;
        encount5 = 0;
        encount6 = 0;
        encount7 = 0;
        encount8 = 0;
        encount9 = 0;
        encount10 = 0;
        encountJ = 0;
        encountQ = 0;
        encountK = 0;


    }

    public void NowLoadingText()
    {
        playerBlackjackHand.text = string.Format("Now Loading...");

        dealerBlackjackHand.text = string.Format("Now Loading...");

    }


}
