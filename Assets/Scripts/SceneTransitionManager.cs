using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager instance;

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

    public void LoadTo(string sceneName)
    {
        FadeIOManager.instance.FadeOutToIn(() => Load(sceneName));
    }
    void Load(string sceneName)
    {
        SoundManager.instance.PlayBGM(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void LoadToNoBGM(string sceneName)
    {
        FadeIOManager.instance.FadeOutToIn(() => LoadNoBGM(sceneName));
    }

    void LoadNoBGM(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
