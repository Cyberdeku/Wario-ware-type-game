using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Circle : MonoBehaviour
{
    public int segments;
    public float radius;
    LineRenderer line;


    private void Awake()
    {
        Destroy(gameObject, /*11.5*/40f);
    }
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;
        CreatePoints();

    }



    private void Update()
    {
        changeScale(0.0005f);
    }

    void CreatePoints()
    {
        float x;
        float y;
        float z = -1f;

        float angle = 0f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle);
            y = Mathf.Cos(Mathf.Deg2Rad * angle);
            line.SetPosition(i, new Vector3(x, y, z) * radius);
            angle += (360f / segments);

        }
    }


    void changeScale(float scaleChange)
    {
        if(Time.timeScale == 1)
        {
            Vector3 change = new Vector3(scaleChange, scaleChange, scaleChange);
            transform.localScale += change;
        }


    }

}