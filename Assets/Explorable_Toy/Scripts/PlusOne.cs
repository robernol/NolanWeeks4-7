using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : MonoBehaviour
{
    float timer;
    void Start()
    {
        timer = Time.time;
    }

    void Update()
    {
        if (Time.time - timer > 2) //lasts for two seconds
        {
            Destroy(gameObject); //then is DESTROYED
        }

        Vector3 temp = transform.position; //moves upwards slowly after spawning in

        temp.y += 0.001f;

        transform.position = temp;
    }
}
