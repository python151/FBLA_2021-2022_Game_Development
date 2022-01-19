using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHomeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoHome()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
