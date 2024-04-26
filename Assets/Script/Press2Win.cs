using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Press2Win : MiniGame
{

    MiniGame miniGame;
    [Header("UI")]
    public TextMeshProUGUI textwin;


    //public TextMeshProUGUI timertext;
    //private bool timeractive = true;
    //private float timer = 5f;

    [Header("Inputs")]
    public KeyCode inputwin = KeyCode.F;


    private void OnEnable()
    {
        
        timeractive = true;
        textwin.text = "Press " + inputwin;
        timer = 5f;
    }
    // Update is called once per frame

    protected override void Update()
    {
        base.Update();

        //if (timeractive)
        //{
        //    timer = timer - Time.deltaTime;
        //}
        //TimeSpan time = TimeSpan.FromSeconds(timer);
        //timertext.text = time.ToString(@"mm\:ss\:fff");





        //if (timer <= 0)
        //{

        //    timeractive = false;
        //    timer = 0;
        //    OnGameOver(false);
        //}

        if (Input.GetKeyDown(inputwin))
        {
            textwin.text = "Win";
            timeractive = false;
            OnGameOver(true);
        }
    }


}
