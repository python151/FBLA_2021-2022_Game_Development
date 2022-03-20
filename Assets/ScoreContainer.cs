using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;

public class ScoreContainer : MonoBehaviour
{
    // literally just here to hold the score variable
    public static int score;
    public static int deltaScore;
    public static TextMeshProUGUI currentText;
    
    
    public static void incrementScore(int num)
    {
        scoreAnimation(num);
        deltaScore += num;
        score += num;
    }

    public static void scoreAnimation(int num)
    {
        if (num < 0)
        {
            currentText.color = Color.red;
        }
        else
        {
            currentText.color = Color.green;
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(updateScore), .5f, .05f);

        currentText = transform.GetComponent<TextMeshProUGUI>();
    }

    void updateScore()
    {
        currentText.text = $"{score}";
    }
}
