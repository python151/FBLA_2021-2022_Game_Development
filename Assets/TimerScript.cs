using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public static int timeInSec = 0;

    public static int maxTime = 5 * 60;

    public TextMeshProUGUI _textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshProUGUI = transform.GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(addSec), 0f, 1f);
    }

    void addSec()
    {
        timeInSec++;
        
        string seconds = String.Format("{0:00}", (maxTime - timeInSec) %60);
        // This just updates the text display using the above value for the displayed seconds
        _textMeshProUGUI.text = $"{Mathf.Floor((maxTime - timeInSec)/60)}:{seconds}";

        if (timeInSec >= maxTime)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
