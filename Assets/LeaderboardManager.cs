using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
    public static string path = "";
    
    public static List<KeyValuePair<string, int>> getPlayers(string name, int score, int num)
    {
        // Puts the user in with the rankings even when they're
        // not in top num
        
        // Gets top players and adds new player to list
        List<KeyValuePair<string, int>> topNum = getPlayers(num - 1);
        topNum.Add(new KeyValuePair<string, int>(name, score));
        
        // sorts list by score
        topNum = topNum.OrderBy(x => x.Value).ToList();
        topNum.Reverse();
        
        // removes duplicates
        topNum = topNum.GroupBy(x => x.Key)
            .Select(g => new KeyValuePair<string, int>(g.Key, g.Sum(x=>x.Value)))
            .ToList();
            
        return topNum;
    }
    
    public static List<KeyValuePair<string, int>> getPlayers(int num)
    {
        // Gets sorted list of top num players and their scores
        
        List<KeyValuePair<string, int>> ret = new List<KeyValuePair<string, int>>();

        foreach (string player in File.ReadLines(path))
        {
            string[] p = player.Split('|');
            print(p[1]);
            ret.Add(new KeyValuePair<string, int>(p[0], Int32.Parse(p[1])));
        }

        ret = ret.OrderBy(x => x.Value).ToList();
        ret.Reverse();
        
        return ret.GetRange(0, num);
    }

    public static void addNewPlayer(string name, int score)
    {
        // Literally just adds a new score and name to the leaderboard list
        name = name.Replace(" ", "").Replace("|", "");

        File.AppendAllText(path, $"\n" + $"{name}|{score}");
    }

    public static void loadLeaderboardScene()
    {

        SceneManager.LoadScene("Leaderboard");
    }

    // Start is called before the first frame update
    void Start()
    {
        path = string.Concat(Application.dataPath, "/leaderboard.flat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
