using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FroggerScript : MonoBehaviour
{
    public float row_size = 1f;
    public int num_rows = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn Logs in random pos
        for (int i = 0; i < num_rows; i++)
        {
            Instantiate(Resources.Load("GameMode3/RowPrefab"), transform.position+(Vector3.up * i * row_size), new Quaternion());
        }
        
        Invoke(nameof(TimeUp), 30f);
    }

    void TimeUp()
    {
        ScoreContainer.incrementScore(2000);
        SceneManager.LoadSceneAsync("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
