using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float movement_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement_speed * Time.deltaTime * Vector3.right);
        
        // Destroying old gameobjects
        if (transform.position.x > 100f || transform.position.x < -100f) 
        {
            Destroy(transform.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(transform.gameObject);
    }
}
