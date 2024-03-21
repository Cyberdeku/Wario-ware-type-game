using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    Rigidbody2D rb;

    public float maxvelocity = 15f;


    public float minthrust;
    public float maxthrust;

    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxvelocity);
        float thrust = Random.Range(minthrust, maxthrust);

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    rb.AddForce(Vector2.up * thrust * 2);
        //    rb.AddTorque(thrust + 3);
        //    print(thrust);
        //}


        //TEST EN CHANGEANT KEY DOWN TO KEY POUR TESTER EN HOLD
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * thrust * 2 );
            rb.AddTorque(thrust+3);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * thrust * 2 );
            rb.AddTorque(thrust + 3);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * thrust * 2);
            rb.AddTorque(thrust + 3 );

    
        }

        


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 ballposition = transform.position;
        if (collision.gameObject.name == "hoop" && Vector2.Dot(Vector3.down,ballposition )< 0)
        {

            print("win");
            ps.Play();

        }

    }
}
