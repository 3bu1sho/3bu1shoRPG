using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{

    Action tapAction;

    public int hp;
    public int at;
    public int accuracy;
    public int agility;
    public int dexterity;

    public new string name;
    public GameObject hitEffect;

    public int Attack(PlayerManager player)
    {
        int hidamage = player.Damage(DiceRoll.instance.roll2D65+at);


        return hidamage;
    }

    public int Damage(int damage)
    {
        Instantiate(hitEffect,this.transform,false);
        transform.DOShakePosition(0.3f,0.5f,20,0,false,true);


        if (DiceRoll.instance.roll2D65 == 2)
        {
            damage = damage / 2;
        }

        else if (DiceRoll.instance.roll2D65 + dexterity / 4 >= 13)
        {
            damage = damage * 3 / 2;
        }

        hp -= damage;
        Debug.Log("敵のHPは" + hp);


        if (hp<=0)
        {
            hp = 0;
        }

        return damage;
    }

    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        Debug.Log("クリックしたね");
        tapAction();
    }
}
