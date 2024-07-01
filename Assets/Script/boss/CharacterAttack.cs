using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class CharacterAttack : MonoBehaviour
{

    public int life;
    public GameObject whiteCircleprefab;
    public GameObject darkCircleprefab;

    public float shootDelay = 0.5f;
    private float nextShot = 0.15f;
    public TextMeshProUGUI textlose;
    public Transform characterCircleContainer;
    public GameManager gameManager;
    public BossAttack bossAttack;
    private void OnEnable()
    {
        characterCircleContainer= (new GameObject("characterCircleContainer")).transform;
    }


    private void Update()
    {
        if(life <= 0)
        {
            bossAttack.GameEnded();
            StartCoroutine(gameManager.Death());
            
        }
        if (Input.GetMouseButtonDown(0) && Time.time > nextShot)
        {
            GameObject CircleIns = Instantiate(whiteCircleprefab, transform.position, Quaternion.identity,characterCircleContainer);
            nextShot = Time.time+shootDelay;
        }

        if (Input.GetMouseButtonDown(1) && Time.time > nextShot)
        {
            GameObject CircleIns = Instantiate(darkCircleprefab, transform.position, Quaternion.identity,characterCircleContainer);
            nextShot = Time.time + shootDelay;
        }

    }


}
