using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManager : MiniGame
{
    public IEnumerator Dead()
    {
        
        yield return new WaitForSeconds(5f);
        print("win");
        OnGameOver(true);
    }
}
