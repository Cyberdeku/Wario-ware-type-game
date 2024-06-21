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

    private const string MusicVolKey = "MusicVol";
    private const string SFXVolKey = "SFXVol";

    void Start()
    {
        LoadVolume(MusicVolKey, musicSlider, ApplyMusicVolume);
        LoadVolume(SFXVolKey, SFXSlider, ApplySFXVolume);
    }

    public void ApplyMusicVolume()
    {
        ApplyVolume(MusicVolKey, musicSlider.value, "MusicVol");
    }

    public void ApplySFXVolume()
    {
        ApplyVolume(SFXVolKey, SFXSlider.value, "SFXVol");
    }

    private void LoadVolume(string key, Slider slider, System.Action applyVolumeAction)
    {
        if (PlayerPrefs.HasKey(key))
        {
            slider.value = PlayerPrefs.GetFloat(key);
            applyVolumeAction.Invoke();
        }
        else
        {
            slider.value = 1.0f; // Default value if no PlayerPrefs found
            PlayerPrefs.SetFloat(key, slider.value);
            applyVolumeAction.Invoke();
        }
    }

    private void ApplyVolume(string key, float value, string mixerParameter)
    {
        mixer.SetFloat(mixerParameter, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(key, value);
    }
}