using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeAnimationScript : MonoBehaviour
{
    SpriteRenderer sr;

    public Sprite img01;
    public Sprite img02;
    public float waitLenght = 0.2f;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void ChangeSprite()
    {
        if (sr.sprite == img01)
        {
            sr.sprite = img02;
        }
        else
        {
            sr.sprite = img01;
        }
        print(sr.sprite);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitLenght);
        ChangeSprite();
        print("waited");
    }
}