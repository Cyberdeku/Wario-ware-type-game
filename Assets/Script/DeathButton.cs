using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathButton : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;

    }

    public void Dialogue()
    {
        SceneManager.LoadScene("Dialogue");
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1.0f;

    }

    
}
