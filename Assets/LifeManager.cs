using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [CanBeNull] static LifeManager singleton;
    // Start is called before the first frame update
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
    }

    void _SetHearts(int hearts)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i < hearts);
        }
    }

    public static void SetHearts(int hearts)
    {
        if (singleton == null)
            throw new Exception("No LifeBox!");
        singleton._SetHearts(hearts);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
