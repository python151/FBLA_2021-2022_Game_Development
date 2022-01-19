using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreContainer : MonoBehaviour
{
    // literally just here to hold the score variable
    public static int score;
    public static int deltaScore;
    public TextMeshProUGUI text;

    public static void incrementScore(int num)
    {
        // TODO: ADD ANIMATION TO CHANGING SCORE
        deltaScore += num;
        score += num;
    }

    private void Start()
    {
        InvokeRepeating(nameof(updateScore), .5f, .05f);

        text = transform.GetComponent<TextMeshProUGUI>();
    }

    void updateScore()
    {
        text.text = $"{score}";
    }
}
