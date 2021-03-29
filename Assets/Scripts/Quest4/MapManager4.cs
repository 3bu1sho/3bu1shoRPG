using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapManager4 : MonoBehaviour
{
    public GameObject BossBattleButton;
    public GameObject TansakuButton;
    public Text tier;

    int stageCurrent;
    public void ShowButton()
    {
        if(stageCurrent==20)
        {
            BossBattleButton.SetActive(true);
            tier.text = string.Format("帰還");
        }
        else
        {
            TansakuButton.SetActive(true);
            stageCurrent++;
            tier.text = string.Format("階層:{0}",tier);
        }
    }
}
