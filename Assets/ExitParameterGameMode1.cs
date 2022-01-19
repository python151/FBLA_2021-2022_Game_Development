using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitParameterGameMode1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(checkScore), .5f, .05f);
    }

    void checkScore()
    {
        if (ScoreContainer.deltaScore > 500)
        {
            EnemyScript.reset();

            ScoreContainer.incrementScore(500);
            ScoreContainer.deltaScore = 0;
            SceneManager.LoadScene("Main");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
