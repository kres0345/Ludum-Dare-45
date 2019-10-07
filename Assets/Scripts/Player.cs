using UnityEngine;

public class Player : Entity
{
    public float JumpPower;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isPlayer = true;
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Jump");
            rb.AddForce(Vector2.up * JumpPower * Time.deltaTime, ForceMode2D.Impulse);
        }*/
    }
}
