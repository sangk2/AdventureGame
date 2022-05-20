using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenHit : MonoBehaviour
{
    public float dame;

    ShurikenPlayer shurikenPlayer;

    public GameObject shurikenExplosion;


    private void Awake()
    {
        shurikenPlayer = GetComponentInParent<ShurikenPlayer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // dừng phi tiêu và tạo hiệu ứng nổ
            shurikenPlayer.removeShuriken();
            Instantiate(shurikenExplosion, transform.position, transform.rotation);
            Destroy(gameObject);

            // trừ máu khi va chạm
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                // lấy component từ EnemyHealth
                EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDame(dame);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // dừng phi tiêu và tạo hiệu ứng nổ
            shurikenPlayer.removeShuriken();
            Instantiate(shurikenExplosion, transform.position, transform.rotation);
            Destroy(gameObject);

            // trừ máu khi va chạm
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                // lấy component từ EnemyHealth
                EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDame(dame);
            }
        }
    }
}
