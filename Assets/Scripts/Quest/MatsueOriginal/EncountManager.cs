using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncountManager : MonoBehaviour
{
    // 60%の確率で敵, 40%の確率でアイテム

    public int r; //0-99までの数字からランダムに１つ選ばれる

    void Update()
    {
        r = Random.Range(0, 100);
    }

    public void RandomEncount()
    {
        Debug.Log(r);
        if (r < 59)
        {
            //Debug.Log("敵に遭遇");
        }
        else
        {

            //Debug.Log("アイテムを発見");
        }
    }
}