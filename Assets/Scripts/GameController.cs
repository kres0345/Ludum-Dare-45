using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Til at holde styr på HP, fjender osv.
    // Burde indeholde nær-alle static methods og fields.

    [Header("Disable onload")]
    public GameObject[] debugObject;

    void Start()
    {
        foreach (GameObject item in debugObject)
        {
            item.SetActive(false);
        }
    }

}
