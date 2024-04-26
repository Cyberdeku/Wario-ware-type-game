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

    Vector3 position = new(1.776f, -1.926f, 0f);
    private void OnEnable()
    {
        _rb.position = position;
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

        //Move = Vector2.zero;
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    Move = Vector2.up;
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    Move = Vector2.down;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Move = Vector2.left;
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    Move = Vector2.right;
        //}

        //_rb.velocity = Move * speed;

        Moving();

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
            print("win");
            StartCoroutine(mouseScript.Death());
            
        }
        else
        {
            print("not a cheese win");
        }

    }


}
