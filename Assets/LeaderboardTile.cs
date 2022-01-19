using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardTile : MonoBehaviour
{
    public string gamertag = string.Empty;

    public int score;

    public GameObject scoreObject;
    public GameObject nameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
        nameObject.GetComponent<TextMeshProUGUI>().text = gamertag;
        print(gamertag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
