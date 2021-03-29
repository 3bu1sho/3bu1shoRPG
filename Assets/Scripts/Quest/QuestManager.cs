using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuestManager : MonoBehaviour
{


    //int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    //int currentStage = 0;

    public QuestManager2 quest2;
    public QuestManager3 quest3;


    public GameObject EnemyPrehab;
    public StageUIManager stageUI;
    public StageUIManager3 stageUI3;
    public StageUIManager4 stageUI4;


    public BattleManager battleManager;
    public WazaManager waza;
    public EnemyUIManager enemyUI;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;
    public PlayerUIManager playerUI;
    public PlayerManager player;
    public CanvasGroup ojamaPanel;
    public EncountManager encount;
    public TakarabakoManager takarabako;


    public GameObject BossEnemyPrehab;
    [SerializeField] GameObject ToMapOKButton;
    public GameObject wazaButton;

    public GameObject runButton;
    public GameObject fightButton;




    void Start()
    {
        playerUI.SetupUI(player);
            //stageUI.UpdateUI(currentStage);
        if(PlayerManager.instance.playerMapCheck==1)
        {
            SetupMori();

        }
    }

    void SetupMori()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "森についた。\nうっそうとした木々が\n視界を塞ぐ。" });
        PlayerManager.instance.playerMapCheck = 1;
    }


    IEnumerator Seaching()
    {
        int random;
        random = encount.r;
        Debug.Log(random);

        DialogTextManager.instance.SetScenarios(new string[] { "自分は森を突き進む。" });
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f)
        .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));

        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 1f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        yield return new WaitForSeconds(1f);

        //currentStage++;
        //Debug.Log("今は"+currentStage+"だよ！");

        //stageUI.UpdateUI(currentStage);


        /*
        if (encountTable.Length <= currentStage)
        {
            Debug.Log("クエストクリア");
            QuestClear();
        }
        */



        /*else*/
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

            if(PlayerManager.instance.jobCheck==4)
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
        stageUI.HideButtons();
        StartCoroutine(Fighting());

    }

    public void OnRunButton()
    {
        runButton.SetActive(false);
        fightButton.SetActive(false);
        SoundManager.instance.PlaySE(0);
        stageUI.HideButtons();
        stageUI.ShowButtons();

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
        SoundManager.instance.PlayBGM("Battle");
        DialogTextManager.instance.SetScenarios(new string[] { "敵だよ！" });
        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(EnemyPrehab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
        waza.SetUp(enemy);
    }


    public void OnTansakuButton()
    {
        PlayerManager.instance.magaChike -= 1;
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

        SoundManager.instance.PlaySE(0);
        StartCoroutine(Seaching());
        stageUI.HideButtons();
    }

    public void CallHideButton()
    {
        wazaButton.SetActive(false);
        if (PlayerManager.instance.playerMapCheck==1)
        {
            stageUI.HideButtons();
        }

        if (PlayerManager.instance.playerMapCheck == 3)
        {
            stageUI3.HideButtons();
        }
    }

    public void OnMachimodoButton()
    {
        SoundManager.instance.PlaySE(0);
        SceneTransitionManager.instance.LoadTo("Town");
        StartCoroutine(Machimodo());
        PlayerManager.instance.playerMapCheck = 0;
    }

    IEnumerator Machimodo()
    {
        yield return new WaitForSeconds(0.75f);
        DialogTextManager.instance.SetScenarios(new string[] { "街にもどったわよ。" });
    }
    
    public void EndBattle()
    {
        PlayerManager.instance.magaChike--;
        enemyUI.gameObject.SetActive(false);
        wazaButton.SetActive(false);
        PlayerManager.instance.jobSkillPoint = PlayerManager.instance.maxJobSkillPoint;

        if (PlayerManager.instance.playerMapCheck == 2)
        {
            quest2.LevelUpForBattle2();
        }

        if (PlayerManager.instance.playerMapCheck == 3)
        {
            quest3.LevelUpForBattle3();
        }

        else
        {
            LevelUpForBattle();
            ToMapOKButton.SetActive(true);

        }
    }

    public void LevelUpForBattle()
    {
        PlayerManager.instance.maxHp += 5;
        PlayerManager.instance.strength += 1;

        DialogTextManager.instance.SetScenarios(new string[] { "レベルアップ！\n気持ち強くなった！\n　　　　　　...気がする。" });
        SoundManager.instance.PlaySE(0);

        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
    }

    public void QuestClear()
    {
        if (PlayerManager.instance.bossCount == 0)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "クリア！！おめでとう！\n＊プリンセスを1手に入れた！" });
        }
        else
        {
            DialogTextManager.instance.SetScenarios(new string[] { "クリア！！おめでとう！\n＊プリンセスは入手済み" });
        }
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        player.bossCount=1;

        //stageUI.ShowClearText();
        //sceneTransitionManager.LoadTo("Town");
    }

    public void BossInstantiate()
    {
        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(BossEnemyPrehab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
        SoundManager.instance.PlayBGM("BossBattle");
    }

    public void ToBossBattle()
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(BossEffect());
        stageUI.HideButtons();
    }


    IEnumerator BossEffect()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "自分は森を突き進む。" });
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f)
    .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));

        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 1f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        yield return new WaitForSeconds(1f);

        if (PlayerManager.instance.bossCount >= 1)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "そういえばボス倒してたわ。" });
            ToMapOKButton.SetActive(true);
        }
        else if (PlayerManager.instance.bossCount<=0)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "ラストバトル！" });

            //player.bossCount++;
            BossInstantiate();
        }
    }

    public void ToGameOver()
    {
        GameOverManager.instance.OnOwariButton();
    }
}