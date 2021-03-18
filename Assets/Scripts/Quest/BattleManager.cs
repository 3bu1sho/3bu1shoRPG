using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleManager : MonoBehaviour
{
    PlayerManager player;
    public EnemyManager enemy;
    public EnemyUIManager enemyUI;
    PlayerUIManager playerUI;
    public QuestManager questmanager;
    public Transform playerDamagePanel;
    public CanvasGroup ojamaPanel;
    public SceneTransitionManager scene;
    public StageUIManager stageUI;
    public GameObject OwariButton;
    public CanvasGroup ojamaPanel2;



    private void Start()
    {
        playerUI = PlayerUIManager.instance;
        player = PlayerManager.instance;
        //4/26 でやったとこ。

        enemyUI.gameObject.SetActive(false);
    }


    public void Setup(EnemyManager enemyManager)
    {
        //SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);

        enemy.AddEventListenerOnTap(BattleStart);
    }

    void BattleStart()
    {
        StartCoroutine(SpeedForBattle());
    }

    IEnumerator SpeedForBattle()
    {
        if (DiceRoll.instance.roll2D6 == 2)
        {
            ojamaPanel.blocksRaycasts = true;
            EnemyMeichuCheck();

            if (PlayerManager.instance.hp <= 0)
            {
                StartCoroutine(Die());
            }

            else
            {
                yield return new WaitForSeconds(1f);
                PlayerMeichuCheck();

                if (enemy.hp == 0)
                {
                    yield return new WaitForSeconds(1f);
                    EndBattle();
                }
            }
            ojamaPanel.blocksRaycasts = false;
        }

        else if (DiceRoll.instance.roll2D6 == 12)
        {
            ojamaPanel.blocksRaycasts = true;
            PlayerMeichuCheck();
            yield return new WaitForSeconds(1f);

            if (enemy.hp == 0)
            {
                yield return new WaitForSeconds(1f);
                EndBattle();
            }

            else
            {
                EnemyMeichuCheck();
                if (PlayerManager.instance.hp <= 0)
                {
                    StartCoroutine(Die());
                }
            }
            ojamaPanel.blocksRaycasts = false;
        }

        else if (PlayerManager.instance.agility + DiceRoll.instance.roll2D6 > enemy.agility + DiceRoll.instance.roll2D62)
        {
            ojamaPanel.blocksRaycasts = true;
            PlayerMeichuCheck();
            yield return new WaitForSeconds(1f);

            if (enemy.hp == 0)
            {
                EndBattle();
            }

            else
            {
                EnemyMeichuCheck();
                if (PlayerManager.instance.hp <= 0)
                {
                    StartCoroutine(Die());
                }
            }
            ojamaPanel.blocksRaycasts = false;
        }

        else
        {

            ojamaPanel.blocksRaycasts = true;
            EnemyMeichuCheck();

            if (PlayerManager.instance.hp <= 0)
            {
                StartCoroutine(Die());
            }

            else
            {
                yield return new WaitForSeconds(1f);
                PlayerMeichuCheck();
                if (enemy.hp == 0)
                {
                    yield return new WaitForSeconds(1f);
                    EndBattle();
                }
            }
            ojamaPanel.blocksRaycasts = false;
        }
    }

    void PlayerMeichuCheck()
    {
        if(DiceRoll.instance.roll2D63==2)
        {
            PlayerMissAttack();
        }

        else if ( DiceRoll.instance.roll2D63 == 12)
        {
            PlayerAttack();
        }

        else if (player.accutracy + DiceRoll.instance.roll2D63 >enemy.agility + DiceRoll.instance.roll2D64)
        {
            PlayerAttack();
        }

        else
        {
            PlayerMissAttack();
        }
    }
    void PlayerAttack()
    {
        int damage = 
        player.Attack(enemy);
        if (DiceRoll.instance.roll2D65 +PlayerManager.instance.dexterity/4>= 13)
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


        enemyUI.UpdateUI(enemy);
    }

    void PlayerMissAttack()
    {
        SoundManager.instance.PlaySE(4);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
             //.OnComplete(() => ojamaPanel.blocksRaycasts = false);
        DialogTextManager.instance.SetScenarios(new string[] { "やばい、外した。" });
    }

    public void EnemyMeichuCheck()
    {
        if (DiceRoll.instance.roll2D63 == 2)
        {
            EnemyMissAttack();
        }

        else if (DiceRoll.instance.roll2D63 == 12)
        {
            EnemyTurn();
        }

        else if (enemy.accuracy + DiceRoll.instance.roll2D63 > player.agility + DiceRoll.instance.roll2D64)
        {
            EnemyTurn();
        }

        else
        {
            EnemyMissAttack();

        }
    }

    void EnemyMissAttack()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "やった！　よけれた！" });
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        SoundManager.instance.PlaySE(4);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
          //.OnComplete(() => ojamaPanel.blocksRaycasts = false);
    }

    void EnemyTurn()
    {
        int hidamage = enemy.Attack(player);
        if (DiceRoll.instance.roll2D65 + enemy.dexterity / 4 >= 13)
        {
            SoundManager.instance.PlaySE(5);
            DialogTextManager.instance.SetScenarios(new string[] { "瞬間、意識が飛ぶ。\n   ..." +  hidamage + "ダメージ！" });

        }

        else if (DiceRoll.instance.roll2D65 == 2)
        {
            SoundManager.instance.PlaySE(4);
            DialogTextManager.instance.SetScenarios(new string[] { "浅い...！\n" + hidamage + "ダメージ！" });
        }

        else
        {
            SoundManager.instance.PlaySE(6);
            DialogTextManager.instance.SetScenarios(new string[] { "敵さんの攻撃！\n" + hidamage + "ダメージ！" });
        }
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
          //.OnComplete(() => ojamaPanel.blocksRaycasts = false);
    }

    public void ToEndBattle()
    {
        EndBattle();
    }

    void EndBattle()
    {        

        if(PlayerManager.instance.playerMapCheck==1)
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

    public IEnumerator Die()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "あっ、これ\n死んだわ。" });
        ojamaPanel2.blocksRaycasts = true;
        ojamaPanel.blocksRaycasts = true;

        stageUI.HideButtons();
        yield return new WaitForSeconds(1.5f);
        ojamaPanel.blocksRaycasts = false;

        OwariButton.SetActive(true);
        Destroy(enemy.gameObject);
        ItemManager.instance.HideErikusaButton();
    }

    public void ToUpdateUI()
    {
        enemyUI.UpdateUI(enemy);

    }
}
