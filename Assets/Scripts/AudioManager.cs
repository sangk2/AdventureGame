using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    float sound = 1;
    float fx = 1;

    public Slider vSoundSlider;
    public Slider vFxSlider;


    public GameObject prefab;

    public AudioClip select;
    private AudioSource selectSource;

    public AudioClip coin;
    private AudioSource coinSource;

    public AudioClip die;
    private AudioSource dieSource;

    public AudioClip gameOver;
    private AudioSource gameOverSource;


    public AudioClip jump;
    private AudioSource jumpSource;

    public AudioClip attack;
    private AudioSource attackSource;

    public AudioClip damge;
    private AudioSource damgeSource;

    public AudioClip explosion;
    private AudioSource explosionSource;

    public AudioClip theme;
    private AudioSource themeSource;


    private void Awake()
    {
        instance = this;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        vSoundSlider.maxValue = 1;
        vSoundSlider.minValue = 0;
        vSoundSlider.value = sound;

        vFxSlider.maxValue = 1;
        vFxSlider.minValue = 0;
        vFxSlider.value = fx;

        
    }

    // Update is called once per frame
    void Update()
    {

        sound = vSoundSlider.value;
        themeSource.volume = sound;
        fx = vFxSlider.value;

    }


    public void PlaySound(AudioClip clip, bool isLoopback)
    {
        if (clip == this.theme)
        {
            Play(clip, ref themeSource, isLoopback);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == this.select)
        {
            Play(clip, ref selectSource);
            return;
        }
        if (clip == this.coin)
        {
            Play(clip, ref coinSource);
            return;
        }
        if (clip == this.die)
        {
            Play(clip, ref dieSource);
            return;
        }
        if (clip == this.gameOver)
        {
            Play(clip, ref gameOverSource);
            return;
        }
        if (clip == this.jump)
        {
            Play(clip, ref jumpSource);
            return;
        }
        if (clip == this.attack)
        {
            Play(clip, ref attackSource);
            return;
        }
        if (clip == this.damge)
        {
            Play(clip, ref damgeSource);
            return;
        }
        if (clip == this.explosion)
        {
            Play(clip, ref explosionSource);
            return;
        }

    }


    private void Play(AudioClip clip, ref AudioSource audioSource, bool isLoopback = false)
    {
        // nếu đang chơi thì ko thực hiện
        if (audioSource != null && audioSource.isPlaying)
        {
            return;
        }
        // còn nếu chưa có thì tạo instance qua prefab
        audioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();

        audioSource.volume = this.fx;
        audioSource.loop = isLoopback;
        audioSource.clip = clip;

        audioSource.Play();

        Destroy(audioSource.gameObject, audioSource.clip.length);
    }

    public void StopSound(AudioClip clip)
    {
        // gọi phương thức Stop của coinSource. nếu coinSoure khác none
        if (clip == this.select)
        {
            selectSource?.Stop(); return;
        }
        if (clip == this.coin)
        {
            coinSource?.Stop(); return;
        }
        if (clip == this.die)
        {
            dieSource?.Stop(); return;
        }
        if (clip == this.jump)
        {
            jumpSource?.Stop(); return;
        }
        if (clip == this.attack)
        {
            attackSource?.Stop(); return;
        }
        if (clip == this.damge)
        {
            damgeSource?.Stop(); return;
        }
        if (clip == this.explosion)
        {
            explosionSource?.Stop(); return;
        }
        if (clip == this.theme)
        {
            themeSource?.Stop();
            return;
        }
    }
    public void PauseSound(AudioClip clip)
    {
        if (clip == this.theme)
        {
            themeSource.Pause();
        }
    }
    public void UnPauseSound(AudioClip clip)
    {
        if (clip == this.theme)
        {
            themeSource.UnPause();
        }
    }
}