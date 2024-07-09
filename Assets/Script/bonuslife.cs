using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonuslife : MonoBehaviour
{
    private GameManager gameManager;
    private void OnEnable()
    {
        gameManager = GetComponent<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.life++;
        print("+life");
    }
}
