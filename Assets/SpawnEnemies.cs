using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float number_of_enemies;

    public float speed_of_enemies;

    public float combat_effectiveness;

    public float fire_rate;
    // Start is called before the first frame update
    void Start()
    {

        EnemyScript.enemySpeed = speed_of_enemies;
        EnemyScript.fireRate = fire_rate;
        EnemyScript.formationFunc = EnemyScript.formationFunc1;
        EnemyScript.formationCenterpoint = new Vector3(10, 0, 0);
        
        // Spawns enemies here
        for (int i = 0; i < number_of_enemies; i++)
        {
            Instantiate(PrefabUtility.LoadPrefabContents("Assets/Prefabs/GameMode1/Enemy.prefab"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
