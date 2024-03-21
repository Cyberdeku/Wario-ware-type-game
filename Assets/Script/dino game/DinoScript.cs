using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DinoScript : MonoBehaviour
{
    public Animator animator;


    bool isgrounded = false;
    public bool isAlive = true;


    Rigidbody2D _rb;
    BoxCollider2D _boxCollider;


    public float Jumpforce;


    public AudioClip AudioClip;
    public AudioSource source;


     

    private void Start()
    {

        animator = GetComponent<Animator>();

        //_boxCollider = GetComponent<BoxCollider2D>();



        
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isAlive == false )
        {

            //print("idied");
            //source.PlayOneShot(AudioClip, 0.1f);

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                if (isgrounded == true)
                {
                    _rb.AddForce(Vector2.up * Jumpforce);
                    isgrounded = false;

                    animator.SetBool("crouch", false);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                if (isgrounded == false)
                {
                    _rb.AddForce(Vector2.down * Jumpforce * 2);


                }

                animator.SetBool("crouch", true);



            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                animator.SetBool("crouch", false);
            }

        }
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "rocket")
        {
            animator.SetTrigger("Death");
            isAlive = false;
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
            source.PlayOneShot(AudioClip,1f);
            Time.timeScale =0.1f;

            Destroy(collision.gameObject);
        }



        if(collision.gameObject.name =="ground")
        {
            if(isgrounded ==false)
            {
                isgrounded = true;
                
            }
        }
    }
}
