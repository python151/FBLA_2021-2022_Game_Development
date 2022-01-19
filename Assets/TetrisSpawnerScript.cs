using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class TetrisSpawnerScript : MonoBehaviour
{
    public int[,] previous_board = new int[(int) height.x, (int)height.y];
    public static Vector2 height = new Vector2(13, 30);
    private List<Vector2> currentPiece = new List<Vector2>();
    public int[,] board = new int[(int) height.x, (int) height.y];
    
    public GameObject ParentGameObject;

    public TetrisParentScript ParentScript;
    
    // The default block gameobject for each type of piece
    // (with the index being the number stored in the board object + 2
    // because you can't store negative indexes)
    public List<GameObject> PieceBlocks = new List<GameObject>();

    public int numberOfPieces;

    public float timeSinceLastPiece = 1f;
    
    private void Awake()
    {
        // Setting all boards to be empty
        for (int i = 0; i < height.x; i++)
        {
            for (int j = 0; j < height.y; j++)
            {
                previous_board[i, j] = -2;
                board[i, j] = -1;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ParentScript = ParentGameObject.GetComponent<TetrisParentScript>();
        
        InvokeRepeating(nameof(gravityMovePiece), 1f, .75f);
        InvokeRepeating(nameof(checkForRows), 1f, .1f);
        
        // Spawning first piece
        spawnNewPiece();
    }

    void checkForRows()
    {        
        // Checks if any complete rows
        List<int> rows = new List<int>();
        for (int i = 0; i < height.x; i++)
        {
            // flag triggered if row has empty spots
            bool flag = false;
            for (int j = 0; j < height.y; j++)
            {
                if (board[i, j] == -1)
                {
                    flag = true;
                    break;
                }
            }

            if (!flag) rows.Add(i);
        }

        foreach (int row in rows)
        {        
            // add 300 to score;
            ScoreContainer.score += 300;
            
            // iterating through the row
            for (int i = 0; i < height.x; i++)
            {
                // delete row;
                board[i, row] = -1;
                
                // and shift all rows above down by 1;
                for (int j = row+1; j < height.y; j++)
                {
                    board[i, j - 1] = board[i, j];
                    board[i, j] = -1;
                }
            }
        }
    }
    
    Vector2 pickDirection()
    {
        bool vertical = UnityEngine.Random.value > .5;
        if (vertical)
        {
            return new Vector2(0, Mathf.Round((UnityEngine.Random.value * 2) - 1));
        }
        return new Vector2(Mathf.Round((UnityEngine.Random.value * 2) - 1), 0);
    }
    
    // Spawns a new piece
    void spawnNewPiece()
    {
        if (timeSinceLastPiece < .5f)
        {
            return;
        }

        timeSinceLastPiece = 0f;
        
        // updating some variables for stats
        numberOfPieces++;
        
        // chooses pseudo-random color
        int color = UnityEngine.Random.Range((int) 0, (int) PieceBlocks.Count-1);
        
        // Creates list of positions to represent piece
        // and sets initial position
        List<Vector2> currentPiece1 = new List<Vector2>();
        currentPiece1.Add(new Vector2(Mathf.Round(height.x/2), height.y-5));
        
        int i = 0;
        while (currentPiece1.Count < 5 && i < 80)
        {
            i++;
            
            // Chooses and evaluates direction
            Vector2 direction = pickDirection();
            Vector2 updatedPosition = currentPiece1[(int) currentPiece1.Count-1] + direction;
            
            
            // Checks if it's a valid position
            if (updatedPosition.x < height.x && updatedPosition.y < height.y && updatedPosition.x > 0 && updatedPosition.y > 0)
            {
                if (board[(int) updatedPosition.x, (int) updatedPosition.y] == -1  &&
                    currentPiece1.LastIndexOf(updatedPosition) == -1)
                {
                    // Adds block to piece
                    currentPiece1.Add(updatedPosition);
                    board[(int) updatedPosition.x, (int) updatedPosition.y] = color;
                    
                    // Destroys old gameobject and replaces with new
                    Destroy(ParentGameObject.transform.GetChild((int) updatedPosition.x).GetChild((int) updatedPosition.y).gameObject);
                    
                    GameObject newBlock = Instantiate(
                            PieceBlocks[
                                Mathf.Clamp((int) board[(int) updatedPosition.x, (int) updatedPosition.y]+2,
                        (int) 0, (int) PieceBlocks.Count-1)], 
                        ParentGameObject.transform.GetChild((int) updatedPosition.x));
                    
                    newBlock.transform.SetSiblingIndex( (int) updatedPosition.y);
                    
                    // Calls function to update the newly created gameobject
                    ParentScript.updateIndex(updatedPosition);
                }
            }
        }

        if (currentPiece1.Count < 4)
        {
            print($"{currentPiece1.Count} pieces is invalid");
            ScoreContainer.incrementScore(-500);
            ScoreContainer.deltaScore = 0;
            SceneManager.LoadScene("Main");
        }

        tryTransformation(currentPiece1, applyTransform(currentPiece1, Vector2.down * 2));
        currentPiece1 = applyTransform(currentPiece1, Vector2.down * 2);

        // THIS IS JUST FOR DEBUGGING!
        foreach (var block in currentPiece1)
        {
            print(block);
        }
        
        currentPiece = currentPiece1;
    }
    
    // Moves piece down following a pseudo-gravity
    void gravityMovePiece()
    {
        print("Gravitying");
        List<Vector2> next = applyTransform(currentPiece, Vector2.down);
        bool needs_new_piece = !tryTransformation(currentPiece, next);

        if (needs_new_piece || next.Count <= 0)
        {
            print("Gravity Spawned");
            spawnNewPiece();
        } else currentPiece = next;
    }

    // Plots the changes on the board array since the last frame
    void plotBoard()
    {
        bool flag = false;
        for (int i = 0; i < height.x; i++)
        {
            for (int j = 0; j < height.y; j++)
            {
                if (previous_board[i, j] != board[i, j])
                {
                    flag = true;
                    
                    if (currentPiece.Contains(new Vector2(i, j))) print("MEEEEEsss");
                        DestroyImmediate(ParentGameObject.transform.GetChild(i).GetChild(j).gameObject);
                    GameObject newBlock = Instantiate(PieceBlocks[board[i, j]+1], ParentGameObject.transform.GetChild(i).transform);
                    newBlock.transform.SetSiblingIndex(j);

                    ParentScript.updateIndex(new Vector2(i, j));
                }
            }
        }
        if (flag) print($"End of kool cids with {currentPiece.Count} blocks");
        previous_board = board;
    }

    // Returns a deep copy of a 2D array
    public static int[,] copy2DArray(int[,] c, Vector2 dimensions)
    {
        int[,] ret = new int[(int) dimensions.x, (int) dimensions.y];

        for (int i = 0; i < dimensions.x; i++)
        {
            for (int j = 0; j < dimensions.y; j++)
            {
                ret[i, j] = c[i, j];
            }
        }
        
        return ret;
    }
    
    bool tryTransformation(List<Vector2> f, List<Vector2> g)
    {
        bool flag = true;
        foreach (Vector2 overlap in tryTransformation(f, g, true))
        {
            print($"is overlapping: {overlap}");
            flag = false;
        }

        return flag;
    }
    
    // Attempts a transformation and returns true if successful,
    // and false if unsuccessful
    // Attempts a transformation (f -> g) and returns a list of positions
    // it will collide with (that have other things in it)
    List<Vector2> tryTransformation(List<Vector2> f, List<Vector2> g, bool overlaps)
    {
        if (!overlaps)
        {
            return new List<Vector2> {Vector2.negativeInfinity};
        }

        List<Vector2> ret = new List<Vector2>();
        
        List<Vector2> hasMoved = new List<Vector2>();
        
        int[,] boardCopy = copy2DArray(board, height);
        for(int i = 0; i < f.Count; i++)
        {
            if (g[i].x < height.x && g[i].y < height.y && g[i].x >= 0 && g[i].y >= 0)
            {
                if (boardCopy[(int) g[i].x, (int) g[i].y] != -1 && !(hasMoved.Contains(g[i]) || f.Contains(g[i]) ))
                {
                    ret.Add(new Vector2(g[i].x, g[i].y));
                }
                
                boardCopy[(int) g[i].x, (int) g[i].y] = board[(int) f[i].x, (int) f[i].y];
                boardCopy[(int) f[i].x, (int) f[i].y] = -1;
            }
            else
            {
                ret.Add(new Vector2(g[i].x, g[i].y));
            }
            
            hasMoved.Add(g[i]);
        }

        if (ret.Count == 0)
        {
            board = boardCopy;
        }
        
        return ret;
    }
    
    // Method applies a linear transformation to a set of positions
    List<Vector2> applyTransform(List<Vector2> f, Vector2 hk)
    {
        List<Vector2> ret = new List<Vector2>();
        foreach (Vector2 i in f)
        {
            ret.Add(i+hk);
        }

        return ret;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastPiece += Time.deltaTime;
        
        // Move Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (tryTransformation(currentPiece, applyTransform(currentPiece, Vector2.right)))
            {
                print("D on the Move");
                currentPiece = applyTransform(currentPiece, Vector2.right);
            } 
        }
        
        // Move Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (tryTransformation(currentPiece, applyTransform(currentPiece, Vector2.left)))
            {
                print($"A on the Move: {currentPiece.Count}");
                currentPiece = applyTransform(currentPiece, Vector2.left);
            } 
        }

        // Move to bottom
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool flag = false;
            // The next possible movement down
            List<Vector2> down = new List<Vector2>();
            while (!flag)
            {
                
                down.Clear();
                // Calculates moving each block down
                foreach (Vector2 block in currentPiece)
                {
                    down.Add(block + Vector2.down);
                }

                if (tryTransformation(currentPiece, down))
                {
                    currentPiece = down;
                }
                else flag = true;

                // Does transformation and keeps running until can't
                // move down anymore
            } 
            
            spawnNewPiece();
        }
    }

    private void LateUpdate()
    {
        // Plots board array to unity
        plotBoard();
    }
}
