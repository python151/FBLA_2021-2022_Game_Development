using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    Vector2 velocity = new Vector2();
    public float sprint_boost = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2();

        if (Input.GetKey("w")) velocity.y++;
        if (Input.GetKey("d")) velocity.x++;
        if (Input.GetKey("s")) velocity.y--;
        if (Input.GetKey("a")) velocity.x--;
        
        if (Input.GetKey(KeyCode.LeftShift)) velocity *= sprint_boost;
        
        
        ;
    }

    private void LateUpdate()
    {
        if (transform.position.x < -1)
        {
            velocity.x = 1;
        } else if(transform.position.x > 18.7)
        {
            velocity.x = -1;
        }
        
        if (transform.position.y < -10)
        {
            velocity.y = 1;
        } else if(transform.position.y > 10)
        {
            velocity.y = -1;
        }
        
        transform.Translate(velocity * (speed * Time.deltaTime));
    }
}
