using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossLevelAttack : MonoBehaviour
{
    private Vector3 scaleChange;
    public GameObject circle;

    private void Start()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
    }
    private void Update()
    {
        


        if (Input.GetMouseButtonDown(0))
        {


            Instantiate(circle);
            circle.transform.localScale += scaleChange;

        }
    }
}
