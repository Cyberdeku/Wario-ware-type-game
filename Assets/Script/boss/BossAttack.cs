using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject whiteCircleCollider;
    public GameObject darkCircleCollider;
    public Animator animator;

    public float shootDelay = 0.5f;
    private float nextShot = 0.15f;

    public int life;

    public Transform position;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        float shootDelays = Random.Range(0.7f, 2f);
        if(Time.time > nextShot)
        {
            Attack();
            //animator.SetTrigger("attack");
            nextShot = Time.time + shootDelays;
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
            Instantiate(whiteCircleCollider, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(darkCircleCollider, transform.position, Quaternion.identity);
        }

        int randomposition = Random.Range(0, 3);

        switch (randomposition)
        {
            case 0:
                transform.position = new Vector3(0,0,0);
                break;
            case 1:
                transform.position = new Vector3(10, 1, 1);
                break;
            case 2:
                transform.position = new Vector3(2, 20, 2);
                break;


        }

    }

}
