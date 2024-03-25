using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseScript : MonoBehaviour
{
    [SerializeField]Rigidbody2D _rb;

    Vector2 Move;

    [SerializeField] float speed;

    private void Update()
    {
        GetInputs();
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

        Move = new Vector2(movex,movey).normalized;
    }

    private void Moving()
    {
        _rb.velocity = new Vector2(Move.x * speed,Move.y* speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.name == "cheese")
        {
            print("win");
        }
        else
        {
            print("not a cheese win");
        }
       
    }
}