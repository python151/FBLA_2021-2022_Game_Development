using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    public float sprint_boost = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2();

        if (Input.GetKey("w")) velocity.y++;
        if (Input.GetKey("d")) velocity.x++;
        if (Input.GetKey("s")) velocity.y--;
        if (Input.GetKey("a")) velocity.x--;
        
        if (Input.GetKey(KeyCode.LeftShift)) velocity *= sprint_boost;
        
        
        transform.Translate(velocity * (speed * Time.deltaTime));
    }
}
