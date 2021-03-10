using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MaouBattleManager : MonoBehaviour
{
    public GameObject MaouEnemyPrehab;
    public StageUIManager stageUI;
    public WazaManager waza;
    public BattleManager battleManager;
    public EnemyUIManager enemyUI;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;
    public PlayerUIManager playerUI;
    public PlayerManager player;
    public CanvasGroup ojamaPanel;
    //public EncountManager encount;
    public TakarabakoManager takarabako;
    public GameObject ToBossbattleButton;

    //public GameObject BossEnemyPrehab;
    [SerializeField] GameObject ToMapOKButton;


    void Start()
    {


        PlayerManager.instance.playerMapCheck = 999;
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        PlayerUIManager.instance.magaChike.text = string.Format("まがチケが無くなった...");

        DialogTextManager.instance.SetScenarios(new string[] { "ここは...\n異質な雰囲気が漂っている。" });
    }


    /*IEnumerator Seaching()
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


        if (random < 35)
        {
            SoundManager.instance.PlayBGM("Battle");
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
        }*/

        /*void EncountEnemy()
        {
            DialogTextManager.instance.SetScenarios(new string[] { "敵だよ！" });
            stageUI.HideButtons();
            GameObject enemyObj = Instantiate(EnemyPrehab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.Setup(enemy);
        }


    /*public void OnTansakuButton()
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(Seaching());
        stageUI.HideButtons();
    }*/

    /*public void OnMachimodoButton()
    {
        SoundManager.instance.PlaySE(0);
        SceneTransitionManager.instance.LoadTo("Town");
        StartCoroutine(Machimodo());
    }

    IEnumerator Machimodo()
    {
        yield return new WaitForSeconds(0.75f);
        DialogTextManager.instance.SetScenarios(new string[] { "街にもどったわよ。" });
    }*/

    /*public void EndBattle()
    {
        enemyUI.gameObject.SetActive(false);
        LevelUpForBattle();
    }

    /*public void LevelUpForBattle()
    {
        PlayerManager.instance.maxHp += 5;
        PlayerManager.instance.at += 5;
        ToMapOKButton.SetActive(true);

        DialogTextManager.instance.SetScenarios(new string[] { "レベルアップ！\n気持ち強くなった！\n　　　　　　...気がする。" });
        SoundManager.instance.PlaySE(0);

        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
    }*/

    public void QuestClear()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "クリア！！おめでとう！" });
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        stageUI.ShowClearText();
        //sceneTransitionManager.LoadTo("Town");
    }

    public void MaouInstantiate()
    {
        GameObject enemyObj = Instantiate(MaouEnemyPrehab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
        waza.SetUp(enemy);
        SoundManager.instance.PlayBGM("BossBattle");


    }

    public void ToBossBattle()
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(BossEffect());
        ToBossbattleButton.SetActive(false);
    }


    IEnumerator BossEffect()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "自分は闇の中を突き進む。" });
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f)
    .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));

        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 1f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        yield return new WaitForSeconds(1f);

        DialogTextManager.instance.SetScenarios(new string[] { "いざ、尋常に―――" });
        MaouInstantiate();
    }

    public void ToGameOver()
    {
        GameOverManager.instance.OnOwariButton();
    }
}
