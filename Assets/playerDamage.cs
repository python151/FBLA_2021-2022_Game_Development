using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TODO: SOUND EFFECT HERE
    
    void OnCollisionEnter2D(Collision2D other)
    {
        ScoreContainer.score -= 500;
        if (ScoreContainer.score < 0)
        {
            ScoreContainer.score = 0;
        }

        SceneManager.LoadScene("Main");
    }
}
