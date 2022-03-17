using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPointScript : MonoBehaviour
{
    private GameObject player;
    
    public float interactionDistance = 5f;

    public Interaction _interaction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player");
        InvokeRepeating(nameof(CheckDistance), .05f, .05f);
    }

    void CheckDistance()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < interactionDistance)
        {
            if (!UserManager.canInteractWith.Contains(_interaction))
            {
                UserManager.canInteractWith.Add(_interaction);
            }
        }
        else
        {
            if (UserManager.canInteractWith.Contains(_interaction))
            {
                UserManager.canInteractWith.Remove(_interaction);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
