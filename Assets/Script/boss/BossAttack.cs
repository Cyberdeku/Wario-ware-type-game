using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private void Start()
    {
        //animator = GetComponent<Animator>();
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

        if(life <= 0)
        {
            textWin.text = "WIN <br> press escape to quit";
            //End game and winning sequence
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

}
