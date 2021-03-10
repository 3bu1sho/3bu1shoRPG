using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owaributton : MonoBehaviour
{
    public Dialog dialog;
    public FadeIOManager fade;
    public SceneTransitionManager scene;

    public GameObject DialogWindow;

    private void Start()
    {
        Destroy(PlayerUIManager.instance);
    }

    public void OnOKButton()
    {
        //Dialog.instance.BreakDialog();
        DialogWindow = GameObject.Find("ダイアログキャンバス");
        SoundManager.instance.PlaySE(0);
        //dialog.BreakDialog();
        StartCoroutine(WaitForDestroy());
        SoundManager.instance.PlaySE(0);
        SceneTransitionManager.instance.LoadTo("Title");

        PlayerUIManager.instance.StatusReset();
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(0.79f);
        Destroy(DialogWindow);
    }

}
