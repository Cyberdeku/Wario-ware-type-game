using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CircleCollisionCheck : MonoBehaviour
{
    public CharacterAttack characterScript;
    public BossAttack enemyScript;
    public Bar healthBar;
    public EnemyBar enemyBar;
    public AudioSource source;
    public AudioClip glideClip;
    public AudioClip collisionClip;
    public AudioClip wrongCollisionClip;
    public AudioMixerGroup SFXMixer;

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
                CollisionSound(collisionClip, "SoundCollision");
                
                enemyBar.Change(-1);
                enemyScript.life--;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("circleDarkE"))
            {
                CollisionSound(wrongCollisionClip, "wrongSoundCollision");
                characterScript.life--;
                healthBar.Change(-1);

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("UFOE"))
            {
                CollisionSound(wrongCollisionClip, "wrongSoundCollision");
                enemyBar.Change(+1);
                Destroy(gameObject);
            }
        }
       
       



        if (gameObject.CompareTag("circleDark"))
        {
            if (collision.gameObject.CompareTag("circleE"))
            {
                CollisionSound(wrongCollisionClip, "wrongSoundCollision");
                characterScript.life--;
                healthBar.Change(-1);
                
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("circleDarkE"))
            {
                CollisionSound(collisionClip, "SoundCollision");
                enemyBar.Change(-1);
                enemyScript.life--;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("UFOE"))
            {
                CollisionSound(wrongCollisionClip, "wrongSoundCollision");
                enemyBar.Change(+1);
                Destroy(gameObject);
            }
        }
        
        if(gameObject.CompareTag("circleE")|| gameObject.CompareTag("circleDarkE"))
        {
            if(collision.gameObject.CompareTag("UFO"))
            {
                //hit sound
                characterScript.life--;
                healthBar.Change(-1);
                Destroy(gameObject) ;
            }
        }


    }
    //instantiate a new object with an audioSource playing the collision clip that destroy itself after 2s
    private void CollisionSound(AudioClip clip,string name)
    {
        float randomNumber = Random.Range(0.8f, 1.2f);
        GameObject soundObject = new GameObject(name);

        AudioSource collisionSource = soundObject.AddComponent<AudioSource>();
        collisionSource.clip = clip;
        collisionSource.pitch = randomNumber;
        collisionSource.volume = 0.5f;
        collisionSource.outputAudioMixerGroup = SFXMixer;
        collisionSource.Play();
        Destroy(soundObject, clip.length +2f);
    }
    }


