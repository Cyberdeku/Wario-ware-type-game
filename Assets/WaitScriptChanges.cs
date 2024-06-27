using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitScriptChanges : MonoBehaviour
{

    public GameObject Background;
    public GameObject Robot;
    public GameObject UI;
    public GameObject Console;
    public GameObject Games;

    public TextMeshProUGUI countdownTextField;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingSlices());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadingSlices()
    {
        yield return new WaitForSeconds(.5f);
        Background.SetActive(true);
        yield return new WaitForSeconds(.3f);
        Robot.SetActive(true);
        yield return new WaitForSeconds(.3f);
        UI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Console.SetActive(true);


        countdownTextField.text = "3";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "2";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "1";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "Go!";
        // start the game here
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "";
        Games.SetActive(true);
        
    }
}
