using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowObject;
    public float smoothTime;
    public Vector3 Offset;
    private Vector3 camVelocity;

    void Update()
    {
        Vector3 localOffset = Offset + new Vector3(0, 0, -10);
        Vector3 targetPosition = FollowObject.TransformPoint(localOffset);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camVelocity, smoothTime);
    }
}
