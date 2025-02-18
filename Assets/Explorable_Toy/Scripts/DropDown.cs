using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public AnimationCurve drop;
    public AnimationCurve up;
    bool goingDown = false;
    bool goingUp = true;
    float timer = -10;
    Vector3 home;
    public Camera main;

    public TMP_Text s;
    public int speed;
    public Button si;
    public Button sd;
    public TMP_Text q;
    public int quantity;
    public Button qi;
    public Button qd;

    public Button dropdown;


    void Start()
    {
        home = transform.position; //keeps track of its home position
        speed = 1; //default values
        quantity = 1;

        si.onClick.AddListener(SiClick); //functions for all me buttons
        sd.onClick.AddListener(SdClick);
        qi.onClick.AddListener(QiClick);
        qd.onClick.AddListener(QdClick);
        dropdown.onClick.AddListener(DropDownClick);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = home; //temporary vector based on the home pos

        if (goingUp == true) //if the dropdown menu is currently up
        {
            temp.y = (home.y - 6.5f) + up.Evaluate(Time.time - timer); //animation curve for bringing the menu back up
        }

        if (goingDown == true) //if it is currently down (probably could have just been one bool)
        {
            temp.y += drop.Evaluate(Time.time - timer); //and for bringing it down
        }

        temp.x = main.transform.position.x; //always centers horizontally on the camera

        transform.position = temp;


        s.text = speed.ToString(); //if the speed value is increased/decreased, updates the number on the dropdown menu
        q.text = quantity.ToString(); //ditto for the quantity value
    }

    void DropDownClick() //if clicking on the dropdown button and it hasn't been too soon since the last time you clicked it, goes up/down depending
    {
        if (Time.time - timer > 1) //one second cooldown
        {
            if (goingDown == true) //if down, go up
            {
                timer = Time.time; //resets the timer
                goingUp = true;
                goingDown = false;
            }
            else if (goingUp == true) //if up, go down
            {
                timer = Time.time;
                goingDown = true;
                goingUp = false;
            }
        }
    }

    void SiClick() //increases speed up to 9 max
    {
        if (speed < 9) { speed++; }
    }

    void SdClick() //decreases speed down to 1 min
    {
        if (speed > 1) { speed--; }
    }

    void QiClick() // + quantity, 20 max
    {
        if (quantity < 20) { quantity++; }
    }

    void QdClick() // -, 1 min
    {
        if (quantity > 1) { quantity--; }
    }
}
