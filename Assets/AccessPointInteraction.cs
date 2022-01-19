using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccessPointInteraction : Interaction
{
    // Start is called before the first frame update
    void Start()
    {
        initiator = KeyCode.F;
        action = Action;
        showPrompt = true;
    }

    bool Action()
    {
        SceneManager.LoadScene("AccessPointUI");
        return true;
    }
}
