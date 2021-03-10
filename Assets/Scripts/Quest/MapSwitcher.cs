using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSwitcher : MonoBehaviour
{

    public GameObject MoriBG;
    public GameObject MoriBG1;

    public GameObject YukiBG;
    public GameObject YukiBG1;




    void Start()
    {
        if (PlayerManager.instance.playerMapCheck==1)
        {
            MoriSetUp();
        }
    }

    void HideAllQuestObj()
    {

    }

void MoriSetUp()
    {

    }
}
