using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathButton : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    
}
