using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;
        [SerializeField] private string input;

        [SerializeField] private float delay;

        //[SerializeField] private float delayBetweenLines;
        [SerializeField] private AudioClip sound;

        private IEnumerator lineAppear;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                if (textHolder.text != input)
                {
                    StopCoroutine(lineAppear);
                    textHolder.text = input;
                }
                else
                    finished = true;
            }
        }



        private void Awake()
        {
            textHolder = GetComponent<TextMeshProUGUI>();


        }

        private void Start()
        {
            lineAppear = WriteText(input, textHolder, delay, sound/*,delayBetweenLines*/);

            StartCoroutine(lineAppear);
            //StartCoroutine(WriteText(input, textHolder, delay, sound/*,delayBetweenLines*/));
        }

    }
}

