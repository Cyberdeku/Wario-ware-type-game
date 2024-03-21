using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public ObstacleGenerator obstaclegenerator;
    public DinoScript dinoScript;
    void Update()
    {
        transform.Translate(Vector2.left * obstaclegenerator.currentspeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.gameObject.name == "SpawnPoint")
        {
            obstaclegenerator.GenerateObstacleDelay();

        }


        if (collision.gameObject.name == "DestroyPoint")
        {


            Destroy(this.gameObject);
        }
    }


}
