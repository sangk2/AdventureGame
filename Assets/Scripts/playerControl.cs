using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed;
    public float jumpHeight;

    bool facingRight;
    bool isGround;

    // Ám khí Shuriken
    public Transform ShurikenTip;
    public GameObject shuriken;
    float hoiSkill = 0.5f; // 0.5s bắn 1 lần
    float nextSkill = 0; // bắn ngay lập tức

    Rigidbody2D myBody;
    Animator myAnim;
    
    // Rớt nv
    public float lowY = -20f;


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal"); //di chuyển theo chiều ngang

        Run(move);
        Jump();

        Jump_Run(move);

        // Phóng phi tiêu
        ThrowShuriken();

        LowY();
    }

    // Rớt nv
    void LowY ()
    {
        if(gameObject.transform.position.y < lowY)
        {
            PlayerHealth health = gameObject.GetComponent<PlayerHealth>();
            health.healthPlayerSlider.value = 0;
            health.gameOver();
            //gameObject.SetActive(false);
            //gameController.instance.GameOver();
            //Time.timeScale = 0;
        }
    }
    public void Run(float move)
    {
        myBody.velocity = new Vector2(move * speed, myBody.velocity.y);
        // quay mặt khi di chuyển
        if (move > 0 && !facingRight) //khi đi qua phải và mặc bên trái thì quay mặt
        {
            flip();
        }
        else if (move < 0 && facingRight) // khi đi qua trái và mặt bên phải thì quay mặt
        {
            flip();
        }
        // chạy
        myAnim.SetFloat("running", Mathf.Abs(move));
    }
    
    // nhảy
    public void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (isGround)
            {
                myAnim.SetBool("jump", true);
                AudioManager.instance.PlaySound(AudioManager.instance.jump);

                isGround = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
            }
        }else myAnim.SetBool("jump", false);

    }
    void Jump_Run(float move)
    {
        if(Input.GetKey(KeyCode.UpArrow) && (move != 0))
        {
            myAnim.SetBool("run&jump", true);
            if (isGround)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.jump);
                isGround = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
            }
        }
        else myAnim.SetBool("run&jump", false);
    }
    // quay mặt
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // xử lí va chạm
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            
            myAnim.SetBool("damge", true);
            AudioManager.instance.PlaySound(AudioManager.instance.damge);
        }else myAnim.SetBool("damge", false);
    }

    // ném phi tiêu
    public void ThrowShuriken()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myAnim.SetBool("attackShuriken", true);
            AudioManager.instance.PlaySound(AudioManager.instance.attack);
            if (Time.time > nextSkill)
            {
                nextSkill = Time.time + hoiSkill;
                if (facingRight)
                {
                    Instantiate(shuriken, ShurikenTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }else if (!facingRight)
                {
                    Instantiate(shuriken, ShurikenTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
            }

        }else myAnim.SetBool("attackShuriken", false);
    }

    
    // chết
    public void Death()
    {
        myAnim.SetBool("death", true);
        AudioManager.instance.PlaySound(AudioManager.instance.die);
    }
}
