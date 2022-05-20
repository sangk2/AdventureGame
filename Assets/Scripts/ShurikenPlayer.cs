using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenPlayer : MonoBehaviour
{
    public float speedShuriken;

    Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        if(transform.localRotation.z > 0)
        {
            myBody.AddForce(new Vector2(-1, 0) * speedShuriken, ForceMode2D.Impulse);
        }else
            myBody.AddForce(new Vector2(1, 0) * speedShuriken, ForceMode2D.Impulse);

}

    // Tạo chức năng dừng phi tiêu
    public void removeShuriken()
    {
        myBody.velocity = new Vector2(0, 0);
    }
}
