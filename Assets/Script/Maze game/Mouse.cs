using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] MouseScript mouseScript;
    Vector2 Move;

    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip movementClip;
    [SerializeField] AudioClip nibbleClip;
    Vector3 position = new(21f, 4f, 0f);
    private void OnEnable()
    {
        transform.localPosition = position;
    }
    private void Update()
    {
        GetInputs();


        //rotation
        if (Move != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, Move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        float random = Random.Range(0.7f, 1.3f);
        Moving();

        if (Move != Vector2.zero)
        {
            audioSource.enabled = true;
            audioSource.pitch = random; 
        }
        else
        {
            audioSource.enabled = false;
        }
    }


    private void GetInputs()
    {
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");

        Move = new Vector2(movex, movey).normalized;
    }

    private void Moving()
    {
        _rb.velocity = new Vector2(Move.x * speed, Move.y * speed);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "cheese")
        {
            audioSource.PlayOneShot(nibbleClip);
            StartCoroutine(mouseScript.Win()); 
        }


    }


}
