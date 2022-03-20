using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowScript : MonoBehaviour
{
    // Number of logs spawned
    public int row_density;

    // Length of time for all logs to spawn
    public float spawn_window;

    public List<GameObject> logs = new List<GameObject>();
    public List<GameObject> new_logs = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < row_density; i++)
        {
            Invoke(nameof(_spawnLog), i * (spawn_window / row_density));
        }
        
        InvokeRepeating(nameof(spawn_checks), spawn_window, .05f);
    }

    void spawn_checks()
    {
        // Makes a shallow copy of list
        List<GameObject> log_copy = new List<GameObject>(logs);
        foreach (GameObject log in logs)
        {
            if (log == null)
            {
                log_copy.Remove(log);
                _spawnLog();
            }
        }

        logs = log_copy;
        logs.AddRange(new_logs);
        
        new_logs = new List<GameObject>();
    }

    void _spawnLog()
    {
        GameObject l = (GameObject) Instantiate(Resources.Load("GameMode3/LogPrefab"), transform.position, new Quaternion());
        new_logs.Add(l);
    }
}
