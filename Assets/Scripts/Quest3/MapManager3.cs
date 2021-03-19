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
        AnyButton();
    }

    public void OnToTANIMAButton()
    {
        type = FieldType.TANIMA;
        AnyButton();
    }

    public void OnToSHURAKUButton()
    {
        type = FieldType.SHURAKU;
        AnyButton();
    }

    public void OnToKOJOButton()
    {
        type = FieldType.KOJO;
        AnyButton();
    }

    public void OnToHIROBAButton()
    {
        type = FieldType.HIROBA;
        AnyButton();
    }

    public void OnToYOSUIROButton()
    {
        type = FieldType.YOSUIRO;
        AnyButton();
    }

    public void OnToROYAButton()
    {
        type = FieldType.ROYA;
        AnyButton();
    }

    public void OnToHEYA101Button()
    {
        type = FieldType.HEYA101;
        AnyButton();
    }

    public void OnToHEYA102Button()
    {
        type = FieldType.HEYA102;
        AnyButton();
    }

    public void OnToHEYA103Button()
    {
        type = FieldType.HEYA103;
        AnyButton();
    }

    public void OnToKAKUSHIButton()
    {
        type = FieldType.KAKUSHI;
        AnyButton();
    }

    public void OnToKANTOKUKANButton()
    {
        type = FieldType.KANTOKUKAN;
        AnyButton();
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
    public GameObject ReturnToHEYA102Button;
    public GameObject ReturnToKakushiButton;
    public GameObject ReturnToKantokukanButton;

    public GameObject MachimodoButton;
    public GameObject MachimodoButton2;

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

            DialogTextManager.instance.SetScenarios(new string[] { "廃工場の跡地だ。\nかつてのこの街はどれほど\n栄えていたのだろうか。" });
        }

        if (type == FieldType.HIROBA)
        {
            ReturnToKojoButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "噴水のある広場に出た。\nその噴水は苔むしていて、\nもう何年も動いていないようだ。" });
        }


        if (type == FieldType.YOSUIRO)
        {
            ReturnToShurakuButton.SetActive(true);
            RoyaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "自分は用水路を移動する。\nねずみがチュウチュウと\n鳴いている。" });
        }

        if (type == FieldType.ROYA)
        {
            ReturnToYosuiroButton.SetActive(true);
            HEYA101Button.SetActive(true);
            HEYA102Button.SetActive(true);
            HEYA103Button.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "用水路を抜けると、そこは牢獄だった。\n牢獄に通ずる廊下は瓦礫で\n塞がっており、3つの開いた\n牢に入れるだけだ。" });
        }

        if (type == FieldType.HEYA101)
        {
            ReturnToRoyaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "何もない。" });
        }

        if (type == FieldType.HEYA102)
        {
            ReturnToRoyaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "一見ただの牢屋のようだ。" });
            KakushiButton.SetActive(true);
        }

        if (type == FieldType.HEYA103)
        {
            ReturnToRoyaButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "白骨だ。" });
        }

        if (type == FieldType.KAKUSHI)
        {
            ReturnToHEYA102Button.SetActive(true);
            KantokukanButton.SetActive(true);
            DialogTextManager.instance.SetScenarios(new string[] { "自分は隠し通路を進む。" });
        }

        if (type == FieldType.KANTOKUKAN)
        {
            ReturnToKakushiButton.SetActive(true);
            BossBattleButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "監督官の部屋と書かれている。\n\n※ボス戦になります。\n覚悟は決まりましたか？" });
        }

        if (type == FieldType.AFTERBOSS)
        {
            ReturnToKakushiButton.SetActive(true);
            MachimodoButton2.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "監督官の部屋だ。" });
        }
    }


    void AnyButton()
    {
        quest.OnTansakuButton();
    }

    /*

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

    */
}
