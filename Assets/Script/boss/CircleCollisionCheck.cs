using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollisionCheck : MonoBehaviour
{
    public CharacterAttack characterScript;
    public BossAttack enemyScript;
    public Bar healthBar;
    public EnemyBar enemyBar;

    private void Start()
    {
        enemyBar= FindObjectOfType<EnemyBar>();
        healthBar = FindObjectOfType<Bar>();
        characterScript = FindObjectOfType<CharacterAttack>();
        enemyScript = FindObjectOfType<BossAttack>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("circle"))
        {
            if (collision.gameObject.CompareTag("circleE"))
            {
                enemyBar.Change(-1);
                enemyScript.life--;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("circleDarkE"))
            {
                characterScript.life--;
                healthBar.Change(-1);

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
       
       



        if (gameObject.CompareTag("circleDark"))
        {
            if (collision.gameObject.CompareTag("circleE"))
            {
                characterScript.life--;
                healthBar.Change(-1);
                
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("circleDarkE"))
            {
                enemyBar.Change(-1);
                enemyScript.life--;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        


    }

    }


