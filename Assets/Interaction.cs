using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public KeyCode initiator;

    public Func<bool> action;

    public bool showPrompt;
}
