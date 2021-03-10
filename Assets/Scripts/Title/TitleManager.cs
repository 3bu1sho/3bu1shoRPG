using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject dialog;
    //PlayerManager player;

    //void Update()
    //{
    //    Destroy(dialog);
    //}

    void Start()
    {
        //player = PlayerManager.instance;
        Dialog.instance.HideDialogWindow();
        PlayerUIManager.instance.HidePlayerUI();
        PlayerUIManager.instance.StatusReset();

    }

    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
        SceneTransitionManager.instance.LoadToNoBGM("CharacterSelect");
    }
}
