using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D r2d2;
    public float jumpForce;
    
    void Start()
    {
        r2d2 = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.Space))
        {
            r2d2.velocity = new Vector2(0.0f, 5.0f);
        }
    }

    

    
}
