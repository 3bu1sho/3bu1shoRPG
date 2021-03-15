using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{

    PlayerManager player;
    PlayerUIManager playerUI;


    private void Start()
    {
        playerUI = PlayerUIManager.instance;
        player = PlayerManager.instance;
    }

    public static PlayerUIManager instance;

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

    public GameObject playerUIManager;

    public Text hpText;
    //public Text atText;
    public Text goldText;
    public Text erikusaText;
    public Text magaChike;




    public void SetupUI(PlayerManager player)
    {
        
        UpdateUI(player);
    }


    public void UpdateUI(PlayerManager player)
    {
        hpText.text = string.Format("HP:{0}/{1}", player.hp, player.maxHp);
        //atText.text = string.Format("STR:{0}", player.at);
        goldText.text = string.Format("Gold:{0}", player.gold);
        magaChike.text = string.Format("まがチケ:{0}", player.magaChike);
        PlayerManager.instance.ActivateHiddenStatus();
        if (ItemManager.instance.erikusa > 0)
        {
            ItemManager.instance.UpdateErikusaUI();
        }
    }

    public void StatusReset()
    {
        PlayerManager.instance.hp = 50;
        PlayerManager.instance.maxHp = 50;
        PlayerManager.instance.at = 30;
        PlayerManager.instance.luck = 5;
        PlayerManager.instance.agility = 5;
        PlayerManager.instance.accutracy = 5;
        PlayerManager.instance.dexterity = 5;
        PlayerManager.instance.strength = 5;
        PlayerManager.instance.bossCount = 0;
        PlayerManager.instance.bossCount2 = 0;
        PlayerManager.instance.bossCount3 = 0;
        PlayerManager.instance.magaChike = 150;
        PlayerManager.instance.maousyori = 0;


        ItemManager.instance.erikusa = 0;

        PlayerManager.instance.ChikaraJiman =0;
        PlayerManager.instance.Subayai = 0;
        PlayerManager.instance.Tairyokugaaru = 0;
        PlayerManager.instance.Tsuiteiru = 0;
        PlayerManager.instance.kiyou = 0;


        PlayerManager.instance.tokusei1text = "特性その１を選択可能";
        PlayerManager.instance.tokusei2text = "特性その２を選択可能";
        PlayerManager.instance.tokusei3text = "特性その３を選択可能";

        ItemManager.instance.HideErikusaButton();

        PlayerManager.instance.weaponSlot=0;
        PlayerManager.instance.weaponType=0;
        PlayerManager.instance.weaponAT=0;
        PlayerManager.instance.armorSlot=0;
        PlayerManager.instance.armorType=0;
        PlayerManager.instance.armorPT=0;


}

    public void OnStatusButton()
    {
        PlayerStatusManager.instance.ShowStatus();
    }

    public void HidePlayerUI()
    {
        playerUIManager.SetActive(false);
    }

    public void ShowPlayerUI()
    {
        playerUIManager.SetActive(true);
    }

}
