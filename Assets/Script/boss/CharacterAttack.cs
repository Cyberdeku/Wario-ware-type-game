using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class CharacterAttack : MonoBehaviour
{
    public GameObject whiteCircleprefab;
    public GameObject darkCircleprefab;


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(whiteCircleprefab,transform.position,Quaternion.identity);

        }

        if(Input.GetMouseButtonDown(1)) 
        {
            Instantiate(darkCircleprefab,transform.position,Quaternion.identity);
        }

    }



}
