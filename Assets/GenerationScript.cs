using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore;
using Random = System.Random;

public class GenerationScript : MonoBehaviour
{
    private static int _id = 0;
    public int room_id = 0;

    public static List<GenerationScript> past = new List<GenerationScript>();
    public static GenerationScript current;
    public static List<GenerationScript> isSpawned = new List<GenerationScript>();
    public bool isNew;
    public Hashtable positions = new Hashtable();
    
    // Starts at top (1) and goes clockwise
    public int side_for_door = 0;
    // Type of puzzle
    public int puzzleID = 0;
    public static bool isFirst = true;
    
    private static bool _exists(GenerationScript g) {
        return g.puzzleID != 0;
    }

    public void OnEnable()
    {
        isSpawned.Add(this);
    }

    public void OnDisable()
    {
        isSpawned.Remove(this);
    }

    public void OnDestroy()
    {
        isSpawned.Remove(this);
    }
    

    private void Awake()
    {
        if (!isFirst && !isNew)
        {
            print(current.room_id);
            room_id = current.room_id;
            side_for_door = current.side_for_door;
            puzzleID = current.puzzleID;

            current.isNew = false;
        }
        else
        {
            // This is just setting the variables for the first time
            // There is better and cleaner ways to do this
            // But because this is only like 4 variables 
            // I'm not gonna spending the time implementing it,
            // But could look into fixing this sometime in the future
            
            current = this;
            _id++;
            room_id = _id;
            side_for_door = UnityEngine.Random.Range(1, 5);
            puzzleID = UnityEngine.Random.value > .5 ? 1 : 3; // TODO: CHANGE THIS TO BE MORE DYNAMIC
            
            print($"Generating the {_id}(th/nd) room with room_id {room_id}");
            
            isNew = false;
            current.isNew = false;
            isFirst = false;
        }
        
        transform.gameObject.name = $"Room{room_id}";
    }

    private void Start()
    {
        /*
        // Spawns old rooms
        foreach (GenerationScript generationScript in past)
        {
            bool flag = true;
            foreach (GenerationScript g in isSpawned)
            {
                if (g.room_id == generationScript.room_id)
                {
                    flag = false;
                    break;
                }
            }
            if (GameObject.Find($"Room{generationScript.room_id}") == null && flag)
            {
                GameObject newRoom = Instantiate(PrefabUtility.LoadPrefabContents("Assets/Prefabs/OldRoom.prefab"));
                GenerationScript newScript = newRoom.GetComponent<GenerationScript>();
                newScript.room_id = generationScript.room_id;
                newScript.side_for_door = generationScript.side_for_door;
                newScript.isNew = false;
                newScript.puzzleID = generationScript.puzzleID;
                print($"Generating past room #{newScript.room_id} from room #{room_id}");
            }
            else
            {
                break;
            }
        }
        
        // Moves room to position
        transformRoom(solveForPosition());
        
        */
    }

    public Vector3 solveForPosition()
    {
        Vector3 movement = Vector3.zero;
        if (room_id <= 1)
        {
            return Vector3.zero;
        }

        foreach (GenerationScript g in past)
        {
            if (g.room_id < room_id)
            {
                if (g.side_for_door == 1) movement.y++;
                else if (g.side_for_door == 3) movement.y--;
                
                else if (g.side_for_door == 2) movement.x++;
                else if (g.side_for_door == 4) movement.x--;
            }
        }
        
        return movement;
    }

    public void transformRoom(Vector3 position)
    {
        // Moves to scaled position
        float k = 25;
        transform.position = position*k;
        
        // Resets rotation and rotates to rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.Rotate(new Vector3(0, 0, 90 * side_for_door));
    }

    public static void puzzle_solved()
    {
        
        past.Add(current);
        // Generates new room and sets as active
        //GameObject newRoom = Instantiate(PrefabUtility.LoadPrefabContents("Assets/Prefabs/Room.prefab"));
        //newRoom.GetComponent<GenerationScript>().isNew = true;
    }
}
