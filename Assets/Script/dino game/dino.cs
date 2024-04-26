using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dino : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    DinoScript dinoScript;
    bool isgrounded = false;
    public bool isAlive = true;


    Rigidbody2D _rb;
    BoxCollider2D _boxCollider;


    public float Jumpforce;

    public ParticleSystem ps;

    public AudioClip AudioClip;
    public AudioSource source;

    Vector3 position = new(-10.23f,-3.5f,0f);

    private void Start()
    {

        animator = GetComponent<Animator>();

        //_boxCollider = GetComponent<BoxCollider2D>();




    }


    private void OnEnable()
    {
        _rb.position = position;
        isAlive = true;
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isAlive == false)
        {

            print("idied");
            source.PlayOneShot(AudioClip, 0.1f);

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
        if (collision.gameObject.tag == "rocket")
        {
            animator.SetTrigger("Death");
            ps.Play();
            isAlive = false;
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
            source.PlayOneShot(AudioClip, 1f);
            //Time.timeScale =0.1f;

            Destroy(collision.gameObject);
            StartCoroutine(dinoScript.End());
        }



        if (collision.gameObject.name == "ground")
        {
            if (isgrounded == false)
            {
                isgrounded = true;

            }
        }
    }

}
