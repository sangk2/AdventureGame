using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public static gameController instance;

    public Text scoreText;
    public Text gameOverScoreText;
    public Text FinalScoreLevel;

    public GameObject gameOver;
    public bool isGameOver = false;

    public GameObject nextLevel;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.theme, true);
        
    }
    public void AddScore( int score)
    {
        this.score += score;
        scoreText.text = ""+this.score;
    }

    public void GameOver()
    {
        AudioManager.instance.StopSound(AudioManager.instance.theme);

        AudioManager.instance.PlaySound(AudioManager.instance.gameOver);

        gameOverScoreText.text = "Score: " + this.score;
        gameOver.SetActive(true);

        isGameOver = true;

        Time.timeScale = 0;
    }
    public void NextLevel()
    {
        AudioManager.instance.StopSound(AudioManager.instance.theme);
        AudioManager.instance.PlaySound(AudioManager.instance.gameOver);

        FinalScoreLevel.text = "Score: " + this.score;
        nextLevel.SetActive(true);

        Time.timeScale = 0;

    }
    public void ButtonSound()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.select);
    }

    
    
}
