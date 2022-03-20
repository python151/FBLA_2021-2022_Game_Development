﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FroggerPlayer : MonoBehaviour
{
    public float movement_speed;

    public int lives = 3;
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
        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, 0, 5*2.1f));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ScoreContainer.incrementScore(-250);
        lives--;
        LifeManager.SetHearts(lives);

        if (lives <= 0)
        {
            SceneManager.LoadSceneAsync("Main");
        }
    }
}
