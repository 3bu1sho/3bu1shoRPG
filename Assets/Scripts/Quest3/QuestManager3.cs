using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuestManager3 : MonoBehaviour
{

    public GameObject questBG;
    public TakarabakoManager takarabako;
    public GameObject EnemyPrehab;
    public StageUIManager3 stageUI;
    public GameObject BossEnemyPrehab;
    public EncountManager encount;

    public GameObject runButton;
    public GameObject fightButton;


    public BattleManager battleManager;
    public EnemyUIManager enemyUI;
    public WazaManager waza;

 //   public GameObject TansakuButton;

    [SerializeField] GameObject ToMapOKButton;
    public GameObject machimodoButton;

    public GameObject bossBattleButton;
 //   public GameObject returnBossBattleButton;

    public GameObject TakarabakoHiButton;
    public GameObject TakarabakoNoButton;



    public int random;


    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "廃墟についた。\n辺りには誰もいないというのに、\n確かな殺気を感じる。" });
        PlayerManager.instance.playerMapCheck = 3;
        //oundManager.instance.PlayBGM("Quest3");


    }

    public void HideAllQuest3Button()
    {
     //   TansakuButton.SetActive(false);
        ToMapOKButton.SetActive(false);
        machimodoButton.SetActive(false);
        bossBattleButton.SetActive(false);
     //   returnBossBattleButton.SetActive(false);
        TakarabakoHiButton.SetActive(false);
        TakarabakoNoButton.SetActive(false);
        stageUI.HideButtons();

    }




    public void OnTansakuButton()
    {
        PlayerManager.instance.magaChike -= 1;

        SoundManager.instance.PlaySE(0);
        StartCoroutine(Seaching());
        //stageUI.HideButtons();
        HideAllQuest3Button();
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

        random = Random.Range(0, 100);

    }

    public void OnToMapOKButton()
    {
        HideAllQuest3Button();

        //    TansakuButton.SetActive(true);
        // ShowStageText();
        // SoundManager.instance.PlaySE(0);
        stageUI.ShowButtons();


    }


    IEnumerator Seaching()
    {
        int random;
        random = encount.r;
        Debug.Log(random);

        DialogTextManager.instance.SetScenarios(new string[] { "自分は瓦礫の山を進む。" });
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f)
        .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));

        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 1f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        yield return new WaitForSeconds(1f);

        if (random < 35)
        {
            Debug.Log("敵だよ！");
            EncountEnemy();
        }

        else if (random < 55)
        {
            stageUI.HideButtons();
            takarabako.FindTakarabako();
        }

        else
        {
            stageUI.ShowButtons();
        }

        void EncountEnemy()
        {

            if (PlayerManager.instance.jobCheck == 4)
            {
                DialogTextManager.instance.SetScenarios(new string[] { "敵が見える。向こうは\nこちらに気づいていない\nようだ。\nさて、どうしようか。" });
                StartCoroutine(ShowRogueButton());

            }

            else
            {
                EncountProcess();
            }
        }
    }

    IEnumerator  ShowRogueButton()
    {
        yield return new WaitForSeconds(1f);
        runButton.SetActive(true);
        fightButton.SetActive(true);
    }

    public void OnFightButton()
    {
        runButton.SetActive(false);
        fightButton.SetActive(false);
        SoundManager.instance.PlaySE(0);
        StartCoroutine(Fighting());
    }

    public void OnRunButton()
    {
        runButton.SetActive(false);
        fightButton.SetActive(false);
        SoundManager.instance.PlaySE(0);
        OnToMapOKButton();

    }


    IEnumerator Fighting()
    {
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f)
.OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));

        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 1f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        yield return new WaitForSeconds(1f);

        EncountProcess();
    }

    public void EncountProcess()
    {
        SoundManager.instance.PlayBGM("Battle3");
        DialogTextManager.instance.SetScenarios(new string[] { "敵だよ！" });
        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(EnemyPrehab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
        waza.SetUp(enemy);
    }

    public void ToBossBattle()
    {
        SoundManager.instance.PlaySE(0);

        HideAllQuest3Button();
        DialogTextManager.instance.SetScenarios(new string[] { "自分は勇気を振り絞る。" });
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f)
    .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));

        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 1f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        StartCoroutine(BossBattle());
    }

    IEnumerator BossBattle()
    {

        yield return new WaitForSeconds(1f);

        if (PlayerManager.instance.bossCount3 == 0)
        {
            PlayerManager.instance.bossCount3++;
            SoundManager.instance.PlayBGM("BossBattle3");

            DialogTextManager.instance.SetScenarios(new string[] { "瞬間、悪寒を覚える。\n自分はこの戦いに持てる\n全てを尽くすまで。" });
            HideAllQuest3Button();

            GameObject enemyObj = Instantiate(BossEnemyPrehab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.Setup(enemy);
            waza.SetUp(enemy);
        }

        else
        {
            DialogTextManager.instance.SetScenarios(new string[] { "そういえばボス倒してたわ。" });
            ToMapOKButton.SetActive(true);
        }

    }

    public void LevelUpForBattle3()
    {
        if (PlayerManager.instance.bossCount3 > 0)
        {
            QuestClear();
        }

        else
        {
            PlayerManager.instance.maxHp += 15;
            PlayerManager.instance.at += 15;

            DialogTextManager.instance.SetScenarios(new string[] { "レベルアップ！\n気持ち強くなった！\n　　　　　　...気がする。" });
            // SoundManager.instance.PlaySE(0);

            PlayerUIManager.instance.UpdateUI(PlayerManager.instance);


            ToMapOKButton.SetActive(true);
        }

    }

    public void QuestClear()
    {
        SaveInt.instance.princess += 5;
        PlayerManager.instance.maxHp += 15;
        PlayerManager.instance.at += 15;
        PlayerManager.instance.magaChike -= 1;
        DialogTextManager.instance.SetScenarios(new string[] { "クリア！！おめでとう！\n＊プリンセスを5手に入れた！" });
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);

        machimodoButton.SetActive(true);
    }

    /*

    void ShowStageText()
    {
        random = Random.Range(0, 100);
        if (random > 25)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "凍てつく外気が肌を刺す。\nここに長居はすべきでは\nないだろう。" });
        }
        else if (random > 50)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "寒い...ただ寒い。\n視界が晴れず、ただ\n不安だけが増していく。" });
        }
        else if (random > 75)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "...暑い。\n寒さを感じないどころか、\nとにかく暑い。\nいっそ装備でも脱いでしまおうか。" });
        }
        else
        {
            DialogTextManager.instance.SetScenarios(new string[] { "---負けてたまるか。\nそう自分に言い聞かせる。\nせめて気持ちだけは、強くあれ。" });
        }
    }

        */

    public void CallHideButton()
    {
        stageUI.HideButtons();
    }

}
