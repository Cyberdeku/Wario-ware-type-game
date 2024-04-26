using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DinoScript : MiniGame
{

    protected override void Outcome()
    {
        OnGameOver(true);
    }
    public IEnumerator End()
    {
        yield return null;
        OnGameOver(false);
    }

}
