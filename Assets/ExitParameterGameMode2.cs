using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ExitParameterGameMode2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(checkExitParameter), .5f, .05f);
    }

    void checkExitParameter()
    {
        if (ScoreContainer.deltaScore >= 600)
        {
            ScoreContainer.incrementScore(600);
            ScoreContainer.deltaScore = 0;
            SceneManager.LoadScene("Main");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
