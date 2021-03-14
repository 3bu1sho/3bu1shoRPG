using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager3 : MonoBehaviour
{
    public enum FieldType
    {
        IRIGUCHI,

        TANIMA,

        SHURAKU,

          KOJO,

          HIROBA,


          YOSUIRO,

          ROYA,

            HEYA101,
            HEYA102,
            HEYA103,
              
            KAKUSHI,

            KANTOKUKAN,

        AFTERBOSS,
    }

    FieldType type = FieldType.IRIGUCHI;




    public void OnToIRIGUCHIButton()
    {
        type = FieldType.IRIGUCHI;
        //AnyButton();
    }

    public void OnToTANIMAButton()
    {
        type = FieldType.TANIMA;
        //AnyButton();
    }

    public void OnToSHURAKUButton()
    {
        type = FieldType.SHURAKU;
        //AnyButton();
    }

    public void OnToKOJOButton()
    {
        type = FieldType.KOJO;
        //AnyButton();
    }

    public void OnToHIROBAButton()
    {
        type = FieldType.HIROBA;
        //AnyButton();
    }

    public void OnToYOSUIROButton()
    {
        type = FieldType.YOSUIRO;
        //AnyButton();
    }

    public void OnToROYAButton()
    {
        type = FieldType.ROYA;
        //AnyButton();
    }

    public void OnToHEYA101Button()
    {
        type = FieldType.HEYA101;
        //AnyButton();
    }

    public void OnToHEYA102Button()
    {
        type = FieldType.HEYA102;
        //AnyButton();
    }

    public void OnToHEYA103Button()
    {
        type = FieldType.HEYA103;
        //AnyButton();
    }

    public void OnToKAKUSHIButton()
    {
        type = FieldType.KAKUSHI;
        //AnyButton();
    }

    public void OnToKANTOKUKANButton()
    {
        type = FieldType.KANTOKUKAN;
        //AnyButton();
    }



    public GameObject IriguchiButton;
    public GameObject TanimaButton;
    public GameObject ShurakuButton;
    public GameObject KojoButton;
    public GameObject YosuiroButton;
    public GameObject HirobaButton;
    public GameObject RoyaButton;
    public GameObject HEYA101Button;
    public GameObject HEYA102Button;
    public GameObject HEYA103Button;
    public GameObject KakushiButton;
    public GameObject KantokukanButton;

    public GameObject ReturnToIriguchiButton;
    public GameObject ReturnToTanimaButton;
    public GameObject ReturnToShurakuButton;
    public GameObject ReturnToKojoButton;
    public GameObject ReturnToYosuiroButton;
    public GameObject ReturnToHirobaButton;
    public GameObject ReturnToRoyaButton;
    public GameObject ReturnToHEYA101Button;
    public GameObject ReturnToHEYA102Button;
    public GameObject ReturnToHEYA103Button;
    public GameObject ReturnToKakushiButton;
    public GameObject ReturnToKantokukanButton;

    public GameObject MachimodoButton;
    public GameObject BossBattleButton;

    public QuestManager3 quest;
    public void OnBossBattleButton()
    {
        type = FieldType.AFTERBOSS;
        quest.ToBossBattle();
    }

    public void ShowFieldButton()
    {
        if (type == FieldType.IRIGUCHI)
        {
            MachimodoButton.SetActive(true);
            TanimaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ここには文明の爪痕がある。\nいずれ自分の見た景色は全て\nこのように瓦礫に還るのだろうか。" });
        }

        if (type == FieldType.TANIMA)
        {
            ReturnToIriguchiButton.SetActive(true);
            ShurakuButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ここには禿鷹と骨と腐乱臭だけだ。\nだが、腐れ谷を抜けた先に光が見える。\nあれは、集落だろうか。" });
        }

        if (type == FieldType.SHURAKU)
        {
            ReturnToTanimaButton.SetActive(true);
            KojoButton.SetActive(true);
            YosuiroButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }

        if (type == FieldType.KOJO)
        {
            ReturnToShurakuButton.SetActive(true);
            HirobaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }

        if (type == FieldType.HIROBA)
        {
            ReturnToShurakuButton.SetActive(true);
            HirobaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }


        if (type == FieldType.YOSUIRO)
        {
            ReturnToShurakuButton.SetActive(true);
            RoyaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }

        if (type == FieldType.ROYA)
        {
            ReturnToYosuiroButton.SetActive(true);
            HEYA101Button.SetActive(true);
            HEYA102Button.SetActive(true);
            HEYA103Button.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }

        if (type == FieldType.HEYA101)
        {
            ReturnToRoyaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }

        if (type == FieldType.HEYA103)
        {
            ReturnToRoyaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }

        if (type == FieldType.HEYA102)
        {
            ReturnToRoyaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }

        if (type == FieldType.KAKUSHI)
        {
            ReturnToHEYA102Button.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }

        if (type == FieldType.KANTOKUKAN)
        {
            ReturnToKakushiButton.SetActive(true);
            BossBattleButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "ならず者の集落だ。\n人々の好意的な態度がむしろ\n自分を疑心暗鬼にさせる。" });
        }
    }


    void AnyButton()
    {
        quest.OnTansakuButton();
    }

    public void OnGameClearButton()
    {
        if (PlayerManager.instance.bossCount == 0)
        {
            SaveInt.instance.princess++;
        }
        quest.CallHideButton();
        quest.QuestClear();
        MachimodoButton.SetActive(true);
    }
}
