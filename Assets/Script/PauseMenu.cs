using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {


            Time.timeScale = 0f;

            SetActiveAllChildren(this.gameObject, true);
            
        }
        else
        {

            Time.timeScale = 1;

            SetActiveAllChildren(this.gameObject, false);
        }
    }
    public void Settings()
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene("SampleScene");

    }


    void SetActiveAllChildren(GameObject parent, bool isActive)
    {
        foreach (Transform child in parent.transform)
        {
            child.gameObject.SetActive(isActive);
            SetActiveAllChildren(child.gameObject, isActive);
        }
    }


}
