using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Glorg : MonoBehaviour
{
    public GameObject sword;
    public GameObject pivot;
    public Camera main;
    Animator anim;
    float timer;
    Vector3 mousePos;

    public float angle;
    void Start()
    {
        anim = sword.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Click", true);
            timer = Time.time;
        }
        if (Time.time - timer >= 0.4)
        {
            anim.SetBool("Click", false);
        }

        mousePos = main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 angle = mousePos - transform.position;



        pivot.transform.up = angle;
        Vector3 temp = pivot.transform.eulerAngles;

        temp.z -= 180;
        pivot.transform.eulerAngles = temp;
    }
}
