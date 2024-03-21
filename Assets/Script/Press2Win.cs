using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Press2Win : MonoBehaviour
{

    [Header("UI")]
    public TextMeshProUGUI textwin;


    public TextMeshProUGUI timertext;
    private bool timeractive = true;
    private float timer = 5f;

    public bool outcome; //true = win false = lose
    [Header("Inputs")]
    public KeyCode inputwin = KeyCode.F;

    private void Start()
    {
        timeractive = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (timeractive)
        {
            timer = timer - Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(timer);
        timertext.text = time.ToString(@"mm\:ss\:fff");

        if (Input.GetKeyDown(inputwin))
        {
            textwin.text = "Win";
            timeractive = false;

        }



        if (timer <= 0)
        {
            textwin.text = "Lose";

            timeractive = false;
            timer = 0;
        }
    }


    //void GameEnded()
    //{
    //    OpenScene.SetActive(true);
    //    CloseScene.SetActive(false);
    //}
}
