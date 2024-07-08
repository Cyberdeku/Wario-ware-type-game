using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollisionCheck : MonoBehaviour
{
    public CharacterAttack characterScript;
    public BossAttack enemyScript;
    public Bar healthBar;
    public EnemyBar enemyBar;
    public AudioSource source;
    public AudioClip glideClip;
    public AudioClip collisionClip;

    private void Start()
    {
        source.PlayOneShot(glideClip);
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
                CollisionSound();
                //instantiate a new object with an audioSource playing the collision clip that destroy itself after 2s
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
            else if (collision.gameObject.CompareTag("UFOE"))
            {
                enemyBar.Change(+1);
                Destroy(gameObject);
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
                CollisionSound();
                //instantiate a new object with an audioSource playing the collision clip that destroy itself after 2s
                enemyBar.Change(-1);
                enemyScript.life--;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("UFOE"))
            {
                enemyBar.Change(+1);
                Destroy(gameObject);
            }
        }
        
        if(gameObject.CompareTag("circleE")|| gameObject.CompareTag("circleDarkE"))
        {
            if(collision.gameObject.CompareTag("UFO"))
            {
                characterScript.life--;
                healthBar.Change(-1);
                Destroy(gameObject) ;
            }
        }


    }
    private void CollisionSound()
    {
        float randomNumber = Random.Range(0.6f, 1.2f);
        GameObject soundObject = new GameObject("SoundCollision");

        AudioSource collisionSource = soundObject.AddComponent<AudioSource>();
        collisionSource.clip = collisionClip;
        collisionSource.pitch = randomNumber;
        collisionSource.volume = 0.4f;
        collisionSource.Play();
        Destroy(soundObject, collisionClip.length +2f);
    }
    }


