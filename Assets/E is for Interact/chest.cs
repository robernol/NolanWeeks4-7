using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public float xpos;
    public float ypos;
    // Start is called before the first frame update
    void Start()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
