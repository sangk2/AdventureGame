using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public float addHeal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            AudioManager.instance.PlaySound(AudioManager.instance.coin);
            playerHealth.addHealth(addHeal);
            Destroy(gameObject);
        }
    }
}
