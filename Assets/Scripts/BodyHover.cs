using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHover : MonoBehaviour
{
    private Transform followObject;
    public Vector3 offset;

    void Awake ()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).tag == "PlayerMovementComponent")
            {
                followObject = transform.parent.GetChild(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (followObject != null)
        {
            transform.position = followObject.position + offset;
        }
    }
}