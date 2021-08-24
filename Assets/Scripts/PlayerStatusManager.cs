using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusManager : MonoBehaviour
{

    public static PlayerStatusManager instance;

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

    public GameObject playerStatusManager;

    private void Start()
    {
        playerStatusManager.SetActive(false);

    }


    public GameObject PlayerStatusWindow;

    public Text hp;
    public Text gold;
    public Text str;
    public Text accutracy;
    public Text agility;
    public Text dexterity;
    public Text luck;
    public Text weapon;
    public Text armor;
    public Text job;
    public Text choker;
    public Text princess;


    public GameObject hpObj;
    public GameObject goldObj;
    public GameObject atObj;
    public GameObject accutracyObj;
    public GameObject agilityObj;
    public GameObject dexterityObj;
    public GameObject luckObj;
    public GameObject tokuseiObj;
    public GameObject weaponObj;
    public GameObject armorObj;
    public GameObject jobObj;
    public GameObject chokerObj;
    public GameObject princessObj;


    public CanvasGroup ojamaPanel;

    public Text tokusei;
    public void ShowStatus()
    {
        playerStatusManager.SetActive(true);
        PlayerStatusWindow.SetActive(true);
        jobObj.SetActive(true);

        hpObj.SetActive(true);
        goldObj.SetActive(true);
        atObj.SetActive(true);
        accutracyObj.SetActive(true);
        agilityObj.SetActive(true);
        luckObj.SetActive(true);
        tokuseiObj.SetActive(true);
        weaponObj.SetActive(true);
        armorObj.SetActive(true);
        dexterityObj.SetActive(true);
        chokerObj.SetActive(true);
        princessObj.SetActive(true);



        ojamaPanel.blocksRaycasts = true;

        if(PlayerManager.instance.jobCheck==1)
        {
            job.text = string.Format("職業:戦士");
        }
        else if (PlayerManager.instance.jobCheck == 2)
        {
            job.text = string.Format("職業:弓術士");
        }
        else if (PlayerManager.instance.jobCheck == 3)
        {
            job.text = string.Format("職業:ギャンブラー");
        }
        else if (PlayerManager.instance.jobCheck == 4)
        {
            job.text = string.Format("職業:盗賊");
        }
        else 
        {
            job.text = string.Format("職業:持たざる者");
        }


        SoundManager.instance.PlaySE(0);
        hp.text = string.Format("HP:{0}/{1}", PlayerManager.instance.hp, PlayerManager.instance.maxHp);
        gold.text = string.Format("Gold:{0}", PlayerManager.instance.gold);
        str.text = string.Format("STR:{0}", PlayerManager.instance.strength);
        accutracy.text = string.Format("ACC:{0}", PlayerManager.instance.accutracy);
        agility.text = string.Format("AGI:{0}", PlayerManager.instance.agility);
        luck.text = string.Format("LUC:{0}", PlayerManager.instance.luck);
        dexterity.text = string.Format("DEX:{0}", PlayerManager.instance.dexterity);


        if (PlayerManager.instance.weaponType==0)
        {
            weapon.text = string.Format("武器:なし");
        }

        else if (PlayerManager.instance.weaponType == 1)
        {
            weapon.text = string.Format("武器:粗悪");
        }
        else if (PlayerManager.instance.weaponType == 2)
        {
            weapon.text = string.Format("武器:普通");
        }
        else if (PlayerManager.instance.weaponType == 3)
        {
            weapon.text = string.Format("武器:上質");
        }
        else if (PlayerManager.instance.weaponType == 4)
        {
            weapon.text = string.Format("武器:上質");
        }
        else if (PlayerManager.instance.weaponType == 5)
        {
            weapon.text = string.Format("武器:神聖");
        }
        else if (PlayerManager.instance.weaponType == 6)
        {
            weapon.text = string.Format("武器:創世");
        }

        if (PlayerManager.instance.armorType == 0)
        {
            armor.text = string.Format("防具:なし");
        }
        else if (PlayerManager.instance.armorType == 1)
        {
            armor.text = string.Format("防具:粗悪");
        }
        else if (PlayerManager.instance.armorType == 2)
        {
            armor.text = string.Format("防具:普通");
        }
        else if (PlayerManager.instance.armorType == 3)
        {
            armor.text = string.Format("防具:上質");
        }
        else if (PlayerManager.instance.armorType == 4)
        {
            armor.text = string.Format("防具:上質");
        }
        else if (PlayerManager.instance.armorType == 5)
        {
            armor.text = string.Format("防具:神聖");
        }
        else if (PlayerManager.instance.armorType == 6)
        {
            armor.text = string.Format("防具:創世");
        }

        choker.text = string.Format("チョーカー:"+SaveInt.instance.choker);
        princess.text = string.Format("プリンセス:" + SaveInt.instance.princess);


        tokusei.text = string.Format("あなたは" + PlayerManager.instance.tokusei1text + "、\n" + PlayerManager.instance.tokusei2text + "、\n" + PlayerManager.instance.tokusei3text + "。");

    }

    public void OnBackButton()
    {
        SoundManager.instance.PlaySE(0);

        playerStatusManager.SetActive(false);
        PlayerStatusWindow.SetActive(false);
        jobObj.SetActive(false);

        hpObj.SetActive(false);
        goldObj.SetActive(false);
        atObj.SetActive(false);
        accutracyObj.SetActive(false);
        agilityObj.SetActive(false);
        luckObj.SetActive(false);
        tokuseiObj.SetActive(false);
        weaponObj.SetActive(false);
        armorObj.SetActive(false);
        dexterityObj.SetActive(false);
        chokerObj.SetActive(false);
        princessObj.SetActive(false);



        ojamaPanel.blocksRaycasts = false;
    }
}
