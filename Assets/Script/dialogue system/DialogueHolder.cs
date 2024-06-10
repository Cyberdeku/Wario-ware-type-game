using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        public GameObject buttons;

        private void Awake()
        {
            StartCoroutine(dialogueSequence());
        }


        private IEnumerator dialogueSequence()
        {
            for (int i = 0; i< transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);

                
            }
            //gameObject.SetActive(false);
            buttons.SetActive(true);
        }

        private void Deactivate()
        {
            for (int i = 0 ; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}

