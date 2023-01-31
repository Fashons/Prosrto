using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text TextGameObject;
    private int index = 0;
    private float prevTime = 0.0f;
    Queue<string> queue = new Queue<string>();
    private string Vvod1 = "ѕриветствую!";
    private string Vvod2 = "ƒавай научу играть";
    bool брать—ледующий = true;

    private void Start()
    {
        TextGameObject.text = "";
        queue.Enqueue(Vvod1);
        queue.Enqueue(Vvod2);
    }

    private void FixedUpdate()
    {
        if (брать—ледующий && queue.Count > 0)
        {
            string word = queue.Peek();
            if (index < word.Length)
            {
                prevTime += Time.deltaTime;
                if (prevTime > 0.1f)
                {
                    TextGameObject.text += word[index++];

                    prevTime = 0;
                }
            }
            else
            {
                
                index = 0;
                queue.Dequeue();
                брать—ледующий = false;
            }
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        брать—ледующий = true;
        TextGameObject.text = "";
    }
}