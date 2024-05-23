using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollisionCheck : MonoBehaviour
{


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("test");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("circle"))
        {
            if (collision.gameObject.CompareTag("circleE"))
            {
                print("did it");
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        else if (gameObject.CompareTag("circle"))
        {
            if (collision.gameObject.CompareTag("circleDark"))
            {
                print("wrong color");
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }



        if (gameObject.CompareTag("circleDark"))
        {
            if (collision.gameObject.CompareTag("circleE"))
            {
                print("wrong color");
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        else if (gameObject.CompareTag("circleDark"))
        {
            if (collision.gameObject.CompareTag("circleDarkE"))
            {
                print("did it");
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }


    }

    }


