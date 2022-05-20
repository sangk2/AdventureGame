using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target; // nhân vật (camera theo dõi)
    public float smoothing; // làm mịn

    Vector3 offset; //vị trí của nhân vật -> camera

    float lowY; // ko theo nhân vật khi rơi

    float lowX; // giới hạn bên trái camera


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; // offset = VT camera 1 - VT NV 1

        lowY = transform.position.y;
        lowX = transform.position.x;
    }

    private void FixedUpdate()
    {
        Vector3 targetCampos = target.position + offset; // VT camera 2 = VT NV 2 + offset

        // vị trí mới camera khi di chuyển
        transform.position = Vector3.Lerp(transform.position, targetCampos, smoothing * Time.deltaTime);

        // Khóa camera
        if (transform.position.y < lowY)
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        if(transform.position.y > lowY)
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);

        // khóa bên trái
        if (transform.position.x < lowX)
            transform.position = new Vector3(lowX, transform.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
