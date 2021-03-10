using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;


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

    public Text erikusaText;

    [SerializeField] GameObject erikusaButton;


    public int erikusa;

    public void ActiveErikusa()
    {
        erikusaButton.SetActive(true);
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

    }

    public void UseErikusa()
    {
        if(PlayerManager.instance.hp == PlayerManager.instance.maxHp)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "もうそんなに飲めないぽよ,,,。" });
        }

        else
        {
            erikusa--;
            PlayerManager.instance.hp += PlayerManager.instance.maxHp;
            DialogTextManager.instance.SetScenarios(new string[] { "めっちゃ回復した。" });
            SoundManager.instance.PlaySE(3);
        }

        if(erikusa<=0)
        {
            erikusaButton = GameObject.Find("エリクサーボタン");
            erikusaButton.SetActive(false);       
        }


        if (PlayerManager.instance.maxHp < PlayerManager.instance.hp)
        {
            PlayerManager.instance.hp = PlayerManager.instance.maxHp;

            PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        }
    }

    public void UpdateErikusaUI()
    {
        erikusaText.text = string.Format("エリクサー:{0}", this.erikusa);

    }

    public void HideErikusaButton()
    {
        erikusaButton.SetActive(false);
    }
    public void EquipWeapon()
    {
        if (PlayerManager.instance.weaponType == 1)
        {
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 10;
        }

        else if (PlayerManager.instance.weaponType == 2)
        {
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 20;
        }

        else if (PlayerManager.instance.weaponType == 3)
        {
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 100;
        }
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);

    }

    public void EquipArmor()
    {
        if (PlayerManager.instance.armorType == 1)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 10;
        }

        else if (PlayerManager.instance.armorType == 2)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 20;
        }
        else if (PlayerManager.instance.armorType == 3)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 100;
        }
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);


    }


}
