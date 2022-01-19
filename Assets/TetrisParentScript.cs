using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisParentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        print("Creating structure");
        for (int i = 0; i < TetrisSpawnerScript.height.x; i++)
        {
            GameObject g = new GameObject($"X{i}");
            g.transform.SetParent(transform);
            g.SetActive(true);
            for (int j = 0; j < TetrisSpawnerScript.height.y; j++)
            {
                GameObject g1 = new GameObject($"Y{j}");
                g1.transform.SetParent(g.transform);
            }
        }

        for (int i = 0; i < TetrisSpawnerScript.height.x; i++)
        {
            for (int j = 0; j < TetrisSpawnerScript.height.y; j++)
            {
                updateIndex(new Vector2(i, j));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateIndex(Vector2 i)
    {
        GameObject current = transform.GetChild((int) i.x).GetChild((int) i.y).gameObject;
        current.transform.position = i * 2;
    }
}
