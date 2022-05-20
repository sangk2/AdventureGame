using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public Slider healthPlayerSlider;

    playerControl player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<playerControl>();

        currentHealth = maxHealth;

        healthPlayerSlider.maxValue = maxHealth;
        healthPlayerSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDame(float dame)
    {
        if (dame <= 0) return;

        currentHealth -= dame;
        healthPlayerSlider.value = currentHealth;


        if (currentHealth <= 0)
        {
            player.Death();
            gameOver();
        }
    }

    public void addHealth(float addheal)
    {
        currentHealth += addheal;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthPlayerSlider.value = currentHealth;
    }

    public void gameOver()
    {
        //gameObject.SetActive(false);
        StartCoroutine(gOv());
    }
    IEnumerator gOv()
    {
        yield return new WaitForSeconds(1);

        gameController.instance.GameOver();
    }
}
