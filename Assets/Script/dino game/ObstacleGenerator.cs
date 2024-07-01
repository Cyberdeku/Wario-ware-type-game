using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject rocket;

    public Transform rocketContainer;
    public float minspeed;
    public float maxspeed;
    public float currentspeed;
    public float SpeedMultiplier;
    
    
    private void OnEnable()
    {
        rocketContainer = (new GameObject("rocketContainer")).transform;
        currentspeed = minspeed + gameManager.score / 2;
        
        GenerateObstacle();
    }
    private void OnDisable()
    {
        Destroy(rocketContainer.gameObject);
    }

    public void GenerateObstacleDelay()
    {
        float SpawnWait = Random.Range(0.1f, 0.5f);
        Invoke("GenerateObstacle", SpawnWait);

    }

    public void GenerateObstacle()
    {
        int randomNumber = Random.Range(0, 6);
        if(randomNumber > 3)
        {
            GameObject ObstacleIns = Instantiate(rocket, transform.position + new Vector3(0f, 1.5f, 0f), transform.rotation, rocketContainer);
            ObstacleIns.GetComponent<Obstacle>().obstaclegenerator = this;

        }
        else
        {
            GameObject ObstacleIns = Instantiate(rocket, transform.position, transform.rotation, rocketContainer);
            ObstacleIns.GetComponent<Obstacle>().obstaclegenerator = this;
        }



        
    }


    private void Update()
    {

        if (currentspeed < maxspeed) 
        {
            currentspeed = currentspeed + SpeedMultiplier;
        }
        if (currentspeed > maxspeed)
        {
            currentspeed = maxspeed;
        }
    }
}
