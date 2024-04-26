using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReactController : MiniGame
{
    [SerializeField]
    private TextMeshProUGUI gameText;

    [SerializeField]
    SpriteRenderer reactBackground;

    private float reactionTime;
    private float startTime;
    private float randomStart;
    private float enemyReactionTime;

    bool clockIsTicking;
    bool canBeStopped;



    // Start is called before the first frame update
    //void Start()
    //{
    //    reactionTime = 0f;
    //    startTime = 0f;
    //    randomStart = 0f;
    //    gameText.text = " Click to begin";
    //    clockIsTicking = false;
    //    canBeStopped = true;   
    //}

    private void OnEnable()
    {
        reactionTime = 0f;
        startTime = 0f;
        randomStart = 0f;
        gameText.text = " Click to begin";
        clockIsTicking = false;
        canBeStopped = true;
        reactBackground.color = Color.white;
    }

    // Update is called once per frame
    protected override void Update()
    {

        timertext.text = "";
        if(Input.GetMouseButtonDown(0))
        {
            if (!clockIsTicking)
            {
                StartCoroutine(StartMeasuring());
                gameText.text = "Wait for Green";
                reactBackground.color = Color.red;
                clockIsTicking = true;
                canBeStopped=false;
            }
            else if(clockIsTicking && canBeStopped)
            {
                StopCoroutine(StartMeasuring());
                reactionTime = Time.time - startTime;
                gameText.text = "Reaction time : " + reactionTime.ToString("N3") + "sec";
                clockIsTicking=false;
                OnGameOver(true);
            }
            else if (clockIsTicking && !canBeStopped)
            {
                StopCoroutine(StartMeasuring());
                reactionTime = 0f;
                clockIsTicking = false;
                canBeStopped = true;
                gameText.text = "Too Soon";
                reactBackground.color = Color.black;
            }
        }

        if (clockIsTicking && canBeStopped)
        {
            enemyReactionTime = Time.time - startTime;
        }
        if (enemyReactionTime >5f)
        {
            print("took to long u ded");
            OnGameOver(false);
        }
        
    }


    IEnumerator StartMeasuring()
    {
        randomStart = Random.Range(0.7f, 6f);
        yield return new WaitForSeconds(randomStart);
        reactBackground.color = Color.green;
        startTime = Time.time;
        clockIsTicking=true;
        canBeStopped = true;
        

    }
}
