using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDame : MonoBehaviour
{
    public float dame;
    float dameColum = 0.5f;
    float nextDame = 0;
    public float lucDayLen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && (nextDame < Time.time))
        {
            PlayerHealth thePlayerH = collision.gameObject.GetComponent<PlayerHealth>();
            thePlayerH.addDame(dame);
            nextDame = dameColum + Time.time;

            dayNVLen(collision.transform);
        }
    }
    void dayNVLen(Transform nv)
    {
        Vector2 pushDriection = new Vector2(0, (nv.position.y - transform.position.y)).normalized;//trả về 1
        pushDriection *= lucDayLen;
        Rigidbody2D pushRB = nv.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;//x:0, y:0
        pushRB.AddForce(pushDriection, ForceMode2D.Impulse); //xung lực, lập tức bay lên được

    }
}
