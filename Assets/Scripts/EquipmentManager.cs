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
