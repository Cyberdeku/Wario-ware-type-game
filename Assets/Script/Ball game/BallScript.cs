using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MiniGame
{
    public ParticleSystem ps;
    public AudioClip clip;
    public AudioSource source;
    public IEnumerator Goal()
    {
        source.PlayOneShot(clip, 1f);
         ps.Play();
        yield return new WaitForSeconds(1f);
        //print("win");
        OnGameOver(true);
    }
}
