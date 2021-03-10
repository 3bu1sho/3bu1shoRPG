using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverManager : MonoBehaviour
{

    public GameObject Dialog;
    public FadeIOManager fade;
    public Dialog dialog;
    

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }



    public void OnOwariButton()
    {
        SoundManager.instance.PlaySE(0);
        StartCoroutine(ShowAoriBun());
        SceneTransitionManager.instance.LoadTo("GameOver");
    }

    IEnumerator ShowAoriBun()
    {
        yield return new WaitForSeconds(fade.fastFadeTime);
        DialogTextManager.instance.SetScenarios(new string[] { "死んでしまったけど、\nねこちゃんの画像で\n心を癒してね。" });
    }

}
