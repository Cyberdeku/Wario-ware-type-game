using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathButton : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void Quit()
    {
        Application.Quit();
    }
}
