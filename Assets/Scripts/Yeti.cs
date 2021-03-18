using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : MonoBehaviour
{
    public bool MoveLeft = true;

    public float speed = 2;

    void Update()
    {
        if (MoveLeft)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D yeti)
    {
        if (yeti.tag == "Turn")
        {
            MoveLeft = !MoveLeft;
        }
    }
}
