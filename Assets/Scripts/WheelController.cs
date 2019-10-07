using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController: MonoBehaviour
{
    public float rotateSpeed = 20f;
    public float speed = 10f;
    public float JumpPower = 1000f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //Jumps
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * JumpPower * Time.deltaTime, ForceMode2D.Impulse);
        }

        //Adds vertical speed
        rb.MoveRotation(rb.rotation - (speed * Input.GetAxis("Horizontal")));
    }
}