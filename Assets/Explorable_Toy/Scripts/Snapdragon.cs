using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Snapdragon : MonoBehaviour
{
    public bool idle;
    public bool up;
    public bool down;
    public bool flip;
    Animator anim;
    public AnimationCurve jump;
    float jumpStart;
    public float mapPos;
    public GameObject eyeSpawn;
    void Start()
    {
        idle = true;
        up = false;
        down = false;
        flip = false;

        jumpStart = -10;

        anim = GetComponent<Animator>();
        anim.SetBool("Idle", idle);
        anim.SetBool("Up", up);
        anim.SetBool("Flip", flip);
        anim.SetBool("Down", down);

        mapPos = 0.5f;
    }

    void Update()
    {


        if ((Input.GetKeyDown(KeyCode.Space) && (Time.time - jumpStart >= 2.6f)))
        {
            idle = false;
            down = false;
            flip = false;
            up = true;

            jumpStart = Time.time;
        }

        Vector3 temp = transform.position;
        Vector3 rot = transform.eulerAngles;

        if ((Input.GetKey(KeyCode.A) && (transform.position.x > -23.5f)))
        {
            temp.x -= 0.03f;
            rot.z = 30f;
            mapPos -= 0.001f;
        }

        if ((Input.GetKey(KeyCode.D) && (transform.position.x < 23.5f)))
        {
            temp.x += 0.03f;
            rot.z = -30f;
            mapPos += 0.001f;
        }

        if (!(Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.D)))
        {
            rot.z = 0;
        }

        temp.y = -5;

        temp.y += jump.Evaluate(Time.time - jumpStart);

        if (Time.time - jumpStart >= 2.1f)
        {
            up = false;
            flip = false;
            down = false;
            idle = true;
        }
        else if (Time.time - jumpStart >= 0.9f)
        {
            idle = false;
            up = false;
            flip = false;
            down = true;
            rot.z *= -1;
        }
        else if (Time.time - jumpStart >= 0.6f)
        {
            idle = false;
            down = false;
            up = false;
            flip = true;
            rot.z = 0;
        }
 

        transform.position = temp;
        transform.eulerAngles = rot;

        anim.SetBool("Idle", idle);
        anim.SetBool("Up", up);
        anim.SetBool("Flip", flip);
        anim.SetBool("Down", down);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rand = new Vector3(transform.position.x + (Random.Range(-2.5f, 2.5f)), (Random.Range(-2f, 3.5f)), -1);
            Instantiate(eyeSpawn, rand, Quaternion.identity);
        }
    }
}
