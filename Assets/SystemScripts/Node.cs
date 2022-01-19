using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private List<Node> connections;
    public int difficulty;
    public int typeOfCypher;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    
    // Make this only return n amount, or even blur some of the connections based on strength
    List<Node> reverseEngineer(int strength)
    {
        return connections;
    }
    
    // Have this open up the puzzle required to solve the connection
    void startCypher()
    {
        
    }
    
    // Have this return a list of nodes ordered based on the difficulty of puzzles and vary in accuracy based on the strength
    public static List<Node> sniff(int strength, List<Node> nodes)
    {
        return nodes;
    }
}
