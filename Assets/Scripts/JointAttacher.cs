using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAttacher : MonoBehaviour
{
    public enum JointType
    {
        Piston, Wheel,
    }
    Rigidbody2D joint;
    public JointType jointType;

    void Awake()
    {
        switch (jointType)
        {
            case JointType.Piston:
                joint = transform.GetChild(0).GetComponent<Rigidbody2D>();
                gameObject.GetComponent<SpringJoint2D>().connectedBody = joint;
                break;
            case JointType.Wheel:
                joint = transform.GetChild(0).GetComponent<Rigidbody2D>();
                gameObject.GetComponent<WheelJoint2D>().connectedBody = joint;
                break;
        }
    }
}


/* File: WheelFinder.cs

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFinder : MonoBehaviour
{
    Rigidbody2D joint;

    void Awake()
    {
        //Connects child object as a wheel
        joint = transform.GetChild(0).GetComponent<Rigidbody2D>();
        gameObject.GetComponent<WheelJoint2D>().connectedBody = joint;
    }
}

*/

/* File: pistonFinder.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistonFinder : MonoBehaviour
{
    Rigidbody2D joint;

    void Awake()
    {
        //Connects child object as a piston
        joint = transform.GetChild(0).GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpringJoint2D>().connectedBody = joint;
    }
}

*/