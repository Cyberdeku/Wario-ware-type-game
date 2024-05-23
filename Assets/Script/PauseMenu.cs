using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public Image image;
    public TextMeshProUGUI text;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            image.enabled = true;
            text.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            image.enabled = false;
            text.enabled = false;
        }
    }
}
