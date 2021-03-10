using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInt : MonoBehaviour
{

    public static SaveInt instance;

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

    public int princess;
    public int choker;

    public int activateNoJob;
    public int activateSenshi;
    public int activateArcher;
    public int activateGambler;
    public int activateRogue;

    public int dirtyPrincess;
    public int doubleDown;
    public int yukiClear;


    private void Start()
    {
        LoadingSaveData();
    }

    void Update()
    {
        SavingSaveData();
    }

    public void SavingSaveData()
    {
        PlayerPrefs.SetInt("princess", princess);
        PlayerPrefs.SetInt("choker", choker);


        PlayerPrefs.SetInt("activateNoJob", activateNoJob);
        PlayerPrefs.SetInt("activateSenshi", activateSenshi);
        PlayerPrefs.SetInt("activateArcher", activateArcher);
        PlayerPrefs.SetInt("activateGambler", activateGambler);
        PlayerPrefs.SetInt("activateRogue", activateRogue);
        PlayerPrefs.SetInt("dirtyPrincess", dirtyPrincess);
        PlayerPrefs.SetInt("doubleDown", doubleDown);
        PlayerPrefs.SetInt("choker", choker);
        PlayerPrefs.SetInt("yukiClear", yukiClear);

    }

    public void LoadingSaveData()
    {
        princess = PlayerPrefs.GetInt("princess");
        choker = PlayerPrefs.GetInt("choker");


        activateNoJob = PlayerPrefs.GetInt("activateNoJob");
        activateSenshi = PlayerPrefs.GetInt("activateSenshi");
        activateArcher = PlayerPrefs.GetInt("activateArcher");
        activateGambler = PlayerPrefs.GetInt("activateGambler");
        activateRogue = PlayerPrefs.GetInt("activateRogue");
        dirtyPrincess = PlayerPrefs.GetInt("dirtyPrincess");
        doubleDown = PlayerPrefs.GetInt("doubleDown");
        yukiClear = PlayerPrefs.GetInt("yukiClear");
    }




}
