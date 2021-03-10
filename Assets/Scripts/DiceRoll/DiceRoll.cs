using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{

    public static DiceRoll instance;


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

    public int dice1;
    public int dice2;
    public int roll2D6;

    public int dice3;
    public int dice4;
    public int roll2D62;

    public int dice5;
    public int dice6;
    public int roll2D63;

    public int dice7;
    public int dice8;
    public int roll2D64;

    public int dice9;
    public int dice10;
    public int roll2D65;

    private void Update()
    {
        dice1 = Random.Range(1, 7);
        dice2 = Random.Range(1, 7);
        roll2D6 = dice1 + dice2;



        dice3 = Random.Range(1, 7);
        dice4 = Random.Range(1, 7);
        roll2D62 = dice3 + dice4;

        dice5 = Random.Range(1, 7);
        dice6 = Random.Range(1, 7);
        roll2D63 = dice5 + dice6;

        dice7 = Random.Range(1, 7);
        dice8 = Random.Range(1, 7);
        roll2D64 = dice7 + dice8;

        dice9 = Random.Range(1, 7);
        dice10 = Random.Range(1, 7);
        roll2D65 = dice9 + dice10;
    }

    public void OhDiceRoll()
    {
        roll2D6 = dice1 + dice2;
        Debug.Log("出目は" + roll2D6);
    }



    public enum DicePattern
        {
            ROKUZORO,
            ICHIZORO,
            NORMAL,
        }

    public DicePattern type = DicePattern.NORMAL;


    public void DiceCheck()
        {
            if(roll2D6==12)
            {
                type = DicePattern.ROKUZORO;
            }

            else if (roll2D6 == 2)
            {
                type = DicePattern.ICHIZORO;

            }

            else
            {
                type = DicePattern.NORMAL;
            }
        }

        
}
