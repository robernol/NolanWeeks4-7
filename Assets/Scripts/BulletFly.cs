using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float x;
    public float y;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 temp = transform.position;

        temp.x += x;
        temp.y += y;

        transform.position = temp;
    }
}
