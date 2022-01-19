using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.GetChild(transform.parent.GetComponent<GenerationScript>().side_for_door-1).GetComponent<WallScript>().hasDoor = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
