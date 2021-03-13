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
    public GameObject HirobaButton;
    public GameObject RoyaButton;
    public GameObject HEYA101Button;
    public GameObject HEYA102Button;
    public GameObject HEYA103Button;
    public GameObject KakushiButton;
    public GameObject KantokukanButton;

    public void OnBossBattleButton()
    {
        type = FieldType.AFTERBOSS;
        /*quest.ToBossBattle(); */
    }
}
