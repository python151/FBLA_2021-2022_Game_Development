using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class EnemyScript : MonoBehaviour
{
    public static float enemySpeed;

    public static float fireRate;

    public static Vector3 formationCenterpoint;
    public static float lengthOfDistrobutionLine;

    private static int _id;
    public int id;
    
    public static Func<float, Vector3> formationFunc;

    public float time;
    public bool time_flag;
    public float timePeriod = 5f;

    private static List<EnemyScript> enemies = new List<EnemyScript>();
    // Start is called before the first frame update
    void Start()
    {
        _id++;
        id = _id;
        
        enemies.Add(this); 
    }

    // Update is called once per frame
    void Update()
    {
        if (time > timePeriod || time_flag)
        {
            time -= Time.deltaTime;
            time_flag = true;
        }
        else
        {
            time += Time.deltaTime;
        }

        if (time < 0) time_flag = false;

        float k = Mathf.PI*3/5;
        transform.position = formationFunc(id * k) + new Vector3(0, time * enemySpeed);

        if (UnityEngine.Random.Range(0, fireRate) > .5)
        {
            shoot();
        }
    }

    public void shoot()
    {
        GameObject bullet = Instantiate(PrefabUtility.LoadPrefabContents("Assets/Prefabs/GameMode1/Bullet.prefab"), transform.position + new Vector3(-2, 0, 0), quaternion.Euler(0, 0, 0));
        bullet.GetComponent<BulletScript>().movement_speed = -8;
    }

    public static Vector3 formationFunc1(float input)
    {
        return new Vector3(((3*Mathf.Sin(input))+formationCenterpoint.x), input);
    }

    private void OnApplicationQuit()
    {
        enemies.Clear();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.GetComponent<BulletScript>().movement_speed > 0)
        {        
            ScoreContainer.incrementScore(100); 
            Destroy(transform.gameObject);
        }

    }

    public static void reset()
    {
        _id = 0;
    }
}
