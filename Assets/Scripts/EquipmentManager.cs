using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{


    public static EquipmentManager instance;

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


    public void EquipWeapon()
    {
        if (PlayerManager.instance.weaponType == 1)
        {
            //粗悪
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 10;
        }

        else if (PlayerManager.instance.weaponType == 2)
        {
            //普通
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 20;
        }

        else if (PlayerManager.instance.weaponType == 3)
        {
            //オリハルコン
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 100;
        }

        else if (PlayerManager.instance.weaponType == 4)
        {
            //最高
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 30;
        }

        else if (PlayerManager.instance.weaponType == 5)
        {
            //神話
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 40;
        }

        else if (PlayerManager.instance.weaponType == 6)
        {
            //創世
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponAT = 50;
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
        else if (PlayerManager.instance.armorType == 4)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 30;
        }
        else if (PlayerManager.instance.armorType == 5)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 40;
        }
        else if (PlayerManager.instance.armorType == 6)
        {
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorPT = 50;
        }


        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);


    }


    public void EquipSoaku()
    {
        PlayerManager.instance.armorType = 1;
        PlayerManager.instance.weaponType = 1;

        EquipWeapon();
        EquipArmor();
    }

    public void EquipSoakuWeapon()
    {
        PlayerManager.instance.weaponType = 1;

        EquipWeapon();
    }


}
