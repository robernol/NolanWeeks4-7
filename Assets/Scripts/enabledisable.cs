using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabledisable : MonoBehaviour
{
    public SpriteRenderer sr;
    public enabledisable ed;
    public GameObject go;
    public AudioSource au;
    public AudioClip clip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            go.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            go.SetActive(true);

        }
        if (Input.GetKey(KeyCode.Space))
        {
            //au.Play();
            if (!au.isPlaying)
            {
                au.PlayOneShot(clip);
            }
            //au.clip.length  
        }
    }
}
