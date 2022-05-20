using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAttack : MonoBehaviour
{
    public float speedEnemy;

    Rigidbody2D enemyRB;
    Animator enemyAni;

    // enemy quay m?t
    public GameObject enemyObj;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAni = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(facingRight && collision.transform.position.x < transform.position.x)
            {
                flip();
            }else if(!facingRight && (collision.transform.position.x > transform.position.x))
            {
                flip();
            }
            canFlip = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!facingRight)
                enemyRB.velocity = new Vector2(-transform.localScale.x, 0) * speedEnemy;
            else
                enemyRB.velocity = new Vector2(transform.localScale.x, 0) * speedEnemy;
            enemyAni.SetBool("Run", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);// dung di chuyen
            enemyAni.SetBool("Run", false);
        }
    }

    // quay m?t
    void flip()
    {
        if (!canFlip) return; // canFlip = false; ko quay mat nua
        facingRight = !facingRight;
        Vector3 theScale = enemyObj.transform.localScale;
        theScale.x *= -1;
        enemyObj.transform.localScale = theScale;
    }
}
