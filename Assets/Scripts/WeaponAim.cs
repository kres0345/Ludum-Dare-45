using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    
    public Transform weapon;
    public float offset;

    private Vector3 objectPosition;
    private Vector3 mousePosition;
    private float angle;
    
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        /*
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        angle = Mathf.Atan((transform.position.x - mousePosition.x) / (transform.position.y - mousePosition.y));
        
        if (mousePosition.y < transform.position.y)
        {
            angle += Mathf.PI;
        }
        Vector2 newPos = new Vector2(Mathf.Sin(angle) * offset + transform.position.x, Mathf.Cos(angle) * offset + transform.position.y);
        weapon.position = newPos;

        //weapon.RotateAround(transform.position, new Vector3(0, 0, 1), angle);

        //transform.rotation = Quaternion.Euler(0,0,angle);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle),10000000f);

        //MAKE ANGLE NON-RADIENT

        //transform.eulerAngles = mousePosition;

        Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), 360);


        /*
        Quaternion rotateTowards = Quaternion.LookRotation(weapon.position - mousePosition);
        rotateTowards.z = rotateTowards.y;
        rotateTowards.y = 0;
        rotateTowards.x = 0;
        weapon.rotation = rotateTowards;
        */
        
        //float newAngle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        //weapon.rotation = Quaternion.Euler(new Vector3(0, 0, newAngle));

        //weapon.LookAt(mousePosition);
        

        //weapon.position = Vector3.MoveTowards(transform.position, position, rotateSpeed * Time.deltaTime);
        //float angle = Vector2.Angle(transform.position, position);
        //print(angle);
        //weapon.RotateAround(transform.position, new Vector3(0, 0, 1), angle);
    }
}