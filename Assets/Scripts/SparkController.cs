using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{
    public float HoverHeight;
    public float HoverPower;
    public float MoveSpeed;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make it hover
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.2f), Vector2.down);
        Debug.DrawRay(transform.position + new Vector3(0, -0.2f), Vector2.down, Color.blue);

        //print(hit.distance);
        if (hit.collider != null)
        {
            hit.distance += 0.2f;
            if (hit.distance < HoverHeight)
            {
                rb.AddForce(Vector2.up * HoverPower * Time.deltaTime);
                print("Adding force");
            }
        }

        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime, 0));
    }
}
