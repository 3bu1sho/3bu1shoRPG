using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithManager : MonoBehaviour
{
    public TownManager town;
    public GameObject kajiyaImage;
    public GameObject ToKajiyaButton;
    public GameObject ToYadoButton;
    public GameObject toPartButton;

    public GameObject selectButton;

    public GameObject showWeaponButton;
    public GameObject showArmorButton;

    public GameObject lowWeaponButton;
    public GameObject midWeaponButton;
    public GameObject hiWeaponButton;

    public GameObject lowArmorButton;
    public GameObject midArmorButton;
    public GameObject hiArmorButton;

    public GameObject lowWeaponYesButton;
    public GameObject midWeaponYesButton;
    public GameObject hiWeaponYesButton;

    public GameObject lowArmorYesButton;
    public GameObject midArmorYesButton;
    public GameObject hiArmorYesButton;

    public GameObject noWeaponButton;
    public GameObject noArmorButton;



    public void BackToTownBlacksmith()
    {
        HideAllBlacksmithButton();
        kajiyaImage.SetActive(false);
        ToKajiyaButton.SetActive(true);
    }
    public void HideAllBlacksmithButton()
    {
        showWeaponButton.SetActive(false);
        showArmorButton.SetActive(false);
        lowWeaponButton.SetActive(false);
        midWeaponButton.SetActive(false);
        hiWeaponButton.SetActive(false);
        lowArmorButton.SetActive(false);
        midArmorButton.SetActive(false);
        hiArmorButton.SetActive(false);
        lowWeaponYesButton.SetActive(false);
        midWeaponYesButton.SetActive(false);
        hiWeaponYesButton.SetActive(false);
        lowArmorYesButton.SetActive(false);
        midArmorYesButton.SetActive(false);
        hiArmorYesButton.SetActive(false);
        noWeaponButton.SetActive(false);
        noArmorButton.SetActive(false);
        selectButton.SetActive(false);

    }
    public void OnToBlacksmithButton()
    {
        town.antenCheck++;
        SoundManager.instance.PlaySE(0);
        FadeIOManager.instance.FadeOutToIn2();
        StartCoroutine(ShowBlacksmithPicture());
    }

    IEnumerator ShowBlacksmithPicture()
    {
        yield return new WaitForSeconds(0.75f);
        kajiyaImage.SetActive(true);
        town.OnToMarumaruButton();
        DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「さあ、何か買っていくか？」" });
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        showWeaponButton.SetActive(true);
        showArmorButton.SetActive(true);
    }

    public void ShowBlacksmithButton()
    {
        SoundManager.instance.PlaySE(0);

        HideAllBlacksmithButton();
        PlayerUIManager.instance.UpdateUI(PlayerManager.instance);
        showWeaponButton.SetActive(true);
        showArmorButton.SetActive(true);

        DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「ゆっくり見て行ってくれ　」" });

    }

    void HideBlacksmithButton()
    {
        showWeaponButton.SetActive(false);
        showArmorButton.SetActive(false);

    }

    public void OnShowWeaponButton()
    {
        HideAllBlacksmithButton();
        SoundManager.instance.PlaySE(0);

        lowWeaponButton.SetActive(true);
        midWeaponButton.SetActive(true);
        hiWeaponButton.SetActive(true);
        HideBlacksmithButton();
        selectButton.SetActive(true);

    }

    public void OnShowArmorButton()
    {
        HideAllBlacksmithButton();
        SoundManager.instance.PlaySE(0);

        lowArmorButton.SetActive(true);
        midArmorButton.SetActive(true);
        hiArmorButton.SetActive(true);
        HideBlacksmithButton();
        selectButton.SetActive(true);

    }


    public void OnNoWeaponButton()
    {

        lowWeaponYesButton.SetActive(false);
        midWeaponYesButton.SetActive(false);
        hiWeaponYesButton.SetActive(false);
        noWeaponButton.SetActive(false);
        OnShowWeaponButton();
    }

    public void OnLowWeaponButton()
    {
        HideAllBlacksmithButton();
        SoundManager.instance.PlaySE(0);

        lowWeaponYesButton.SetActive(true);
        noWeaponButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「いわゆる”訳アリ”だ。\n今なら80Gで譲るぜ」" });

    }
    public void OnMidWeaponButton()
    {
        HideAllBlacksmithButton();
        SoundManager.instance.PlaySE(0);

        midWeaponYesButton.SetActive(true);
        noWeaponButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「俺手製の武器だ。\n切れ味は保証する。\nそうだな...150Gでどうだ？」" });

    }

    public void OnHiWeaponButton()
    {
        HideAllBlacksmithButton();
        SoundManager.instance.PlaySE(0);

        hiWeaponYesButton.SetActive(true);
        noWeaponButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「やめときな。\nそいつはオリハルコンでできてる。\n一応6000Gで売ってはいるが...」" });

    }

    public void OnNoArmorButton()
    {

        lowArmorYesButton.SetActive(false);
        midArmorYesButton.SetActive(false);
        hiArmorYesButton.SetActive(false);
        noArmorButton.SetActive(false);
        OnShowArmorButton();
    }

    public void OnLowArmorButton()
    {
        HideAllBlacksmithButton();
        lowArmorYesButton.SetActive(true);
        noArmorButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「いわゆる”訳アリ”だ。\n今なら70Gで譲るぜ」" });
        SoundManager.instance.PlaySE(0);

    }
    public void OnMidArmorButton()
    {
        HideAllBlacksmithButton();
        SoundManager.instance.PlaySE(0);

        midArmorYesButton.SetActive(true);
        noArmorButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「俺手製の防具だ。\n耐久性は保証する。\nそうだな...125Gでどうだ？」" });

    }

    public void OnHiArmorButton()
    {
        HideAllBlacksmithButton();
        SoundManager.instance.PlaySE(0);

        hiArmorYesButton.SetActive(true);
        noArmorButton.SetActive(true);
        DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「やめときな。\nそいつはオリハルコンでできてる。\n一応5000Gで売ってはいるが...」" });

    }

    public void OnLowWeaponYesButton()
    {
        if (PlayerManager.instance.gold >= 80)
        {
            PlayerManager.instance.gold -= 80;
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponType = 1;
            PlayerManager.instance.weaponAT = 10;

            HideAllBlacksmithButton();
            ShowBlacksmithButton();
            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「まいどあり！」" });
        }

        else
        {
            SoundManager.instance.PlaySE(0);

            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「おいおい。それじゃ足りんな。\n出直してきな」" });
        }


    }

    public void OnMidWeaponYesButton()
    {
        if (PlayerManager.instance.gold >= 150)
        {
            PlayerManager.instance.gold -= 150;
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponType = 2;
            PlayerManager.instance.weaponAT = 20;

            HideAllBlacksmithButton();
            ShowBlacksmithButton();
            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「まいどあり！」" });

        }

        else
        {
            SoundManager.instance.PlaySE(0);

            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「おいおい。それじゃ足りんな。\n出直してきな」" });
        }


    }

    public void OnHiWeaponYesButton()
    {
        if (PlayerManager.instance.gold >= 6000)
        {
            PlayerManager.instance.gold -= 6000;
            PlayerManager.instance.weaponSlot = 1;
            PlayerManager.instance.weaponType = 3;
            PlayerManager.instance.weaponAT = 100;

            HideAllBlacksmithButton();
            ShowBlacksmithButton();
            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「まいどあり！」" });

        }

        else
        {
            SoundManager.instance.PlaySE(0);

            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「おいおい。それじゃ足りんな。\n出直してきな」" });
        }


    }

    public void OnLowArmorYesButton()
    {
        if (PlayerManager.instance.gold >= 70)
        {
            PlayerManager.instance.gold -= 70;
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorType = 1;
            PlayerManager.instance.armorPT = 10;

            HideAllBlacksmithButton();
            ShowBlacksmithButton();
            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「まいどあり！」" });

        }

        else
        {
            SoundManager.instance.PlaySE(0);

            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「おいおい。それじゃ足りんな。\n出直してきな」" });
        }


    }

    public void OnMidArmorYesButton()
    {
        if (PlayerManager.instance.gold >= 125)
        {

            PlayerManager.instance.gold -= 125;
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorType = 2;
            PlayerManager.instance.armorPT = 20;

            HideAllBlacksmithButton();
            ShowBlacksmithButton();
            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「まいどあり！」" });

        }

        else
        {
            SoundManager.instance.PlaySE(0);

            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「おいおい。それじゃ足りんな。\n出直してきな」" });
        }


    }

    public void OnHiArmorYesButton()
    {
        if (PlayerManager.instance.gold >= 5000)
        {
            PlayerManager.instance.gold -= 5000;
            PlayerManager.instance.armorSlot = 1;
            PlayerManager.instance.armorType = 3;
            PlayerManager.instance.armorPT = 100;

            HideAllBlacksmithButton();
            ShowBlacksmithButton();
            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「まいどあり！」" });

        }

        else
        {
            SoundManager.instance.PlaySE(0);

            DialogTextManager.instance.SetScenarios(new string[] { "鍛冶屋のおやじ\n「おいおい。それじゃ足りんな。\n出直してきな」" });
        }


    }



}
