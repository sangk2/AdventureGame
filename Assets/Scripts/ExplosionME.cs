using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionME : MonoBehaviour
{
    public GameObject explo;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(explo, transform.position, transform.rotation);
            gameObject.SetActive(false);
            AudioManager.instance.PlaySound(AudioManager.instance.explosion);
            
        }
    }

}
