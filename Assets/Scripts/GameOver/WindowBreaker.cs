using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreaker : MonoBehaviour
{

    GameObject playerUI;
    private void Start()
    {
        playerUI = GameObject.Find("プレイヤー用キャンバス");
        //Destroy(PlayerUIManager.instance);
        Destroy(playerUI);
    }
}
