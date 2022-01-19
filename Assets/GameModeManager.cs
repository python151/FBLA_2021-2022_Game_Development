using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(GenerationScript.current.puzzleID -1).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
