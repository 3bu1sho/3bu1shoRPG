using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WazaManager : MonoBehaviour
{

    public BattleManager battle;
    EnemyManager enemy;
    public EnemyUIManager enemyUI;
    public QuestManager questmanager;
    public EnemyManager enemyManager;


    public CanvasGroup canvasGroup;
    public CanvasGroup BladeEffectCanvas;

    public CanvasGroup QuestBGBlur;
    public CanvasGroup ojamaPanel;





    public GameObject BladeEffectImage;

    [SerializeField] Transform playerDamagePanel;

    float kirisakiFadeInTime;
    float kirisakiFadeOutTime;


    public GameObject wazaButton;

    private void Start()
    {
        //ShowWazaButton();
        kirisakiFadeInTime = 0.1f;
        kirisakiFadeOutTime = 0.2f;
    }

    public void SetUp(EnemyManager enemyManager)
    {
        ShowWazaButton();
        enemy = enemyManager;
    }

    void ShowWazaButton()
    {
        if (PlayerManager.instance.jobSkillPoint > 0)
        {
            wazaButton.SetActive(true);
        }

        if (PlayerManager.instance.jobSkillPoint == 4)
        {
            wazaButton.SetActive(false);
        }
    }

    public void OnWazaButton()
    {
        ojamaPanel.blocksRaycasts = true;

        SoundManager.instance.PlaySE(0);
        PlayerManager.instance.jobSkillPoint--;
        if (PlayerManager.instance.jobSkillPoint <= 0)
        {
            wazaButton.SetActive(false);
        }

        if (PlayerManager.instance.jobCheck == 1)
        {

            StartCoroutine(Kirisaki());
        }

        if (PlayerManager.instance.jobCheck == 2)
        {

            StartCoroutine(Ensha());
        }
    }

    IEnumerator Kirisaki()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "叩き切る！！" });

        ojamaPanel.blocksRaycasts = true;

        //暗転１
        yield return new WaitForSeconds(0.3f);
        canvasGroup.DOFade(1, kirisakiFadeInTime);
        yield return new WaitForSeconds(kirisakiFadeInTime);
        canvasGroup.DOFade(0, kirisakiFadeOutTime);
        yield return new WaitForSeconds(kirisakiFadeOutTime);

        //暗転２
        canvasGroup.DOFade(1, kirisakiFadeInTime);
        yield return new WaitForSeconds(kirisakiFadeInTime);
        canvasGroup.DOFade(0, kirisakiFadeOutTime);
        yield return new WaitForSeconds(kirisakiFadeOutTime);
        //暗転終了。
        yield return new WaitForSeconds(0.4f);
        //ここで合計１秒



        //攻撃開始
        canvasGroup.DOFade(1, kirisakiFadeInTime);
        yield return new WaitForSeconds(kirisakiFadeInTime);


        //ここで攻撃がヒット
        BladeEffectCanvas.DOFade(1, 0f);
        BladeEffectCanvas.DOFade(0, 0.9f);
        playerDamagePanel.DOShakePosition(0.5f, 0.5f, 20, 0, false, true);
        KirisakiMeichuCheck();


        canvasGroup.DOFade(0, kirisakiFadeOutTime);
        yield return new WaitForSeconds(kirisakiFadeOutTime);
        QuestBGBlur.DOFade(1, 0.35f);
        yield return new WaitForSeconds(0.35f);
        QuestBGBlur.DOFade(0, 0.35f);

        yield return new WaitForSeconds(0.35f);
    }

    void KirisakiMeichuCheck()
    {
        if(DiceRoll.instance.roll2D6==12)
        {
            KirisakiAttack();

        }

        else if(DiceRoll.instance.roll2D6 == 2)
        {
            SkillMiss();
        }
        else if (DiceRoll.instance.roll2D6+PlayerManager.instance.accutracy/2>DiceRoll.instance.roll2D62+enemy.agility)
        {
            KirisakiAttack();
        }
        else
        {
            SkillMiss();
        }

    }

    void KirisakiAttack()
    {
        int damage;

        damage = DiceRoll.instance.roll2D65 + PlayerManager.instance.at;
        damage = damage*5/2;

        enemy.hp -= damage;



        if (DiceRoll.instance.roll2D65 == 12)
        {
            SoundManager.instance.PlaySE(5);
            DialogTextManager.instance.SetScenarios(new string[] { "小気味よい当たり！\n" + damage + "ダメージ！" });

        }

        else if (DiceRoll.instance.roll2D65 == 2)
        {
            SoundManager.instance.PlaySE(4);
            DialogTextManager.instance.SetScenarios(new string[] { "浅い...！\n" + damage + "ダメージ！" });
        }

        else
        {
            SoundManager.instance.PlaySE(1);
            DialogTextManager.instance.SetScenarios(new string[] { "自分の攻撃！\n" + damage + "ダメージ！" });
        }

        if (enemy.hp <= 0)
        {
            enemy.hp = 0;
        }
        battle.ToUpdateUI();

        StartCoroutine(EndBattleCheck());
    }

    void SkillMiss()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "...自分の攻撃は空を切る。" });
        battle.ToUpdateUI();
        StartCoroutine(ToEndButtleCheck());

    }






    IEnumerator Ensha()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "超長距離の一方的な狙撃！" });
        ojamaPanel.blocksRaycasts = true;
        QuestBGBlur.DOFade(1, 1f);


        yield return new WaitForSeconds(1f);

        //ここで合計１秒



        //攻撃開始
        //ここで攻撃がヒット
        QuestBGBlur.DOFade(0, 0f);
        canvasGroup.DOFade(1, 0f);
        canvasGroup.DOFade(0, 0.2f);

        playerDamagePanel.DOShakePosition(0.5f, 0.5f, 20, 0, false, true);
        EnshaMeichuCheck();


        yield return new WaitForSeconds(1f);
        ojamaPanel.blocksRaycasts = false;
    }


    void EnshaMeichuCheck()
    {
        if (DiceRoll.instance.roll2D6 == 12)
        {
            EnshaAttack();

        }

        else if (DiceRoll.instance.roll2D6 == 2)
        {
            EnshaMiss();
        }
        else if (DiceRoll.instance.roll2D6 + PlayerManager.instance.accutracy / 2 > DiceRoll.instance.roll2D62 + enemy.agility)
        {
            EnshaAttack();
        }
        else
        {
            EnshaMiss();
        }

    }

    void EnshaAttack()
    {
        int damage;

        damage = DiceRoll.instance.roll2D65 + PlayerManager.instance.at;
        damage = damage * 3/2;

        enemy.hp -= damage;



        if (DiceRoll.instance.roll2D65 == 12)
        {
            SoundManager.instance.PlaySE(5);
            DialogTextManager.instance.SetScenarios(new string[] { "小気味よい当たり！\n" + damage + "ダメージ！" });

        }

        else if (DiceRoll.instance.roll2D65 == 2)
        {
            SoundManager.instance.PlaySE(4);
            DialogTextManager.instance.SetScenarios(new string[] { "浅い...！\n" + damage + "ダメージ！" });
        }

        else
        {
            SoundManager.instance.PlaySE(1);
            DialogTextManager.instance.SetScenarios(new string[] { "自分の攻撃！\n" + damage + "ダメージ！" });
        }


        if (enemy.hp <= 0)
        {
            enemy.hp = 0;
        }
            battle.ToUpdateUI();

        StartCoroutine(EnshaEnemyCheck());
    }

    void EnshaMiss()
    {
                DialogTextManager.instance.SetScenarios(new string[] { "...自分の攻撃は空を切る。" });
                battle.ToUpdateUI();
    }


    IEnumerator EnshaEnemyCheck()
    {
        if (enemy.hp <= 0)
        {
            enemy.hp = 0;
            battle.ToUpdateUI();

            yield return new WaitForSeconds(1f);
            EndBattle();
        }
    }


    IEnumerator ToEndButtleCheck()
    {
        yield return new WaitForSeconds(0f);
        StartCoroutine(EndBattleCheck());

    }







    IEnumerator EndBattleCheck()
    {

        if (enemy.hp <= 0)
        {
            enemy.hp = 0;
            battle.ToUpdateUI();

            yield return new WaitForSeconds(1f);
            EndBattle();   
        }

        else
        {
            yield return new WaitForSeconds(1f);

            battle.EnemyMeichuCheck();
            yield return new WaitForSeconds(1f);
            ojamaPanel.blocksRaycasts = false;

            if (PlayerManager.instance.hp <= 0)
            {
                StartCoroutine(battle.Die());
            }

        }

    }



    void EndBattle()
    {

        if (PlayerManager.instance.playerMapCheck == 1)
        {
            SoundManager.instance.PlayBGM("Quest");

        }

        else if (PlayerManager.instance.playerMapCheck == 2)
        {
            SoundManager.instance.PlayBGM("Quest2");

        }

        else if (PlayerManager.instance.playerMapCheck == 3)
        {
            SoundManager.instance.PlayBGM("Quest3");

        }

        else if (PlayerManager.instance.playerMapCheck == 4)
        {
            SoundManager.instance.PlayBGM("Quest4");

        }

        else
        {
            SoundManager.instance.PlayBGM("Quest");

        }
        Debug.Log("EndBattle");
        questmanager.EndBattle();
        Destroy(enemy.gameObject);
        enemyUI.gameObject.SetActive(false);
        ojamaPanel.blocksRaycasts = false;

    }


    public void Setup(EnemyManager enemyManager)
    {
        //SoundManager.instance.PlayBGM("Battle");
        enemy = enemyManager;
    }

        public void Test()
    {
        PlayerManager.instance.hp -= 10;

        SoundManager.instance.PlaySE(1);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        DialogTextManager.instance.SetScenarios(new string[] { "痛っ！\nなにかやばいのを踏んづけた。" });

    }
}
