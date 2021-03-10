using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public enum FieldType
    {
        HEIGEN,

        HAYASHI,
        KEMONOMICHI,

        MORI,
        KURAIMORI,
          NUMA,


          AFTERBOSS,
    }

     FieldType type = FieldType.HEIGEN;




    public void OnToHEIGENButton()
    {
        type = FieldType.HEIGEN;
        AnyButton();
    }

    public void OnToHAYASHIButton()
    {
        type = FieldType.HAYASHI;
        AnyButton();
    }
    public void OnToKEMONOMICHIButton()
    {
        type = FieldType.KEMONOMICHI;
        AnyButton();
    }

    public void OnToMORIButton()
    {
        type = FieldType.MORI;
        AnyButton();
    }

    public void OnToKURAIMORIButton()
    {
        type = FieldType.KURAIMORI;
        AnyButton();
    }

    public void OnToNUMAButton()
    {
        type = FieldType.NUMA;
        AnyButton();
    }

    public void OnReturnToHEIGENButton()
    {
        type = FieldType.HEIGEN;
        AnyButton();
    }

    public void OnReturnToHAYASHIButton()
    {
        type = FieldType.HAYASHI;
        AnyButton();
    }

    public void OnReturnToMORIButton()
    {
        type = FieldType.MORI;
        AnyButton();
    }

    public void OnReturnToKURAIMORIButton()
    {
        type = FieldType.KURAIMORI;
        AnyButton();
    }





    public GameObject HeigenButton;
    public GameObject HayashiButton;
    public GameObject KemonomichiButton;
    public GameObject MoriButton;
    public GameObject KuraiMoriButton;
    public GameObject NumaButton;
    public GameObject MachimodoButton;
    public GameObject ReturnHeigenButton;
    public GameObject ReturnHayashiButton;
    public GameObject ReturnMoriButton;
    public GameObject ReturnKuraiMoriButton;
    public GameObject BossBattleiButton;
    public GameObject GameClearButton;
    public GameObject FakeButton;





    public void ShowFieldButton()
    {
        if(type==FieldType.HAYASHI)
        {
            MoriButton.SetActive(true);
            KuraiMoriButton.SetActive(true);
            ReturnHeigenButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "草木が辺りを覆う。\nだが来た道はまだ見えている。" });
        }

        if (type == FieldType.KEMONOMICHI)
        {
            ReturnHeigenButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "強靭な蔦が周囲に張り巡らされている。\n\n\n             ...戻ろう。" });
        }

        if (type == FieldType.HEIGEN)
        {
            HayashiButton.SetActive(true);
            KemonomichiButton.SetActive(true);
            MachimodoButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "うっそうとした木々が\n視界を塞ぐ。" });
        }

        if (type == FieldType.MORI)
        {
            KuraiMoriButton.SetActive(true);
            ReturnHayashiButton.SetActive(true);
            DialogTextManager.instance.SetScenarios(new string[] { "来た道が見えない。\n引き返すのも手だろう。" });
        }

        if (type == FieldType.KURAIMORI)
        {
            ReturnMoriButton.SetActive(true);
            NumaButton.SetActive(true);
            FakeButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "どうとでもなれ。" });
        }

        if (type == FieldType.NUMA)
        {
            ReturnKuraiMoriButton.SetActive(true);
            BossBattleiButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "悪寒がする。\n何かがいる...！\n\n※ボス戦になります。\n覚悟は決まりましたか？" });
        }

        if (type == FieldType.AFTERBOSS)
        {
            GameClearButton.SetActive(true);

            DialogTextManager.instance.SetScenarios(new string[] { "光が見える---。" });
        }
    }

    public QuestManager quest;
    void AnyButton()
    {
        quest.OnTansakuButton();
    }


    public void OnBossBattleButton()
    {
        type = FieldType.AFTERBOSS;
        quest.ToBossBattle();
    }

    public void OnGameClearButton()
    {
        if(PlayerManager.instance.bossCount==0)
        {
            SaveInt.instance.princess++;
        }
        quest.CallHideButton();
        quest.QuestClear();
        MachimodoButton.SetActive(true);
    }
}
