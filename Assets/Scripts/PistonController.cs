using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonController : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;

    private Rigidbody2D rb;
    [SerializeField] private bool touchingGround = true;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            touchingGround = true;
            print("Touching ground");
        }

        print("Touching: " + collision.gameObject.name);
    }
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && touchingGround)
        {
            touchingGround = false;
            rb.AddForce(Vector2.up * verticalSpeed, ForceMode2D.Impulse);
        }

        //Adds horizontal speed if in mid-air
        if (!touchingGround)
        {
            rb.MoveRotation(rb.rotation - (horizontalSpeed * Input.GetAxis("Horizontal")));
        }
    }
}