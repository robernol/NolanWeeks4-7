using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Snapdragon : MonoBehaviour
{
    bool idle;
    bool up;
    bool down;
    bool flip;
    Animator anim;
    public AnimationCurve jump;
    float jumpStart;
    public float mapPos;
    public GameObject eyeSpawn;
    
    public DropDown menu;

    void Start()
    {
        menu = GameObject.Find("/Main Camera/Canvas/Menu").GetComponent<DropDown>(); //needs the speed and quantity variables from this script

        idle = true;
        up = false;
        down = false;
        flip = false;

        jumpStart = -10;

        anim = GetComponent<Animator>();
        anim.SetBool("Idle", idle); //plays animation when respective bool value is set to true
        anim.SetBool("Up", up);
        anim.SetBool("Flip", flip);
        anim.SetBool("Down", down);

        mapPos = 0.5f; //start in the middle of the "map"
    }

    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space) && (Time.time - jumpStart >= 2.6f))) //if spacebar is pressed and not in the middle of a jump, jumps
        {
            idle = false;
            down = false;
            flip = false;
            up = true;

            jumpStart = Time.time; //sets value to the current time to track when you are jumping
        }

        Vector3 temp = transform.position; //temporary vectors
        Vector3 rot = transform.eulerAngles;

        if ((Input.GetKey(KeyCode.A) && (transform.position.x > -23.5f)))
        {
            temp.x -= 0.015f; //if a is pressed and not too far to the left, moves and rotates the player
            rot.z = 30f;
            mapPos -= 0.0005f;
        }

        if ((Input.GetKey(KeyCode.D) && (transform.position.x < 23.5f)))
        {
            temp.x += 0.015f; //same but for d and to the right
            rot.z = -30f;
            mapPos += 0.0005f;
        }

        if (!(Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.D)))
        {
            rot.z = 0; //rotation is set back to 0 if neither are being held
        }

        temp.y = -5; //sets the player at the bottom of the screen

        temp.y += jump.Evaluate(Time.time - jumpStart); //when jumping, uses an animation curve to inform the arc

        if (Time.time - jumpStart >= 2.1f) //different parts of the animation at different points
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
 

        transform.position = temp; //uses temporary vectors to set position and rotation
        transform.eulerAngles = rot;

        anim.SetBool("Idle", idle); //have to do this again or it dont work
        anim.SetBool("Up", up);
        anim.SetBool("Flip", flip);
        anim.SetBool("Down", down);

        if (Input.GetMouseButtonDown(1)) //when right clicking, spawns an eye
        {
            for (int i = 0; i < menu.quantity; i++) //if the quantity is more than 1, spawns that many at a time
            {
                Vector3 rand = new Vector3(transform.position.x + (Random.Range(-2.5f, 2.5f)), (Random.Range(-2f, 3.5f)), -1); //random placement around the player for the eye
                GameObject g = Instantiate(eyeSpawn, rand, Quaternion.identity); //creates the eye

                g.GetComponent<Eye>().multiplier = menu.speed; //if speed is more than 1, multiplies new eyes' speed by that number
            }
        }
    }
}
