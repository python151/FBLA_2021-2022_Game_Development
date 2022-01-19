using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movement_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate((Vector3.up * movement_speed) * Time.deltaTime);
        }
        
        // Move down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate((Vector3.down * movement_speed) * Time.deltaTime);
        }
        
        // Clamping position
        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, -30f, 30f));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(PrefabUtility.LoadPrefabContents("Assets/Prefabs/GameMode1/Bullet.prefab"), transform.position + new Vector3(1, 0, 0), quaternion.Euler(0, 0, 0));
        }
    }
}
