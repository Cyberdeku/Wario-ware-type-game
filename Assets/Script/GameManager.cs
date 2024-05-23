using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image lifeImage;

    public List<MiniGame> gameList;
    private MiniGame currentGame;
    private ObstacleGenerator obstacleGenerator;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI lifetext;
    public int score = 0;
    [SerializeField]
    int life = 3;
    float basetimer = 10f;
    int index;

    public Canvas deathScreen;
    public GameObject psVita;

    private void Start()
    {
        gameList.Shuffle();

        currentGame = gameList[index];
        foreach(MiniGame game in gameList)
        {
            print(game.name);
            game.GameOver += switchGame /*(win) => StartCoroutine(WaitSwitch(win))*/;
            
        }
        currentGame.gameObject.SetActive(true);
    }

    private void Update()
    {
        lifeImage.fillAmount = life / 3f;

        scoretext.text = score.ToString();
        lifetext.text = life.ToString();

        if(life <= 0 )
        {

            deathScreen.gameObject.SetActive(true);
            psVita.SetActive(false);
        }


    }
    private void switchGame(bool win)
    {

        if (win)
        {
            score++;

            print("win");
            print("nextgame");
        }
        else
        {
            life--;
            print("-1 life");
            print("nextgame");
        }



        print("index = "+index);

        currentGame.gameObject.SetActive(false);
        //index = ++index % gameList.Count;
        index++;
        if ( index >= gameList.Count )
        {
            index = 0;
            gameList.Shuffle();
        }
        currentGame = gameList[index];
        currentGame.gameObject.SetActive(true);

        print("index = " + index);

        currentGame.timer = basetimer - (score/10);

    }
    IEnumerator WaitSwitch(bool win)
    {
        print("I wait");
        yield return new WaitForSeconds(0.5f);
        print("I waited");
        switchGame(win);

    }

}
