using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGame : MonoBehaviour
{

    GameManager gameManager;
    [Header("UI")]
    public TextMeshProUGUI timertext;
    public bool timeractive = true;
    public float timer = 10f;

    public event Action<bool> GameOver;

    protected void OnGameOver(bool win)
    {
        GameOver?.Invoke(win);
        timeractive = true;
    }

    protected virtual void Update()
    {
        Timer();

    }



    protected virtual void Timer()
    {

        if (timeractive)
        {
            timer = timer - Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(timer);
        timertext.text = time.ToString(@"mm\:ss\:fff");





        if (timer <= 0)
        {
            timeractive = false;
            timertext.text = "00:00:000";
            timer = 0;
            Outcome();
        }
    }
    protected virtual void Outcome()
    {
        OnGameOver(false);
    }
}

