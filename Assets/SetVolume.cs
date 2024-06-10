using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider SFXSlider;

    public void Start()
    {
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            LoadLevel();
        }
        else
        {
            SetLevel();
        }
        
    }
    public void SetLevel()
    {
        float sliderValue = musicSlider.value;
        mixer.SetFloat("MusicVol",Mathf.Log10 (sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVol",sliderValue);
    }

    public void SetSFXLevel()
    {
        float sliderValue = SFXSlider.value;
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVol", sliderValue);
    }

    private void LoadLevel()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVol");

        SetLevel();
        SetSFXLevel();
    }
}
