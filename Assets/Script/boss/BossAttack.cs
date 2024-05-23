using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject whiteCircleCollider;
    public GameObject darkCircleCollider;
    public Animator animator;

    // Update is called once per frame

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {



        int randomNumber = Random.Range(0, 10000);
        if(randomNumber > 9900)
        {
            Attack();
            //animator.SetBool("attack", true);
            animator.SetTrigger("attack");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("circle") || collision.gameObject.CompareTag("circleDark"))
        {
            animator.SetTrigger("death");
            Destroy(this);
        }
    }

    void Attack()
    {
        Instantiate(whiteCircleCollider, transform.position, Quaternion.identity);

    }

}
