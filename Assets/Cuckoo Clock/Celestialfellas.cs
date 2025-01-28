using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Celestialfellas : MonoBehaviour
{
    public float speed;
    Vector3 centre;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenSizeInTheWorld = new Vector2();
        screenSizeInTheWorld = Camera.main.ScreenToWorldPoint(screenSize);

        centre = new Vector3(0, screenSizeInTheWorld.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -0.05f);
    }
}
