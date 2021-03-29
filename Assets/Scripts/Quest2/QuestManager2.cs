using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuestManager2 : MonoBehaviour
{

    public GameObject questBG;
    public TakarabakoManager takarabako;
    public GameObject EnemyPrehab;
    public GameObject BossEnemyPrehab;

    public GameObject runButton;
    public GameObject fightButton;

    public BattleManager battleManager;
    public EnemyUIManager enemyUI;
    public WazaManager waza;

    public GameObject TansakuButton;

    [SerializeField] GameObject ToMapOKButton;
    public GameObject machimodoButton;

    public GameObject bossBattleButton;
    public GameObject returnBossBattleButton;

    public GameObject TakarabakoHiButton;
    public GameObject TakarabakoNoButton;



    public int random;

    int bossCount;


    private void Start()
    {
       // SoundManager.instance.PlayBGM("Quest2");
        DialogTextManager.instance.SetScenarios(new string[] { "雪原についた。\n荒れ狂う吹雪が容赦なく\n自分に襲い掛かる。\n...視界がよくない。" });

        if(PlayerManager.instance.playerMapCheck>0)
        {
            bossCount++;
        }

    }

    void HideAllQuest2Button()
    {
        TansakuButton.SetActive(false);
        ToMapOKButton.SetActive(false);
        machimodoButton.SetActive(false);
        bossBattleButton.SetActive(false);
        returnBossBattleButton.SetActive(false);
        TakarabakoHiButton.SetActive(false);
        TakarabakoNoButton.SetActive(false);

    }




    public void OnTansakuButton()
    {
        PlayerManager.instance.magaChike -= 1;

        SoundManager.instance.PlaySE(0);
        StartCoroutine(Seaching());
        //stageUI.HideButtons();
        HideAllQuest2Button();
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

        random = Random.Range(0, 100);

    }

    public void OnToMapOKButton()
    {
        HideAllQuest2Button();

        TansakuButton.SetActive(true);
        SHowStageText();
       // SoundManager.instance.PlaySE(0);

    }


    IEnumerator Seaching()
    {

        DialogTextManager.instance.SetScenarios(new string[] { "自分は吹雪を突き進む。" });
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
            HideAllQuest2Button();
            //stageUI.HideButtons();
            takarabako.FindTakarabako();
        }

        else if (random < 65)
        {
            TansakuButton.SetActive(true);
            machimodoButton.SetActive(true);
            DialogTextManager.instance.SetScenarios(new string[] { "来た道が見えた！\n引き返すなら今だ" });

        }

        else if(random < 80)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "刹那、寒気とは違う寒気が走る。\n\n*ボス戦になります。\n覚悟は決まりましたか？" });
            StartCoroutine(PreparationBossBattle());

        }

        else
        {

            //stageUI.ShowButtons();
            HideAllQuest2Button();
            TansakuButton.SetActive(true);
            SHowStageText();

        }

        IEnumerator PreparationBossBattle()
        {
            yield return new WaitForSeconds(1f);
            bossBattleButton.SetActive(true);
            returnBossBattleButton.SetActive(true);
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
        SoundManager.instance.PlayBGM("Battle2");
        DialogTextManager.instance.SetScenarios(new string[] { "敵だよ！" });
        HideAllQuest2Button();
        GameObject enemyObj = Instantiate(EnemyPrehab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
        waza.SetUp(enemy);
    }

    public void ToBossBattle()
    {
        SoundManager.instance.PlaySE(0);

        HideAllQuest2Button();
        DialogTextManager.instance.SetScenarios(new string[] { "自分は吹雪を突き進む。" });
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f)
    .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));

        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 1f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        PlayerManager.instance.bossCount2++;
        StartCoroutine(BossBattle());
    }

    IEnumerator BossBattle()
    {

        yield return new WaitForSeconds(1f);

        if(bossCount>0)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "そういえばボス倒してた。" });
            returnBossBattleButton.SetActive(true);

        }
        else
        {
            SoundManager.instance.PlayBGM("BossBattle2");

            DialogTextManager.instance.SetScenarios(new string[] { "ラストバトル!" });
            //stageUI.HideButtons();
            HideAllQuest2Button();

            GameObject enemyObj = Instantiate(BossEnemyPrehab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.Setup(enemy);
            waza.SetUp(enemy);

            bossCount++;
        }
    }

    public void LevelUpForBattle2()
    {
        if(PlayerManager.instance.bossCount2>0)
        {
            QuestClear();
        }

        else
        {
            PlayerManager.instance.maxHp += 10;
            PlayerManager.instance.strength += 2;

            DialogTextManager.instance.SetScenarios(new string[] { "レベルアップ！\n気持ち強くなった！\n　　　　　　...気がする。" });
           // SoundManager.instance.PlaySE(0);

            PlayerUIManager.instance.UpdateUI(PlayerManager.instance);


            ToMapOKButton.SetActive(true);

        }

    }

    void QuestClear()
    {
        SaveInt.instance.princess += 3;
        PlayerManager.instance.maxHp += 15;
        PlayerManager.instance.at += 15;
        PlayerManager.instance.magaChike -= 1;
        DialogTextManager.instance.SetScenarios(new string[] { "クリア！！おめでとう！\n＊プリンセスを3手に入れた！" });
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);

        machimodoButton.SetActive(true);
    }

    void SHowStageText()
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

}
