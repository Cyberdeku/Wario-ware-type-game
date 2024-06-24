
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

    //// Array of possible KeyCodes
    //private KeyCode[] possibleKeys = {
    //    KeyCode.Ampersand, KeyCode.DoubleQuote, KeyCode.Hash,
    //    KeyCode.Percent, KeyCode.Asterisk,
    //    KeyCode.Exclaim, KeyCode.Question, KeyCode.Dollar,
    //    KeyCode.Plus, KeyCode.Equals, KeyCode.Minus,
    //    KeyCode.Underscore, KeyCode.Caret, KeyCode.At

    //};

    private KeyCode[] possibleKeys = {
        KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E,
        KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J,
        KeyCode.K, KeyCode.L, KeyCode.N, KeyCode.O,
        KeyCode.P, KeyCode.R, KeyCode.S, KeyCode.T,
        KeyCode.U, KeyCode.V, KeyCode.X, KeyCode.Y,
    };

    // The randomly chosen KeyCode
    private KeyCode inputwin;

    private void OnEnable()
    {
        timeractive = true;

        // Choose a random KeyCode from possibleKeys
        inputwin = possibleKeys[UnityEngine.Random.Range(0, possibleKeys.Length)];

        //textwin.text = "Press " + KeyCodeToString(inputwin);
        textwin.text = "Press " + inputwin.ToString();
        //timer = 10f;
    }

    protected override void Update()
    {
        base.Update();
        if (timer <= 0)
        {

            timeractive = false;
            timer = 0;
            OnGameOver(false);
        }

        if (Input.GetKeyDown(inputwin))
        {
            textwin.text = "Win";
            timeractive = false;
            OnGameOver(true);
        }
    }

    //// Helper function to convert KeyCode to string for display
    //private string KeyCodeToString(KeyCode key)
    //{
    //    switch (key)
    //    {
    //        case KeyCode.Ampersand: return "&";
    //        case KeyCode.DoubleQuote: return "\"";
    //        case KeyCode.Hash: return "#";
    //        case KeyCode.Percent: return "%";
    //        case KeyCode.Asterisk: return "*";
    //        case KeyCode.Exclaim: return "!";
    //        case KeyCode.Question: return "?";
    //        case KeyCode.Dollar: return "$";
    //        case KeyCode.Plus: return "+";
    //        case KeyCode.Equals: return "=";
    //        case KeyCode.Minus: return "-";
    //        case KeyCode.Underscore: return "_";
    //        case KeyCode.At: return "@";
    //        default: return key.ToString(); // Fallback if not found
    //    }
    //}
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using System;

//public class Press2Win : MiniGame
//{

//    MiniGame miniGame;
//    [Header("UI")]
//    public TextMeshProUGUI textwin;


//    //public TextMeshProUGUI timertext;
//    //private bool timeractive = true;
//    //private float timer = 5f;

//    [Header("Inputs")]
//    public KeyCode inputwin = KeyCode.F;


//    private void OnEnable()
//    {

//        timeractive = true;
//        textwin.text = "Press " + inputwin;
//        timer = 5f;
//    }
//    // Update is called once per frame

//    protected override void Update()
//    {
//        base.Update();

//        //if (timeractive)
//        //{
//        //    timer = timer - Time.deltaTime;
//        //}
//        //TimeSpan time = TimeSpan.FromSeconds(timer);
//        //timertext.text = time.ToString(@"mm\:ss\:fff");





//        //if (timer <= 0)
//        //{

//        //    timeractive = false;
//        //    timer = 0;
//        //    OnGameOver(false);
//        //}

//        if (Input.GetKeyDown(inputwin))
//        {
//            textwin.text = "Win";
//            timeractive = false;
//            OnGameOver(true);
//        }
//    }


//}