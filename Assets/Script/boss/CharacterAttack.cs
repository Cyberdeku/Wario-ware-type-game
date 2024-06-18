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
    private void Update()
    {
        if(life <= 0)
        {
            textlose.text = "LOSE <br> press escape to quit";
            //lose so back to menu
        }
        if (Input.GetMouseButtonDown(0) && Time.time > nextShot)
        {
            Instantiate(whiteCircleprefab, transform.position, Quaternion.identity);
            nextShot = Time.time+shootDelay;
        }

        if (Input.GetMouseButtonDown(1) && Time.time > nextShot)
        {
            Instantiate(darkCircleprefab, transform.position, Quaternion.identity);
            nextShot = Time.time + shootDelay;
        }

    }


}
