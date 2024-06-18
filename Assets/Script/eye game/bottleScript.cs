using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleScript : MonoBehaviour
{
    public Transform dropSpawnPoint;
    public GameObject dropPrefab;
    public float dropSpeed = 10f;

    public float moveSpeed =  5f;
    public bool hold =false ;
    public Animator animator;
    public bool shoot = false ;
    public float life;
    public EyeManager eyeManager;
    public SpriteRenderer spriteRenderer;


    private void OnEnable()
    {
        spriteRenderer.color = Color.white;
        moveSpeed = 5f;
        life = 1f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        #region Movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.fixedDeltaTime* moveSpeed;
        #endregion

        #region Shoot
        if (Input.GetKey(KeyCode.Space))
        {
            hold = true;
        }
        
        else /*if (Input.GetKeyUp(KeyCode.Space))*/
        {
            hold = false;
        }


        if(hold==true)
        {
            animator.SetBool("hold", true);
        }
        else
        {
            animator.SetBool("hold", false);
        }
        if (shoot ==true)
        {
            Shoot();
            shoot = false;
        }

        #endregion

        if (life <= 0)
        {
            spriteRenderer.color = new Color(1,0,0,0.8f);
            moveSpeed = 0f;
            StartCoroutine(eyeManager.Dead());
        }
    }

    void Shoot()
    {
        var drop = Instantiate(dropPrefab, dropSpawnPoint.position, dropSpawnPoint.rotation);
        drop.GetComponent<Rigidbody2D>().velocity = dropSpawnPoint.up * dropSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bloodDrop")
        {
            life--;
        }

    }
}
