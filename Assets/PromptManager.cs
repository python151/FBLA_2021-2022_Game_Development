using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
    public GameObject LeaderboardPrompt;
    public GameObject EndScreenPrompt;

    public static PromptManager current;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        
        LeaderboardPrompt.SetActive(true);
    }

    public static void loadEndScreen()
    {
        current.LeaderboardPrompt.SetActive(false);
        current.EndScreenPrompt.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
