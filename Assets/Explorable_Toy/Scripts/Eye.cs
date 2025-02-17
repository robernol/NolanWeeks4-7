using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Eye : MonoBehaviour
{

    public int multiplier;
    float speed;
    int randDir;
    Vector2 flip = new Vector2(-1, 1);
    void Start()
    {

        speed = Random.Range(0.9f, 2.9f);

        randDir = Random.Range(0, 2);
        if (randDir == 0)
        {
            speed *= -1;
            transform.localScale *= flip;
        }
    }

    void Update()
    {

        Vector3 temp = transform.position;

        if ((transform.position.x <= -23) || (transform.position.x >= 23))
        {
            speed *= -1;
            transform.localScale *= flip;
        }

        temp.x += speed * 0.005f;

        transform.position = temp;
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Snapdragon")
        {
            Destroy(gameObject);
        }
    }
}
