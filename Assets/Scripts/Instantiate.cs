using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject logo;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(logo, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
