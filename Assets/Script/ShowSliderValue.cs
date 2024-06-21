using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShowSliderValue : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI percentageText;
    // Start is called before the first frame update
    private void Start()
    {
        textUpdate(slider.value);
        slider.onValueChanged.AddListener(textUpdate);
        //play audio of the type modified to know the change
    }
    // Update is called once per frame
    void textUpdate(float value)
    {
        percentageText.text = value.ToString("0.00");
    }
}
