using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class testaudio : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    // Start is called before the first frame update

    private void Start()
    {
        test();
    }
    void test()
    {
        float randomStart = Random.Range(0.7f, 500f);
        float audioLength = audioClip.length;
        float audioStart = audioLength - randomStart;
        audioSource.time = audioStart;
        print(randomStart +" "+  audioLength +" " +audioStart);

        audioSource.PlayOneShot(audioClip);
    }


    //when to play the end sound :
    //
    //when to start = length of audio - variable of start
}
