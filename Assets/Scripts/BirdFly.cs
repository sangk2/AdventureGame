using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public float speed = 30;

    public float maxDistance = 30;
    private Rigidbody2D rb2d;


    private float distance = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        distance = 0;

    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * 2;
        if (distance > maxDistance)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            distance = 0;

        }

        //gia toc
        rb2d.velocity = new Vector2(-transform.localScale.x, 0) * speed;
    }
}
