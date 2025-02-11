using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankYou : MonoBehaviour
{
    public GameObject barrel;
    public GameObject pivot;
    public Transform mouse;
    public GameObject bulletPrefab;
    GameObject bulletInstance;
    Vector3 pos;
    Vector3 mousePos;
    public Vector3 angle;
    void Start()
    {
        
    }


    void Update()
    {
        pos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= 0.001f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += 0.001f;
        }

        transform.position = pos;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        mouse.transform.position = mousePos;

        angle = mousePos - pivot.transform.position;

        pivot.transform.up = angle;

        if (Input.GetMouseButtonDown(0))
        {
            bulletInstance = Instantiate(bulletPrefab);
        }

    }
}
