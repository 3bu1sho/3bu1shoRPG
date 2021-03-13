using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxHp;
    public int hp;
    public int strength;
    public int at;
    public int gold;
    public int damage;
    public int accutracy;
    public int agility;
    public int bossCount;
    public int bossCount2;
    public int bossCount3;
    public int magaChike;
    public int luck;
    public int dexterity;

    public int jobCheck;
    public int jobSkillPoint;
    public int maxJobSkillPoint;


    //ここから下、隠しステータス。
    public void ActivateHiddenStatus()
    {
        at = strength * 5 + weaponAT+luck/2;
    }

    //ここから下、特性。

    //intが1で特性が有効、0で無効です。

    public int ChikaraJiman;
    public int Subayai;
    public int Tairyokugaaru;
    public int Tsuiteiru;
    public int kiyou;
    public int okanemochi;

    public int playerMapCheck;

    public static PlayerManager instance;

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

    public int maousyori;
    private void Update()
    {
        if(magaChike<=0)
        {
            maousyori++;
        }

        if(maousyori==1)
        {
            PlayerUIManager.instance.magaChike.text = string.Format("まがチケが無い...");
            SceneTransitionManager.instance.LoadTo("Maou");

        }
    }



    public int Attack(EnemyManager enemy)
    {

        int damage = enemy.Damage(DiceRoll.instance.roll2D65+at);
        return damage;
    }

    public int Damage(int damage)
    {

        if (DiceRoll.instance.roll2D65 == 2)
        {
            damage = damage / 2;
        }

        else if (DiceRoll.instance.roll2D65 + PlayerManager.instance.dexterity / 4 >= 13)
        {
            damage = damage * 5 / 4;
        }

        damage -= PlayerManager.instance.armorPT;
        if (damage <= 0)
        {
            damage = 0;
        }
        hp -= damage;
        Debug.Log("プレイヤーのHPは" + hp);

        if (hp<=0)
        {
            hp = 0;
        }
        return damage;
    }

    //以下特性
    public string tokusei1text = "特性その１を選択可能";
    public string tokusei2text = "特性その２を選択可能";
    public string tokusei3text = "特性その３を選択可能";

    //以下武器
    public int weaponSlot;
    //１で有効、０で無効

    public int weaponType;
    //１で粗い、２で普通、３で上質

    public int weaponAT;

    //以下防具
    public int armorSlot;
    //１で有効、０で無効

    public int armorType;
    //１で粗い、２で普通、３で上質

    public int armorPT;
}


