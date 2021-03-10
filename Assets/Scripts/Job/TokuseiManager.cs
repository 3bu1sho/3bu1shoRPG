using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokuseiManager : MonoBehaviour
{


    [SerializeField] GameObject tokuseiWindow;

    [SerializeField] GameObject MachiniikuButton;
    [SerializeField] GameObject TuyotuyoCanvas;
    [SerializeField] JobManager job;
    public void ShowTokuseiWindow()
    {
        tokuseiWindow.SetActive(true);
    }


    //public string tokusei1text = "特性その１を選択可能";
    //public string tokusei2text = "特性その２を選択可能";
    //public string tokusei3text = "特性その３を選択可能";

    int tokusei1;
    int tokusei2;
    int tokusei3;

    int chikaraNom1;
    int chikaraNom2;
    int chikaraNom3;


    int subayaiNom1;
    int subayaiNom2;
    int subayaiNom3;


    int TairyokugaaruNom1;
    int TairyokugaaruNom2;
    int TairyokugaaruNom3;


    int TsuiteiruNom1;
    int TsuiteiruNom2;
    int TsuiteiruNom3;

    int kiyouNom1;
    int kiyouNom2;
    int kiyouNom3;

    int okanemochiNom1;
    int okanemochiNom2;
    int okanemochiNom3;

    int tokuseisuu;

    void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "あなたの職業を思い出してね。" });

        if(tokuseisuu>=3)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "あなたは" + PlayerManager.instance.tokusei1text + "、\n" + PlayerManager.instance.tokusei2text + "、\n" + PlayerManager.instance.tokusei3text + "。" });
            MachiniikuButton.SetActive(true);
        }
    }

    void UpdateTokusei()
    {
        SoundManager.instance.PlaySE(0);



        DialogTextManager.instance.SetScenarios(new string[] { "あなたは"+ PlayerManager.instance.tokusei1text + "、\n"+ PlayerManager.instance.tokusei2text + "、\n"+ PlayerManager.instance.tokusei3text + "。"});
        if (tokuseisuu >= 3)
        {
            MachiniikuButton.SetActive(true);
        }
        else
        {
            MachiniikuButton.SetActive(false);
        }
    }

    void ActivateTokusei()
    {
        PlayerManager.instance.hp += PlayerManager.instance.Tairyokugaaru * 10;
        PlayerManager.instance.maxHp += PlayerManager.instance.Tairyokugaaru * 10;
        PlayerManager.instance.strength += PlayerManager.instance.ChikaraJiman * 2;
        PlayerManager.instance.agility += PlayerManager.instance.Subayai * 2;
        PlayerManager.instance.luck += PlayerManager.instance.Tsuiteiru * 2;
        PlayerManager.instance.dexterity += PlayerManager.instance.kiyou * 2;
        PlayerManager.instance.gold += PlayerManager.instance.okanemochi * 80;
    }

    public void OnOKButton()
    {
        SoundManager.instance.PlaySE(0);

        SceneTransitionManager.instance.LoadTo("Town");
        PlayerWindowManager.instance.ShowTownText();
        job.JobCheck();
        ActivateTokusei();
        PlayerWindowManager.instance.ShowTownText();
    }

    public void OnNoButtton()
    {
        SoundManager.instance.PlaySE(0);

        DialogTextManager.instance.SetScenarios(new string[] { "消したい特性を押してね。\nあなたは" + PlayerManager.instance.tokusei1text + "、\n" + PlayerManager.instance.tokusei2text + "、\n" + PlayerManager.instance.tokusei3text + "。" });
        TuyotuyoCanvas.SetActive(false);
    }

    public void OnMachiniikuButton()
    {
        SoundManager.instance.PlaySE(0);

        TuyotuyoCanvas.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "キャラを決定して進むわよ。\nゲームオーバーになるまで\n変えれないけど、これでよろし？" });

    }

    public void OnResetButton()
    {


        PlayerManager.instance.ChikaraJiman = 0;
        if (chikaraNom1 == 1)
        {
            chikaraNom1 = 0;
            tokusei1 = 0;
            PlayerManager.instance.tokusei1text = "特性その1を選択可能";
            tokuseisuu--;
        }

        if (chikaraNom2 == 1)
        {
            chikaraNom2 = 0;
            tokusei2 = 0;
            PlayerManager.instance.tokusei2text = "特性その2を選択可能";
            tokuseisuu--;
        }

        if (chikaraNom3 == 1)
        {
            chikaraNom3 = 0;
            tokusei3 = 0;
            PlayerManager.instance.tokusei3text = "特性その3を選択可能";
            tokuseisuu--;
        }

        PlayerManager.instance.Subayai = 0;
        if (subayaiNom1 == 1)
        {
            subayaiNom1 = 0;
            tokusei1 = 0;
            PlayerManager.instance.tokusei1text = "特性その1を選択可能";
            tokuseisuu--;
        }

        if (subayaiNom2 == 1)
        {
            subayaiNom2 = 0;
            tokusei2 = 0;
            PlayerManager.instance.tokusei2text = "特性その2を選択可能";
            tokuseisuu--;
        }

        if (subayaiNom3 == 1)
        {
            subayaiNom3 = 0;
            tokusei3 = 0;
            PlayerManager.instance.tokusei3text = "特性その3を選択可能";
            tokuseisuu--;
        }

        PlayerManager.instance.Tairyokugaaru = 0;
        if (TairyokugaaruNom1 == 1)
        {
            TairyokugaaruNom1 = 0;
            tokusei1 = 0;
            PlayerManager.instance.tokusei1text = "特性その1を選択可能";
            tokuseisuu--;
        }

        if (TairyokugaaruNom2 == 1)
        {
            TairyokugaaruNom2 = 0;
            tokusei2 = 0;
            PlayerManager.instance.tokusei2text = "特性その2を選択可能";
            tokuseisuu--;
        }

        if (TairyokugaaruNom3 == 1)
        {
            TairyokugaaruNom3 = 0;
            tokusei3 = 0;
            PlayerManager.instance.tokusei3text = "特性その3を選択可能";
            tokuseisuu--;
        }

        PlayerManager.instance.Tsuiteiru = 0;
        if (TsuiteiruNom1 == 1)
        {
            TsuiteiruNom1 = 0;
            tokusei1 = 0;
            PlayerManager.instance.tokusei1text = "特性その1を選択可能";
            tokuseisuu--;
        }

        if (TsuiteiruNom2 == 1)
        {
            TsuiteiruNom2 = 0;
            tokusei2 = 0;
            PlayerManager.instance.tokusei2text = "特性その2を選択可能";
            tokuseisuu--;
        }

        if (TsuiteiruNom3 == 1)
        {
            TsuiteiruNom3 = 0;
            tokusei3 = 0;
            PlayerManager.instance.tokusei3text = "特性その3を選択可能";
            tokuseisuu--;
        }

        PlayerManager.instance.kiyou = 0;
        if (kiyouNom1 == 1)
        {
            kiyouNom1 = 0;
            tokusei1 = 0;
            PlayerManager.instance.tokusei1text = "特性その1を選択可能";
            tokuseisuu--;
        }

        if (kiyouNom2 == 1)
        {
            kiyouNom2 = 0;
            tokusei2 = 0;
            PlayerManager.instance.tokusei2text = "特性その2を選択可能";
            tokuseisuu--;
        }

        if (kiyouNom3 == 1)
        {
            kiyouNom3 = 0;
            tokusei3 = 0;
            PlayerManager.instance.tokusei3text = "特性その3を選択可能";
            tokuseisuu--;
        }
        PlayerManager.instance.okanemochi = 0;
        if (okanemochiNom1 == 1)
        {
            okanemochiNom1 = 0;
            tokusei1 = 0;
            PlayerManager.instance.tokusei1text = "特性その1を選択可能";
            tokuseisuu--;
        }

        if (okanemochiNom2 == 1)
        {
            okanemochiNom2 = 0;
            tokusei2 = 0;
            PlayerManager.instance.tokusei2text = "特性その2を選択可能";
            tokuseisuu--;
        }

        if (okanemochiNom3 == 1)
        {
            okanemochiNom3 = 0;
            tokusei3 = 0;
            PlayerManager.instance.tokusei3text = "特性その3を選択可能";
            tokuseisuu--;
        }




        UpdateTokusei();


    }

    public void OnChikaraJimanButton()
    {
        if (tokuseisuu < 3)
        {

            if (tokusei1==0)
            {
                PlayerManager.instance.ChikaraJiman++;
                tokuseisuu++;
                PlayerManager.instance.tokusei1text = "力が強く";
                tokusei1 = 1;
                chikaraNom1 = 1;
            }
            else if (tokusei2 == 0)
            {
                PlayerManager.instance.ChikaraJiman++;
                tokuseisuu++;
                PlayerManager.instance.tokusei2text = "腕相撲では負けなしで";
                tokusei2 = 1;
                chikaraNom2 = 1;
            }
            else if (tokusei3==0)
            {
                PlayerManager.instance.ChikaraJiman++;
                tokuseisuu++;
                PlayerManager.instance.tokusei3text = "腕力に自信がある";
                tokusei3 = 1;
                chikaraNom3 = 1;
            }
        }

        else
        {
            PlayerManager.instance.ChikaraJiman = 0;
            if(chikaraNom1==1)
            {
                chikaraNom1 = 0;
                tokusei1 = 0;
                PlayerManager.instance.tokusei1text = "特性その1を選択可能";
                tokuseisuu--;
            }

            if (chikaraNom2 == 1)
            {
                chikaraNom2 = 0;
                tokusei2 = 0;
                PlayerManager.instance.tokusei2text = "特性その2を選択可能";
                tokuseisuu--;
            }

            if (chikaraNom3 == 1)
            {
                chikaraNom3 = 0;
                tokusei3 = 0;
                PlayerManager.instance.tokusei3text = "特性その3を選択可能";
                tokuseisuu--;
            }

        }
        UpdateTokusei();
    }

    public void OnSubayaiButton()
    {
        if (tokuseisuu < 3)
        {

            if (tokusei1 == 0)
            {
                PlayerManager.instance.Subayai++;
                tokuseisuu++;
                PlayerManager.instance.tokusei1text = "素早く";
                tokusei1 = 1;
                subayaiNom1 = 1;
            }
            else if (tokusei2 == 0)
            {
                PlayerManager.instance.Subayai++;
                tokuseisuu++;
                PlayerManager.instance.tokusei2text = "駆けっこに自信があり";
                tokusei2 = 1;
                subayaiNom2 = 1;
            }
            else if (tokusei3 == 0)
            {
                PlayerManager.instance.Subayai++;
                tokuseisuu++;
                PlayerManager.instance.tokusei3text = "ハヤブサと呼ばれていた";
                tokusei3 = 1;
                subayaiNom3 = 1;
            }
        }

        else
        {
            PlayerManager.instance.Subayai = 0;
            if (subayaiNom1 == 1)
            {
                subayaiNom1 = 0;
                tokusei1 = 0;
                PlayerManager.instance.tokusei1text = "特性その1を選択可能";
                tokuseisuu--;
            }

            if (subayaiNom2 == 1)
            {
                subayaiNom2 = 0;
                tokusei2 = 0;
                PlayerManager.instance.tokusei2text = "特性その2を選択可能";
                tokuseisuu--;
            }

            if (subayaiNom3 == 1)
            {
                subayaiNom3 = 0;
                tokusei3 = 0;
                PlayerManager.instance.tokusei3text = "特性その3を選択可能";
                tokuseisuu--;
            }

        }
        UpdateTokusei();
    }


    public void OnTairyokugaaruButton()
    {
        if (tokuseisuu < 3)
        {

            if (tokusei1 == 0)
            {
                PlayerManager.instance.Tairyokugaaru++;
                tokuseisuu++;
                PlayerManager.instance.tokusei1text = "体力には自信があり";
                tokusei1 = 1;
                TairyokugaaruNom1 = 1;
            }
            else if (tokusei2 == 0)
            {
                PlayerManager.instance.Tairyokugaaru++;
                tokuseisuu++;
                PlayerManager.instance.tokusei2text = "趣味は筋トレで";
                tokusei2 = 1;
                TairyokugaaruNom2 = 1;
            }
            else if (tokusei3 == 0)
            {
                PlayerManager.instance.Tairyokugaaru++;
                tokuseisuu++;
                PlayerManager.instance.tokusei3text = "強靭な肉体を秘めている";
                tokusei3 = 1;
                TairyokugaaruNom3 = 1;
            }
        }

        else
        {
            PlayerManager.instance.Tairyokugaaru = 0;
            if (TairyokugaaruNom1 == 1)
            {
                TairyokugaaruNom1 = 0;
                tokusei1 = 0;
                PlayerManager.instance.tokusei1text = "特性その1を選択可能";
                tokuseisuu--;
            }

            if (TairyokugaaruNom2 == 1)
            {
                TairyokugaaruNom2 = 0;
                tokusei2 = 0;
                PlayerManager.instance.tokusei2text = "特性その2を選択可能";
                tokuseisuu--;
            }

            if (TairyokugaaruNom3 == 1)
            {
                TairyokugaaruNom3 = 0;
                tokusei3 = 0;
                PlayerManager.instance.tokusei3text = "特性その3を選択可能";
                tokuseisuu--;
            }

        }
        UpdateTokusei();
    }


    public void OnTsuiteiruButton()
    {
        if (tokuseisuu < 3)
        {

            if (tokusei1 == 0)
            {
                PlayerManager.instance.Tsuiteiru++;
                tokuseisuu++;
                PlayerManager.instance.tokusei1text = "運が強く";
                tokusei1 = 1;
                TsuiteiruNom1 = 1;
            }
            else if (tokusei2 == 0)
            {
                PlayerManager.instance.Tsuiteiru++;
                tokuseisuu++;
                PlayerManager.instance.tokusei2text = "イカサマの技術があり";
                tokusei2 = 1;
                TsuiteiruNom2 = 1;
            }
            else if (tokusei3 == 0)
            {
                PlayerManager.instance.Tsuiteiru++;
                tokuseisuu++;
                PlayerManager.instance.tokusei3text = "天に味方されている";
                tokusei3 = 1;
                TsuiteiruNom3 = 1;
            }
        }

        else
        {
            PlayerManager.instance.Tsuiteiru = 0;
            if (TsuiteiruNom1 == 1)
            {
                TsuiteiruNom1 = 0;
                tokusei1 = 0;
                PlayerManager.instance.tokusei1text = "特性その1を選択可能";
                tokuseisuu--;
            }

            if (TsuiteiruNom2 == 1)
            {
                TsuiteiruNom2 = 0;
                tokusei2 = 0;
                PlayerManager.instance.tokusei2text = "特性その2を選択可能";
                tokuseisuu--;
            }

            if (TsuiteiruNom3 == 1)
            {
                TsuiteiruNom3 = 0;
                tokusei3 = 0;
                PlayerManager.instance.tokusei3text = "特性その3を選択可能";
                tokuseisuu--;
            }

        }
        UpdateTokusei();
    }

    public void OnKiyouButton()
    {
        if (tokuseisuu < 3)
        {

            if (tokusei1 == 0)
            {
                PlayerManager.instance.kiyou++;
                tokuseisuu++;
                PlayerManager.instance.tokusei1text = "手先が器用で";
                tokusei1 = 1;
                kiyouNom1 = 1;
            }
            else if (tokusei2 == 0)
            {
                PlayerManager.instance.kiyou++;
                tokuseisuu++;
                PlayerManager.instance.tokusei2text = "趣味は裁縫で";
                tokusei2 = 1;
                kiyouNom2 = 1;
            }
            else if (tokusei3 == 0)
            {
                PlayerManager.instance.kiyou++;
                tokuseisuu++;
                PlayerManager.instance.tokusei3text = "盗品蔵で育った";
                tokusei3 = 1;
                kiyouNom3 = 1;
            }
        }

        else
        {
            PlayerManager.instance.kiyou = 0;
            if (kiyouNom1 == 1)
            {
                kiyouNom1 = 0;
                tokusei1 = 0;
                PlayerManager.instance.tokusei1text = "特性その1を選択可能";
                tokuseisuu--;
            }

            if (kiyouNom2 == 1)
            {
                kiyouNom2 = 0;
                tokusei2 = 0;
                PlayerManager.instance.tokusei2text = "特性その2を選択可能";
                tokuseisuu--;
            }

            if (kiyouNom3 == 1)
            {
                kiyouNom3 = 0;
                tokusei3 = 0;
                PlayerManager.instance.tokusei3text = "特性その3を選択可能";
                tokuseisuu--;
            }

        }
        UpdateTokusei();
    }


    public void OnOkanemochiButton()
    {
        if (tokuseisuu < 3)
        {

            if (tokusei1 == 0)
            {
                PlayerManager.instance.okanemochi++;
                tokuseisuu++;
                PlayerManager.instance.tokusei1text = "お金を持っていて";
                tokusei1 = 1;
                okanemochiNom1 = 1;
            }
            else if (tokusei2 == 0)
            {
                PlayerManager.instance.okanemochi++;
                tokuseisuu++;
                PlayerManager.instance.tokusei2text = "裕福な家庭で育ち";
                tokusei2 = 1;
                okanemochiNom2 = 1;
            }
            else if (tokusei3 == 0)
            {
                PlayerManager.instance.okanemochi++;
                tokuseisuu++;
                PlayerManager.instance.tokusei3text = "事業に成功した経験がある";
                tokusei3 = 1;
                okanemochiNom3 = 1;
            }
        }

        else
        {
            PlayerManager.instance.Tairyokugaaru = 0;
            if (okanemochiNom1 == 1)
            {
                okanemochiNom1 = 0;
                tokusei1 = 0;
                PlayerManager.instance.tokusei1text = "特性その1を選択可能";
                tokuseisuu--;
            }

            if (okanemochiNom2 == 1)
            {
                okanemochiNom2 = 0;
                tokusei2 = 0;
                PlayerManager.instance.tokusei2text = "特性その2を選択可能";
                tokuseisuu--;
            }

            if (okanemochiNom3 == 1)
            {
                okanemochiNom3 = 0;
                tokusei3 = 0;
                PlayerManager.instance.tokusei3text = "特性その3を選択可能";
                tokuseisuu--;
            }

        }
        UpdateTokusei();
    }

}