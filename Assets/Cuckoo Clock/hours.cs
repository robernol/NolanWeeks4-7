using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class hours : MonoBehaviour
{
    public float speed;
    Vector3 centre;
    public AudioClip chime;
    public AudioSource noise;
    public SpriteRenderer sr;

    public Boolean annoying;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenSizeInTheWorld = new Vector2();
        screenSizeInTheWorld = Camera.main.ScreenToWorldPoint(screenSize);

        centre = new Vector3(0, 0, 0);


    }

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(centre, Vector3.forward, speed);
        if ((Mathf.Round(transform.eulerAngles.z % 30) == 0 ) && (annoying == true) && (!noise.isPlaying))
        {
            noise.PlayOneShot(chime);
        }

        if (annoying == true)
        {
            if (noise.isPlaying)
            {
                sr.enabled = true;
            }
            else
            {
                sr.enabled = false;
            }

        }
        
    }
}
