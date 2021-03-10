using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public GameObject DialogWindow;
    public static Dialog instance;
    public FadeIOManager fade;
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

    public void BreakDialog()
    {
        DialogWindow=GameObject.Find("メッセージパネル");

        StartCoroutine(WaitForDestroy());
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(fade.deleyFadeTime);
        Destroy(DialogWindow);
    }

    public void InstantiateDialog()
    {
        DialogWindow = GameObject.Find("ダイアログキャンバス");
        StartCoroutine(WaitForInstantiate());
    }

    IEnumerator WaitForInstantiate()
    {
        yield return new WaitForSeconds(fade.deleyFadeTime);
        Instantiate(DialogWindow);
    }

    public void HideDialogWindow()
    {
        DialogWindow.SetActive(false);
    }

    public void ShowDialogWindow()
    {
        DialogWindow.SetActive(true);
    }
}