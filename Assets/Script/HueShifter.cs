using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HueShifter : MonoBehaviour
{
    float m_Hue;
    float m_Saturation;
    float m_Value;

    float Speed = 1;    

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = Color.HSVToRGB(.34f, .87f, .65f);
    }

    // Update is called once per frame
    void Update()
    {
        float h, s, v;
        Color.RGBToHSV(spriteRenderer.material.color, out h, out s, out v);


        spriteRenderer.material.color = Color.HSVToRGB(h + Time.deltaTime * .5f, s, v);


        //spriteRenderer.material.SetColor("_Color", .ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));

        //spriteRenderer.material.color = Color.HSVToRGB(m_Hue, m_Saturation, m_Value);
    }
}
