using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseScript : MiniGame
{
    public ParticleSystem ps;
    public IEnumerator Death()
    {
        //mouse.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ps.Play();
        print("death");
        yield return null;
        OnGameOver(true);
    }
}