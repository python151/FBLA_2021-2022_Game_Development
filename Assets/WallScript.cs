using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public bool hasDoor;

    public bool isLocked = true;

    private bool doorDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (hasDoor) Destroy(transform.GetChild(0).gameObject);
        else
        {
            Destroy(transform.GetChild(1).gameObject);
        }
        
        InvokeRepeating(nameof(_checkIfLocked), .5f, .1f);
    }

    void _checkIfLocked()
    {
        if (!isLocked && !doorDestroyed)
        {
            Destroy(transform.GetChild(1).gameObject);

            doorDestroyed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
