using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestScript : MonoBehaviour
{

    void Start()
    {
        a=1;
    }

    [SerializeField] Transform playerDamagePanel;

    public void GetErikusa()
    {
        PlayerManager.instance.hp -= 10;

        SoundManager.instance.PlaySE(1);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        DialogTextManager.instance.SetScenarios(new string[] { "痛っ！\nなにかやばいのを踏んづけた。" });

        ItemManager.instance.erikusa++;

        ItemManager.instance.ActiveErikusa();
    }

    public void SaikoroWoFuru()
    {
        DiceRoll.instance.OhDiceRoll();
        DialogTextManager.instance.SetScenarios(new string[] { "出目は" + DiceRoll.instance.roll2D6 });
    }

    public void ShimazuTsuyu()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "痛っ！\n雨で滑っちゃったよ...\nよよよ..." });
        PlayerManager.instance.hp -= 10;

        SoundManager.instance.PlaySE(1);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);


        if (PlayerManager.instance.hp <= 0)
            PlayerManager.instance.hp = 1;

        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
    }

    public void BGMEmo()
    {
        SoundManager.instance.PlayBGM("Battle2");
    }

    public void TextTest()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "これは...プリンセスだろうか。\n薄汚れてよくわからない。\nただ、何か悲しさを感じさせる。\n一体ここでなにがあったのだろう...\n自分は薄汚れたプリンセスを拾った。" });

    }
    float a;
    float b;
    float c;
    float d;
    int count;

    public void TextNum()
    {
        if(a ==8)
        {

        }
        else
        {
            c++;
            b = 1 / c;
            a += b;
            Debug.Log(c);
            TextNum();
        }
    }
}
