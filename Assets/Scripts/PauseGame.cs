using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject gamePause;
    public bool isGamePause = false;
    public void GamePause()
    {
        gamePause.SetActive(true);
        isGamePause = true;
        Time.timeScale = 0;

        AudioManager.instance.PauseSound(AudioManager.instance.theme);
    }

    public void GameResume()
    {
        AudioManager.instance.UnPauseSound(AudioManager.instance.theme);

        gamePause.SetActive(false);
        isGamePause = false;
        Time.timeScale = 1;
    }

}
