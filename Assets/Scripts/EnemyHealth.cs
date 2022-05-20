using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public Slider enemyHealthSlider;

    // Tao vat pham khi enemy chet;
    public bool drop;
    public GameObject theDrop;

    void Start()
    {
        currentHealth = maxHealth;

        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;

        // ẩn thanh máu
        enemyHealthSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void addDame(float dame)
    {
        // Hiện thanh máu khi nhận sát thương
        enemyHealthSlider.gameObject.SetActive(true);
        currentHealth -= dame;
        enemyHealthSlider.value = currentHealth;
        
        if(currentHealth <= 0)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.explosion);
            gameObject.SetActive(false);

            // rơi vật phẩm
            if (drop)
            {
                Instantiate(theDrop, transform.position, transform.rotation);

            }
        }
    }
}
