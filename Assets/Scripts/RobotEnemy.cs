using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnemy : Entity
{
    public float speed;

    private int direction = 1;
    private float previousPosX;
    private Rigidbody2D rb;
    private new SpriteRenderer renderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * direction * speed, ForceMode2D.Impulse);

        // Har ikke flyttet sig.
        if (previousPosX - transform.position.x == 0)
        {
            direction = -direction; // Invert direction
            /*if (rb.velocity.x * -1 > 0)
            {
                renderer.flipX = true;
            }
            else
            {
                renderer.flipX = false;
            }*/
            renderer.flipX = rb.velocity.x < 0;
        }

        // Tildeler den nuværende position.
        previousPosX = transform.position.x;
    }
}
