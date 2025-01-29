using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWalk : MonoBehaviour
{
    float xpos;
    float ypos;
    public GameObject chest;
    public GameObject reward;
    public GameObject canvas;
    Vector3 chestPos;

    public AudioClip treasure;
    public AudioSource birdy;

    // Start is called before the first frame update
    void Start()
    {
        chestPos = chest.transform.position;
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;

        if (Input.GetKey(KeyCode.A))
        {
            xpos -= 0.01f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xpos += 0.01f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ypos += 0.01f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            ypos -= 0.01f;
        }

        Vector3 newPos = new Vector3(xpos, ypos, -1);
        transform.position = newPos;

        if ((transform.position.x >= chestPos.x - 1) && (transform.position.x <= chestPos.x + 1) && (transform.position.y >= chestPos.y - 1) && (transform.position.y <= chestPos.y + 1))
        {
            canvas.SetActive(true);
            if ((Input.GetKey(KeyCode.E) && (!birdy.isPlaying)))
            {
                reward.SetActive(true);
                birdy.PlayOneShot(treasure);
            }
        }
        else
        {
            canvas.SetActive(false);
        }

    }
}
