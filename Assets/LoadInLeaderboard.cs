using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class LoadInLeaderboard : MonoBehaviour
{
    public GameObject LeaderboardTilePrefab;
    // Start is called before the first frame update
    void Awake()
    {
        List<KeyValuePair<string, int>> scores = LeaderboardManager.getPlayers(6);
        
        int i = 0;
        foreach (KeyValuePair<string, int> score in scores)
        {
            i++;
            
            GameObject leaderboardTile = Instantiate(LeaderboardTilePrefab, this.transform);
            LeaderboardTile tileScript = leaderboardTile.GetComponent<LeaderboardTile>();
            tileScript.gamertag = score.Key;
            tileScript.score = score.Value;
            print(tileScript.gamertag);

            leaderboardTile.SetActive(true);
            
            leaderboardTile.transform.localPosition = new Vector3(0, -30 * i+1, 0);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
