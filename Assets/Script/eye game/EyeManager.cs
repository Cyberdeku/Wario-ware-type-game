using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManager : MiniGame
{
    public IEnumerator Win()
    {
        
        yield return new WaitForSeconds(1.2f);
        print("win");
        OnGameOver(true);
    }
    public IEnumerator Dead()
    {

        yield return new WaitForSeconds(1.2f);
        print("lose");
        OnGameOver(false);
    }
}
