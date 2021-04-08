using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuestManager5 : MonoBehaviour
{
    public GameObject questBG;
    public TakarabakoManager takarabako;
    public GameObject EnemyPrehab;
    public StageUIManager5 stageUI;
    public GameObject BossEnemyPrehab;
    public EncountManager encount;

    public GameObject runButton;
    public GameObject fightButton;


    public BattleManager battleManager;
    public EnemyUIManager enemyUI;
    public WazaManager waza;

    //  public GameObject TansakuButton;

    [SerializeField] GameObject ToMapOKButton;
    public GameObject machimodoButton;

    public GameObject bossBattleButton;
    //   public GameObject returnBossBattleButton;

    public GameObject TakarabakoHiButton;
    public GameObject TakarabakoNoButton;



    public int random;
    int bossCheck;


    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "　　...ここはどこだろう。\n自分の身体すら暗く見えないが\n今はただ進まなければ。" });
        //oundManager.instance.PlayBGM("Quest3");

    }

    public void HideAllQuest4Button()
    {
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
        stageUI.tier++;
        SoundManager.instance.PlaySE(0);
        StartCoroutine(Seaching());
        stageUI.HideButtons();
        HideAllQuest4Button();
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

        random = Random.Range(0, 100);

    }

    public void OnBackButton()
    {
        PlayerManager.instance.magaChike -= 1;
        stageUI.tier--;
        SoundManager.instance.PlaySE(0);
        StartCoroutine(Seaching());
        stageUI.HideButtons();
        HideAllQuest4Button();
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

        random = Random.Range(0, 100);

    }

    public void OnToMapOKButton()
    {
        HideAllQuest4Button();

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

        DialogTextManager.instance.SetScenarios(new string[] { "自分はどぶの中を進む。" });
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

    IEnumerator ShowRogueButton()
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
        SoundManager.instance.PlayBGM("Battle4");
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

        HideAllQuest4Button();
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
            bossCheck++;
            SoundManager.instance.PlayBGM("BossBattle4");

            DialogTextManager.instance.SetScenarios(new string[] { "出口を塞ぐ魔物を見る。\nかなりの強敵であることを\n本能的に理解した。" });
            HideAllQuest4Button();

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

    public void LevelUpForBattle5()
    {
        HideAllQuest4Button();
        if (bossCheck > 0)
        {
            QuestClear();
        }

        else
        {
            PlayerManager.instance.maxHp += 25;
            PlayerManager.instance.strength += 5;

            DialogTextManager.instance.SetScenarios(new string[] { "レベルアップ！\n気持ち強くなった！\nHP+25\nSTR+5" });
            // SoundManager.instance.PlaySE(0);

            PlayerUIManager.instance.UpdateUI(PlayerManager.instance);


            ToMapOKButton.SetActive(true);
        }

    }

    public void QuestClear()
    {
        SaveInt.instance.princess += 7;
        PlayerManager.instance.maxHp += 20;
        PlayerManager.instance.at += 4;
        PlayerManager.instance.magaChike -= 1;
        DialogTextManager.instance.SetScenarios(new string[] { "クリア！！おめでとう！\n＊プリンセスを5手に入れた！" });
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);

        machimodoButton.SetActive(true);
    }

    public void CallHideButton()
    {
        stageUI.HideButtons();
    }

    public void ShowAreaMessage()
    {
        int randomArea;
        randomArea = Random.Range(0, 3);
        if (randomArea == 0)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "へどろが衣服につく。\n　　　......帰りたい。" });
        }
        if (randomArea == 1)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "肌に刺すような痛みが染み渡る。\n長居はすべきではない。\n早く脱出しなければ。\n" });
        }
    }

}
