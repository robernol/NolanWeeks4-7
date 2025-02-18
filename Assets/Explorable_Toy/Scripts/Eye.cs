using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Eye : MonoBehaviour
{

    public int multiplier;
    float speed;
    int randDir;
    Vector2 flip = new Vector2(-1, 1);
    public GameObject plusOne;

    void Start()
    {

        speed = Random.Range(0.9f, 2.9f); //random speed cause life is the spice of variety

        randDir = Random.Range(0, 2);  //starts facing a random direction
        if (randDir == 0)
        {
            speed *= -1;
            transform.localScale *= flip; //if backwards, flip backwards and go backwards
        }
    }

    void Update()
    {

        Vector3 temp = transform.position; //temporary vector

        if ((transform.position.x <= -23) || (transform.position.x >= 23)) //keeps the eyes in bounds of the map
        {
            speed *= -1;
            transform.localScale *= flip; //flips em when they reach either bound
        }

        temp.x += multiplier * speed * 0.005f; //calculates their movement

        transform.position = temp; //sets the position
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Snapdragon") //when colliding with the player, eye is DFESTROYED
        {
            Instantiate(plusOne, transform.position, Quaternion.identity); //and you get a fun little plus one in it's place (don't do nothing though)
            Destroy(gameObject);
        }
    }
}
