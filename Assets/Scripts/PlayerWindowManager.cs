using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWindowManager : MonoBehaviour
{
    public static PlayerWindowManager instance;

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

    public void ShowTownText()
    {
        StartCoroutine(ShowTownTextC());
    }
    IEnumerator ShowTownTextC()
    {
        yield return new WaitForSeconds(0.81f);
        DialogTextManager.instance.SetScenarios(new string[] { "街についた。\nシャバの空気はうまいぜ。" });
    }
}
