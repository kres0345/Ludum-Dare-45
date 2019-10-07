using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDebug : MonoBehaviour
{
    public bool Freecam = true;
    public float Flyspeed;
    public float Zoomspeed;
    public Camera ChildCamera;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("GameController").Length != 0)
        {
            Destroy(gameObject);
        }
        else if (Freecam)
        {
            print("Free fly mode enabled, use WASD or Arrowkeys");
        }
    }

    void Update()
    {
        if (Freecam)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Flyspeed * Time.deltaTime);

            ChildCamera.orthographicSize += Input.mouseScrollDelta.y * Zoomspeed * Time.deltaTime * -1;
        }
    }
}
