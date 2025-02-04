using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReaction : MonoBehaviour
{
    public float speed;
    Vector3 pos;
    void Start()
    {
        
    }

    void Update()
    {
        pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed;
        }
        transform.position = pos;

    }
}
