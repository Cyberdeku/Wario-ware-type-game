using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitch : MonoBehaviour
{

    AudioSource audioSource;

    private void Awake()
    { 
        audioSource = GetComponent<AudioSource>();  
    }
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
