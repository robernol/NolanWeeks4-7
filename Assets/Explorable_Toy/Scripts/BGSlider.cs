using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGSlider : MonoBehaviour
{
    Slider bg;
    public GameObject player;
    void Start()
    {
        bg = GetComponent<Slider>();
    }

    
    void Update()
    {
        bg.value = player.GetComponent<Snapdragon>().mapPos;

        if ((bg.value > 0) && (bg.value < 1))
        {
            Vector3 temp = transform.position;

            temp.x = player.transform.position.x;

            transform.position = temp;
        }

    }
}
