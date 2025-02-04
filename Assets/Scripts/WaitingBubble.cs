using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class WaitingBubble : MonoBehaviour
{
    
    public Image s;
    public GameObject good;
    public GameObject bad;
    public GameObject play;
    Vector3 p;
    Vector3 b;
    Vector3 player;

    public Sprite s0;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;

    public Sprite pizza;
    public Sprite broccoli;

    float time;

    void Start()
    {
        player = play.transform.position;
        p = good.transform.position;
        b = bad.transform.position;

        s = GetComponent<Image>();
        s.GetComponent<Image>().sprite = s0;
        time = 0;
    }

    void Update()
    {
        player = play.transform.position;
        p = good.transform.position;
        b = bad.transform.position;

        time += Time.deltaTime;

        time %= 4;

        if (time <= 1) { s.GetComponent<Image>().sprite = s0; }
        else if (time <= 2) { s.GetComponent<Image>().sprite = s1; }
        else if (time <= 3) { s.GetComponent<Image>().sprite = s2; }
        else if (time <= 4) { s.GetComponent<Image>().sprite = s3; }

        if ((player.x - p.x <= 1) && (player.x - p.x >= -1) && (player.y - p.y <= 1) && (player.y - p.y >= -1))
        {
            s.GetComponent<Image>().sprite = pizza;
        }


        if ((player.x - b.x <= 1) && (player.x - b.x >= -1) && (player.y - b.y <= 1) && (player.y - b.y >= -1))
        {
            s.GetComponent<Image>().sprite = broccoli;
        }
    }
}