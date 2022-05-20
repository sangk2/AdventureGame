using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Info : MonoBehaviour
{
    public GameObject info;
    public Button noInfo;
    public Button yesInfo;
    public bool isInfo = false;

    public Slider sound;
    public Button yesSound;
    public Button noSound;
    public bool isSound = false;
    public void Info()
    {
        info.SetActive(true);
        noInfo.gameObject.SetActive(true);
        yesInfo.gameObject.SetActive(false);
        isInfo = true;
    }
    public void NoInfo()
    {
        yesInfo.gameObject.SetActive(true);
        noInfo.gameObject.SetActive(false);
        info.SetActive(false);
        isInfo = false;
    }

    public void Sound()
    {
        sound.gameObject.SetActive(true);
        noSound.gameObject.SetActive(true);
        yesSound.gameObject.SetActive(false);
        isSound = true;
    }
    public void NoSound()
    {
        yesSound.gameObject.SetActive(true);
        noSound.gameObject.SetActive(false);
        sound.gameObject.SetActive(false);
        isSound = false;
    }
    
    
}
