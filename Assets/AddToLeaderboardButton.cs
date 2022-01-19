using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddToLeaderboardButton : MonoBehaviour
{
    public GameObject Input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToLeaderboard()
    {
        LeaderboardManager.addNewPlayer(Input.GetComponent<TMP_InputField>().text, ScoreContainer.score);
        
        PromptManager.loadEndScreen();
    }
}
