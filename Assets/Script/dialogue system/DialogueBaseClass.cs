using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; protected set; }
        public IEnumerator WriteText(string input, TextMeshProUGUI TextHolder, float delay, AudioClip sound/*, float delayBetweenLines*/)
        {
            for (int i = 0; i < input.Length; i++)
            {
                TextHolder.text += input[i];
                SoundManager.Instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }
            //yield return new WaitForSeconds(delayBetweenLines);
            //yield return new WaitUntil(() => Input.anyKeyDown);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            finished = true;
        }


    }
}

