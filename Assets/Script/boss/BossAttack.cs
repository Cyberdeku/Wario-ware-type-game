using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BossAttack : MonoBehaviour
{
    public GameObject whiteCircleCollider;
    public GameObject darkCircleCollider;
    public Animator animator;

    private float nextShot = 0.15f;
    public float minShotDelay;
    public float maxShotDelay;
    public int life;

    public Transform position;
    public TextMeshProUGUI textWin;
    public bool defeated;
    public BossAttack bossAttack;
    private Transform enemyCircleContainer;
    public CharacterAttack characterAttack;

    private void OnEnable()
    {
        //animator = GetComponent<Animator>();
        defeated = false;
        enemyCircleContainer = (new GameObject("enemyCircleContainer")).transform;
    }
    void FixedUpdate()
    {
        float shootDelays = Random.Range(minShotDelay, maxShotDelay);
        if(Time.time > nextShot)
        {
            Attack();
            //animator.SetTrigger("attack");
            nextShot = Time.time + shootDelays;
        }

        if(life <= 0 && defeated == false)
        {
            defeated = true;
            GameEnded();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("circle") || collision.gameObject.CompareTag("circleDark"))
        {
            //animator.SetTrigger("death");
            Destroy(this);
        }
    }

    void Attack()
    {
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 0)
        {
            GameObject CircleIns = Instantiate(whiteCircleCollider, transform.position, Quaternion.identity, enemyCircleContainer);
        }
        else
        {
            GameObject CircleIns = Instantiate(darkCircleCollider, transform.position, Quaternion.identity, enemyCircleContainer);
        }

        int randomposition = Random.Range(0, 2);

        switch (randomposition)
        {
            case 0:
                transform.localPosition= new Vector3(-6.5f,-2f,0);
                break;
            case 1:
                transform.localPosition = new Vector3(6.5f,-2f, 0);
                break;




        }

    }
    public void GameEnded()
    {
        position.localPosition = new Vector3(0, -2, 0);

        Destroy(enemyCircleContainer.gameObject);
        Destroy(characterAttack.characterCircleContainer.gameObject);
        bossAttack.enabled = false;
        characterAttack.enabled = false;
    }
}
