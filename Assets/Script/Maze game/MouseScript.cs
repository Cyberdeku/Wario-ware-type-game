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
    [SerializeField] float rotateSpeed;

    public ParticleSystem ps;
    private void Update()
    {
        GetInputs();


        //rotation
        if (Move != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward,Move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotation,rotateSpeed * Time.deltaTime);
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
            StartCoroutine(Death());
        }
        else
        {
            print("not a cheese win");
        }
       
    }


    IEnumerator Death()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ps.Play();
        print("death");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        
    }
}