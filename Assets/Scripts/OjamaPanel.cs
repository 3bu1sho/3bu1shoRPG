using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjamaPanel : MonoBehaviour
{


    public static OjamaPanel instance;

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



    public CanvasGroup ojamaPanel;




    public void Ojama1f()
    {
        StartCoroutine(Ojama1fC());
    }

    IEnumerator Ojama1fC()
    {
        ojamaPanel.blocksRaycasts = true;
        yield return new WaitForSeconds(1f);


        ojamaPanel.blocksRaycasts = false;

    }
}
