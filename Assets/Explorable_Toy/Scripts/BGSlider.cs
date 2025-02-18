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
        bg.value = player.GetComponent<Snapdragon>().mapPos; //moves the background on a slider for some layered movement

        if ((bg.value > 0) && (bg.value < 1)) //moves the camera only if the player is within the range of the slider so it doesn't go out of bounds
        {
            Vector3 temp = transform.position;

            temp.x = player.transform.position.x; //copies the player's x value

            transform.position = temp;
        }

    }
}
