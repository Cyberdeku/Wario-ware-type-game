using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootDrops : MonoBehaviour
{
    public Transform dropSpawnPoint;
    public GameObject dropPrefab;
    public float dropSpeed = 10f;
    [SerializeField]
    float Gravity = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var drop = Instantiate(dropPrefab,dropSpawnPoint.position,dropSpawnPoint.rotation);
            drop.GetComponent<Rigidbody2D>().velocity = dropSpawnPoint.up * dropSpeed * Gravity;
        }
    }
}
