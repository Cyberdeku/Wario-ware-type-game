using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource source;
    public AudioClip[] sounds;

    private void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();

    }

    public void PlaySound(AudioClip sound)
    {
        int randomClip = Random.Range(0,sounds.Length);
        source.clip = sounds[randomClip];
        float randomPitch = Random.Range(0.8f, 1.2f);
        source.pitch = randomPitch;
        source.PlayOneShot(sound);
    }

}
