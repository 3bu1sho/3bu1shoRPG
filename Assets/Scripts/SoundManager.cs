using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour

{
    public AudioSource audioSourceBGM;
    public AudioClip[] audioClipsBGM;

    public AudioSource audioSourceSE;
    public AudioClip[] audioClipsSE;

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public static SoundManager instance;

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

    void Start()
    {
        PlayBGM("title");
    }

    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();

        switch (sceneName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;

            case "Town":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;

            case "Quest":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;

            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;

            case "GameOver":
                audioSourceBGM.clip = audioClipsBGM[4];
                break;
            case "BossBattle":
                audioSourceBGM.clip = audioClipsBGM[5];
                break;
            case "Quest2":
                audioSourceBGM.clip = audioClipsBGM[6];
                break;
            case "Battle2":
                audioSourceBGM.clip = audioClipsBGM[7];
                break;

            case "BossBattle2":
                audioSourceBGM.clip = audioClipsBGM[8];
                break;
            case "Battle3":
                audioSourceBGM.clip = audioClipsBGM[9];
                break;
            case "BossBattle3":
                audioSourceBGM.clip = audioClipsBGM[10];
                break;

        }
        audioSourceBGM.Play();
    }

    public void PlaySE(int index)
    { 
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
}
